namespace cv8
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            TemperaturesArchive temperatures = new TemperaturesArchive();

            temperatures.Load(@"<PATH>);

            Console.WriteLine("Archive :");
            temperatures.Temperatures();

            Console.WriteLine("\nAverage yearly temperatures :");
            temperatures.AverageYearlyTemperatures();
            Console.WriteLine();

            temperatures.AverageMonthlyTemperatures();
            Console.WriteLine();

            Console.WriteLine("\nCalibration :");
            temperatures.Calibrate(-0.1);
            temperatures.Temperatures();

            Console.WriteLine();
            temperatures.Find(2021);

            temperatures.Save(@"<PATH>");
        }
    }
}