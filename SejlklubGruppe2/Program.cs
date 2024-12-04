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
        Console.WriteLine("");
        Console.WriteLine( "Alex test start");

        Member courseMember1 = new Member("testName", "123435", "only message in bottle");
        Member courseMember2 = new Member("testName2", "12345677", "no message in bottle");
        string[] time = { "1", "2" };
        int[] range = { 1, 10 };
        List<Member> members = new List<Member>();
        members.Add(courseMember1);
        members.Add(courseMember2);
        Course testCourse = new Course(1,time,range, members,courseMember1,"this is a test Course");

        Console.WriteLine( testCourse);

        Console.WriteLine( "Alex test end");
        Console.WriteLine( );
        #endregion

        #region KTest
        Member testEgon = new Member("Egon", "11 11 11 11", "REalMail@Mail.ru");
        Console.WriteLine(testEgon);

        #endregion

        #region LTest

        #endregion
        }
}