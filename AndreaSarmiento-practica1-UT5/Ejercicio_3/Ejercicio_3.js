'use strict';

let personas_1 = ["Maria","Juan","Alba","Paloma","Pablo","Bertin"];
let personas_2 = ["Paloma","Pablo","Bertin","Carla","Mario","Pepe","Adriana"];

let nombresIguales = true;
let nombresDistintos = false;

// con foreach 

personas_1.forEach(personas => {

    if(personas_2.includes(personas)){

        nombresDistintos = true;
    }
    else{
        nombresIguales = false;
    }  
});

if(nombresIguales){

    console.log("Personas: " + personas_1 +" \nArray donde buscar: "+ personas_2 + " \nCoinciden los nombres");
}
else if (nombresDistintos){
    console.log("Personas: " + personas_1 +" \nArray donde buscar: "+ personas_2 + " \nCoinciden algunos nombres");
}
else{
    console.log("Personas: " + personas_1 +" \nArray donde buscar: "+ personas_2 + " \nNo coinciden");
}
