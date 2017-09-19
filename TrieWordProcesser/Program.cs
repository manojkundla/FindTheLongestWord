using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace TrieWordProcesser
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\wordlist.txt");
            Trie trie = new Trie();
            List<Word> words = ReadFile(path);
            Console.WriteLine("Number of words to process: {0}", words.Count);
            foreach(Word word in words)
            {
                trie.Insert(word.Name);
            }
            foreach (Word word in words)
            {
                word.Search(trie);
                Console.Write("\r{0}                        ", word.Name);
            }
            Console.WriteLine("\r              ");
            List<Word> completewords = words.Where(x => x.IsComplete()).ToList();           
            List<Word> topTwenty = completewords
                .OrderByDescending(x => x.NumberOfSubWords)
                .ThenByDescending(x => x.Name.Length)
                .Take(20)
                .ToList();
            Console.WriteLine("First longest word: {0} = {1}", topTwenty[0].Name, string.Join(",", topTwenty[0].SubWords()));
            Console.WriteLine("\r              ");
            Console.WriteLine("Second longest word: {0} = {1}", topTwenty[1].Name, string.Join(",", topTwenty[1].SubWords()));
            Console.WriteLine("\r              ");
            Console.WriteLine("Total number of words constructed of other words: {0}", completewords.Count);
            Console.WriteLine("\r              ");
            Console.WriteLine("Top 20 longest words:");
            Console.WriteLine("\r              ");
            foreach (Word w in topTwenty)
            {
                Console.WriteLine(string.Format("{0} = {1}", w.Name, string.Join(",", w.SubWords())));
            }
            Console.ReadKey();
        }

        private static List<Word> ReadFile(string filePath)
        {
            List<Word> words = new List<Word>();
            string[] lines = File.ReadAllLines(filePath);
            foreach (string word in lines.OrderBy(w => w).ToList())
            {
                if (!string.IsNullOrEmpty(word))
                {
                    words.Add(new Word(word));
                }
            }
            return words;
        }
    }
}
