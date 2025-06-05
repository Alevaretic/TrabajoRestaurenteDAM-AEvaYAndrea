public abstract class Institucion
{
    public string Nombre { get; set; }

    public string Ciudad { get; set; }
    public string Pais { get; set; }

    public Institucion(string nombre, string ciudad, string pais)
    {
        Nombre = nombre;
        Ciudad = ciudad;
        Pais = pais;
    }

    public override string ToString() => $"{Nombre} ({Ciudad}, {Pais})" ;
}