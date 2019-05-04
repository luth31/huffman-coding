using System;
using System.Collections.Generic;
using System.Linq;

namespace Huffman {
    // Specialized priority queue used to store HuffmanTreeNodes
    class HuffmanPriorityQueue {
        // Create a new priority queue based on a predefined list of key value pairs of chars and ints
        public HuffmanPriorityQueue(List<KeyValuePair<char, int>> Data) {
            Storage = new List<HuffmanTreeNode>();
            for (int i = 0; i < Data.Count; ++i) {
                // Save index of the element with lowest frequency in the initial dataset
                if (Data.ElementAt(NextIndex).Value > Data.ElementAt(i).Value)
                    NextIndex = i;
                // Create and add the HuffmanTreeNode created from the current data iteration
                HuffmanTreeNode NewNode = new HuffmanTreeNode(Data.ElementAt(i).Key, Data.ElementAt(i).Value);
                Storage.Add(NewNode);
            }
        }
        // Internal function used to update NextIndex with the node that has the lowest Value
        private void FindNextIndex() {
            NextIndex = 0;
            for (int i = 0; i < Storage.Count; ++i)
                if (Storage.ElementAt(NextIndex).Value > Storage.ElementAt(i).Value)
                    NextIndex = i;
        }
        public void Enqueue(KeyValuePair<char, int> Element) {
            // Check if the data being Enqueued has a lower frequency and if true, update NextIndex
            if (Storage.ElementAt(NextIndex).Value > Element.Value)
                // Next element added to the storage will have index = Count due to List index being zero-based
                NextIndex = Storage.Count;
            HuffmanTreeNode NewNode = new HuffmanTreeNode(Element.Key, Element.Value);
            Storage.Add(NewNode);
        }
        public void Enqueue(HuffmanTreeNode Node) {
            Storage.Add(Node);
        }
        public HuffmanTreeNode Dequeue() {
            var Next = Storage.ElementAt(NextIndex);
            Storage.RemoveAt(NextIndex);
            FindNextIndex();
            return Next;
        }
        public bool IsEmpty() {
            return Storage.Count == 0;
        }
        public int Count {
            get {
                return Storage.Count;
            }
        }
        private int NextIndex = 0;
        private List<HuffmanTreeNode> Storage;
    }
    class HuffmanTreeNode
    {
        public enum NodeType {
            TYPE_LEAF,
            TYPE_PATH
        }
        public HuffmanTreeNode(char c, int frequency) {
            Type = NodeType.TYPE_LEAF;
            Character = c;
            Value = frequency;
        }
        public HuffmanTreeNode(HuffmanTreeNode Node1, HuffmanTreeNode Node2) {
            Type = NodeType.TYPE_PATH;
            Value = Node1.Value + Node2.Value;
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
            Node1.ParentNode = this;
            Node2.ParentNode = this;
        }
        public NodeType Type { get; private set; }
        public char Character { get; private set; }
        public int Value { get; private set; }
        public HuffmanTreeNode LeftNode { get; private set; } = null;
        public HuffmanTreeNode RightNode { get; private set; } = null;
        public HuffmanTreeNode ParentNode { get; private set; } = null;
    }
    class HuffmanTree {
        public HuffmanTree(List<KeyValuePair<char, int>> IV) {
            HuffmanPriorityQueue Queue = new HuffmanPriorityQueue(IV);
            while (Queue.Count != 1) {
                HuffmanTreeNode FirstNode = Queue.Dequeue();
                HuffmanTreeNode SecondNode = Queue.Dequeue();
                HuffmanTreeNode NewNode = Merge(FirstNode, SecondNode);
                Queue.Enqueue(NewNode);
            }
            Root = Queue.Dequeue();
            Position = Root;
        }
        HuffmanTreeNode Merge(HuffmanTreeNode FirstNode, HuffmanTreeNode SecondNode) {
            return new HuffmanTreeNode(FirstNode, SecondNode);
        }
        public enum TraverseDirection {
            TRAVERSE_LEFT,
            TRAVERSE_RIGHT,
            TRAVERSE_UP,
            TRAVERSE_CURRENT,
            TRAVERSE_ROOT
        }
        public NodeInfo TraverseTree(TraverseDirection Direction) {
            switch (Direction) {
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
            if (Position == null) {
                ConsoleColor TempColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Null node! Repositioning to Root...\n");
                Console.ForegroundColor = TempColor;
                Position = Root;
            }
            return new NodeInfo(Position);
        }
        public class NodeInfo  {
            public NodeInfo(HuffmanTreeNode Node) {
                NodeRef = Node;
                DisplayInfo();
            }
            void DisplayInfo() {
                if (NodeRef == null) {
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
                //Console.WriteLine("Value: {0}\nCharacter: {1}\n", Value, Character);
            }
            HuffmanTreeNode NodeRef = null;
            int Value {
                get {
                    return NodeRef.Value;
                }
            }
            char Character {
                get {
                    return NodeRef.Character;
                }
            }
        }
        private HuffmanTreeNode Root;
        private HuffmanTreeNode Position = null;
    }
    class Program {
        static void Main(string[] args) {
            Console.Clear();
            Console.Write("Mode: ");
            ConsoleKeyInfo mode = Console.ReadKey(true);
            HuffmanTree tree;
            if (mode.KeyChar == '1') {
                Console.Clear();
                List<KeyValuePair<char, int>> StaticData = new List<KeyValuePair<char, int>>();
                StaticData.Add(new KeyValuePair<char, int>('f', 60));
                StaticData.Add(new KeyValuePair<char, int>('x', 23));
                StaticData.Add(new KeyValuePair<char, int>('y', 11));
                StaticData.Add(new KeyValuePair<char, int>('d', 3));
                foreach (var i in StaticData)
                {
                    Console.WriteLine("'{0}' - '{1}'", i.Key, i.Value);
                }
                tree = new HuffmanTree(StaticData);
            }
            else {
                Console.Clear();
                List<KeyValuePair<char, int>> RandomData = RandomHuffmanInput(10);
                tree = new HuffmanTree(RandomData);
            }

            while (true) {
                Console.WriteLine("Select where to go:\n1. Left\n2. Right\n3. Up\n4. Current\n5. Root");
                ConsoleKeyInfo key = Console.ReadKey(true);
                Console.Write("\n");
                switch (key.KeyChar) {
                    case '1':
                        tree.TraverseTree(HuffmanTree.TraverseDirection.TRAVERSE_LEFT);
                        break;
                    case '2':
                        tree.TraverseTree(HuffmanTree.TraverseDirection.TRAVERSE_RIGHT);
                        break;
                    case '3':
                        tree.TraverseTree(HuffmanTree.TraverseDirection.TRAVERSE_UP);
                        break;
                    case '4':
                        tree.TraverseTree(HuffmanTree.TraverseDirection.TRAVERSE_CURRENT);
                        break;
                    case '5':
                        tree.TraverseTree(HuffmanTree.TraverseDirection.TRAVERSE_ROOT);
                        break;
                }
            }
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