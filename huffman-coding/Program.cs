using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace Huffman {
    class HuffmanDictionary
    {
        HuffmanDictionary(string Path) {
            CreateFromFile();
        }
        public void CreateFromFile() {

        } 
        private Dictionary<char, BitArray> Storage;
    }
    class Program {
        static void Main(string[] args) {
            //Console.Clear();
            //Console.Write("Mode: ");
            //ConsoleKeyInfo mode = Console.ReadKey(true);
            //Tree tree;
            //if (mode.KeyChar == '1') {
            //    Console.Clear();
            //    List<KeyValuePair<char, int>> StaticData = new List<KeyValuePair<char, int>>();
            //    StaticData.Add(new KeyValuePair<char, int>('f', 60));
            //    StaticData.Add(new KeyValuePair<char, int>('x', 23));
            //    StaticData.Add(new KeyValuePair<char, int>('y', 11));
            //    StaticData.Add(new KeyValuePair<char, int>('d', 3));
            //    foreach (var i in StaticData)
            //    {
            //        Console.WriteLine("'{0}' - '{1}'", i.Key, i.Value);
            //    }
            //    tree = new Tree(StaticData);
            //}
            //else {
            //    Console.Clear();
            //    List<KeyValuePair<char, int>> RandomData = RandomHuffmanInput(10);
            //    tree = new Tree(RandomData);
            //}

            //while (true) {
            //    Console.WriteLine("Select where to go:\n1. Left\n2. Right\n3. Up\n4. Current\n5. Root");
            //    ConsoleKeyInfo key = Console.ReadKey(true);
            //    Console.Write("\n");
            //    switch (key.KeyChar) {
            //        case '1':
            //            tree.TraverseTree(Tree.TraverseDirection.TRAVERSE_LEFT);
            //            break;
            //        case '2':
            //            tree.TraverseTree(Tree.TraverseDirection.TRAVERSE_RIGHT);
            //            break;
            //        case '3':
            //            tree.TraverseTree(Tree.TraverseDirection.TRAVERSE_UP);
            //            break;
            //        case '4':
            //            tree.TraverseTree(Tree.TraverseDirection.TRAVERSE_CURRENT);
            //            break;
            //        case '5':
            //            tree.TraverseTree(Tree.TraverseDirection.TRAVERSE_ROOT);
            //            break;
            //    }
            //}
            IOManager.IFile testfile = new IOManager.IFile(@"C:\Users\Luth\source\repos\huffman-coding\test");
            testfile.DEBUGoutput();
        }
        [Obsolete("Debug")]
        static List<KeyValuePair<char, int>> RandomHuffmanInput(int Amount) {
            Random rng = new Random();
            char[] Chars = RandomCharacters(Amount);
            int[] Freqs = RandomNumbers(Amount);
            List<KeyValuePair<char, int>> list = new List<KeyValuePair<char, int>>();
            for (int i = 0; i < Amount; ++i)
            {
                Console.WriteLine("'{0}' - '{1}'", Chars[i], Freqs[i]);
                list.Add(new KeyValuePair<char, int>(Chars[i], Freqs[i]));
            }
            int sum = 0;
            foreach (var e in list)
            {
                sum += e.Value;
            }
            return list;
        }
        [Obsolete("Debug")]
        static char[] RandomCharacters(int Amount) {
            if (Amount > 122 - 97)
                throw new Exception("Amount higher than number of characters!");
            char[] Values = new char[100];
            Random RNG = new Random();
            for (int i = 0; i < Amount; ++i)
            {
                char tmp = (char)RNG.Next(97, 122);
                while (Values.Contains(tmp) == true)
                {
                    tmp = (char)RNG.Next(97, 122);
                }
                Values[i] = tmp;
            }
            return Values;
        }
        [Obsolete("Debug")]
        static int[] RandomNumbers(int Amount, int Min = 1, int Max = 100) {
            int[] Values = new int[100];
            Random RNG = new Random();
            for (int i = 0; i < Amount; ++i)
            {
                int tmp = RNG.Next(Min, Max);
                Values[i] = tmp;
            }
            return Values;
        }
    }
}