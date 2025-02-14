using System.Globalization;

internal class Program
{
    private static void Main(string[] args)
    {
        string frase = "Me gustan los croissants por las mañanas";

        string[] palabras = frase.Split([' '],StringSplitOptions.RemoveEmptyEntries); // Esto separa las palabras quitando los espacios ? 

        //array con las palabras del reves 
        string[] palabrasReves = new string[palabras.Length]; // esto le estas indicando la reserva de memoria igual que el array de palabras 
        string aux = "";
        int j = 0;

        // recorrer 
        foreach(string palabra in palabras){

            Console.WriteLine("Palabras: " + palabra);
            Console.WriteLine("Palabras del reves: ");
            // saca la plabra al reves
            /*
            for(int i = palabra.Length -1; i >= 0; i--){
                Console.Write(palabra[i]);
            }*/

            // sacar caracteres 
            for(int i = palabra.Length -1; i >= 0; i--){
                aux += palabra[i];
            }

            palabrasReves[j++] = aux;
            aux = ""; //limpiar
        }

        string salida = string.Join(" ",palabrasReves);
        Console.WriteLine(salida);
    }
}