using System;
using System.Collections.Generic;
using System.IO;

namespace WordRiddle
{
    internal class Program
    {
        private static readonly string[] Words;

        static Program()
        {
            Words = WordList();
        }

        static void Main(string[] args)
        {
            int wordCount = 200;
            for (int i = 0; i < wordCount; i++)
            {
                string randomWord = GetRandomWord();
                string matchingWord = FindMatchingWord(randomWord);
                Console.WriteLine(randomWord + " - " + matchingWord);
            }
        }



        private static string FindMatchingWord(string word)
        {
            int substringLength = 3;
            string wordSubstring = word.Substring(word.Length - substringLength);

            while (substringLength < 5)
            {
                foreach (string ord in Words)
                {
                    string ordSub = ord.Substring(0, substringLength);
                    if (ordSub == wordSubstring)
                    {
                        return ord;
                    }
                }
                substringLength++;
            }
            return "Couldn't find matching word.";
        }

        private static string GetRandomWord()
        {
            Random rand = new Random();
            return Words[rand.Next(Words.Length)];
        }

        private static string[] WordList()
        {
            string[] ordliste = File.ReadAllLines("ordliste.txt");
            string previousWord = null;
            List<string> words = new List<string>();
            foreach (string ord in ordliste)
            {
                string word = ord.Split("\t")[1];
                if (word != previousWord && word.Length > 7 && !word.Contains("-"))
                {
                    words.Add(word);
                    previousWord = word;
                }
            }
            return words.ToArray();
        }
    }
}
