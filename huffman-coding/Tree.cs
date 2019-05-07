using System;
using System.Collections.Generic;
using System.Text;

namespace Huffman
{
    // Specialized tree for Huffman coding
    public class Tree
    {
        // Create a tree from a dictionary containing the chars and their frequencies
        public Tree(Dictionary<char, int> Dataset)
        {
            // Initialize the list of the visited nodes
            Visited = new List<Node>();
            // Create a new priority queue to help us build the tree
            PriorityQueue Queue = new PriorityQueue(Dataset);
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
            // Assign the last element  of the queue and Position with Root
            Root = Queue.Dequeue();
            Position = Root;
        }
        // Create a new node with the two nodes as children and return it
        Node Merge(Node FirstNode, Node SecondNode)
        {
            return new Node(this, FirstNode, SecondNode);
        }
        public enum TraverseDirection
        {
            TRAVERSE_LEFT,
            TRAVERSE_RIGHT,
            TRAVERSE_UP,
            TRAVERSE_ROOT
        }
        // Move the Position pointer toward the given TraverseDirection
        public void Move(TraverseDirection Direction) {
            switch (Direction) {
                case TraverseDirection.TRAVERSE_LEFT:
                    Position = Position.Left;
                    break;
                case TraverseDirection.TRAVERSE_RIGHT:
                    Position = Position.Right;
                    break;
                case TraverseDirection.TRAVERSE_UP:
                    Position = Position.Parent;
                    break;
                case TraverseDirection.TRAVERSE_ROOT:
                    Position = Root;
                    break;
            }

        }
        // Getter for current node given by Position
        public Node CurrentNode
        {
            get
            {
                return Position;
            }
        }
        public void Visit(Node Node) {
            Visited.Add(Node);
        }
        public bool IsVisited(Node Node) {
            if (Visited.Contains(Node))
                return true;
            return false;
        }
        private Node Root;
        private Node Position = null;
        private List<Node> Visited;
    }
}
