/*
    1. Install-Package CsvHelper 
 */
using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Project2_Group4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"Project 2_INFO_5101.csv";
            CSVFile csvFile = new();
            PostfixConversion postConverter = new();
            PrefixConversion preConverter = new();
            CompareExpressions comparer = new();

            // 1. 
            List<Infix> inFixList = csvFile.populateList(filePath);

            // 2. Convert Infix expressions stored in the InFix list to prefix expressions and save them in a generic list named PreFix
            List<string> postFixList = new List<string>(); // will contain postfix expressions
            List<string> preFixList = new List<string>(); // will contain prefix expressions
            string postfix;
            string prefix;
            double prefixRes;
            double postfixRes;

            Console.WriteLine("==========================================================================================================");
            Console.WriteLine("|  Sno|                 InFix|               PostFix|               PreFix| PreFix Res| PostFixRes| Match|");
            Console.WriteLine("==========================================================================================================");

            for (int i = 0; i < inFixList.Count; i++)
            {
                postfix = postConverter.Convert(inFixList[i].expression);
                prefix = preConverter.Convert(inFixList[i].expression);
                postfixRes = ExpressionEvaluation.evaluatePostfix(postfix);
                prefixRes = ExpressionEvaluation.evaluatePrefix(prefix);
                postFixList.Add(postfix);
                preFixList.Add(prefix);
                Console.WriteLine($"| {i+1,4}| {inFixList[i].expression,21}| {postfix, 21}| {prefix, 20}| {postfixRes, 10}| {prefixRes,10}| {(comparer.Compare(postfixRes, prefixRes) == 0 ? "True" : "False"), 5}|");
            }
            Console.WriteLine("==========================================================================================================");

            using (StreamWriter writer = new StreamWriter("ExpressionEvaluationSummary.xml"))
            {
                writer.WriteRootStart();

                for (int i = 0; i < inFixList.Count; i++)
                {
                    postfix = postFixList[i];
                    prefix = preFixList[i];
                    postfixRes = ExpressionEvaluation.evaluatePostfix(postfix);
                    prefixRes = ExpressionEvaluation.evaluatePrefix(prefix);

                    writer.WriteElementsStart();
                    writer.WriteElement("sno", (i + 1).ToString());
                    writer.WriteElement("infix", inFixList[i].expression);
                    writer.WriteElement("prefix", prefix);
                    writer.WriteElement("postfix", postfix);
                    writer.WriteElement("evaluation", postfixRes.ToString());
                    writer.WriteElement("comparison", (comparer.Compare(postfixRes, prefixRes) == 0 ? "true" : "false"));
                    writer.WriteElementsEnd();
                }

                writer.WriteRootEnd();
            }

        }
    }
}
