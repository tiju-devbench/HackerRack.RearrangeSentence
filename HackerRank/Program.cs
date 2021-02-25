using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace HackerRank
{
    class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string sentence = Console.ReadLine();
            string result = Result.arrange(sentence);
            textWriter.WriteLine(result);
            textWriter.Flush();
            textWriter.Close();
        }
    }
    class Result
    {
        public static string arrange(string sentence)
        {
            //StringBuilder result = new StringBuilder();
            var sentenceFiltered = RemoveSpecialCharacters(sentence);
            var words = sentenceFiltered.Split(' ');

            var split = words
                .GroupBy(l => l.Length).OrderBy(w => w.Key)
                .Select(x=> String.Join(" ", x)).ToArray();

            string result = String.Join(" ", split).ToLower();
            result = result[0].ToString().ToUpper() + result.Substring(1, result.Length-1) + ".";
            return result;
        }        
            public static string RemoveSpecialCharacters(string str)
            {
                return Regex.Replace(str, "[^a-zA-Z0-9_ ]+", "", RegexOptions.Compiled);
            }
    }
}
