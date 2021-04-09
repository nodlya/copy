using System;

namespace FieldGeneration
{
    class Program
    {
        public static string path = @"..\\..\\..\\original.txt";
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            FieldWork.IfDirectoryExists();
            FieldWork.SplitIntoStrings();
            //FieldWork.WriteChosen();
           // FieldWork.GenerateField();
            FieldWork.WriteField();
        }
    }
}
