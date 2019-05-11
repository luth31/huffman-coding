using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace Huffman {
    class Program {
        static void Main(string[] args)
        {
            Dictionary<char, int> Data = new Dictionary<char, int>();
            Data.Add('f', 60);
            Data.Add('x', 23);
            Data.Add('y', 11);
            Data.Add('d', 3);
            //Data.Add('h', 5);
            //Data.Add('z', 63);
            //Data.Add('s', 69);
            Tree DTree = new Tree(Data);
            Tree.Traverser Hehe = new Tree.Traverser(DTree);
            Dictionary<char, string> d = Hehe.GetEncodingTable();
            foreach (var x in d)
            {
                Console.WriteLine("{0} - {1}", x.Key, x.Value);
            }
        }
    }
}