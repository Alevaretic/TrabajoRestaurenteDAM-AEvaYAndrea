'use strict';

let bolUsuario  = prompt("Indiqueme un booleano : "); 
let arrayNumUsuario = new Array(prompt("Indiqueme una serie de numeros : "));
let cadenaUsuario = prompt("Digame una frase : ");


let ejercicio1 = (bolUsuario,arrayNumUsuario,cadenaUsuario) => {

    if(bolUsuario == true){

        arrayNumUsuario.forEach(array => {

            for (let i = 0; i <= array.length; i++) {
                let numeros = array[i];
                suma+= numeros; 
            }

            if(suma > 100){

                let patron = /[a]/;
                let cadena = cadenaUsuario.includes(patron);

                if(cadena == true){

                    console.log("La letra 'a' no está permitida.");
                }
                else{

                    console.log("Muy bien no has usado la 'a'. ");
                }

            }

            else if(suma < 100){
                console.log("“El resultado de tu array es insuficiente para comprobar la cadena");
            }
        });
    }

    else{

        console.log("Error");
    }

}

console.log(ejercicio1(bolUsuario,arrayNumUsuario,cadenaUsuario));