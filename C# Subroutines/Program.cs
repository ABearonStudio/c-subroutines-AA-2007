using System.Reflection;

///////////////
// TASKS
//
//    - Find and answer all the QUESTIONs
//    - Implement the TODOs
//
///////////////


internal class Program
{
    // QUESTION: Is Country a Record or a Tuple?
    // Record - An ordered set of values of any type - mutable
    // Tuple - An ordered set of values of any type - immutable
    // Critical thinking QUESTION: in C#, "readonly struct" is immutable.  Does that alter your answer above?
    internal struct Country
    {
        public string Name;
        public int Population;
        public int LandArea;
        public int Density;
    }

    // QUESTION: What is the scope of countriesData?
    // Hint: consider if it is Global or Local (or something else)
    static List<Country> countriesData = new List<Country>();

    private static void Main(string[] args)
    {
        ImportData();

        // TODO - 1. Ask the user to enter the name of a country
        // TODO - 2. Use FindPopulation to find the population of that country.
        // TODO - 3. Output the population to the user
        // TODO - 4. Go back to 1
        // Extension - countriesData is sorted by name.  Update FindPopulation to use BinarySearch instead of LinearSearch

    }

    // QUESTION: is FindPopulation a function or procedure
    /// <summary>
    /// Linear Search through countriesData to find the population
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private static int FindPopulation(string name)
    {
        // QUESTION: What is the scope of country?
        foreach (var country in countriesData)
        {
            if (country.Name == name)
            {
                return country.Population;
            }
        }

        return -1;
    }


    // QUESTION: is ImportData a function or procedure
    private static void ImportData()
    {
        // QUESTION: What is the scope of assembly?
        var assembly = Assembly.GetExecutingAssembly();
        const string resourceName = "C__Subroutines.WorldCountries.csv";

        var resourceStream = assembly.GetManifestResourceStream(resourceName);
        if (resourceStream == null) { throw new ApplicationException("Build error; resource file missing."); }

        using var reader = new StreamReader(resourceStream);

        // Skip the 1st line because it contains headers
        reader.ReadLine();

        while (true)
        {
            // QUESTION: What is the scope of line?
            var line = reader.ReadLine();

            // Reached end of file so we're done
            if (line == null) { return; }

            string[] values = line.Split(',');
            Country country = new Country()
            {
                Name = values[0],
                Population = int.Parse(values[1]),
                LandArea = int.Parse(values[2]),
                Density = int.Parse(values[3])
            };
            countriesData.Add(country);
        }
    }
}
