using System;
using System.Collections.Generic;
using System.Text;

namespace Huffman
{
    // Specialized Node for Huffman Tree
    class Node
    {
        // Create a new HuffmanTreeNode from a character and a frequency
        public Node(char c, int frequency)
        {
            Character = c;
            Value = frequency;
        }
        // Create a new HuffmanTreeNode from two nodes
        public Node(Node Node1, Node Node2)
        {
            Value = Node1.Value + Node2.Value;
            // Make sure that the Left node is the node with a higher frequency
            if (Node1.Value > Node2.Value)
            {
                LeftNode = Node1;
                RightNode = Node2;
            }
            else
            {
                LeftNode = Node2;
                RightNode = Node1;
            }
            // Make this node the parent of the two nodes
            Node1.ParentNode = this;
            Node2.ParentNode = this;
        }
        public char Character { get; private set; }
        public int Value { get; private set; }
        public Node LeftNode { get; private set; } = null;
        public Node RightNode { get; private set; } = null;
        public Node ParentNode { get; private set; } = null;
    }
}
