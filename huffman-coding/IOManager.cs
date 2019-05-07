using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.IO;
namespace Huffman.IOManager {
    public abstract class BaseFile {
        public BaseFile(string Path) {
            FilePath = Path;
            // Throw if FilePath is a folder
            if (IsFolder())
                throw new Exception("File is a folder!");
        }
        protected bool Exists()
        {
            return File.Exists(FilePath);
        }
        private bool IsFolder() {
            return (File.GetAttributes(FilePath) & FileAttributes.Directory) != FileAttributes.Directory;
        }
        protected bool IsReadable() {
            try {
                File.Open(FilePath, FileMode.Open, FileAccess.Read).Dispose();
                return true;
            }
            catch (IOException) {
                return false;
            }
        }
        protected bool IsWritable() {
            try {
                File.Open(FilePath, FileMode.Open, FileAccess.Write).Dispose();
                return true;
            }
            catch (IOException) {
                return false;
            }
        }
        protected string FilePath;
    }
    public class IFile : BaseFile {
        public IFile(string Path) : base(Path) {
            if (!IsReadable())
                throw new Exception("File is not readable!");
            if (!Exists())
                throw new Exception("File doesn't exist!");
            //while (!Reader.EndOfStream) {
            //    char TempChar = (char)Reader.Read();
            //    if (FreqList.ContainsKey(TempChar))
            //        ++FreqList[TempChar];
            //    else
            //        FreqList.Add(TempChar, 1);
        }
        }
    public class OFile : BaseFile {
        OFile(string Path) : base(Path) {
            if (!IsWritable())
                throw new Exception("File is not writable!");
            // If file doesn't exist create it and pass the stream to the StreamWriter
            if (!Exists())
                File.Open(FilePath, FileMode.Create, FileAccess.Write);
        }
    }
}