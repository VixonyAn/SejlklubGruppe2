using ClassLibrary.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        Model optimistjolle = new Model("Optimistjolle", 00.00, 00.00, 00.00, 00.00);
        Boat b1 = new Boat(optimistjolle, "hyggelig for begyndere", "5678");
        Console.WriteLine(b1);
        //Kommentar
    }
}