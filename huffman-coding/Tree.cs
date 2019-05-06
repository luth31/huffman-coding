using System;
using System.Collections.Generic;
using System.Text;

namespace Huffman
{
    // Specialized tree for Huffman coding
    class Tree
    {
        // Create a tree from a list of KeyValuePairs of chars and ints
        public Tree(List<KeyValuePair<char, int>> IV)
        {
            // Create a new priority queue to help us build the tree
            PriorityQueue Queue = new PriorityQueue(IV);
            // Repeat until one node is left in the queue
            while (Queue.Count != 1)
            {
                // Get the first two elements from the queue
                Node FirstNode = Queue.Dequeue();
                Node SecondNode = Queue.Dequeue();
                // Merge the two nodes together
                Node NewNode = Merge(FirstNode, SecondNode);
                Queue.Enqueue(NewNode);
            }
            // "Initialize" Root with the last element of the queue and Position with Root
            Root = Queue.Dequeue();
            Position = Root;
        }
        // Create a new node with the two nodes as children and return it
        Node Merge(Node FirstNode, Node SecondNode)
        {
            return new Node(FirstNode, SecondNode);
        }
        public enum TraverseDirection
        {
            TRAVERSE_LEFT,
            TRAVERSE_RIGHT,
            TRAVERSE_UP,
            TRAVERSE_CURRENT,
            TRAVERSE_ROOT
        }
        public NodeInfo TraverseTree(TraverseDirection Direction)
        {
            switch (Direction)
            {
                case TraverseDirection.TRAVERSE_LEFT:
                    Position = Position.LeftNode;
                    break;
                case TraverseDirection.TRAVERSE_RIGHT:
                    Position = Position.RightNode;
                    break;
                case TraverseDirection.TRAVERSE_UP:
                    Position = Position.ParentNode;
                    break;
                case TraverseDirection.TRAVERSE_ROOT:
                    Position = Root;
                    break;
                default:
                    break;
            }
            if (Position == null)
            {
                ConsoleColor TempColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Null node! Repositioning to Root...\n");
                Console.ForegroundColor = TempColor;
                Position = Root;
            }
            return new NodeInfo(Position);
        }
        public class NodeInfo
        {
            public NodeInfo(Node Node)
            {
                NodeRef = Node;
                DisplayInfo();
            }
            void DisplayInfo()
            {
                if (NodeRef == null)
                {
                    Console.WriteLine("NULL");
                    return;
                }
                ConsoleColor tmp = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Value ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(Value);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\nChar ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(Character + "\n\n");
                Console.ForegroundColor = tmp;
            }
            Node NodeRef = null;
            int Value
            {
                get
                {
                    return NodeRef.Value;
                }
            }
            char Character
            {
                get
                {
                    return NodeRef.Character;
                }
            }
        }
        private Node Root;
        private Node Position = null;
    }
}
