using System;
using System.Text;

public class Class1
{
	public Class1()
	{
        id = Guid.NewGuid();
        user = "Margaret";
        Dt = DateTime.Now;
        value = Convert.ToDouble(rand.Next(100)) / 10;
    }
    public Guid id;
    public string user;
    public DateTime Dt;
    public double value;
    public Random rand = new Random();

    public void Print()
    {
        Console.WriteLine("Guid: {0}\nUser: {1}\nDateTime: {2}\nValue: {3}\n", id, user, Dt, value);
    }
}
