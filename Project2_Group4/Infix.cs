namespace Project2_Group4
{
    public class Infix // create small class to store infix equations initially
    {
        public string expression;
        public Infix(string expression_) // constructor will be passed in from file
        {
            expression = expression_;
        }

        public override string ToString() 
        {
            return expression;  
        }
    }
}