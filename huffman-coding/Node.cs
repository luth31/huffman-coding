using System;
using System.Collections.Generic;
using System.Text;

namespace Huffman
{
    // Specialized Node for Huffman Tree
    public class Node
    {
        // Create a new HuffmanTreeNode from a character and a frequency
        public Node(Tree Owner, char Char, int Freq)
        {
            Character = Char;
            Value = Freq;
            Tree = Owner;
        }
        // Create a new HuffmanTreeNode from two nodes
        public Node(Tree Owner, Node FirstNode, Node SecondNode)
        {
            Tree = Owner;
            Value = FirstNode.Value + SecondNode.Value;
            // Make sure that the Left node is the node with a higher frequency
            if (FirstNode.Value > SecondNode.Value)
            {
                Left = FirstNode;
                Right = SecondNode;
            }
            else
            {
                Left = SecondNode;
                Right = FirstNode;
            }
            // Make this node the parent of the two nodes
            FirstNode.Parent = this;
            SecondNode.Parent = this;
        }
        public bool IsVisited() {
            return Tree.IsVisited(this);
        }
        public char Character { get; private set; }
        public int Value { get; private set; }
        public Node Left { get; private set; } = null;
        public Node Right { get; private set; } = null;
        public Node Parent { get; private set; } = null;
        private Tree Tree;
    }
}
