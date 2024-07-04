public class Student : Person, KPI
{
    public string Major { get; set; }

    public void kpi()
    {
        Console.WriteLine("Implementing the kpi() method.");
    }
}