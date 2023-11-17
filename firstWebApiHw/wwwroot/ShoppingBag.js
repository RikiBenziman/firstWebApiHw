const showBag = () => {
    const stringProductsCard = sessionStorage.getItem("ProductsCard");
    let MyCard = JSON.parse(stringProductsCard);
    for (let i = 0; i < MyCard.length; i++) {
        var tmpRow = document.getElementById("temp-row");
        var cln = tmpRow.content.cloneNode(true);
        cln.querySelector(".image").src = "../images/"+MyCard[i].productImage;
        document.querySelector("tbody").appendChild(cln);
    }
}
