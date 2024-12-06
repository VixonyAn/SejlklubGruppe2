using ClassLibrary.Data;
using ClassLibrary.Exceptions;
using ClassLibrary.Helpers;
using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using ClassLibrary.Services;
using System.Threading.Channels;

internal class Program
{
    private static void Main(string[] args)
    {
        #region VTest
        /* initial constructor and Add to list exception test
        // test create new model and boats, add to list, catch exception when ID already exists in list
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
        */

        // initializing data
        IModelRepository modelRepo = new ModelRepository();
        IBoatRepository boatRepo = new BoatRepository();
        List<Boat> boatList = boatRepo.GetAll(); // bring our dict into a list

        /* testing edit function using the Reg ID
        // test edit Reg ID function
        boatRepo.EditBoat(boatList[0].Registration, "6666"); // edit first boat in list Reg (1234 = 6666)
        // test try and catch exception, cannot update Reg ID to a Reg ID that already exists
        try
        {
            boatRepo.EditBoat(boatList[0].Registration, "3456");
        }
        catch (KeyTakenException error)
        {
            Console.WriteLine($"{error.Message}"); // works!! tested 05/12
        }
        // print boat list
        foreach (Boat boat in boatList)
        {
            Console.WriteLine($"{boat}");
        }
        // test searching for the new ID
        Boat search = boatRepo.GetBoatByReg("6666");
        Console.WriteLine($"found your boat {search}"); // works!! tested 05/12
        // test adding a new boat using the old (no longer in use) ID that belonged to b1
        Boat b5 = new Boat(modelRepo.GetModelByName("Laserjolle"), "1234");
        Console.WriteLine(b5); // works!! tested 05/12
        */
        #endregion

        #region Atest
        Console.WriteLine("");
        Console.WriteLine("Alex test start");

        /*
        CourseRepository courseRepository = new CourseRepository();
        Member courseMember1 = new Member("testName", "123435", "only message in bottle");
        Member courseMember2 = new Member("testName2", "12345677", "no message in bottle");
        

        DateTime start = new DateTime(2015, 4, 7);
        DateTime end = new DateTime(2015, 8, 7);
        List<Member> members = new List<Member>();
        members.Add(courseMember1);
        members.Add(courseMember2);
        int[] att = { 1, 10 };
        Course testCourse = new Course(1, "TestNavn", start, end, att, members, courseMember1, "this is a test Course");
        courseRepository.Add(testCourse);
        DateTime start2 = new DateTime(2015, 4, 7);
        DateTime end2 = new DateTime(2015, 8, 7);
        List<Member> members2 = new List<Member>();
        members2.Add(courseMember1);
        members2.Add(courseMember2);
        int[] att2 = { 2, 200 };
        Course testCourse2 = new Course(2, "TestNavn2", start2, end2, att2, members2, courseMember1, "this is a test Course2");
        courseRepository.Add(testCourse2);
        courseRepository.PrintAllCourses();*/

        Console.WriteLine("Alex test end");
        Console.WriteLine();
        #endregion

        #region KTest
        /* Test of member ctor
        Member testEgon = new Member("Egon", "11 11 11 11", "REalMail@Mail.ru");
        Console.WriteLine(testEgon);
        */

        /*Cost of editing algorithm
        List<string> DLTestList = new List<string>() { "Egon", "Svendsonson", "Al Jazeera", "Sigurd", "Ejgild", "Egon Olsen"};

        string query = "Eegon";

        List<string> DLTestResultList = DLStringComparer.Matches(DLTestList, query, 9, 5);

        List<DLStringValuePair> DLTestResultListWithValues = DLStringComparer.SortPairs(DLTestList, query);

        Console.WriteLine("Testing the cost-of-editing algorithm");
        for(int i = 0; i<DLTestResultList.Count;i++)
        {
            Console.WriteLine($"Result {i}: {DLTestResultListWithValues[i]}");
        }
        Console.WriteLine("Test ended");
        */

        #endregion

        #region LTest

        #endregion
        }
}