
using System.Text;
using System.Text.RegularExpressions;

abstract class Vehiculo
{
  public enum Color { Rojo, Azul, Verde, Amarillo, Blanco, Negro, Marron }
  public class VehiculoExcepcion : Exception
  {
    public VehiculoExcepcion() : base() { }
    public VehiculoExcepcion(string mensaje) : base(mensaje) { }
  }
  readonly private string marca;
  readonly private string modelo;
  private Color color;
  protected string matricula;
  readonly private int anyo;

  public Vehiculo(string marca, string modelo, Color color, int anyo)
  {
    this.marca = marca;
    this.modelo = modelo;
    this.color = color;
    this.anyo = anyo;
  }
  public string GetMatricula() => matricula;
  public void SetColor(Color color) => this.color = color;
  public abstract void MatricularVehiculo(string matricula);
  override public string ToString()
  {
    return $"\nMarca: {marca}\nModelo: {modelo}\nColor: {color}\nAño: {anyo}";
  }
}
class Coche : Vehiculo
{
  private int numPuertas;
  private string tipoCombustible;

  public Coche(string marca, string modelo, Color color, int anyo, int numPuertas, string tipoCombustible) : base(marca, modelo, color, anyo)
  {
    this.numPuertas = numPuertas;
    this.tipoCombustible = tipoCombustible;
  }

  public override void MatricularVehiculo(string matricula)
  {
    string patron = @"^[0-9]{4} [A-Z]{3}$";
    if (Regex.IsMatch(matricula, patron)) this.matricula = matricula;
    else throw new VehiculoExcepcion("Matrícula coche incorrecta");
  }

  override public string ToString()
  {
    return base.ToString() + $"\nNúmero de puertas: {numPuertas}\nCombustible: {tipoCombustible}";
  }
}
class Moto : Vehiculo
{
  private string tipoMoto;
  private int cilindrada;

  public Moto(string marca, string modelo, Color color, int anyo, string tipoMoto, int cilindrada) : base(marca, modelo, color, anyo)
  {
    this.tipoMoto = tipoMoto;
    this.cilindrada = cilindrada;
  }

  public override void MatricularVehiculo(string matricula)
  {
    string patron = @"^(\d{4} [A-Z]{3})|([A-Z] \d{4} [A-Z]{3})$";
    if (Regex.IsMatch(matricula, patron)) this.matricula = matricula;
    else throw new VehiculoExcepcion("Matrícula moto incorrecta");
  }

  override public string ToString()
  {
    return base.ToString() + $"\nTipo de moto: {tipoMoto}\nCilindrada: {cilindrada}";
  }
}
class ParteReparacion
{
  private string codigoReparacion;
  private bool enEspera;

  private DateTime fechaIngreso;

  private DateTime fechaReparacion;
  private string descripcionAveria;
  private double precio;
  private string informacionBaseVehiculo;

  public ParteReparacion(Vehiculo vehiculo, string mecanico)
  {
    this.codigoReparacion = $"{vehiculo.GetMatricula()}:{DateTime.Now.ToString("ddMMyyyy")}:{mecanico}";
    this.fechaIngreso = DateTime.Now;
    this.enEspera = true;
    this.informacionBaseVehiculo = vehiculo.ToString();
  }

  public string GetInformacionBaseVehiculo() => informacionBaseVehiculo;

  public string GetCodigoReparacion() => codigoReparacion;
  public bool GetEnEspera() => enEspera;

  public double GetPrecio() => precio;
  public void ActualizarParteReparacion(string descripcionAveria, double precio)
  {
    this.descripcionAveria = descripcionAveria;
    this.precio = precio;
    this.fechaReparacion = DateTime.Now.AddDays(new Random().Next(1, 10));
    enEspera = false;
  }
  public DateTime GetFechaReparacion() => fechaReparacion;

  public int DiasEnTaller() => (GetFechaReparacion() - fechaIngreso).Days;

  public String InformacionParaGestorTaller()
  {
    return $"El vehículo con las caracteristicas {GetInformacionBaseVehiculo()}\nEstá en el siguiente estado: {this}\n\n";
  }
  override public string ToString()
  {
    string salida = enEspera ? " esta en espera de reparación" : $"tenía la siguiente avería: {descripcionAveria}, " +
    $"el coste de la reparación ha sido: {GetPrecio()} euros y ha permanecido en el taller {DiasEnTaller()} días"; ;
    return $"El Vehiculo con Código de Reparacion: {GetCodigoReparacion()} {salida}";
  }
}

class Taller
{
  private ParteReparacion[] partes;

