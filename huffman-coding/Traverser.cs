using System;
using System.Collections.Generic;
using System.Text;

namespace Huffman
{
    public partial class Tree
    {
        public class Traverser
        {
            public Traverser(Tree Subject)
            {
                Tree = Subject;
                Visited = new List<Node>();
                EncodeTable = new Dictionary<char, string>();
                Position = Tree.Root;
            }
            public Dictionary<char, string> GetEncodingTable()
            {
                List<string> Path = new List<string>();
                while (true)
                {
                    if (IsVisited(Position.Left) && IsVisited(Position.Right) && Position.Parent == null)
                        break;
                    if (Position.Left == null && Position.Right == null)
                    {
                        EncodeTable.Add(Position.Character, string.Concat(Path));
                        Move(TraverseDirection.TRAVERSE_UP);
                        continue;
                    }
                    if (!IsVisited(Position.Left))
                    {
                        Path.Add("0");
                        Move(TraverseDirection.TRAVERSE_LEFT);
                    }
                    else if (!IsVisited(Position.Right))
                    {
                        Path.Add("1");
                        Move(TraverseDirection.TRAVERSE_RIGHT);
                    }
                    else
                    {
                        Path.RemoveAt(Path.Count - 1);
                        Move(TraverseDirection.TRAVERSE_UP);
                    }
                }
                return EncodeTable;
            }
            public void Move(TraverseDirection Direction)
            {
                switch (Direction)
                {
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
                        Position = Tree.Root;
                        break;
                }
                if (!Visited.Contains(Position))
                    Visit(Position);
            }
            public void Visit(Node Node)
            {
                Visited.Add(Node);
            }
            public bool IsVisited(Node Node)
            {
                if (Visited.Contains(Node))
                    return true;
                return false;
            }
            Dictionary<char, string> EncodeTable;
            private Tree Tree;
            private Node Position = null;
            private List<Node> Visited;
        }
    }
}
