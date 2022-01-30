using Labb3SQLochORM.Models;
using System;
using System.Linq;

namespace Labb3SQLochORM
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool menu = true;
            while (menu)
            {                            
                Console.WriteLine("Välj nedan i menyn:");
                Console.WriteLine();
                Console.WriteLine("1: Hämta alla Elever"); 
                Console.WriteLine("2: Hämta alla Elever i en klass");
                Console.WriteLine("3: Lägg till ny personal");
                string MenuInput = Console.ReadLine();
                switch (MenuInput)
                {
                    case "1":
                        getStudents();
                        break;
                    case "2":
                        getStudentsInClass();               
                        break;
                    case "3":
                        addStaff();
                        break;
                    default:
                        Console.WriteLine("Ogiltigt alternativ");
                        break;
                }
            }
        }
        public static void getStudents()
        {
            SampleDbContext Context = new SampleDbContext();
            Console.Clear();
            Console.WriteLine("Hämta alla Elever");
            Console.WriteLine("Vill du se elever sorterade på för eller efternamn?");
            Console.WriteLine("1: Förnamn");
            Console.WriteLine("2: Efternamn");
            int order = Convert.ToInt32(Console.ReadLine());

            if (order == 1)
            {
                var stud = from elev in Context.Elev
                           orderby elev.FNamn
                           select elev;
                foreach (var item in stud)
                {
                    Console.WriteLine($"ID:{item.Id} Namn :{item.FNamn} {item.ENamn} Personnumer :{item.PersonNummer}");
                    Console.WriteLine("------------------------------");
                }
            }
            else if (order == 2)
            {
                var stud = from elev in Context.Elev
                           orderby elev.ENamn
                           select elev;
                foreach (var item in stud)
                {
                    Console.WriteLine($"ID:{item.Id} Namn :{item.FNamn} {item.ENamn} Personnumer :{item.PersonNummer}");
                    Console.WriteLine("------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Ogiltigt alternativ");
            }
            Console.WriteLine("Tryck enter för att återgå till huvudmenyn");
            Console.ReadKey();
            Console.Clear();

        }
        public static void getStudentsInClass()
        {
            SampleDbContext Context = new SampleDbContext();
            Console.Clear();
            Console.WriteLine("Hämta alla Elever i en klass");
            var classes = from Klass in Context.Klass
                          orderby Klass.Id
                          select Klass;

            foreach (var item in classes)
            {
                Console.WriteLine(item.Id + ": " + item.Namn);
            }
            Console.WriteLine("Välj vilken klass du vill se:");
            int case2 = Convert.ToInt32(Console.ReadLine());
            if (case2 == 1)
            {
                var sut21 = from elev in Context.Elev
                            where elev.KlassId == 1
                            select elev;
                Console.Clear();
                Console.WriteLine("Alla elever i sut21");
                foreach (var item in sut21)
                {
                    Console.WriteLine($"ID:{item.Id} Namn :{item.FNamn} {item.ENamn} Personnumer :{item.PersonNummer}");
                    Console.WriteLine("------------------------------");
                }
                Console.WriteLine("Tryck enter för att återgå till huvudmenyn");
                Console.ReadKey();
                Console.Clear();                
            }
            if (case2 == 2)
            {
                var sut20 = from elev in Context.Elev
                            where elev.KlassId == 2
                            select elev;
                Console.Clear();
                Console.WriteLine("Alla elever i sut20");
                foreach (var item in sut20)

                    Console.WriteLine($"ID:{item.Id} Namn :{item.FNamn} {item.ENamn} Personnumer :{item.PersonNummer}");
                Console.WriteLine("------------------------------");

                Console.WriteLine("Tryck enter för att återgå till huvudmenyn");
                Console.ReadKey();
                Console.Clear();              
            }
        }
        public static void addStaff()
        {
            SampleDbContext Context = new SampleDbContext();

            Console.Clear();
            Console.WriteLine("Lägg till ny personal");
            Console.WriteLine("Vill du lägga till:");
            Console.WriteLine("[1} Lärare");
            Console.WriteLine("[2} Adminitratör");
            Console.WriteLine("[3} Rektor ");

            int roll = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Skriv in förnamn:");
            string newFname = Console.ReadLine();
            Console.WriteLine("Skriv in efternamn");
            string newLname = Console.ReadLine();

            Personal p1 = new Personal()
            {
                BefattningsId = roll,
                SkolId = 1,
                FNamn = newFname,
                ENamn = newLname,
            };
            Console.WriteLine(p1.ENamn + " Lades till i databasen");
            Context.Add(p1);
            Context.SaveChanges();
            Console.Clear();
        }
    }
}
