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
            
            char[] tokens = expression.ToCharArray();

            
            Stack<double> values = new Stack<double>();

            
            Stack<char> ops = new Stack<char>();

            
            for (int i = 0; i < tokens.Length; i++)
            {
                
                if (tokens[i] == ' ')
                {
                    continue;
                }
               
        
                
                if (tokens[i] >= '0' && tokens[i] <= '9')
                {
                    StringBuilder sbuf = new StringBuilder();
                    
                    while ((i < tokens.Length) && (tokens[i] >= '0' && tokens[i] <= '9' || tokens[i] == '.'))
                    {
                        sbuf.Append(tokens[i++]);
                    }
                    
                    values.Push(double.Parse(sbuf.ToString(), CultureInfo.InvariantCulture.NumberFormat));
                }

                
                else if (tokens[i] == '(')
                {
                    ops.Push(tokens[i]);
                }

                
                else if (tokens[i] == ')')
                {
                    while (ops.Peek() != '(')
                    {
                        values.Push(applyOp(ops.Pop(), values.Pop(), values.Pop()));
                    }
                    ops.Pop();
                }

                 
                else if (tokens[i] == '+' || tokens[i] == '-' || tokens[i] == '*' || tokens[i] == '/' || tokens[i] == '%' || tokens[i] == '^')
                {
                    
                    while (ops.Count > 0 && hasPrecedence(tokens[i], ops.Peek()))
                    {
                        values.Push(applyOp(ops.Pop(), values.Pop(), values.Pop()));
                    }

                   
                    ops.Push(tokens[i]);
                }
            }

            
            while (ops.Count > 0)
            {
                values.Push(applyOp(ops.Pop(), values.Pop(), values.Pop()));
            }

            
            return values.Pop();
        }


        
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
