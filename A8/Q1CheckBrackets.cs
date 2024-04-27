using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A8
{
    public class Bracket
    {
        public char type {get; set;}
        public int index {get; set;}
        public Bracket(char t, int i)
        {
            type = t;
            index = i;
        }
        public bool IsMatched(char c)
        {
            if (type == '[' && c == ']')
            {
                return true;
            }
            if (type == '{' && c == '}')
            {
                return true;
            }
            if (type == '(' && c == ')')
            {
                return true;
            }
            return false;
        }
    }
    public class Q1CheckBrackets : Processor
    {
        public Q1CheckBrackets(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, long>)Solve);

        public long Solve(string str)
        {
            // string bracketsOnly = Regex.Replace(str, "[A-Za-z ]", "");
            if (str.Length == 1)
            {
                return 1;
            }
            Stack<Bracket> opening_brackets_stack = new Stack<Bracket>();
            for (int i = 0; i < str.Length; i++)
            {
                char next = str[i];
                if (next == '[' || next == '(' || next == '{')
                {
                    Bracket b = new Bracket(next, i);
                    opening_brackets_stack.Push(b);
                }
                else if (next == ']' || next == ')' || next == '}')
                {
                    if (opening_brackets_stack.Count == 0)
                    {
                        return i + 1;
                    }
                    var top = opening_brackets_stack.Pop();
                    if (top.IsMatched(next) == false)
                    {
                        return i + 1;
                    }
                }
            } 
            if (opening_brackets_stack.Count == 1)
            {
                return opening_brackets_stack.Peek().index + 1;
            }
            return -1;
        }
    }
}
