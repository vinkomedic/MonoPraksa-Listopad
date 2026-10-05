using System.Xml.Schema;

class Auto
{
    public int Cijena { get; protected set; }


    public Auto(int cijena)
    {
        this.Cijena = cijena;

    }

    public Auto() { }

    public virtual int Broj_Cilindara()
    {
        return 4;
    }
}

interface IMotor
{
    bool IsHybrid();

}

class Mazda : Auto, IMotor
{
    public string Model { get; set; }
    public string Boja { get; set; }

    public Mazda(int cijena, string model, string boja)
    {
        Cijena = cijena;
        Model = model;
        Boja = boja;
    }

    public override int Broj_Cilindara()
    {
        return 6;
    }
    public bool IsHybrid()
    {
        return false;
    }
}
class Program1
{

    static void Main(string[] args)
    {
        Mazda mazda = new Mazda(30000, "CX-5", "Crvena");

        Console.WriteLine($"Broj cilindara: {mazda.Broj_Cilindara()}\n");
        Console.WriteLine($"Cijena: {mazda.Cijena} EUR\nModel: {mazda.Model}\nBoja: {mazda.Boja}\n");
        Console.WriteLine($"Je li hybrid: {mazda.IsHybrid()}");

    }
}
