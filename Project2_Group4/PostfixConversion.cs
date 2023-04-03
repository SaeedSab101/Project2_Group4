namespace Project2_Group4
{
    public class PostfixConversion
    {
        // define the operator presedence
        static int Precedence(char op)
        {
            return op switch
            {
                '+' or '-' => 1,
                '*' or '/' => 2,
                '^' => 3,
                _ => -1,
            };
        }
        // take in an infix post, and turn it to postfix
        public static string Convert(string infix)
        {
            string postfix = "";
            Stack<char> stack = new();
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
