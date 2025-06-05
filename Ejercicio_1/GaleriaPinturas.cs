using System.ComponentModel;
using System.Linq;
using System.Text;

public class GaleriaPinturas : Institucion, IExposicion<Pintura>
{
    Dictionary<Pintura, EstadoVenta> diccionarioGaleria = new Dictionary<Pintura, EstadoVenta>();

    public string Expone
    {
        get
        {
            StringBuilder descripcionPinturas = new StringBuilder();
            /*
            foreach (var d in diccionarioGaleria)
            {
                exponeString = d.Value.disponible ? d.Key.DescripcionTecnica() : exponeString;
            }

            return exponeString;*/

            foreach (var d in diccionarioGaleria)
            {
                if (d.Value.disponible)
                {
                    return descripcionPinturas.Append(d.Key.DescripcionTecnica()).ToString();
                }
            }

            return "Ha sido vendida";
        }

    }

    public GaleriaPinturas(string nombre, string ciudad, string pais) : base(nombre, ciudad, pais) { }

    public void AñadeAExposicion(Pintura pintura)
    {
        foreach (var d in diccionarioGaleria)
        {
            if (!diccionarioGaleria.ContainsKey(pintura))
            {
                diccionarioGaleria.Add(pintura, new EstadoVenta(true, pintura.CalculaPrecio, null));
            }
            else
            {
                throw new InstitucionException("");
            }
        }
    }

    public void Venta(Pintura pintura, string nombreComprador)
    {
        foreach (var d in diccionarioGaleria)
        {
            if (!diccionarioGaleria.ContainsKey(pintura) || !diccionarioGaleria[pintura].disponible)
            {
                throw new InstitucionException("Ya esta vendida");
            }
            else
            {
                diccionarioGaleria[pintura] = new EstadoVenta(false, pintura.CalculaPrecio, nombreComprador);

            }
        }
    }

    public string InformeVentas()
    {
        StringBuilder infrome = new StringBuilder();

        foreach (var d in diccionarioGaleria)
        {
            if (d.Value.comparador != null)
            {
                infrome.AppendLine(d.Key.DescripcionTecnica());
            }
        }

        return infrome.ToString();

    }

    //public float GananciasVentas() => 

}
