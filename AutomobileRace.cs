using System;
using System.Collections.Generic;

namespace ExerciseFromUniWithRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            Runway runwayA = new Runway(500);
            Runway runwayB = new Runway(1000);

            Racer[] racers = new Racer[]
            {
                new Racer("Gosho", "Peshov", "BMW", 1540, 231, "do-100"),
                new Racer("Tosho", "Toshev", "Mercedes", 1600, 204, "do-200"),
                new Racer("Petur", "Medov", "Audi", 1400, 178, "do-200")
            };


            for (int i = 0; i < racers.Length; i++)
            {
                for (int k = 0; k < racers.Length; k++)
                {
                    if (i != k)
                    {
                        if (!racers[i].PreviousEncounters.Contains(racers[k]))
                        {
                            runwayA.InitiateRace(racers[i], racers[k]);
                            runwayB.InitiateRace(racers[i], racers[k]);
                        }
                    }

                }
            }

            for (int i = 0; i < racers.Length; i++)
            {
                Console.WriteLine($"{racers[i].Name} {racers[i].Points}");
            }
            Console.ReadLine();
        }
    }

    public class Racer
    {
        public string Name { get; private set; }
        public string FamilyName { get; private set; }
        public Automobile automobile { get; private set; }
        public int Points { get; set; }

        public List<Racer> PreviousEncounters = new List<Racer>();

        public Racer(string name, string familyName, string automobileBrand, int automobileWeight, int automobileHorsePower, string typeOfBoost)
        {
            Name = name;
            FamilyName = familyName;
            automobile = new Automobile(automobileHorsePower, automobileBrand, automobileWeight,typeOfBoost);
        }
    }
    public class Automobile
    {
        public int HorsePower { get; private set; }
        public string Brand { get; private set; }
        public int Weight { get; private set; }
        public double SecondsTo100KM { get; private set; }
        public double SecondsFrom100To200KM { get; private set; }

        public Automobile(int horsePower, string brand, int weight,string typeOfBoost)
        {
            HorsePower = horsePower;
            Brand = brand;
            Weight = weight;
            SecondsTo100KM = CalculateSecondsTo100KM(HorsePower);
            SecondsFrom100To200KM = CalculateSecondsFrom100To200KM(HorsePower);
            if (typeOfBoost=="do-100")
            {
                SecondsTo100KM = SecondsTo100KM - ((SecondsTo100KM * 30) / 100);
            }
            if (typeOfBoost=="do-200")
            {
                SecondsFrom100To200KM = SecondsFrom100To200KM - ((SecondsFrom100To200KM * 20) / 100);
            }
        }

        private double CalculateSecondsTo100KM(int HorsePower)
        {
            return ((1 / (double)HorsePower) * 1000) / 2;
        }
        private double CalculateSecondsFrom100To200KM(int HorsePower)
        {
            return (1 / (double)HorsePower) * 1000;
        }
    }
    public class Runway
    {
        private int Length { get; set; }

        public Runway(int length)
        {
            Length = length;
        }

        public void InitiateRace(Racer RacerA, Racer RacerB)
        {
            bool FasterThanRacerBInSecondsTo100KM = RacerA.automobile.SecondsTo100KM < RacerB.automobile.SecondsTo100KM;
            bool FasterThanRacerBInSecondsFrom100To200KM = RacerA.automobile.SecondsFrom100To200KM < RacerB.automobile.SecondsFrom100To200KM;

            if (Length == 500)
            {
                if (FasterThanRacerBInSecondsTo100KM)
                {
                    RacerA.Points += 3;
                }
                else
                {
                    RacerB.Points += 3;
                }
            }
            if (Length == 1000)
            {
                if (FasterThanRacerBInSecondsTo100KM && FasterThanRacerBInSecondsFrom100To200KM)
                {
                    RacerA.Points += 3;
                }
                else
                {
                    RacerB.Points += 3;
                }
            }

            RacerA.PreviousEncounters.Add(RacerB);
            RacerB.PreviousEncounters.Add(RacerA);
        }
    }
}