  public Taller()
  {
    partes = new ParteReparacion[0];
  }

  public void EntraVehiculo(Vehiculo vehiculo, string mecanico)
  {
    Array.Resize(ref partes, partes.Length + 1);
    partes[partes.Length - 1] = new ParteReparacion(vehiculo, mecanico);
  }

  public void ReparaVehiculo(string codigoReparacion, string descripcionAveria, double precio)
  {

    for (int i = 0; i < partes.Length; i++)
    {
      if (partes[i].GetCodigoReparacion() == codigoReparacion)
      {
        partes[i].ActualizarParteReparacion(descripcionAveria, precio);
      }
    }
  }


  public void AvisaCliente()
  {
    foreach (ParteReparacion parte in partes)
    {
      string patron = @"^(?<matricula>([0-9]{4} [A-Z]{3})|([A-Z] [0-9]{4} [A-Z]{3})):(?<fecha>\d{8}):(?<mecanico>[a-zA-Z]+)$";
      Match match = Regex.Match(parte.GetCodigoReparacion(), patron);
      string mecanico = match.Groups["mecanico"].Value;
      string matricula = match.Groups["matricula"].Value;
      if (!parte.GetEnEspera())
      {
        Console.WriteLine("__________________________________________________________________________________________________________________");
        Console.WriteLine($"llamando al cliente de vehículo con matrícula {matricula} para informarle de la reparación");
        Thread.Sleep(1000);
        Console.WriteLine($"Estimado cliente, su vehículo ha sido reparado en fecha {parte.GetFechaReparacion()} \n" +
                          $"el coste de reparación es de {parte.GetPrecio()} euros\n" +
                          $"para cualquier duda pongase en contacto con nosotros y pregunte por el tecnico {mecanico}");
        Console.WriteLine("__________________________________________________________________________________________________________________");
      }
    }
  }

  public string InformacionParaGestorTaller()
  {
    StringBuilder resultado = new StringBuilder();
    foreach (ParteReparacion parte in partes)
    {
      resultado.AppendLine(parte.InformacionParaGestorTaller());
    }
    return resultado.ToString();
  }

  override public string ToString()
  {
    StringBuilder resultado = new StringBuilder("Estado del taller:\n");
    foreach (ParteReparacion parte in partes)
    {
      resultado.AppendLine(parte.ToString());
    }
    return resultado.ToString();
  }


}
internal class Program
{

  private static void Main(string[] args)
  {
    try
    {
      Coche ibiza = new Coche("Seat", "Ibiza", Vehiculo.Color.Rojo, 2010, 5, "Gasolina");
      ibiza.MatricularVehiculo("1234 ABC");
      Coche fiat = new Coche("Fiat", "Punto", Vehiculo.Color.Blanco, 2023, 3, "Gasolina");
      fiat.MatricularVehiculo("2224 AZZ");
      Moto yamaha = new Moto("Yamaha", "FZ6", Vehiculo.Color.Negro, 2015, "Deportiva", 600);
      yamaha.MatricularVehiculo("Z 1111 XBC");
      Moto yamaha2 = new Moto("Yamaha", "G39", Vehiculo.Color.Negro, 2024, "Deportiva", 1100);
      yamaha2.MatricularVehiculo("7895 AXX");


      Taller taller = new Taller();
      taller.EntraVehiculo(ibiza, "Juan");
      taller.EntraVehiculo(yamaha, "Pedro");
      taller.EntraVehiculo(fiat, "Juan");
      taller.EntraVehiculo(yamaha2, "Pedro");
      Console.WriteLine(taller);

      taller.ReparaVehiculo("2224 AZZ:07022025:Juan", "Cambio de ruedas", 400);
      taller.ReparaVehiculo("7895 AXX:07022025:Pedro", "Revision anual", 80);
      Console.WriteLine(taller);

      Console.WriteLine("El gerente revisa el estado de los vehiculos del taller, para realizar las llamadas");
      Console.WriteLine("________________________________________________________________________________________");
      Console.WriteLine(taller.InformacionParaGestorTaller());


      Console.WriteLine("El Gerente procede a realizar la llamadas de los vehiculos reparados");
      taller.AvisaCliente();

      Coche ford = new Coche("Ford", "Focus", Vehiculo.Color.Marron, 2010, 5, "Gasolina");
      ibiza.MatricularVehiculo("124 ABC");

    }
    catch (Vehiculo.VehiculoExcepcion e)
    {
      Console.WriteLine(e.Message);
    }

    Console.ReadLine();
  }
}