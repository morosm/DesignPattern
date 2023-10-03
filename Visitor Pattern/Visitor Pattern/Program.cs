using System.Collections.Generic;

namespace VisitorPattern
{
    public class Program
    {
        public static void Main()
        {
            var obj = new ObjectStructure();
            var visitorA = new ConcreteVisitorA();
            var visitorB = new ConcreteVisitorB();
            obj.Accept(visitorA);
            obj.Accept(visitorB);

        }
    }

    public class ObjectStructure
    {
        public List<Element> Elements { get; private set; }

        public ObjectStructure()
        {
            Elements = new List<Element>()
            {
                new ConcreteElementA{Name = "CEB"},
                new ConcreteElementB{Title = "CEA"},
            };
        }

        public void Accept(Visitor visitor)
        {
            foreach (Element element in Elements)
            {
                element.Accept(visitor);
            }
        }
    }

    public interface Element
    {
        void Accept(Visitor visitor);
    }

    public class ConcreteElementA : Element
    {
        public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public string Name { get; set; }
    }
    public class ConcreteElementB : Element
    {
        public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public string Title { get; set; }
    }

    public interface Visitor
    {
        void Visit(ConcreteElementA element);

        void Visit(ConcreteElementB element);
    }

    public class ConcreteVisitorA : Visitor
    {
        public void Visit(ConcreteElementA element)
        {
            Console.WriteLine("VisitorA visited ElementA : {0}", element.Name);
        }

        public void Visit(ConcreteElementB element)
        {
            Console.WriteLine("VisitorA visited ElementB : {0}", element.Title);
        }
    }
    public class ConcreteVisitorB : Visitor
    {
        public void Visit(ConcreteElementA element)
        {
            Console.WriteLine("VisitorB visited ElementA : {0}", element.Name);
        }

        public void Visit(ConcreteElementB element)
        {
            Console.WriteLine("VisitorB visited ElementB : {0}", element.Title);
        }
    }


}