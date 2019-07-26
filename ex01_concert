using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace ex01_concert
{
    class BandMembers
    {
        public string Members { get; set; }
        public int Time { get; set; }

        public BandMembers()
        {
            this.Members = "";
            this.Time = 0;
        }
    }
    class Program
    {
        static void Main()
        {
            int totalTime = 0;
            string command = "";
            Dictionary<string, BandMembers> concertBands = new Dictionary<string, BandMembers>();
            string lasBand = "";
            string finalInputBand = "";
            while((command = Console.ReadLine()) != "start of concert")
            {
                string currentBandInsert = "";
                List<string> entry = command.Split(new [] { "; ", ", " },
                    StringSplitOptions.RemoveEmptyEntries).ToList();
                if (entry.Count >= 2)
                {
                    for (int i = 2; i < entry.Count; i++)
                    {
                        currentBandInsert += entry[i] + ",";
                    }
                }
                if (entry[0] == "Add")
                {
                    if(!concertBands.Keys.Contains(entry[1]))
                    {
                        concertBands.Add(entry[1], new BandMembers { Members = currentBandInsert });
                    }
                    else if(concertBands.Keys.Contains(entry[1]))
                    {
                        List<string> tempNames = currentBandInsert.Split(',').ToList();
                       List<string> tempExistingNames = concertBands[entry[1]].Members.Split(',').ToList();
                        foreach (var item in tempNames)//
                        {
                            if(!tempExistingNames.Contains(item))
                            {
                                concertBands[entry[1]].Members += item + ",";
                                tempExistingNames.Add(item);
                            }
                        }
                    }
                }
                else if (entry[0] == "Play")
                {
                    if (!concertBands.Keys.Contains(entry[1]))
                        {
                            concertBands.Add(entry[1], new BandMembers { Time = int.Parse(entry[2]) });
                            totalTime += int.Parse(entry[2]);
                    }
                    else if (concertBands.Keys.Contains(entry[1]))
                    {
                        if (concertBands[entry[1]].Time == 0)//
                        {
                            concertBands[entry[1]].Time = int.Parse(entry[2]);
                            totalTime += int.Parse(entry[2]);
                        }
                        else if (concertBands[entry[1]].Time > 0)
                        {
                            concertBands[entry[1]].Time += int.Parse(entry[2]);
                            totalTime += int.Parse(entry[2]);
                        }
                    }

                }
                lasBand = entry[1];
            }
            finalInputBand = Console.ReadLine();
            //Print result
            Console.WriteLine("Total time: " + totalTime);
            var ordered = concertBands.OrderByDescending(x => x.Value.Time).ThenBy(x => x.Key);
            foreach (var band in ordered)
            {
                Console.WriteLine($"{band.Key} -> {band.Value.Time}");
            }
            //
            Console.WriteLine(finalInputBand);
            string[] ouputMembers = concertBands[finalInputBand].Members.Split(',', StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in ouputMembers)
            {
                Console.WriteLine($"=> {item}");
            }

        }
    }
}
