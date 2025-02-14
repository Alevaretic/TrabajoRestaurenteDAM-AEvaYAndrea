internal class Program
{
    //Definir valores
    enum Tamaño { xs,s,m,l,xl}
    private static void Main(string[] args)
    {
        //Declarar el enumerado
        Tamaño t = default;

        Console.WriteLine(t.ToString()); // Con el ToString lo pasamos a string y  podemos hacer todas las combinaciones de string. 

        //ejemplo : pasar a mayusculas.
        Console.WriteLine(t.ToString().ToUpper()); // XS 

        // Console.WriteLine(t.ToUpper()); -> NO SE PUEDE HACER  puesto estas diciendole a un entero que se convierta a mayuscula el ToUpper no entra dentro de las combiaciones de enum SON DE TIPO STRING. 

        Console.WriteLine("¿Que talla quieres?");
        string talla = Console.ReadLine();
        
        if(Enum.TryParse(talla,true, out t)){

            Console.WriteLine("La talla es correcta");
        }
        else{
            Console.WriteLine("error");
        }

        //
        Console.WriteLine("Introduce tu edad");
        int edad = default;
        Console.WriteLine(int.TryParse(Console.ReadLine(),out edad) ? "Tu edad esta bien" : "Tu edad es incorrecta");

        // Enum a Array
        Console.WriteLine(typeof(int));
        Tamaño[] tamaño = (Tamaño[])Enum.GetValues(typeof(Tamaño));
        foreach(int ta in tamaño){

            Console.Write(ta);
        }
    }
}