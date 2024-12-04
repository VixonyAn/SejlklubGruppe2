using ClassLibrary.Exceptions;
using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using ClassLibrary.Services;
using System.Threading.Channels;

internal class Program
{
    private static void Main(string[] args)
    {
        #region VTest
        Model optimistjolle = new Model("Optimistjolle", "hyggelig for begyndere", 00.00, 00.00, 00.00, 00.00);
        Boat b1 = new Boat(optimistjolle, "5678");
        Boat b2 = new Boat(optimistjolle, "5678");
        IBoatRepository boatRepo = new BoatRepository();
        try
        {
            boatRepo.AddBoat(b1);
            boatRepo.AddBoat(b2);
        }
        catch (KeyTakenException error)
        {
            Console.WriteLine($"{error.Message}");
        }
        List<Boat> boats = boatRepo.GetAll();
        foreach (Boat boat in boats)
        {
            Console.WriteLine(boat);
        }
        //Console.WriteLine(b1);
        #endregion

        #region Atest

        #endregion

        #region KTest
        Member testEgon = new Member("Egon", "11 11 11 11", "REalMail@Mail.ru");
        Console.WriteLine(testEgon);

        #endregion

        #region LTest

        #endregion
        }
}