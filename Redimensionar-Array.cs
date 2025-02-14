internal class Program
{
    private static void Main(string[] args)
    {
        int[] numeros = new int[0];
        int numero = default;

        Console.WriteLine("Indtroduce números (separa por intro)");

        do{

            numero = int.Parse(Console.ReadLine() ?? "");
            if(numero != -1){

                Array.Resize(ref numeros, numero.Length +1); // Para ir rellenando 
                // numeros[^1] para acceder a la ultima posicion. 
                numero[^1] = numero;
            }

        }while(numeros != -1);

        

        Console.WriteLine(string.Join("-", numeros)); // sacar el contenido del array
    }
}