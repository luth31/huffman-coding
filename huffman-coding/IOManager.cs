using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;
namespace Huffman
{
    static class IOManager {
        public class IFile {
            public IFile(string Path) {
                FilePath = Path;
                CharList = new Dictionary<char, int>();
                // We don't deal with folders or inexistent files here
                if (!File.Exists(FilePath) || ((File.GetAttributes(FilePath) & FileAttributes.Directory) == FileAttributes.Directory))
                    throw new Exception("File doesn't exist or is a folder!");
                Reader = new StreamReader(FilePath);
                while (!Reader.EndOfStream)
                {
                    char TempChar = (char)Reader.Read();
                    if (CharList.ContainsKey(TempChar))
                        ++CharList[TempChar];
                    else
                        CharList.Add(TempChar, 1);
                }
            }
            public void DEBUGoutput()
            {
                foreach (var x in CharList)
                {
                    switch (x.Key)
                    {
                        case ' ':
                            Console.Write("space");
                            break;
                        case '\n':
                            Console.Write("\\n");
                            break;
                        case '\r':
                            Console.Write("\\r");
                            break;
                        case '\t':
                            Console.Write("\\t");
                            break;
                        default:
                            Console.Write("{0}", x.Key);
                            break;
                    }
                    Console.Write("\t{0}\n", x.Value);
                }
            }
            private string FilePath;
            private Dictionary<char, int> CharList;
            private int FileSize; // Size in bytes
            private StreamReader Reader = null;
            private BinaryWriter Writer = null;
        }
        
    }
}
