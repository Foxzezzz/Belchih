public class ChemicalElement
{
    public string Symbol { get; set; }
    public string NameRu { get; set; }
    public int AtomicNumber { get; set; }
    public double AtomicMass { get; set; }
    public string Category { get; set; }
    public string ElectronConfig { get; set; }
    public int Row { get; set; }   
    public int Column { get; set; } 
    public bool IsNotFound { get; internal set; }
    public int Id { get; internal set; }
}