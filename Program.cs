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

        private static int editDistDP(String str1, String str2, int m, int n)
        {
            // Create a table to store
            // results of subproblems
            int[,] dp = new int[m + 1, n + 1];

            // Fill d[][] in bottom up manner
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    // If first string is empty, only option is to
                    // insert all characters of second string
                    if (i == 0)

                        // Min. operations = j
                        dp[i, j] = j;

                    // If second string is empty, only option is to
                    // remove all characters of second string
                    else if (j == 0)

                        // Min. operations = i
                        dp[i, j] = i;

                    // If last characters are same, ignore last char
                    // and recur for remaining string
                    else if (str1[i - 1] == str2[j - 1])
                        dp[i, j] = dp[i - 1, j - 1];
                    else
                        dp[i, j] = 1 + min(dp[i, j - 1],
                                        dp[i - 1, j],
                                        dp[i - 1, j - 1]);
                }
            }

            return dp[m, n];
        }

        private static int min(int x, int y, int z)
        {
            if (x <= y && x <= z) return x;
            if (y <= x && y <= z) return y;
            else return z;
        }
    }
}