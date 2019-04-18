using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryWindowsApp
{
    class EvaluateString
    {
        public EvaluateString()
        {

        }

        public static void main(string[] args)
        {



        }

        public double evaluate(string expression)
        {
            //get all the tokens in the charachter array from the expression string passed
            char[] tokens = expression.ToCharArray();

            // Stack for numbers: 'values' 
            Stack<double> values = new Stack<double>();

            // Stack for Operators: 'operators' 
            Stack<char> ops = new Stack<char>();

            //iterating through the tokens to get numbers and operators
            for (int i = 0; i < tokens.Length; i++)
            {
                // Current token is a whitespace, skip it 
                if (tokens[i] == ' ')
                {
                    continue;
                }
               
        
                // Current token is a number, push it to stack for numbers 
                if (tokens[i] >= '0' && tokens[i] <= '9')
                {
                    StringBuilder sbuf = new StringBuilder();
                    // There may be more than one digits in number 
                    while ((i < tokens.Length) && (tokens[i] >= '0' && tokens[i] <= '9' || tokens[i] == '.'))
                    {
                        sbuf.Append(tokens[i++]);
                    }
                    
                    values.Push(double.Parse(sbuf.ToString(), CultureInfo.InvariantCulture.NumberFormat));
                }

                // Current token is an opening brace, push it to 'operator stack' 
                else if (tokens[i] == '(')
                {
                    ops.Push(tokens[i]);
                }

                // Closing brace encountered, solve entire brace 
                else if (tokens[i] == ')')
                {
                    while (ops.Peek() != '(')
                    {
                        values.Push(applyOp(ops.Pop(), values.Pop(), values.Pop()));
                    }
                    ops.Pop();
                }

                // Current token is an operator. 
                else if (tokens[i] == '+' || tokens[i] == '-' || tokens[i] == '*' || tokens[i] == '/' || tokens[i] == '%' || tokens[i] == '^')
                {
                    // While top of 'ops' has same or greater precedence to current 
                    // token, which is an operator. Apply operator on top of 'ops' 
                    // to top two elements in values stack 
                    while (ops.Count > 0 && hasPrecedence(tokens[i], ops.Peek()))
                    {
                        values.Push(applyOp(ops.Pop(), values.Pop(), values.Pop()));
                    }

                    // Push current token to 'ops'. 
                    ops.Push(tokens[i]);
                }
            }

            // Entire expression has been parsed at this point, apply remaining 
            // ops to remaining values 
            while (ops.Count > 0)
            {
                values.Push(applyOp(ops.Pop(), values.Pop(), values.Pop()));
            }

            // Top of 'values' contains result, return it 
            return values.Pop();
        }


        // A utility method to apply an operator 'op' on operands 'a' 
        // and 'b'. Return the result. 
        public static double applyOp(char op, double b, double a)
        {
            double result = 0.0;
            switch (op)
            {
                case '+':
                    return a + b;
                case '-':         
                    return a - b;
                case '*':
                    ;
                    return a * b;
                case '/':
                    if (b == 0)
                    {
                        throw new System.NotSupportedException("Cannot divide by zero");
                    }
                    return a / b;
                case '^':
                    result = Math.Pow((int)a, (int)b);

                    return result;
                case '%':
                    result = (int)a % (int)b;
                    return result;
            }
            return 0;
        }


        // Returns true if 'op2' has higher or same precedence as 'op1', 
        // otherwise returns false. 
        public static bool hasPrecedence(char op1, char op2)
        {
            if (op2 == '(' || op2 == ')')
            {
                return false;
            }
            if ((op1 == '*' || op1 == '/' || op1=='%') && (op2 == '+' || op2 == '-'))
            {
                return false;
            }
            if (op1 == '^')
                return true;
            else
            {
                return true;
            }
        }
    }
}
