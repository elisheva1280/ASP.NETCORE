var baseURL="http://localhost:5125";

var btn=document.getElementById("addPizzaButton");
var pizzaFormContainer=document.getElementById("pizzaFormContainer");

// btn.onclick=function(){
//     pizzaFormContainer.classList.remove("hidden"); 
//     document.getElementById("addPizzaButton").style.display="none";
// }

function addPizza(){
    var pizza={
        Id:document.getElementById("id").value,
        ifGluten:document.getElementById("gluten").value==='true',
        Name:document.getElementById("name").value
    };
  

    var myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/json");

    var raw = JSON.stringify(pizza);

    const requestOptions = {
      method: "POST",
      redirect: "follow"
    };
    
    
      
      fetch(`${baseURL}/MyPizza/Post?nameOfPizza=${pizza.Name}&id=${pizza.Id}&glotan=${pizza.ifGluten}`, requestOptions)
        .then((response) => response.text())
        .then((result) => console.log(result))
        .catch((error) => console.error(error));

}
