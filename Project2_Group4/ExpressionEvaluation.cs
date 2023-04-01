using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_Group4
{
    public class ExpressionEvaluation
    {
        static bool isOperand(char c)
        {
            // If the character is a digit
            // then it must be an operand
            if (c >= 48 && c <= 57)
                return true;
            else
                return false;
        }

        public static double evaluatePrefix(string exprsn)
        {
            Stack<double> stack = new();

            for (int j = exprsn.Length - 1; j >= 0; j--)
            {

                // Push operand to Stack
                // To convert exprsn[j] to digit subtract
                // '0' from exprsn[j].
                if (isOperand(exprsn[j]))
                    stack.Push((double)(exprsn[j] - 48));

                else
                {

                    // Operator encountered
                    // Pop two elements from Stack
                    double o1 = stack.Peek();
                    stack.Pop();
                    double o2 = stack.Peek();
                    stack.Pop();

                    // Use switch case to operate on o1
                    // and o2 and perform o1 Or o2.
                    switch (exprsn[j])
                    {
                        case '+':
                            stack.Push(o1 + o2);
                            break;
                        case '-':
                            stack.Push(o1 - o2);
                            break;
                        case '*':
                            stack.Push(o1 * o2);
                            break;
                        case '/':
                            stack.Push(o1 / o2);
                            break;
                    }
                }
            }

            return stack.Peek();
        }

        // The main function that returns value
        // of a given postfix expression
        public static double evaluatePostfix(string exp)
        {
            // Create a stack of capacity equal to expression size
            Stack<double> st = new Stack<double>();

            // Scan all characters one by one
            for (int i = 0; i < exp.Length; ++i)
            {
                // If the scanned character is an operand
                // (number here), push it to the stack.
                if (char.IsDigit(exp[i]))
                    st.Push(exp[i] - '0');

                // If the scanned character is an operator,
                // pop two elements from stack apply the operator
                else
                {
                    double val1 = st.Pop();
                    double val2 = st.Pop();
                    switch (exp[i])
                    {
                        case '+':
                            st.Push(val2 + val1);
                            break;
                        case '-':
                            st.Push(val2 - val1);
                            break;
                        case '*':
                            st.Push(val2 * val1);
                            break;
                        case '/':
                            st.Push(val2 / val1);
                            break;
                    }
                }
            }
            return st.Pop();
        }


    }
}
