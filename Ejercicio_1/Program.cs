using System;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            var prado = new Museo("Museo del Prado", "Madrid", "España");

            var galeria = new GaleriaPinturas("Galería Clásica", "Barcelona", "España");

            galeria.AñadeAExposicion(new Pintura("El jardín de las delicias", "Bosch", 1490, "Oleo"));
            galeria.AñadeAExposicion(new Pintura("La noche estrellada", "Van Gogh", 1889, "Oleo"));
            galeria.AñadeAExposicion(new Pintura("La persistencia de la memoria", "Dalí", 1931, "Acrilico"));
            galeria.AñadeAExposicion(new Pintura("El grito", "Munch", 1893, "Mixta"));
            galeria.AñadeAExposicion(new Pintura("La joven de la perla", "Vermeer", 1665, "Oleo"));

            Console.WriteLine(galeria.Expone);
            Console.WriteLine("Se vende la noche estrellada");
            galeria.Venta(new Pintura("La noche estrellada", "Van Gogh", 1889, "Oleo"), "Juan Pérez");
            Console.WriteLine("Se vende el jardín de las delicias");
            galeria.Venta(new Pintura("El jardín de las delicias", "Bosch", 1490, "Oleo"), "María López");
            Console.WriteLine();
            Console.WriteLine(galeria.Expone);
            Console.WriteLine($"Ganancias totales de la galería: {galeria.GananciasVentas()}euros");

            Console.WriteLine("\n");
            prado.AdquiereObra(new Pintura("El nacimiento de Venus", "Botticelli", 1486, "Oleo"));
            prado.AdquiereObra(new Pintura("Las Meninas", "Velázquez", 1656, "Oleo"));
            prado.AdquiereObra(new Pintura("Guernica", "Picasso", 1937, "Oleo"));

            prado.RestauraObra();
            prado.RestauraObra();
            prado.AdquiereObra(new Pintura("La última cena", "Da Vinci", 1498, "Oleo"));
            prado.AdquiereObra(new Escultura("La Piedad", "Miguel Ángel", 1499, "Mármol"));
            prado.AdquiereObra(new Escultura("El David", "Miguel Ángel", 1504, "Mármol"));
            prado.AdquiereObra(new Escultura("El pensador", "Rodin", 1902, "Bronce"));
            prado.RestauraObra();
            prado.RestauraObra();
        
            prado.AñadeAExposicion(new Pintura("Las Meninas", "Velázquez", 1656, "Oleo"));
           // prado.AñadeAExposicion(new Escultura("El David", "Miguel Ángel", 1504, "Mármol"));//Lanza Exception
            prado.RestauraObra();
            prado.RestauraObra();
            prado.AñadeAExposicion(new Pintura("La última cena", "Da Vinci", 1498, "Oleo"));
            prado.AñadeAExposicion(new Escultura("El David", "Miguel Ángel", 1504, "Mármol"));
            Console.WriteLine(prado.Expone);
            Console.WriteLine("Se está generando un informe con todas las pinturas expuestas al Oleo,\n\tlo podrás encontrar en oleo.txt\n");
            prado.BuscaPorTecnica(TecnicaPintura.Óleo);
            Console.WriteLine("Obras más antiguas que \"Las Meninas(1656)\":");
            prado.ObrasMasAntiguasQue(new Pintura("Las Meninas", "Velázquez", 1656, "Oleo"))
                                .ToList().ForEach(o => Console.WriteLine(o.DescripcionTecnica()));
        }
        catch (InstitucionException e)
        {
            Console.WriteLine($"Error: {e.Message}");

        }
        finally
        {
            Console.ReadLine();
        }

    }
}
