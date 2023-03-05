﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MILSTD1553ClassLibrary
{
    public class CommandWord
    {
        // private string[] commandWordFields = new string[4]; // index 0 : remote terminal address
                                                            // index 1 : transmit/receive bit
                                                            // index 2 : subaddress
                                                            // index 3 : word count
        private int terminalAddress;
        private int trBit; //RT-BC = 1 or T //BC-RT = 0 or R
        private int subAddress;
        private int wordCount;
        private int commandWordInt;

        public int TerminalAddress { get => terminalAddress; }
        public int TrBit { get => trBit; }
        public int SubAddress { get => subAddress; }
        public int WordCount { get => wordCount; }
        public int CommandWordInt { get => commandWordInt; }

        public CommandWord (string terminalAddress, string trBit, string subAddress, string wordCount, int numBase)
        {
            this.terminalAddress = stringToInt(terminalAddress, numBase);
            this.trBit = stringToInt(trBit, numBase);
            this.subAddress = stringToInt(subAddress, numBase);
            this.wordCount = stringToInt(wordCount, numBase);
            commandWordInt = (this.terminalAddress << 11) + (this.trBit << 10) + (this.subAddress << 5) + (this.wordCount);
        }

        

        public int stringToInt(string data, int numBase)
        {
            if (data == "T")
            {
                return 1;
            }
            else if (data == "R")
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(data, numBase);
            }
        }
    }
}
