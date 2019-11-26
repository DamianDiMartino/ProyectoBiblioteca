
let busca = document.getElementById("busca")



busca.addEventListener("submit",()=>{
    
})



btns.forEach(busca=>{
    listado.addEventListener("click",e=>{
        e.preventDefault()
        ajax(`${e.target.dataset.archivo}.html`)
        nav.classList="0"
        header.classList="0"
       
    })  
})


function ajax(url){
    
    let xhr = new XMLHttpRequest
    xhr.open("GET",url)
    xhr.addEventListener("readystatechange",()=>{
        if(xhr.readyState==4&&xhr.status==200){         
            main.innerHTML=xhr.response            
        }     
    })
    xhr.send()
}