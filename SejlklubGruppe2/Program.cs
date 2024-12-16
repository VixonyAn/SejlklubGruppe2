using ClassLibrary.Data;
using ClassLibrary.Exceptions;
using ClassLibrary.Helpers;
using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using ClassLibrary.Services;
using System.Diagnostics;
using System.Threading.Channels;

internal class Program
{
    private static void Main(string[] args)
    {
        #region VTest
        /* testing for UML design sekvens diagram
        ModelRepository modelRepo = new ModelRepository();
        modelRepo.AddModel("Optimistjolle", "hyggelig for begyndere", 00.00, 00.00, 00.00, 00.00);
        // should try catch here when testing adding the same model to keep the program running
        */

        /* initial constructor and Add to list exception test
        // THIS WILL NO LONGER WORK as of 06/12 since nicknames were added
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
        //IModelRepository modelRepo = new ModelRepository();
        IBoatRepository boatRepo = new BoatRepository();
        List<Boat> boatList = boatRepo.GetAll(); // bring our dict into a list
        foreach (Boat boat in boatList)
        {
            Console.WriteLine($"{boat}");
        }

        /* testing maintlogs
        IMaintenanceRepository maintRepo = new MaintenanceRepository();
        List<MaintenanceNote> maintList = maintRepo.GetAll();
        foreach (MaintenanceNote maintenanceNote in maintList)
        {
            Console.WriteLine($"{maintenanceNote}");
        }
        */

        /* test print alle modeller
        List<Model> modelList = modelRepo.GetAll();
        foreach (Model model in modelList)
        {
            Console.WriteLine($"{model}");
        } */

        /* testing edit function using the Reg ID
        // THIS WILL NO LONGER WORK as of 06/12 since nicknames were added
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

        /* testing maintenance notes, works on 13/12/2024, remember 50/50 chance of generation
        IMaintenanceRepository maintRepo = new MaintenanceRepository();
        List<IMaintenanceNote> noteList = maintRepo.GetAll();
        foreach (IMaintenanceNote note in noteList)
        {
            Console.WriteLine($"{note}");
        }*/
        #endregion

        #region Atest
        /*
        Console.WriteLine("");
        Console.WriteLine("Alex test start");

        
        CourseRepository courseRepository = new CourseRepository();
        Member courseMember1 = new Member("testName", "123435", "only message in bottle");
        Member courseMember2 = new Member("testName2", "12345677", "no message in bottle");
        

        DateTime start = new DateTime(2015, 4, 7);
        DateTime end = new DateTime(2015, 8, 7);
        List<Member> members = new List<Member>();
        members.Add(courseMember1);
        members.Add(courseMember2);
        int[] att = { 1, 10 };
        Course testCourse = new Course(1, "TestNavn", start, end, att, members, courseMember1, "this is a test Course","this is a test course des");
        courseRepository.Add(testCourse.Name, testCourse.TimeSlot[0], testCourse.TimeSlot[1],testCourse.AttendeeRange,testCourse.Attendees,testCourse.Master,testCourse.Summary,testCourse.Description);
        DateTime start2 = new DateTime(2015, 4, 7);
        DateTime end2 = new DateTime(2015, 8, 7);
        List<Member> members2 = new List<Member>();
        members2.Add(courseMember1);
        members2.Add(courseMember2);
        int[] att2 = { 2, 200 };
        Course testCourse2 = new Course(2, "TestNavn2", start2, end2, att2, members2, courseMember1, "this is a test Course2", "this is a test course2 des");

        courseRepository.Add(testCourse2.Name, testCourse2.TimeSlot[0], testCourse2.TimeSlot[1], testCourse2.AttendeeRange, testCourse2.Attendees, testCourse2.Master, testCourse2.Summary, testCourse2.Description);
        courseRepository.PrintAllCourses();
        Console.WriteLine("courses added");

        DateTime start3=new DateTime(2024,4, 7); DateTime end3 = new DateTime(2025, 4, 7); int[] att3 = { 5, 200 };
        Course newcourse = new Course(3, "TestNavn_Newtest", start3, end3, att3, members2, courseMember1, "this is a newCourse3", "this is a newCourse3 des");
        courseRepository.Update(newcourse, testCourse2);
        courseRepository.PrintAllCourses();
        Console.WriteLine( "course edited");

        courseRepository.Delete(testCourse.Id);
        courseRepository.PrintAllCourses();
        Console.WriteLine( "course Deleted");


        Console.WriteLine("Alex test end");
        Console.WriteLine();
        */
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

        /* Test of bookingRepository
        //Accessing mockdata
        List<IMember> mTestList = MockData.GetInstance().MemberData.Values.ToList();
        List<Boat> bTestList = MockData.GetInstance().BoatData.Values.ToList();

        //References to select objects from mockdata
        IMember m1 = mTestList[0]; IBoat b1 = bTestList[0];
        IMember m2 = mTestList[1]; IBoat b2 = bTestList[1];
        IMember m3 = mTestList[2]; IBoat b3 = bTestList[2];

        //Adding bookings to the repo (and creating dateTime instances)
        BookingRepository bookingTestRepo = new BookingRepository();
        bookingTestRepo.AddBooking(m1,b1,new DateTime(2024,1,1),new DateTime(2024,1,2));
        bookingTestRepo.AddBooking(m2, b2, new DateTime(2024, 1, 3), new DateTime(2024, 1, 4));
        bookingTestRepo.AddBooking(m3, b2, new DateTime(2023, 1, 1), new DateTime(2023, 1, 2));
        bookingTestRepo.AddBooking(m3, b3, new DateTime(2022, 1, 1), new DateTime(2022, 1, 2));

        List<IBooking> bookingTestList;

        Console.WriteLine("Testing bookings and their filters, 11-12-2024");
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        for(int i = 0; i<5; i++) //5 is the number of different scenarios here
        {
            switch(i)
            {
                case 0:
                    bookingTestList = bookingTestRepo.GetAll();
                    break;
                case 1:
                    bookingTestList = bookingTestRepo.GetBookingsForMember(m3);
                    break;
                case 2:
                    bookingTestList = bookingTestRepo.GetBookingsForBoat(b2);
                    break;
                case 3:
                    bookingTestList = bookingTestRepo.GetBookingsForModel(b1.Model);//Should be the same as getAll with current Mockdata
                    break;
                case 4:
                    bookingTestList = bookingTestRepo.GetBookingsForDayInterval(new DateTime(2023, 1, 1), new DateTime(2024, 1, 1), out bool found);
                    break;
                default:
                    bookingTestList = bookingTestRepo.GetBookingsForDayInterval(new DateTime(2023, 1, 1), new DateTime(2024, 1, 1), out bool found2);
                    break;
            }
            Console.WriteLine($"Test {i+1}:\n\n");
            foreach(IBooking b in bookingTestList)
            {
                Console.WriteLine($"\nHolder: {b.Holder.Name}. Boat: {b.Bookable.Nickname}, {b.Bookable.Model.ModelName}.\nStart of booking: {b.Start}\nEnd of Booking: {b.End}");
            }
        }
        stopwatch.Stop();
        Console.WriteLine($"\nTime taken to run all filters once: {stopwatch.Elapsed.TotalMilliseconds} ms");
        Console.WriteLine("\nEnd of test \"bookingrepo\" 11-12-24");
        */


        #endregion

        #region LTest

        #endregion
    }
}