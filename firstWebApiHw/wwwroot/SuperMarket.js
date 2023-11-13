const showProduct=async()=>{
    const products = await getAllProduct();
    for (let i = 0; i < products.length;i++) {
        var tmpProd = document.getElementById("tmp-card");
        var cln = tmpProd.content.cloneNode(true);
        cln.querySelector("img").src = "./images/" + products[i].productImage;
        cln.querySelector("h1").textContent = products[i].productName ;
        cln.getElementByClass("description").innerHtml = products[i].productDescription;
        cln.getElementByClass("price").innerHtml = products[i].producPrice;
        document.getElementById("PoductList").appendChild(cln);
    }
}

const getAllProduct = async () => {
    try {
        const res = await fetch("https://localhost:44354/api/Products")
        const products = await res.json();
        return products;
    }
    catch (ex) {
        console.log(ex);
    }
}