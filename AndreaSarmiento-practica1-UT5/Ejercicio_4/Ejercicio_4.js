'use strict';

let alumno = [

    {nombre : 'Pedro', curso : '1-ESO'},
    {nombre : 'Carla', curso : '1-BACHILLERATO'},
    {nombre : 'Mario', curso : '1-DAM'},
]

console.log(alumno);

let asignaturas = alumno.map(alumnos => {

        let clase = prompt("Indique en que clase esta matriculado: ");
        return {
            nombre: alumnos.nombre,
            curso : alumnos.curso,
            asignaturas : clase,
        };
    }
)

console.log(asignaturas);


