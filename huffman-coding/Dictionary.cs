using System;
using System.Collections.Generic;
using System.Collections;

namespace Huffman
{
    // A dictionary that stores a character and it's encoding in a binary format
    class BinaryDictionary {
        BinaryDictionary(char Character, BitArray Encoding) {
            if (_Dictionary.ContainsKey(Character))
                throw new Exception("Character already exists!");
            _Dictionary.Add(Character, Encoding);
        }
        public void BuildFrom(Tree Tree)
        {
            List<char> wannabeStack = new List<char>();
            Tree.Move(Tree.TraverseDirection.TRAVERSE_ROOT);
            while (true)
            {
                // End the loop if there's no parent node and both left and right nodes have been visited
                if (Tree.CurrentNode.Parent == null &&
                    Tree.CurrentNode.Left.IsVisited() &&
                    Tree.CurrentNode.Right.IsVisited())
                    break;
                if (Tree.CurrentNode.Left != null) {
                    if (!Tree.CurrentNode.Left.IsVisited()) {
                        wannabeStack.Add('0');
                        Tree.Move(Tree.TraverseDirection.TRAVERSE_LEFT);
                        continue;
                    }
                }
                if (Tree.CurrentNode.Right != null) {
                    if (!Tree.CurrentNode.Right.IsVisited()) {
                        wannabeStack.Add('1');
                        Tree.Move(Tree.TraverseDirection.TRAVERSE_RIGHT);
                        continue;
                    }
                }
                if (Tree.CurrentNode.Character != '\0')
                {
                    Console.WriteLine("{0} = ", Tree.CurrentNode.Character);

                }
            }
        }
        Dictionary<char, BitArray> _Dictionary;
    }
}
