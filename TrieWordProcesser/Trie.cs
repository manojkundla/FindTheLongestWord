using System;

namespace TrieWordProcesser
{
    public class Trie
    {
        private TrieNode root = new TrieNode();
        public TrieNode Insert(string s)
        {
            char[] charArray = s.ToLower().ToCharArray();
            TrieNode node = root;
            foreach (char c in charArray)
            {
                node = Insert(c, node);
            }
            node.EndOfWord = true;
            return root;
        }
        private TrieNode Insert(char c, TrieNode node)
        {
            if (node.Contains(c)) return node.GetChild(c);
            else
            {
                int n = Convert.ToByte(c) - TrieNode.ASCIIA;
                TrieNode t = new TrieNode();
                node.nodes[n] = t;
                return t;
            }
        }
        public bool Contains(string s)
        {
            char[] charArray = s.ToLower().ToCharArray();
            TrieNode node = root;
            bool contains = true;
            foreach (char c in charArray)
            {
                node = Contains(c, node);
                if (node == null)
                {
                    contains = false;
                    break;
                }
            }
            if ((node == null) || (!node.EndOfWord))
                contains = false;
            return contains;
        }
        private TrieNode Contains(char c, TrieNode node)
        {
            if (node.Contains(c))
            {
                return node.GetChild(c);
            }
            else
            {
                return null;
            }
        }
    }
}
