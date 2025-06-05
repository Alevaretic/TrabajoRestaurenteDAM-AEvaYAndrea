public abstract class Obra : IComparable<Obra>
{
    protected string Titulo { get; }
    protected string Autor { get; }
    protected int AnyoCreacion { get; }

    public Obra(string titulo, string autor, int anyo)
    {
        Titulo = titulo;
        Autor = autor;
        AnyoCreacion = anyo;
    }

    public virtual float CalculaPrecio
    {
        get
        {
            int fechaActual = DateTime.Now.Year - AnyoCreacion;
            float precio = (fechaActual + Titulo.Length) * 100;
            return precio;
        }
    }

    public abstract string DescripcionTecnica();

    public int CompareTo(Obra? otraObra)
    {
        return AnyoCreacion.CompareTo(otraObra.AnyoCreacion);
    }

    /*public override bool Equals(object? obj) =>

        obj is Obra obra &&
        Titulo == obra.Titulo &&
        Autor == obra.Autor &&
        AnyoCreacion == obra.AnyoCreacion;*/

    /*public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }
    public override int GetHashCode() => HashCode.Combine(Titulo, Autor, AnyoCreacion);*/

    public override bool Equals(object? obj) =>
        obj is Obra obra &&
        obra.GetHashCode() == GetHashCode();
    
    public override int GetHashCode()
    {
        return DescripcionTecnica().GetHashCode();
    }

    public override string ToString() => $"{Titulo} por {Autor}, {AnyoCreacion}";

}