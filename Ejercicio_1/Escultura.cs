public class Escultura : Obra
{
    public string Material { get; set; }

    public Escultura(string titulo, string autor, int anyo, string material) : base(titulo, autor, anyo)
    {
        Material = material;
    }

    public override string DescripcionTecnica() => $"{Titulo} por {Autor} - {Material},({AnyoCreacion})";
}
