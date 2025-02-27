using Microsoft.VisualBasic;

class Receta{

    public LineaIngrediente[] ingredientes;
    public string Nombre {get;}

    public Receta(string nombreReceta){

        ingredientes = new LineaIngrediente[0];
        Nombre = nombreReceta;
    }

    public double CosteTotal{
        get{
            double total = 0;
            foreach(var lineaIng in ingredientes){
                total+= lineaIng.SubTotal;
            }
            return total;
        } 
    }

    public void AñadeIngrediente(Ingrediente producto, int cantidad){

        if(!producto.EnStock){
            throw new Ingrediente.IngredienteException("No hay stock ");
        }
        producto.Stock -= cantidad;

        Array.Resize(ref ingredientes, ingredientes.Length +1);
        ingredientes[^1] = new LineaIngrediente(producto,cantidad);
    }

    public override string ToString()
    {
        return $"Coste total: {CosteTotal}€";
    }
}