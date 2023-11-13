
const getAllProducts = async (desc, minPrice, maxPrice, categoryIds) => {

    try {
        let url = `https://localhost:44354/api/Products`;
        if (desc || minPrice || maxPrice || categoryIds) url += `?`;
           
        if (desc)url += ` desc = ${desc}`;
            
        if (minPrice)url += ` minPrice = ${minPrice}`;
            
        if (maxPrice)url += ` maxPrice = ${maxPrice}`;
            
        if (categoryIds) {
            for (let i = 0; i < categoryIds.length; i++) {
                url += `&categoryIds=${categoryIds[i]}`;
            }
        }
        const res = await fetch(url)
        const products = await res.json();
        return products;
    }
    catch (ex) {
        console.log(ex);
    }
}

const showProducts = async () => {
    const products = await getAllProducts();
    for (let i = 0; i < products.length; i++) {
        var tmpProd = document.getElementById("temp-card");
        var cln = tmpProd.content.cloneNode(true);
        cln.querySelector("img").src = "./images/" + products[i].productImage;
        cln.querySelector("h1").innerText = products[i].productName;
        cln.querySelector("p.description").innerText = products[i].productDescription;
        cln.querySelector("p.price").innerText = products[i].productPrice+'$';
        document.getElementById("PoductList").appendChild(cln);
    }
}
const getAllCartegories = async () => {
    try {
        const res = await fetch("https://localhost:44354/api/Ctegories")
        const Categories = await res.json();
        return Categories;
    }
    catch (ex) {
        console.log(ex);
    }
}

const showCategories = async () => {
    const Categories = await getAllCartegories();
    for (let i = 0; i < Categories.length; i++) {
        var tmpCatg = document.getElementById("temp-category");
        var cln = tmpCatg.content.cloneNode(true);
        cln.querySelector("label").for = Categories[i].categoryName;
        cln.querySelector("input").value = Categories[i].categoryName;
        cln.querySelector("input").id = Categories[i].categoryId;
        cln.querySelector("span.OptionName").innerText = Categories[i].categoryName;
        document.getElementById("categoryList").appendChild(cln);
    }
}
const filterProducts = async () => {
    let checkedArr = [];
    var allCategoriesOptions = document.querySelectorAll(".opt");
    for (i = 0; i < allCategoriesOptions.length; i++) {
        if (allCategoriesOptions[i].checked) checkedArr.push(allCategoriesOptions[i]);
        let getMinPrice = document.getElementById("minPrice").value; 
        let getMaxPrice = document.getElementById("maxPrice").value; 
        let getDesc = document.getElementById("nameSearch").value; 
        const products = await getAllProducts(getDesc, getMinPrice, getMaxPrice, checkedArr);
        document.getElementById("ProductsList").children = [];
        for (let i = 0; i < products.length; i++) {
            var tmpProd = document.getElementById("temp-card");
            var cln = tmpProd.content.cloneNode(true);
            cln.querySelector("img").src = "./images/" + products[i].productImage;
            cln.querySelector("h1").innerText = products[i].productName;
            cln.querySelector("p.description").innerText = products[i].productDescription;
            cln.querySelector("p.price").innerText = products[i].productPrice + '$';
            document.getElementById("PoductList").appendChild(cln);
        }

    }

}