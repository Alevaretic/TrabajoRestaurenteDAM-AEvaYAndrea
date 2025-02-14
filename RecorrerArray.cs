internal class Program
{
    private static void Main(string[] args)
    {
        // creacion de array
        
        /*
            string [] saludos; 

            - Esto daria null y no se puede recorrer.Hay quue reservar memoria.
        */
        string [] saludos = new string[5]; // reserva de memoria 

        saludos[0] = "Hola";
        saludos[4] = "Hello";

        //Recorrer con for 
        for(int i = 0 ; i < saludos.Length; i++){

            Console.Write(saludos[i]); // esto saca HolaHello = al contenido del array
        }

        // Recorrer en foreach 
        foreach(string saludo in saludos ){

            Console.Write(saludo); // esto saca HolaHello = al contenido del array
        }

        //Act : Separa las palabras (sacaPalabras)

        
    }
}