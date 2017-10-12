using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class LinqOverview : Form
    {
        public LinqOverview()
        {
            InitializeComponent();
        }

        private void LinqOverview_Load(object sender, EventArgs e)
        {
            /*
            foreach (Racer r in TraditionalQuery())
            {
                txtOverview.AppendText(String.Format("{0:A}", r));
                txtOverview.AppendText("\n");
            }
           

            foreach (Racer r in LambdaExpressions())
            {
                txtOverview.AppendText(String.Format("{0:A}", r));
                txtOverview.AppendText("\n");

            }
            

            foreach (Racer r in LinqQuery())
            {
                txtOverview.AppendText(String.Format("{0:A}", r));
                txtOverview.AppendText("\n");

            }
            

            foreach (string r in LinqQuery())
            {
                txtOverview.AppendText(String.Format("{0:A}", r));
                txtOverview.AppendText("\n");

            }
            */


            foreach (Racer r in LinqQuery())
            {
                txtOverview.AppendText(String.Format("{0:A}", r));
                txtOverview.AppendText("\n");

            }



        }

        public static List<Racer> TraditionalQuery()
        {

            List<Racer> racers = new List<Racer>(Formula1.GetChampions());

            List<Racer> brazilRacers = racers.FindAll(delegate (Racer r)
             { return r.Country == "Brazil"; });
            brazilRacers.Sort(
                delegate (Racer r1, Racer r2)
                {

                    return r2.Wins.CompareTo(r1.Wins);
                });

            return brazilRacers;
                    
        }
        public static IEnumerable<Racer> LambdaExpressions()
        {

            IEnumerable<Racer> brazilChampions =
                Formula1.GetChampions().
                Where(r => r.Country == "Brazil").
                OrderByDescending(r => r.Wins).
                Select(r => r);
            /*
            foreach (Racer r in brazilChampions)
            {

                Console.WriteLine("{0:A}, r");
            }
            */

            return brazilChampions;
        }
        public static IEnumerable<Racer> LinqQuery()
        {
            var query = from r in Formula1.GetChampions()
                        where r.Country == "Brazil"
                        orderby r.Wins descending
                        select r;

            //Filtering
            var races = from r in Formula1.GetChampions()
                        where r.Wins > 15 && (r.Country == "Brazil" || r.Country == "Austria")
                        select r;

            //Filtering with lambda expression
            var racers = Formula1.GetChampions().Where(r => r.Wins > 15 && (r.Country == "Brazil" || r.Country == "Austria")).Select(r => r);

            //Filtering with index
            var racerss = Formula1.GetChampions().Where((r, index) => r.LastName.StartsWith("A") && index % 2 != 0);

            //Type Filtering
            object[] data = { "one", 2, 3, "four", "five", 6 };

            var myquery = data.OfType<string>();

            foreach(var s in query)
            {
                Console.WriteLine(s);
            }

            //Compound form
            var ferrariDrivers = from r in
                                     Formula1.GetChampions()
                                 from c in r.Cars
                                 where c == "Ferrari"
                                 orderby r.LastName
                                 select r.FirstName + " " + r.LastName;

            //SelectMany
            var ferrariDriversMany = Formula1.GetChampions().
                SelectMany(r => r.Cars, (r, c) => new { Racer = r, Car = c }).
                 Where(r => r.Car == "Ferrari").
                 OrderBy(r => r.Racer.LastName).
                 Select(r => r.Racer.FirstName + " " + r.Racer.LastName);

            //Sorting Linq
            var racersSortingLinq = from r in Formula1.GetChampions()
                                where r.Country == "Brazil"
                                orderby r.Wins descending
                                select r;

            //Sorting Lamba (extansion methods)
            var racersSortingLambda = Formula1.GetChampions().
                Where(r => r.Country == "Brazil").
                OrderByDescending(r => r.Wins).
                Select(r => r);

            //Take
            var racersTake = (from r in Formula1.GetChampions()
                              orderby r.Country, r.LastName, r.FirstName
                              select r).Take(10);

            //Take with extension methods Lambda
            var racersTakeLambda = Formula1.GetChampions().
                OrderBy(r => r.Country).
                ThenBy(r => r.LastName).
                ThenBy(r => r.FirstName).
                Take(10);

            //Grouping
            var countries = from r in Formula1.GetChampions()
                            group r by r.Country into g
                            orderby g.Count() descending, g.Key
                            where g.Count() >= 2
                            select new { Country = g.Key, Count = g.Count() };

            //Gouping with extension methods Lambda
            var countriesLambda = Formula1.GetChampions().
                    GroupBy(r => r.Country).
                     OrderByDescending(g => g.Count()).
                     ThenBy(g => g.Key).
                     Where(g => g.Count() >= 2).
                     Select(g => new { Country = g.Key, Count = g.Count() });
            


            return racersTake;
        }


    }

    //using List<>
    [Serializable]
    public class Racer: IComparable<Racer>, IFormattable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Wins { get; set; }
        public string Country { get; set; }
        public int Starts { get; set; }
        public string[] Cars { get; set; }
        public int[] Years { get; set; }

        public override string ToString()
        {
            return String.Format("{0}{1}", FirstName, LastName);
        }

        public int CompareTo(Racer other)
        {
            return this.LastName.CompareTo(other.LastName);
        }

        public string ToString(string format)
        {
            return ToString(format, null);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            switch (format)
            {
                case null:
                case "N":
                    return ToString();
                case "F":
                    return FirstName;
                case "L":
                    return LastName;
                case "C":
                    return Country;
                case "S":
                    return Starts.ToString();
                case "W":
                    return Wins.ToString();
                case "A":
                    return String.Format("{0}{1}, {2};" + " starts: {3}, wins{4}", FirstName, LastName, Country, Starts, Wins);
                default:
                    throw new FormatException(String.Format("Format {0} not supported", format));

            }

        }

    }

    public static class Formula1
    {

        public static IList<Racer> GetChampions()
        {
            List<Racer> racers = new List<Racer>(40);

            racers.Add(new Racer()
            {
                FirstName = "Nino",
                LastName = "Farina",
                Country = "Italy",
                Starts = 33,
                Wins = 5,
                Years = new int[] { 1950 },
                Cars = new string[] { "Alfa Romeo" }});

            racers.Add(new Racer()
            {
                FirstName = "Alberto",
                LastName = "Ascari",
                Country = "Italy",
                Starts = 32,
                Wins = 10,
                Years = new int[] { 1952, 1953 },
                Cars = new string[] { "Ferrari" } });

            racers.Add(new Racer()
            {
                FirstName = "Juan Manuel",
                LastName = "Fangio",
                Country = "Argentina",
                Starts = 51,
                Wins = 24,
                Years = new int[] { 1951, 1954, 1955, 1956, 1957 },
                Cars = new string[] { "Alfa Romeo","Maserati", "Mercedes","Ferrari" }});

            racers.Add(new Racer() { FirstName = "Mike", LastName = "Hawthorn", Country = "UK", Starts = 45, Wins = 3, Years = new int[] { 1958 }, Cars = new string[] { "Ferrari" } });
            racers.Add(new Racer() { FirstName = "Phil", LastName = "Hill", Country = "USA", Starts = 48, Wins = 3, Years = new int[] { 1961 }, Cars = new string[] { "Ferrari" } });
            racers.Add(new Racer() { FirstName = "John", LastName = "Surtees", Country = "UK", Starts = 111, Wins = 6, Years = new int[] { 1964 }, Cars = new string[] { "Ferrari" } });
            racers.Add(new Racer() { FirstName = "Jim", LastName = "Clark", Country = "UK", Starts = 72, Wins = 25, Years = new int[] { 1963, 1965 }, Cars = new string[] { "Lotus" } });
            racers.Add(new Racer() { FirstName = "Jack", LastName = "Brabham", Country = "Australia", Starts = 125, Wins = 14, Years = new int[] { 1959, 1960, 1966 }, Cars = new string[] { "Cooper", "Brabham" } });
            racers.Add(new Racer() { FirstName = "Denny", LastName = "Hulme", Country = "New Zealand", Starts = 112, Wins = 8, Years = new int[] { 1967 }, Cars = new string[] { "Brabham" } });
            racers.Add(new Racer() { FirstName = "Graham", LastName = "Hill", Country = "UK", Starts = 176, Wins = 14, Years = new int[] { 1962, 1968 }, Cars = new string[] { "BRM", "Lotus" } });
            racers.Add(new Racer() { FirstName = "Jochen", LastName = "Rindt", Country = "Austria", Starts = 60, Wins = 6, Years = new int[] { 1970 }, Cars = new string[] { "Lotus" } });
            racers.Add(new Racer() { FirstName = "Jackie", LastName = "Stewart", Country = "UK", Starts = 99, Wins = 27, Years = new int[] { 1969, 1971, 1973 }, Cars = new string[] { "Matra", "Tyrrell" } });
            racers.Add(new Racer() { FirstName = "Emerson", LastName = "Fittipaldi", Country = "Brazil", Starts = 143, Wins = 14, Years = new int[] { 1972, 1974 }, Cars = new string[] { "Lotus","McLaren" } });
            racers.Add(new Racer() { FirstName = "James", LastName = "Hunt", Country = "UK", Starts = 91, Wins = 10, Years = new int[] { 1976 }, Cars = new string[] { "McLaren" } });
            racers.Add(new Racer() { FirstName = "Mario", LastName = "Andretti", Country = "USA", Starts = 128, Wins = 12, Years = new int[] { 1978 }, Cars = new string[] { "Lotus" } });
            racers.Add(new Racer() { FirstName = "Jody", LastName = "Scheckter", Country = "South Africa", Starts = 112, Wins = 10, Years = new int[] { 1979 }, Cars = new string[] { "Ferrari" } });
            racers.Add(new Racer() { FirstName = "Alan", LastName = "Jones", Country = "Australia", Starts = 115, Wins = 12, Years = new int[] { 1980 }, Cars = new string[] { "Williams" } });
            racers.Add(new Racer() { FirstName = "Keke", LastName = "Rosberg", Country = "Finland", Starts = 114, Wins = 5, Years = new int[] { 1982 }, Cars = new string[] { "Williams" } });
            racers.Add(new Racer() { FirstName = "Niki", LastName = "Lauda", Country = "Austria", Starts = 173, Wins = 25, Years = new int[] { 1975, 1977, 1984 }, Cars = new string[] { "Ferrari","McLaren" } });
            racers.Add(new Racer() { FirstName = "Nelson", LastName = "Piquet", Country = "Brazil", Starts = 204, Wins = 23, Years = new int[] { 1981, 1983, 1987 }, Cars = new string[] { "Brabham","Williams" } });
            racers.Add(new Racer() { FirstName = "Ayrton", LastName = "Senna", Country = "Brazil", Starts = 161, Wins = 41, Years = new int[] { 1988, 1990, 1991 }, Cars = new string[] { "McLaren" } });
            racers.Add(new Racer() { FirstName = "Nigel", LastName = "Mansell", Country = "UK", Starts = 187, Wins = 31, Years = new int[] { 1992 }, Cars = new string[] { "Williams" } });
            racers.Add(new Racer() { FirstName = "Alain", LastName = "Prost", Country = "France", Starts = 197, Wins = 51, Years = new int[] { 1985, 1986, 1989, 1993 }, Cars = new string[] { "McLaren","Williams" } });
            racers.Add(new Racer() { FirstName = "Damon", LastName = "Hill", Country = "UK", Starts = 114, Wins = 22, Years = new int[] { 1996 }, Cars = new string[] { "Williams" } });
            racers.Add(new Racer() { FirstName = "Jacques", LastName = "Villeneuve", Country = "Canada", Starts = 165, Wins = 11, Years = new int[] { 1997 }, Cars = new string[] { "Williams" } });
            racers.Add(new Racer() { FirstName = "Mika", LastName = "Hakkinen", Country = "Finland", Starts = 160, Wins = 20, Years = new int[] { 1998, 1999 }, Cars = new string[] { "McLaren" } });
            racers.Add(new Racer() { FirstName = "Michael", LastName = "Schumacher", Country = "Germany", Starts = 250, Wins = 91, Years = new int[] { 1994, 1995, 2000, 2001, 2002, 2003, 2004 }, Cars = new string[] { "Benetton","Ferrari" } });
            racers.Add(new Racer() { FirstName = "Fernando", LastName = "Alonso", Country = "Spain", Starts = 105, Wins = 19, Years = new int[] { 2005, 2006 }, Cars = new string[] { "Renault" } });
            racers.Add(new Racer() { FirstName = "Kimi", LastName = "R ä ikk ö nen", Country = "Finland", Starts = 122, Wins = 15, Years = new int[] { 2007 }, Cars = new string[] { "Ferrari" } });
            return racers;

        }

        /*
       public static IList<Team> GetConstructorChampions()
        {
            List<Team> teams = new List<Team>(20);


        }
        */
    }

}
