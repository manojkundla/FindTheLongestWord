using System;

namespace TrieWordProcesser
{
    public class TrieNode
    {
        public TrieNode[] nodes;
        public bool EndOfWord = false;
        public const int ASCIIA = 97;
        public TrieNode()
        {
            nodes = new TrieNode[26];
        }
        public bool Contains(char c)
        {
            int n = Convert.ToByte(c) - ASCIIA;
            if (n < 26)
                return (nodes[n] != null);
            else
                return false;
        }
        public TrieNode GetChild(char c)
        {
            int n = Convert.ToByte(c) - ASCIIA;
            return nodes[n];
        }
    }
}
