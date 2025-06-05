public interface IExposicion<T>
{
    public string Expone { get; }

    public void AñadeAExposicion(T elemento);
}