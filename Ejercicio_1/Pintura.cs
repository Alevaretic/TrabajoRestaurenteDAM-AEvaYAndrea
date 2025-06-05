
public class Pintura : Obra
{
    public TecnicaPintura Tecnica { get; set; }

    public override float CalculaPrecio
    {
        get
        {
            float precio = base.CalculaPrecio * (int)Tecnica;
            return precio;
        }
    }

    public Pintura(string titulo, string autor, int anyo, string tecnica) : base(titulo, autor, anyo)
    {
        //Tecnica = (TecnicaPintura)Enum.Parse(typeof(TecnicaPintura), tecnica);
        if (Enum.TryParse<TecnicaPintura>(tecnica, ignoreCase: true, out var tecnicaEnum))
        {
            Tecnica = tecnicaEnum;
        }
        else
        {
            throw new ArgumentException($"Técnica no válida: {tecnica}");
        }
    }

    public override string DescripcionTecnica() => $"{Titulo} por {Autor}, {Tecnica} sobre lienzo ({AnyoCreacion})";
}