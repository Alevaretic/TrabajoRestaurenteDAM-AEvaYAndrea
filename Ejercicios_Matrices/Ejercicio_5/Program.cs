internal class Program
{
    public static void MostrarJardin(int[][] jardin)
    {

        Console.WriteLine("Jardin: ");

        for (int i = 0; i < jardin.Length; i++)
        {
            for (int j = 0; j < jardin[i].Length; j++)
            {
                Console.Write(jardin[i][j] + " ");
            }
            Console.WriteLine();
        }
    }

    public static void ContarFlores(int[][] jardin)
    {
        const int NUM_COLORES = 5;
        int[] colores = new int[NUM_COLORES];


        foreach (var fila in jardin)
        {
            foreach (var flor in fila)
            {
                if (flor >= 1 && flor <= NUM_COLORES)
                {
                    colores[flor - 1]++;
                }
            }
        }

        Console.WriteLine("Flores por color: ");
        for (int i = 0; i < NUM_COLORES; i++)
        {
            Console.WriteLine($"Color {i+1}: {colores[i]} flores");
        }   
    }

    public static void ArrieteMasDiverso(int[][] jardin)
    {
        int[] aux = new int[0];
        
        for(int i = 1; i < jardin.Length; i++){

            for(int j = 1; j < jardin[i].Length; j++){

                if(aux.Length < jardin[i].Length){
                    
                    aux = jardin[i];

                    Console.WriteLine($"Arriete más diverso: Arriete {i + 1} con {aux.Length} colores distintos");                   
                }
            }
            
            
        }
        
    }
    private static void Main(string[] args)
    {
        int[][] jardin = {

            new int[] {1,3,2,1},
            new int[] {4,4,2},
            new int[] {2,1,3,3,5},
            new int[] {3,2},

        };

        MostrarJardin(jardin);

        Console.WriteLine();
        ContarFlores(jardin);
        
        Console.WriteLine();
        ArrieteMasDiverso(jardin);
    }

}
