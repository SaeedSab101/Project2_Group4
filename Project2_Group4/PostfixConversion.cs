using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_Group4
{
    public class PostfixConversion
    {
        // define the operator presedence
        static int Precedence(char op)
        {
            switch (op)
            {
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
                case '^':
                    return 3;
                default:
                    return -1;
            }
        }
        // take in an infix post, and turn it to postfix
        public string Convert(string infix)
        {
            string postfix = "";
            Stack<char> stack = new Stack<char>();
            // iterate through string chars
            for (int i = 0; i < infix.Length; i++)
            {
                char c = infix[i];

                if (Char.IsDigit(c))
                {
                    postfix += c;
                }
                else if (c == '(')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    while (stack.Count > 0 && stack.Peek() != '(')
                    {
                        postfix += stack.Pop();
                    }

                    if (stack.Count > 0 && stack.Peek() != '(')
                    {
                        throw new Exception("Invalid expression");
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
                else
                {
                    // check precedence and compare for stack operation
                    while (stack.Count > 0 && Precedence(c) <= Precedence(stack.Peek()))
                    {
                        postfix += stack.Pop();
                    }

                    stack.Push(c);
                }
            }

            while (stack.Count > 0)
            {
                postfix += stack.Pop();
            }

            return postfix;
        }
    }
}
