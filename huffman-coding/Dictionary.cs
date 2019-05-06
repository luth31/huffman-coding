using System;
using System.Collections.Generic;
using System.Collections;

namespace Huffman
{
    // A dictionary that stores a character and it's encoding in a binary format
    class BinaryDictionary {
        BinaryDictionary(char Character, BitArray Encoding) {
            if (_Dictionary.ContainsKey(Character))
                throw new Exception("Character already exists!");
            _Dictionary.Add(Character, Encoding);
        }
        Dictionary<char, BitArray> _Dictionary;

    }
}
