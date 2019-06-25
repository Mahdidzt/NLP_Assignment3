using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP_Assingmnet3_cs
{
    internal class Program
    {
        public static string EditDistance_en = @"D:\Doros\term 8\NLP\Assignment\NLP_Assingmnet3_cs\NLP_Assingmnet3_cs\app_data\EditDistance.en";
        public static string EditDistance_fa = @"D:\Doros\term 8\NLP\Assignment\NLP_Assingmnet3_cs\NLP_Assingmnet3_cs\app_data\EditDistance.fa";
        public static string tokens_en = @"D:\Doros\term 8\NLP\Assignment\NLP_Assingmnet3_cs\NLP_Assingmnet3_cs\app_data\tokens.en";
        public static string incorrect_en = @"D:\Doros\term 8\NLP\Assignment\NLP_Assingmnet3_cs\NLP_Assingmnet3_cs\app_data\incorrect.en";
        public static string output_en = @"D:\Doros\term 8\NLP\Assignment\NLP_Assingmnet3_cs\NLP_Assingmnet3_cs\output\94463125_Assignment3_Part1_EN.txt";
        public static string output_fa = @"D:\Doros\term 8\NLP\Assignment\NLP_Assingmnet3_cs\NLP_Assingmnet3_cs\output\94463125_Assignment3_Part1_FA.txt";

        private static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string[] lines = File.ReadAllLines(EditDistance_fa);
            string[] tokens = File.ReadAllLines(tokens_en);
            string[] incorrect = File.ReadAllLines(incorrect_en);
            //List<int> editDisArr = new List<int>();
            //foreach (string token in tokens)
            //{
            //    foreach (string incorrectWord in incorrect)
            //    {
            //        editDisArr.Add(Compute(token, incorrectWord));
            //    }
            //}
            //int cnt = 0;
            //while (cnt < 10)
            //{
            //}

            //editdistance

            foreach (string a in lines)
            {
                String[] word = a.Split(null);
                int cost = Compute(word[0], word[1]);
                System.IO.File.AppendAllText(output_fa, word[0] + "   " + word[1] + " -> " + cost + Environment.NewLine);
                //    Console.WriteLine("{0} -> {1} = {2}",
                //        word[0],
                //        word[1],
                //        cost);
            }

            Console.ReadLine();
        }

        public static int Compute(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }

            return d[n, m];
        }
    }
}