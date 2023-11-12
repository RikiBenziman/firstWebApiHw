const showProduct=async()=>{
    const products = await getAllProduct();
    for (let i = 0; i < products.length;i++) {
        var tmpProd = document.getElementById("tmp-prod");
        var cln = tmpProd.content.cloneNode(true);
        cln.querySelector("img").src = "./images/" + products[i].productImage;
        cln.querySelector("p").innerHtml = products[i].productDescription;
        cln.querySelector("h2").innerHtml = products[i].productName;
        cln.querySelector("h3").innerHtml = products[i].producPrice;
        document.getElementById("products").appendChild(cln);
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