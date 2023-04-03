using System.Linq.Expressions;

namespace Project2_Group4
{
    public class ExpressionEvaluation
    {
        static bool IsOperand(char c)
        {
            // If the character is a digit
            // then it must be an operand
            if (c >= 48 && c <= 57)
                return true;
            else
                return false;
        }

        public static double EvaluatePrefix(string exprsn)
        {
            Stack<double> stack = new();
            Expression<Func<double, double, double>> applyOperation = (a, b) => 0;

            for (int j = exprsn.Length - 1; j >= 0; j--)
            {

                // Push operand to Stack
                // To convert exprsn[j] to digit subtract
                // '0' from exprsn[j].
                if (IsOperand(exprsn[j]))
                    stack.Push(exprsn[j] - 48);

                else
                {

                    // Operator encountered
                    // Pop two elements from Stack
                    double val1 = stack.Pop();
                    double val2 = stack.Pop();

                    // Use switch case to operate on o1
                    // and o2 and perform o1 Or o2.
                    switch (exprsn[j])
                    {
                        case '+':
                            applyOperation = (a, b) => a + b;
                            break;
                        case '-':
                            applyOperation = (a, b) => a - b;
                            break;
                        case '*':
                            applyOperation = (a, b) => a * b;
                            break;
                        case '/':
                            applyOperation = (a, b) => a / b;
                            break;
                    }
                    stack.Push(applyOperation.Compile().Invoke(val1, val2));
                }
            }

            return stack.Peek();
        }

        // The main function that returns value
        // of a given postfix expression
        public static double EvaluatePostfix(string exp)
        {
            // Create a stack of capacity equal to expression size
            Stack<double> stack = new();
            Expression<Func<double, double, double>> applyOperation = (a, b) => 0;

            // Scan all characters one by one
            for (int i = 0; i < exp.Length; ++i)
            {
                // If the scanned character is an operand
                // (number here), push it to the stack.
                if (char.IsDigit(exp[i]))
                    stack.Push(exp[i] - '0');

                // If the scanned character is an operator,
                // pop two elements from stack apply the operator
                else
                {
                    double val1 = stack.Pop();
                    double val2 = stack.Pop();
                    switch (exp[i])
                    {
                        case '+':
                            applyOperation = (a, b) => a + b;
                            break;
                        case '-':
                            applyOperation = (a, b) => a - b;
                            break;
                        case '*':
                            applyOperation = (a, b) => a * b;
                            break;
                        case '/':
                            applyOperation = (a, b) => a / b;
                            break;
                    }
                    stack.Push(applyOperation.Compile().Invoke(val2, val1));
                }
            }
            return stack.Pop();
        }


    }
}
