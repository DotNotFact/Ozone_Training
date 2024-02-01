using System.Collections.Generic;
using System.Text;
using System;

class SimpleTerminal
{
    static void Main()
    {
        int t = int.Parse(Console.ReadLine()); // 4

        //var strings = new string[]
        //{
        //    "otLLLrRuEe256LLLN",
        //    "LRLUUDE",
        //    "itisatest",
        //    "abNcdLLLeUfNxNx"
        //}; 

        for (int i = 0; i < t; i++)
        {
            string input = Console.ReadLine(); // strings[i]; 
            var output = ChangingTerminalLogic(input);

            foreach (string line in output)
                Console.WriteLine(line);

            // Console.WriteLine(string.Join("\n", output));
            Console.WriteLine("-");
        }
    }

    static IEnumerable<string> ChangingTerminalLogic(string input)
    {
        int currentLine = 0, cursorPosition = 0;
        var lines = new List<string> { "" };

        foreach (char ch in input)
        {
            switch (ch)
            {
                case 'L': cursorPosition = Math.Max(0, cursorPosition - 1); break;
                case 'R': cursorPosition = Math.Min(lines[currentLine].Length, cursorPosition + 1); break;
                case 'U':
                    {
                        if (currentLine > 0)
                        {
                            cursorPosition = Math.Min(lines[currentLine].Length, cursorPosition);
                            currentLine--;
                        }
                        break;
                    }
                case 'D':
                    {
                        if (currentLine < lines.Count - 1)
                        {
                            cursorPosition = Math.Min(lines[currentLine].Length, cursorPosition);
                            currentLine++;
                        }
                        break;
                    }
                case 'B': cursorPosition = 0; break;
                case 'E': cursorPosition = lines[currentLine].Length; break;
                case 'N':
                    {
                        string currentText = lines[currentLine];
                        lines[currentLine] = currentText[..cursorPosition];
                        lines.Insert(currentLine + 1, currentText[cursorPosition..]);
                        cursorPosition = 0;
                        currentLine++;
                        break;
                    }
                default:
                    if (char.IsLetterOrDigit(ch))
                    {
                        lines[currentLine] = lines[currentLine].Insert(cursorPosition, ch.ToString());
                        cursorPosition++;
                    }
                    break;
            }
        }
        return lines;
    }

    static IEnumerable<string> ChangingTerminalLogic1(string input)
    {
        var lines = new List<StringBuilder> { new StringBuilder() };
        int currentLine = 0, cursorPosition = 0;

        foreach (char ch in input)
        {
            var line = lines[currentLine];
            switch (ch)
            {
                case 'R': cursorPosition = Math.Min(line.Length, cursorPosition + 1); break;
                case 'L': cursorPosition = Math.Max(0, cursorPosition - 1); break;
                case 'E': cursorPosition = line.Length; break;
                case 'B': cursorPosition = 0; break;
                case 'U':
                    {
                        if (currentLine > 0)
                        {
                            cursorPosition = Math.Min(line.Length, cursorPosition);
                            currentLine--;
                        }
                        break;
                    }
                case 'D':
                    {
                        if (currentLine < lines.Count - 1)
                        {
                            cursorPosition = Math.Min(line.Length, cursorPosition);
                            currentLine++;
                        }
                        break;
                    }
                case 'N':
                    {
                        lines.Insert(currentLine + 1, new StringBuilder(line.ToString(cursorPosition, line.Length - cursorPosition)));
                        line.Length = cursorPosition;
                        currentLine++;
                        cursorPosition = 0;
                        break;
                    }
                default:
                    {
                        if (char.IsLetterOrDigit(ch))
                        {
                            lines[currentLine] = lines[currentLine].Insert(cursorPosition, ch.ToString());
                            cursorPosition++;
                        }
                        break;
                    }
            }
        }
        return lines.Select(sb => sb.ToString());
    }
}