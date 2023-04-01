/*
    1. Install-Package CsvHelper 
 */
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.IO;

namespace Project2_Group4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"./Data/Project 2_INFO_5101.csv";
            CSVFile csvFile = new();
            PostfixConversion postConverter = new();
            PrefixConversion preConverter = new();
            
            // 1. 
            List<Infix> inFixList = csvFile.populateList(filePath);
           
            // 2. Convert Infix expressions stored in the InFix list to prefix expressions and save them in a generic list named PreFix
            List<string> postFixList = new List<string>(); // will contain postfix expressions
            List<string> preFixList = new List<string>(); // will contain postfix expressions
            foreach (Infix inFix in inFixList)
            {
                Console.WriteLine(inFix.expression + " ------ " + postConverter.Convert(inFix.expression) + "----" + preConverter.Convert(inFix.expression));
                postFixList.Add(postConverter.Convert(inFix.expression));
                preFixList.Add(preConverter.Convert(inFix.expression));
            }

        }
        
    }
}