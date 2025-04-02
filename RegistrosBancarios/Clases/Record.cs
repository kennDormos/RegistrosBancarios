public class Record
{
    public int NumeroCuenta { get; set; }
    public string PrimerNombre { get; set; }
    public string PrimerApellido { get; set; }
    public decimal Balance { get; set; }

    public Record() { }

    public Record(int numeroCuenta, string primerNombre, string primerApellido, decimal balance)
    {
        NumeroCuenta = numeroCuenta;
        PrimerNombre = primerNombre;
        PrimerApellido = primerApellido;
        Balance = balance;
    }
}
