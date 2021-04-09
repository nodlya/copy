using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FieldGeneration
{
    public static class FieldWork
    {
        public static char[,] field = new char[4, 4];
        public static int[,] pattern = { { 0, 0, 0, 1 }, { 0, 2, 1, 1 }, { 0, 2, 2, 2 }, { 3, 3, 3, 2 } };
        public static string[] start = { "[0,2]-0,5", "[2,2]-1,3", "[3,3]-2,5", "[3,2]-3,3" };

        public static void IfDirectoryExists()
        {
            if (!File.Exists(Program.path)) throw new Exception("Dictionary doesn't exist");
            else Console.WriteLine("Dictionary is ok");
        }

        public static void ChoosePattern()
        {

        }

        public static /*string[]*/ void SplitIntoStrings()
        {
            var random = new Random();
            string[] stringsFile = File.ReadAllLines(Program.path);
            string rand0 = string.Empty;
            string rand1 = string.Empty;
            string rand2 = string.Empty;
            string rand3 = string.Empty;
            while (rand0.Length + rand1.Length + rand2.Length + rand3.Length != 16)
            {
                string temp = stringsFile[random.Next(stringsFile.Length)];
                if (temp.Length == Convert.ToInt32(start[0].Substring(8, start[0].Length - 8)) 
                        && rand0 == string.Empty) rand0 = temp;
                else if (temp.Length == Convert.ToInt32(start[1].Substring(8, start[1].Length - 8)) 
                        && rand1 == string.Empty) rand1 = temp;
                else if (temp.Length == Convert.ToInt32(start[2].Substring(8, start[2].Length - 8)) 
                        && rand2 == string.Empty) rand2 = temp;
                else if (temp.Length == Convert.ToInt32(start[3].Substring(8, start[3].Length - 8)) 
                        && rand3 == string.Empty) rand3 = temp;

                if (rand0 == rand2) rand2 = string.Empty;
                if (rand1 == rand3) rand3 = string.Empty;

            }
            string[] words = { rand0, rand1, rand2, rand3 };
            //Console.WriteLine(rand3 + "\n \n");
            WriteChosen(words);
            //return stringsFile;
            GenerateField(words);
        }

        public static void GenerateField(string[] words)
        {
            for (int i = 0; i < words.Length; i++)
            {
                FitWord(words[i], i);
            }
        }

       private static void FitWord(string word, int number)
        {
            int x = int.Parse(start[number].Substring(1, 1));
            int y = int.Parse(start[number].Substring(3, 1));
            Console.WriteLine(x+" "+y);
            field[x,y] = word[0];
            //string newword = word.Substring(1);
            bool flag = false;
            while (!flag)
            {
                flag = true;
                for (int i = 1; i < word.Length; i++)
                {
                    if (x+1<4 && field[x + 1, y] == number) { field[x + 1, y] = word[i]; x++; }
                    else if (y+1<4 && field[x, y + 1] == number) { field[x, y + 1] = word[i]; y++; }
                    else if (y - 1 >= 0 && field[x, y - 1] == number) { field[x, y - 1] = word[i]; y--; }
                    else if (x - 1 >= 0 && field[x - 1, y] == number) { field[x - 1, y] = word[i]; x--; }
                    else flag = false;
                }
            }
        }

      

        public static void WriteChosen(string[] words)
        {
            foreach (string a in words)
                Console.WriteLine(a);
        }
        public static void WriteField()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                    Console.Write(char.ToString(field[i, j])+ " ");
                Console.WriteLine();
            }
        }
    }
}
