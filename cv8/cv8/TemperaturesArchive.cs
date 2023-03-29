using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace cv8
{
    public class TemperaturesArchive
    {
        private SortedDictionary<int, AnnualTemperature> _archive;

        public TemperaturesArchive()
        {
            _archive = new SortedDictionary<int, AnnualTemperature>();
        }

        public void Load(string filePath)
        {
            string[] lines = System.IO.File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(": ");
                int year = int.Parse(parts[0]);
                List<double> temps = parts[1].Split("; ").Select(double.Parse).ToList();
                _archive[year] = new AnnualTemperature(year, temps);
            }
        }

        public void Save(string filePath)
        {
            string jsonString = JsonSerializer.Serialize(_archive);

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(jsonString);
            }
        }

        public void Calibrate(double number)
        {
            foreach (var item in _archive.Values)
            {
                for (int i = 0; i < item.MonthlyTemperatures.Count; i++)
                {
                    item.MonthlyTemperatures[i] = item.MonthlyTemperatures[i] + number;
                }
            }
        }

        public AnnualTemperature Find(int year)
        {
            if (_archive.TryGetValue(year, out AnnualTemperature temperature))
            {
                Console.Write(year + ": ");
                string temperatureString = string.Join(" ", temperature.MonthlyTemperatures.Select(t => t.ToString("0.0")));
                Console.WriteLine(temperatureString);
                return temperature;
            }
            else
            {
                Console.WriteLine($"Year {year} not found in archive");
                return null;
            }
        }

        public void Temperatures()
        {
            foreach (var pair in _archive)
            {
                Console.Write($"{pair.Key}: ");
                var temperatures = pair.Value.MonthlyTemperatures;
                for (int i = 0; i < temperatures.Count; i++)
                {
                    Console.Write($"{temperatures[i]:F1}");
                    if (i < temperatures.Count - 1)
                    {
                        Console.Write("; ");
                    }
                }
                Console.WriteLine();
            }
        }

        public void AverageYearlyTemperatures()
        {
            foreach (var pair in _archive)
            {
                double avgTemp = pair.Value.AverageYearlyTemperature;
                Console.WriteLine($"{pair.Key}: {avgTemp:F1}");
            }
        }

        public void AverageMonthlyTemperatures()
        {
            double[] monthlyTemp = new double[12];

            foreach (var pair in _archive)
            {
                List<double> avgYearTemp = pair.Value.MonthlyTemperatures;
                for (int i = 0; i < avgYearTemp.Count; i++)
                {
                    monthlyTemp[i] += avgYearTemp[i];
                }
            }

            Console.Write("Average month temperatures: ");
            for (int i = 0; i < 12; i++)
            {
                double avgTemp = monthlyTemp[i] / _archive.Count;
                Console.Write($"{avgTemp:F1} ");
            }
        }

    }
}
