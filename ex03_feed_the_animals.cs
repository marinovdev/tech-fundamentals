using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ex03_feed_the_animals
{
    class AnimalsReefugee
    {
        public int FoodLimit { get; set; }
        public string Area { get; set; }

        public AnimalsReefugee()
        {
            this.FoodLimit = FoodLimit;
            this.Area = Area;
        }
    }

    class Program
    {
        static void Main()
        {
            var areaByHungryAnimals = new Dictionary<string, int>();
            Dictionary<string, AnimalsReefugee> animals = new Dictionary<string, AnimalsReefugee>();
            string command = "";
            while((command = Console.ReadLine()) != "Last Info")
            {

                string[] execute = command.Split(':');
                string name = execute[1];
                int food = int.Parse(execute[2]);
                string area = Convert.ToString(execute[3]);
                if (execute[0] == "Add")
                {
                    AnimalsReefugee c = new AnimalsReefugee { FoodLimit = food, Area = area };
                    if (!animals.ContainsKey(name))
                    {
                        animals.Add(name, c);
                        if (!areaByHungryAnimals.ContainsKey(area))
                        {
                            areaByHungryAnimals.Add(area, 0);
                        }
                        
                            areaByHungryAnimals[area] += 1;                    
                    }
                    else
                    {
                        animals[name].FoodLimit += food;
                    }
                }
                else if(execute[0] == "Feed") // 
                {
                    if(animals.ContainsKey(name))// VVVVVVVVV
                    {
                        if ((animals[name].FoodLimit - food) > 0)
                        {
                            animals[name].FoodLimit -= food;
                        }
                        else
                        {
                            animals.Remove(name);
                            areaByHungryAnimals[area] -= 1;
                            Console.WriteLine($"{name} was successfully fed");
                        }
                    }
                }
            }
            Console.WriteLine("Animals:");
            var sorted = animals.OrderByDescending(x => x.Value.FoodLimit).ThenBy(x => x.Key);
            foreach (var item in sorted.Where(x => x.Value.FoodLimit > 0))
            {
                Console.WriteLine($"{item.Key} -> {item.Value.FoodLimit}g");
            }
            //Ading each area to new Dictionary
            Console.WriteLine("Areas with hungry animals:");
            foreach (var item in areaByHungryAnimals.OrderByDescending(x => x.Value).Where(x => x.Value > 0))
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }
        }
    }
}
