using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace ex01_string_manipulator
{
    class Program
    {
        static void Main()
        {
            string text = "";
            string input;
            while((input = Console.ReadLine()) != "End")
            {
                string[] inputToCommand = input.Split(' ');
                switch(inputToCommand[0])
                {
                    case "Add":
                        text += inputToCommand[1];
                        break;
                    case "Upgrade":
                        List<char> textLoop = new List<char>();
                        foreach (var letter in text)
                        {
                            textLoop.Add(letter);
                        }
                        for (int i = 0; i < textLoop.Count; i++)
                        {
                            if(textLoop[i] == Convert.ToChar(inputToCommand[1]))
                            {
                                textLoop[i] = Convert.ToChar(Convert.ToInt32(textLoop[i]) + 1);
                            }
                        }
                        text = string.Join("", textLoop); // <----------------------------------------------
                        break;
                    case "Print":
                        Console.WriteLine(text);
                        break;
                    case "Index":
                        List<char> textLoopTemp = new List<char>();
                        foreach (char item in text)
                        {
                            textLoopTemp.Add(item);
                        }
                        if (!(textLoopTemp.Contains(Convert.ToChar(inputToCommand[1])))) Console.WriteLine("None");
                        else
                        {
                            for (int i = 0; i < textLoopTemp.Count; i++)
                            {
                                if (textLoopTemp[i] == Convert.ToChar(inputToCommand[1]))
                                {
                                    Console.Write(i + " ");
                                }
                            }
                        }
                        break;
                    case "Remove":
                        Regex pattern = new Regex(inputToCommand[1]);
                        var newText = pattern.Replace(text, "");
                        text = newText;
                        break;
                }
            }
        }
    }
}
