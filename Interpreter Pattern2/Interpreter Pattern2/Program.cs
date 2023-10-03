using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter_Pattern2
{
    public class Program
    {
        public static void Main()
        {
            var client = new Client();
            client.BuildAndInterpretCommands();
        }
    }
    public class Client
    {
        public void BuildAndInterpretCommands()
        {
            Context context = new Context("Dot Net context");
            NonterminalExpression root = new NonterminalExpression();
            root.Expression1 = new TerminalExpression();
            root.Expression2 = new TerminalExpression();
            root.Interpret(context);
        }
    }

    public class Context
    {
        public string Name { get; set; }

        public Context(string name)
        {
            Name = name;
        }
    }

    public interface IExpression
    {
        void Interpret(Context context);
    }

    public class TerminalExpression : IExpression
    {
        public void Interpret(Context context)
        {
            Console.WriteLine("Terminal for {0}.", context.Name);
        }
    }

    public class NonterminalExpression : IExpression
    {
        public IExpression Expression1 { get; set; }

        public IExpression Expression2 { get; set; }

        public void Interpret(Context context)
        {
            Console.WriteLine("Nonterminal for {0}.", context.Name);
            Expression1.Interpret(context);
            Expression2.Interpret(context);
        }
    }

}
