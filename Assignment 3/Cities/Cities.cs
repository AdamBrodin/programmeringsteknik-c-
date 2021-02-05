using System;
using System.Collections.Generic;
using System.Linq;

namespace ImperativeToFunctional
{
    public class City
    {
        public string Name;
        public int Population;
        public double Area;
        public int Founded;
    }

    public class Cities
    {
        public static void Main()
        {
            City[] cities =
            {
                new City
                {
                    Name = "Stockholm",
                    Area = 381.63,
                    Population = 1515017,
                    Founded = 1252
                },
                new City
                {
                    Name = "G�teborg",
                    Area = 215.13,
                    Population = 590580,
                    Founded = 1621
                },
                new City
                {
                    Name = "Malm�",
                    Area = 77.06,
                    Population = 312012,
                    Founded = 1250
                },
                new City
                {
                    Name = "Uppsala",
                    Area = 43.74,
                    Population = 156854,
                    Founded = 1286
                },
                new City
                {
                    Name = "V�ster�s",
                    Area = 48.07,
                    Population = 121806,
                    Founded = 990
                },
                new City
                {
                    Name = "�rebro",
                    Area = 50.64,
                    Population = 119091,
                    Founded = 1200
                }
            };

            int highestPopulation = cities[0].Population;
            highestPopulation = cities.Where(c => c.Population > highestPopulation).DefaultIfEmpty(cities[0]).Select(c => c.Population).Max();

            Console.WriteLine("Highest population: " + highestPopulation);

            int earliestFounding = cities[0].Founded;
            earliestFounding = cities.Where(c => c.Founded < earliestFounding).DefaultIfEmpty(cities[0]).Select(c => c.Founded).Min();
            Console.WriteLine("Earliest founding: " + earliestFounding);

            double totalPopulationDensity = 0;
            cities.ToList().ForEach(c => totalPopulationDensity += c.Population / c.Area);
            double averagePopulationDensity = Math.Round(totalPopulationDensity / cities.Length);
            Console.WriteLine("Average population density: " + averagePopulationDensity + " people per square kilometer");

            List<City> longNameCities = new List<City>();
            longNameCities.AddRange(cities.Where(c => c.Name.Length !=> 6).ToList());

            List<string> longNames = new List<string>();
            longNameCities.ForEach(c => longNames.Add(c.Name));
            Console.WriteLine("Cities with names longer than six letters: " + String.Join(", ", longNames));

        }
    }
}