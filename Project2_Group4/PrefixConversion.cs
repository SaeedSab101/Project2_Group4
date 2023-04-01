using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_Group4
{
    public class PrefixConversion
    {
        public string Convert(string infix)
        {
            // Reverse the infix expression
            char[] reversed = infix.Reverse().ToArray();

            // Initialize the output and operator stacks
            Stack<char> output = new Stack<char>();
            Stack<char> operators = new Stack<char>();

            // Define a helper function to check operator precedence
            int Precedence(char op) => op switch
            {
                '+' or '-' => 1,
                '*' or '/' or '%' => 2,
                _ => 0
            };

            // Scan the reversed infix expression and build the prefix expression in the output stack
            foreach (char token in reversed)
            {
                if (char.IsDigit(token))
                {
                    // Operand, add to output
                    output.Push(token);
                }
                else if (token == ')')
                {
                    // Closing parenthesis, push onto operator stack
                    operators.Push(token);
                }
                else if (token == '(')
                {
                    // Opening parenthesis, pop operators and add to output until matching closing parenthesis
                    while (operators.Peek() != ')')
                    {
                        output.Push(operators.Pop());
                    }
                    operators.Pop(); // Discard matching closing parenthesis
                }
                else
                {
                    // Operator, pop operators and add to output until lower precedence or stack is empty
                    while (operators.Count > 0 && operators.Peek() != ')' && Precedence(token) < Precedence(operators.Peek()))
                    {
                        output.Push(operators.Pop());
                    }
                    operators.Push(token); // Push current operator onto stack
                }
            }

            // Pop any remaining operators and add to output
            while (operators.Count > 0)
            {
                output.Push(operators.Pop());
            }

            // Reverse the output stack to get prefix expression
            char[] prefix = output.ToArray();
            Array.Reverse(prefix);

            return new string(prefix);
        }
    }
}
