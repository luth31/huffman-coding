using System.Collections.Generic;
using System.Linq;

namespace Huffman
{
    // Specialized priority queue used to store Huffman Nodes
    class PriorityQueue
    {
        // Create a new priority queue based on a predefined list of key value pairs of chars and ints
        public PriorityQueue(Dictionary<char, int> Data)
        {
            Storage = new List<Node>();
            for (int i = 0; i < Data.Count; ++i)
            {
                // Save index of the element with lowest frequency in the initial dataset
                if (Data.ElementAt(NextIndex).Value > Data.ElementAt(i).Value)
                    NextIndex = i;
                // Create and add the HuffmanTreeNode created from the current data iteration
                Node NewNode = new Node(Data.ElementAt(i).Key, Data.ElementAt(i).Value);
                Storage.Add(NewNode);
            }
        }
        // Internal function used to update NextIndex with the index of the node that has the lowest Value
        private void FindNextIndex()
        {
            NextIndex = 0;
            for (int i = 0; i < Storage.Count; ++i)
                if (Storage.ElementAt(NextIndex).Value > Storage.ElementAt(i).Value)
                    NextIndex = i;
        }
        // Internal function used to add new elements to the internal nodes list
        private void Add(Node Node)
        {
            if (Storage.Count != 0)
            {
                if (Storage.ElementAt(NextIndex).Value > Node.Value)
                    NextIndex = Storage.Count;
            }
            Storage.Add(Node);
        }
        // Create a new node from the KeyValuePair and pass it to Add()
        public void Enqueue(KeyValuePair<char, int> Element)
        {
            Node NewNode = new Node(Element.Key, Element.Value);
            Add(NewNode);
        }
        public void Enqueue(Node Node)
        {
            Add(Node);
        }
        //  Make a copy of the next element, remove it, call FindNextIndex() and return the copy
        public Node Dequeue()
        {
            var Next = Storage.ElementAt(NextIndex);
            Storage.RemoveAt(NextIndex);
            FindNextIndex();
            return Next;
        }
        // Returns true if the internal list Storage has no elements
        public bool IsEmpty()
        {
            return Storage.Count == 0;
        }
        // Getter for Storage's count
        public int Count
        {
            get
            {
                return Storage.Count;
            }
        }
        private int NextIndex = 0; // The index of the next element in the priority queue
        private List<Node> Storage; // Internal list used to store elements in the queue
    }
}
