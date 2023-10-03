using System.Collections;

namespace StructuralDesignPatterns
{
    /// <summary>
    /// The 'Component' Treenode
    /// </summary>
    public interface IEmployee
    {
        int EmpID { get; set; }
        string Name { get; set; }
    }

    /// <summary>
    /// The 'Composite' class
    /// </summary>
    public class Employee : IEmployee, IEnumerable<IEmployee>, IEnumerable
    {
        private List<IEmployee> _subordinates = new List<IEmployee>();

        public int EmpID { get; set; }
        public string Name { get; set; }

        public void AddSubordinate(IEmployee subordinate)
        {
            _subordinates.Add(subordinate);
        }

        public void RemoveSubordinate(IEmployee subordinate)
        {
            _subordinates.Remove(subordinate);
        }

        public IEmployee GetSubordinate(int index)
        {
            return _subordinates[index];
        }

        public IEnumerator<IEmployee> GetEnumerator()
        {
            foreach (IEmployee subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    /// <summary>
    /// The 'Leaf' class
    /// </summary>
    public class Contractor : IEmployee
    {
        public int EmpID { get; set; }
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Employee Rahul = new Employee { EmpID = 1, Name = "Rahul" };

            Employee Amit = new Employee { EmpID = 2, Name = "Amit" };
            Employee Mohan = new Employee { EmpID = 3, Name = "Mohan" };

            Rahul.AddSubordinate(Amit);
            Rahul.AddSubordinate(Mohan);

            Employee Rita = new Employee { EmpID = 4, Name = "Rita" };
            Employee Hari = new Employee { EmpID = 5, Name = "Hari" };

            Amit.AddSubordinate(Rita);
            Amit.AddSubordinate(Hari);

            Employee Kamal = new Employee { EmpID = 6, Name = "Kamal" };
            Employee Raj = new Employee { EmpID = 7, Name = "Raj" };

            Contractor Sam = new Contractor { EmpID = 8, Name = "Sam" };
            Contractor tim = new Contractor { EmpID = 9, Name = "Tim" };

            Mohan.AddSubordinate(Kamal);
            Mohan.AddSubordinate(Raj);
            Mohan.AddSubordinate(Sam);
            Mohan.AddSubordinate(tim);

            Console.WriteLine("EmpID={0}, Name={1}", Rahul.EmpID, Rahul.Name);

            foreach (Employee manager in Rahul)
            {
                Console.WriteLine("\n EmpID={0}, Name={1}", manager.EmpID, manager.Name);

                foreach (var employee in manager)
                {
                    Console.WriteLine(" \t EmpID={0}, Name={1}", employee.EmpID, employee.Name);
                }
            }
            Console.ReadKey();
        }
    }
}