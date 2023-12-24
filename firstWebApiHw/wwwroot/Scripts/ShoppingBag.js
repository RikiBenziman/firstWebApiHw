const showBag = () => {
    let Mycart = JSON.parse(sessionStorage.getItem("Mycart"));
    let totalSum = 0;
    let i = 0;
    while (Mycart.length != 0) {
        let productDelete = Mycart[0];
        const tmpRow = document.getElementById("temp-row");
        const cln = tmpRow.content.cloneNode(true);
        cln.querySelector(".image").src = "images/" + Mycart[i].productImage;
        let count = Mycart.filter(p => p.productId == Mycart[i].productId);
        cln.querySelector(".quantity").innerHTML = count.length;
        cln.querySelector(".DeleteButton").addEventListener('click', () => { deletProduct(productDelete) }) 
        cln.querySelector(".AddButton").addEventListener('click', () => { AddtProduct(productDelete) })   
        cln.querySelector(".sum").innerHTML = Mycart[i].productPrice * count.length;
        totalSum += Mycart[i].productPrice * count.length;
        document.querySelector("tbody").appendChild(cln);
        Mycart = Mycart.filter(p => p.productId != Mycart[i].productId);
        
    }
    document.querySelector("#itemCount").innerHTML = totalSum;

}
const deletProduct = (product) => {
    let Mycart = JSON.parse(sessionStorage.getItem("Mycart"));
    let index = Mycart.findIndex(p=>p.productId==product.productId);
    Mycart=Mycart.filter((p, i) => i != index);
    sessionStorage.Mycart = JSON.stringify(Mycart);
    document.querySelector("tbody").replaceChildren([]);
    showBag();

}
const AddtProduct = (product) => {
    let Mycart = JSON.parse(sessionStorage.getItem("Mycart"));
    Mycart = [...Mycart, product];
    sessionStorage.Mycart = JSON.stringify(Mycart);
    document.querySelector("tbody").replaceChildren([]);
    showBag();
}
const closeOrder = async () => {
    if (!sessionStorage.getItem("user"))
        document.querySelector(".setUser").href = "/Login.html";
        let Mycart = JSON.parse(sessionStorage.getItem("Mycart"));
        let totalSum = 0;
        const order = {
            OderDate: new Date(),
            OrderSum: 0,
            UserId: (JSON.parse(sessionStorage.getItem("user"))).userId,
            OrderItems: []
        };
        while (Mycart.length != 0) {
            let prod = Mycart[0];
            let count = Mycart.filter(p => p.productId == prod.productId).length;
            let orderItem = {
                Quantity: count,
                ProductId: prod.productId
            };
            order.OrderItems = [...order.OrderItems, orderItem];
            totalSum += prod.productPrice * count;
            Mycart = Mycart.filter(p => p.productId != prod.productId);
        }
    order.OrderSum = totalSum;
    try {
        const res = await fetch('https://localhost:44354/api/Orders',
            {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(order)

            });
        if (!res.ok)
            alert("created order failed, please try again!!")
        else {
            const data = await res.json()
            alert(`order ${data.orderId} created successfully`)
        }
    }
    catch (e) {
        alert("error to creat order please try again!")
    }
}
