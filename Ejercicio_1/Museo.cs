using System.Text;

public class Museo : Institucion, IExposicion<Obra>
{
    public Museo(string nombre, string ciudad, string pais) : base(nombre, ciudad, pais) { }

    private Queue<Obra> obrasARestaurar;
    private List<Obra> obrasRestauradas;
    private Stack<Obra> obrasEnExposicion;



    public string Expone
    {
        get
        {
            StringBuilder cadena = new StringBuilder();
            foreach (var exponer in obrasEnExposicion)
            {
                cadena.Append(exponer.DescripcionTecnica());
            }

            return cadena.ToString();
        }
    }

    public void AdquiereObra(Obra obra) => obrasARestaurar.Enqueue(obra);

    public string? RestauraObra()
    {
        Obra obra = default;

        if (obrasARestaurar.Count() != 0)
        {
            obra = obrasARestaurar.Dequeue();
            obrasRestauradas.Add(obra);
        }

        return obrasARestaurar.Count() > 0 ? obra.ToString() : null;
    }

    public void AñadeAExposicion(Obra obraExpuesta)
    {
        if (!obrasRestauradas.Contains(obraExpuesta))
        {
            obrasRestauradas.Remove(obraExpuesta);
            obrasEnExposicion.Push(obraExpuesta);
        }
        else
        {
            throw new InstitucionException($"No se puede exponer {obraExpuesta} porque no esta restaurada todavía.");
        }
    }

    public void BuscaPorTecnica(TecnicaPintura tecnica)
    {
        FileStream fichero = new FileStream("Tecnica.txt", FileMode.Create, FileAccess.Write);
    }

    public void ObrasMasAntiguasQue(Obra obra)
    {
        
    }

    
} 