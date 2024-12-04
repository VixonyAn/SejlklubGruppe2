using ClassLibrary.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        #region VTest
        Model optimistjolle = new Model("Optimistjolle", "hyggelig for begyndere", 00.00, 00.00, 00.00, 00.00);
        Boat b1 = new Boat(optimistjolle, "5678");
        //Boat b2 = new Boat(optimistjolle, "5678");
        Console.WriteLine(b1);
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