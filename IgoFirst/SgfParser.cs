using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgoFirst
{
    public class SgfParser
    {
        private string sgf;
        private int pos = -1;
        public char Current
        {
            get
            {
                return sgf[pos];
            }
        }
        public bool HasNext
        {
            get
            {
                return pos >= 0 && pos < sgf.Length;
            }
        }
        public bool IsEof
        {
            get
            {
                return pos < sgf.Length;
            }
        }

        public SgfParser(string sgf)
        {
            this.sgf = sgf;
        }

        public void GoNext()
        {
            pos++;
        }

        public void Parse()
        {
            var current = new Node();
            var stack = new Stack<Node>();
            bool isEscaped = false;

            while (IsEof == false)
            {
                char c = Current;
                if (isEscaped)
                {
                    switch (c)
                    {
                        default:
                            //プロパティ値にAdd
                            isEscaped = false;
                            break;
                    }
                }
                else
                {
                    switch (c)
                    {
                        case '(':
                            break;
                        case ')':
                            break;
                        case ';':
                            break;
                        case '[':
                            break;
                        case ']':
                            break;
                        case '\\':
                            isEscaped = true;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
