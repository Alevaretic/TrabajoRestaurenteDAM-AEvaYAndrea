using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        // SIMPLE \\

        string patron = @"[O]";
        string cadena = "HOLA MUNDO";

        Console.WriteLine(Regex.IsMatch(cadena,patron)); // Es para comparar si cumple con el patron. Como la cadena tiene O retorna true. 

        patron = @"E";
        Console.WriteLine(Regex.IsMatch(cadena,patron)); // Como la cadena no tiene E retorna false.

        RegexOptions opciones = RegexOptions.IgnoreCase; // Para ignorar las mayúsculas?
        Console.WriteLine(Regex.IsMatch(cadena,patron,opciones)); 

        patron = @"[OE]";
        Console.WriteLine(Regex.IsMatch(cadena,patron,opciones)); // Retorna true porque contiene una de las dos en este caso O;

        patron = @"[\w]"; // Es lo mismo que esto : @"[A-Za-z]"; // Abecedario
        //patron = @"[A-Za-z0-9]"; // Abecedario + numeros

        //Para encontrar una palabra textual
        patron = @"HOLA";
        Console.WriteLine(Regex.IsMatch(cadena,patron));
        
        //Busca todos los saludos en el fichero : 
        patron = @"HOLA|BUENAS";
        cadena = "BUENAS NOCHES";
        Console.WriteLine(Regex.IsMatch(cadena,patron));

        // COMPLICADO \\

        Console.WriteLine("Introduce tu nombre: ");
        string nombre = Console.ReadLine();

        patron = @"^[A-Z]";

        if(Regex.IsMatch(nombre,patron)){}
        else{
            Console.WriteLine("Los nombres propios empiezan por mayuscula.");
        }

        Console.WriteLine("Introduce una palabra en plural: ");
        string plural = Console.ReadLine();

        patron = @"[aeiou]s$";

        if(Regex.IsMatch(plural,patron)){}
        else{
            Console.WriteLine("La plabra debe de terminar en 's'");
        }

        // ETIQUETAS 
        string patron2 = @"(?<num>\d)";
        string cadena2 = "0adc1def2ghi3jkl4mno5";

        Match conincidencia = Regex.Match(cadena2,patron2);

        while (conincidencia.Success)
        {
            string numero = conincidencia.Groups["num"].Value; // Para quedarte con el numero de la cadena.
            Console.WriteLine(numero);
            
            // string numero2 = conincidencia.Groups[2].Value; // Devuelve la posicion.
            conincidencia = conincidencia.NextMatch();
        }

    }
}