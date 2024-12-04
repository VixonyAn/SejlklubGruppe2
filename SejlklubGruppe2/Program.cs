using ClassLibrary.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        #region VTest
        Model optimistjolle = new Model("Optimistjolle", 00.00, 00.00, 00.00, 00.00);
        Boat b1 = new Boat(optimistjolle, "hyggelig for begyndere", "5678");
        Console.WriteLine(b1);
        //Kommentar
        #endregion

        #region Atest

        #endregion

        #region KTest

        #endregion

        #region LTest

        #endregion
    }
}