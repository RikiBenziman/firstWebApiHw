const showRegisterationForm = () => {
    const register = document.getElementById("register")
    register.style.visibility ="unset"
}

const register = async() =>{
   const user = {
     UserName : document.getElementById("userName").value,
     Password: document.getElementById("password").value,
     FirstName: document.getElementById("firstName").value,
     LastName: document.getElementById("lastName").value
}
    
    try {
        const progress = document.getElementById("progress").value;
        if (progress < 2)
            alert("Easy password,please change your password")
        else {
            const res = await fetch('api/Users',
                {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify(user)

                })
            if (!res.ok)
                alert("Registeration failed, please try again!!")
            else {
                const data = await res.json()
                alert(`user ${data.userName} registered successfully`)

            }
        }
    }
    catch (e)
    {
        alert(e.massage)
    }
}

const login = async () => {

    try {
        const UserNameAndPassword = {
            UserName: document.getElementById("userName1").value,
            Password: document.getElementById("password1").value
        }
        const res = await fetch('api/Users/login',
            {
                method: "POST",
                headers: { 'Content-type': 'application/json' },
                body: JSON.stringify(UserNameAndPassword)
            });
        if (!res.ok)
            window.alert("userName or password are not valid")
        else { 
            const user=await res.json()
            sessionStorage.setItem("user", JSON.stringify(user))
            window.location.href="SuperMarket.html"
        }
    } catch (e) {
        alert(e)
    }
}
const update = async () => {
    const user = {
        UserName: document.getElementById("userNameToUpdate").value,
        Password: document.getElementById("password").value,
        FirstName: document.getElementById("firstNameToUpdate").value,
        LastName: document.getElementById("lastNameToUpdate").value
    }
    try {
        const progress = document.getElementById("progress").value;
        if (progress < 2)
            alert("Easy password,please change your password")
        else {
            const userJson = sessionStorage.getItem("user")
            const id = JSON.parse(userJson).userId
            const res = await fetch(`api/Users/${id}`,
                {
                    method: 'PUT',
                    headers: { 'Content-Type': `application/json` },
                    body: JSON.stringify(user)
                })
            if (!res.ok)
                alert("your password is not sequrity, please enter another password. tanks!")
            else {
                sessionStorage.user = JSON.stringify(await res.json());
                const userJson = sessionStorage.getItem("user")
                const firstName = JSON.parse(userJson).firstName
             
                document.getElementById("hello").innerText = `wellcom to ${firstName}`
                alert(`user ${id} updated succfully`)
            }
        }
    } catch (e) {
      alert(e)
    }
}
async function strengthPassword() {
    const password = document.getElementById("password").value
    try {
        const res = await fetch("api/Users/password",
            {
                method: 'POST',
                headers: { 'Content-Type': `application/json` },
                body: JSON.stringify(password)

            })
        if (!res.ok) { 
            alert("The password is not strong or weak password")
            progress.value = 0;
     }
    else
    {
        const result = await res.json()
        progress.value = result;
    }
 }
    catch (e) {
        alert(e.massage)
    }
} 
const displayUserName = () => { 
const hello = document.createElement('p')
hello.id="hello"
document.body.appendChild(hello)
const userJson = sessionStorage.getItem("user")
const firstName=JSON.parse(userJson).firstName
hello.innerText = `wellcom to ${firstName}`
}