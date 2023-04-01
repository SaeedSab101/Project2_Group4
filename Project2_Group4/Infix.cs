/*
    1. Install-Package CsvHelper 
 */
namespace Project2_Group4
{
    public class Infix
    {
        public string expression;
        public Infix(string expression_)
        {
            expression = expression_;
        }

        public override string ToString()
        {
            return expression;  
        }
    }
}