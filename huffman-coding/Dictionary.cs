using System;
using System.Collections.Generic;
using System.Collections;

namespace Huffman
{
    // A dictionary that stores a character and it's encoding in a binary format
    //class BinaryDictionary {
    //    BinaryDictionary(char Character, BitArray Encoding) {
    //        if (_Dictionary.ContainsKey(Character))
    //            throw new Exception("Character already exists!");
    //        _Dictionary.Add(Character, Encoding);
    //    }
    //    public static void BuildFrom(Tree Tree)
    //    {

    //        List<char> wannabeStack = new List<char>();
    //        Tree.Move(Tree.TraverseDirection.TRAVERSE_ROOT);
    //        while (true)
    //        {
    //            if (Tree.CurrentNode == null)
    //                throw new Exception("This shouldn't happen");
    //            // End the loop if there's no parent node and both left and right nodes have been visited
    //            if (Tree.CurrentNode.Left == null && Tree.CurrentNode.Right == null)
    //            {
    //                Console.Write("\n{0} coded: ", Tree.CurrentNode.Character);
    //                foreach (var b in wannabeStack)
    //                    Console.Write(b);
    //                Tree.Move(Tree.TraverseDirection.TRAVERSE_UP);
    //                wannabeStack.RemoveAt(wannabeStack.Count - 1);
    //                continue;
    //            }
    //            if (Tree.CurrentNode.Parent == null &&
    //                Tree.CurrentNode.Left.IsVisited() &&
    //                Tree.CurrentNode.Right.IsVisited())
    //                break;
    //            if (Tree.CurrentNode.Left != null) {
    //                if (!Tree.CurrentNode.Left.IsVisited()) {
    //                    wannabeStack.Add('0');
    //                    Tree.Move(Tree.TraverseDirection.TRAVERSE_LEFT);
    //                    continue;
    //                }
    //            }
    //            if (Tree.CurrentNode.Right != null) {
    //                if (!Tree.CurrentNode.Right.IsVisited()) {
    //                    wannabeStack.Add('1');
    //                    Tree.Move(Tree.TraverseDirection.TRAVERSE_RIGHT);
    //                    continue;
    //                }
    //            }
    //        }
    //    }
    //    Dictionary<char, BitArray> _Dictionary;
    //}
}
