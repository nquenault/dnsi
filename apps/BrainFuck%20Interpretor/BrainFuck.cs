/**
 * BrainFuck Interpretor
 *
 * code by @NQuenault
 *
 * eg:
 * Console.WriteLine(Utility.BrainFuck.Eval(
 *   "++++++++++[>+++++++>++++++++++>+++>+<<<<-]"+
 *   ">++.>+.+++++++..+++.>++.<<+++++++++++++++.>.+++.------.--------.>+."
 * ));
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Utility
{
    public class BrainFuck
    {
        private BrainFuck() { }
        public static byte[] LastMemoryState { get; set; }
        public static string Eval(string brainFckCode, Func<byte[]> input = null)
        {
            byte[] memory = new byte[ushort.MaxValue + 1];
            int instptr = 0;
            ushort ptr = 0;
            string output = "";
            var callstack = new Stack<int>();
            var inputBuffer = new Queue<byte>();
            brainFckCode = Regex.Replace(brainFckCode, @"[^<>\-+\.,\[\]]", "");

            var opCodes = new Dictionary<char, Action>() {
                {'>', () => ptr++}, {'<', () => ptr--},
                {'+', () => memory[ptr]++}, {'-', () => memory[ptr]--},
                {'.', () => output += Convert.ToChar(memory[ptr])},
                {'[', () => callstack.Push(instptr)},
                {']', () => instptr = memory[ptr] == 0 ? instptr : callstack.Pop() - 1},
                {',', () => {
                    if(input != null && inputBuffer.Count == 0)
                        input().ToList().ForEach((b) => inputBuffer.Enqueue(b));
                    if(inputBuffer.Count != 0)
                        memory[ptr] = inputBuffer.Dequeue();
                }}
            };
            
            while (instptr < brainFckCode.Length) 
            {
                opCodes[brainFckCode[instptr]]();
                instptr++;
            }

            LastMemoryState = memory;
            return output;
        }
    }
}

