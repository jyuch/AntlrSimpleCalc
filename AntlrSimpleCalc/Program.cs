using System;
using Antlr4.Runtime;

namespace AntlrSimpleCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("> ");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }
                else
                {
                    var inputStream = new AntlrInputStream(input);
                    var lexer = new AntlrSimpleCalcLexer(inputStream);
                    var commonTokenStream = new CommonTokenStream(lexer);
                    var parser = new AntlrSimpleCalcParser(commonTokenStream);
                    var exprContext = parser.expr();

                    Console.WriteLine(Eval(exprContext));
                }
            }
        }

        static double Eval(AntlrSimpleCalcParser.ExprContext expr)
        {
            if (expr.expr().Length == 1)
            {
                return Eval(expr.expr()[0]);
            }

            if (expr.NUM() == null)
            {
                var left = Eval(expr.left);
                var right = Eval(expr.right);

                switch (expr.op.Text)
                {
                    case "+":
                        return left + right;
                    case "-":
                        return left - right;
                    case "*":
                        return left * right;
                    case "/":
                        return left / right;
                }

                throw new Exception();
            }
            else
            {
                return double.Parse(expr.NUM().GetText());
            }
        }
    }
}
