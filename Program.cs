using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
internal class Program
{
    private static void Main(string[] args)
    {
        // ETIQUETAS 
        string patron = @"(?<num>\d)";
        string cadena = "0adc1def2ghi3jkl4mno5\n0adc1def2ghi3jkl4mno5\n0adc1def2ghi3jkl4mno5\n0adc1def2ghi3jkl4mno5\n0adc1def2ghi3jkl4mno5\n0adc1def2ghi3jkl4mno5\n0adc1def2ghi3jkl4mno5\n0adc1def2ghi3jkl4mno5\n0adc1def2ghi3jkl4mno5\n0adc1def2ghi3jkl4mno5";

        string[] cadena2 = new string[cadena.Length];

        Match conincidencia = Regex.Match(cadena,patron);

        while (conincidencia.Success)
        {
            string numero = conincidencia.Groups["num"].Value; // Para quedarte con el numero de la cadena.
            
            string primerNumero = conincidencia.Groups[0].Value;
            string segundoNumero = conincidencia.Groups[5].Value;

            int suma = 0;

            for(int i = 0; i < cadena.Length; i++){

                cadena2 = numero.Split("1234\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

               suma = numero[0] + numero[cadena2.Length-1]; 
            }

            //Console.Write(String.Join("",cadena2));
            Console.Write(suma);

          

           //Console.WriteLine($"Suma: {primerNumero+segundoNumero}");

            conincidencia = conincidencia.NextMatch();
        }
    }
}