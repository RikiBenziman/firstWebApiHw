const showBag = () => {
    const stringProductsCard = sessionStorage.getItem("MyCard");
    let MyCard = JSON.parse(stringProductsCard);
    let totalSum = 0;
    let i = 0;
    while (MyCard.length != 0) {
        let productDelete = MyCard[0];
        const tmpRow = document.getElementById("temp-row");
        const cln = tmpRow.content.cloneNode(true);
        cln.querySelector(".image").src = "images/" + MyCard[i].productImage;
        let count = MyCard.filter(p => p.productId == MyCard[i].productId);
        cln.querySelector(".quantity").innerHTML = count.length;
        cln.querySelector(".DeleteButton").addEventListener('click', () => { deletProduct(productDelete) }) 
        cln.querySelector(".AddButton").addEventListener('click', () => { AddtProduct(productDelete) })   
        cln.querySelector(".sum").innerHTML = MyCard[i].productPrice * count.length;
        totalSum += MyCard[i].productPrice * count.length;
        document.querySelector("tbody").appendChild(cln);
        MyCard = MyCard.filter(p => p.productId != MyCard[i].productId);
        
    }
    document.querySelector("#itemCount").innerHTML = totalSum;

}
const deletProduct = (product) => {
    let stringProductsCard = sessionStorage.getItem("MyCard")
    let MyCard = JSON.parse(stringProductsCard);
    let index = MyCard.findIndex(p=>p.productId==product.productId);
    MyCard=MyCard.filter((p, i) => i != index);
    sessionStorage.MyCard = JSON.stringify(MyCard);
    document.querySelector("tbody").replaceChildren([]);
    showBag();

}
const AddtProduct = (product) => {
    let stringProductsCard = sessionStorage.getItem("MyCard")
    let MyCard = JSON.parse(stringProductsCard);
    MyCard = [...MyCard, product];
    sessionStorage.MyCard = JSON.stringify(MyCard);
    document.querySelector("tbody").replaceChildren([]);
    showBag();
}

const closeOrder =async () => {
    if (!sessionStorage.getItem("user")) {
        document.querySelector(".setUser").href = "/Login.html";
    }
    else {
        let MyCard = sessionStorage.getItem("MyCard");
        const orderItem = {
            Quantity:0,
            ProductId:0
        };
        const order = {
            OderDate: new Date,
            OrderSum: 0,
            UseId: (JSON.parse(sessionStorage.getItem("user"))).useId,
            OrderItems: []
        };
        while (MyCard.length != 0) {
            let mycard = MyCard[0];
            let count = MyCard.filter(p => p.productId == mycard.productId);
            orderItem.Quantity = count.length;
            orderItem.ProductId = (JSON.parse(sessionStorage.getItem("user"))).useId;
            order.OrderItems = [...OrderItems, orderItem];
            order.OrderSum += mycard.productPrice * count.length;
            MyCard = MyCard.filter(p => p.productId != mycard.productId);
        }
    }
  try {
      const res = await fetch("https://localhost:44354/api/Orders" ,
          {
              method: 'POST',
              headers: { 'Content-Type': 'application/json' },
              body: JSON.stringify(order)

          });
    if (!res.ok)
        alert("created order failed, please try again!!")
    else {
        const data = await res.json()
        alert(`order ${data.UseId} registered successfully`)
    }
     }
   catch (e) {
        alert(e.massage)
  }
}
