using ClassLibrary.Models;
using ClassLibrary.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        Model optimistjolle = new Model("Optimistjolle", 00.00, 00.00, 00.00, 00.00);
        Boat b1 = new Boat(optimistjolle, "hyggelig for begyndere", "5678");
        Console.WriteLine(b1);
        //Kommentar



        //course test---
        Console.WriteLine( );
        Console.WriteLine("next section ---------------------");
        Member test1 = new Member();
        string[] time = { "1", "2" };
        List<Member> list = new List<Member>();
        list.Add(test1);
        int[] att = { 1, 10 };
        Course testCourse = new Course(1, time,att, list, test1, "this is a test");

        CourseRepository listCourse = new CourseRepository();
        listCourse.Add(testCourse);
        Console.WriteLine(testCourse.ToString());
        listCourse.PrintAllCourses();
    }
}