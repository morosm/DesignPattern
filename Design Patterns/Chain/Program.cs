namespace Behaviour
{
    // Loan event argument holds Loan info
    public class LoanEventArgs : EventArgs
    {
        internal Loan Loan { get; set; }
    }

    /// <summary>
    /// The 'Handler' abstract class
    /// </summary>
    abstract class Approver
    {
        // Loan event 
        public EventHandler<LoanEventArgs> Loan;

        // Loan event handler
        public abstract void LoanHandler(object sender, LoanEventArgs e);

        // Constructor
        public Approver()
        {
            Loan += LoanHandler;
        }

        public void ProcessRequest(Loan loan)
        {
            OnLoan(new LoanEventArgs { Loan = loan });
        }

        // Invoke the Loan event
        public virtual void OnLoan(LoanEventArgs e)
        {
            if (Loan != null)
            {
                Loan(this, e);
            }
        }

        // Sets or gets the next approver
        public Approver Successor { get; set; }
    }

    /// <summary>
    /// The 'ConcreteHandler' class
    /// </summary>
    class Clerk : Approver
    {
        public override void LoanHandler(object sender, LoanEventArgs e)
        {
            if (e.Loan.Amount < 25000.0)
            {
                Console.WriteLine("{0} approved request# {1}",
                this.GetType().Name, e.Loan.Number);
            }
            else if (Successor != null)
            {
                Successor.LoanHandler(this, e);
            }
        }
    }

    /// <summary>
    /// The 'ConcreteHandler' class
    /// </summary>
    class AssistantManager : Approver
    {
        public override void LoanHandler(object sender, LoanEventArgs e)
        {
            if (e.Loan.Amount < 45000.0)
            {
                Console.WriteLine("{0} approved request# {1}",
                this.GetType().Name, e.Loan.Number);
            }
            else if (Successor != null)
            {
                Successor.LoanHandler(this, e);
            }
        }
    }

    /// <summary>
    /// The 'ConcreteHandler' clas
    /// </summary>
    class Manager : Approver
    {
        public override void LoanHandler(object sender, LoanEventArgs e)
        {
            if (e.Loan.Amount < 100000.0)
            {
                Console.WriteLine("{0} approved request# {1}",
                sender.GetType().Name, e.Loan.Number);
            }
            else if (Successor != null)
            {
                Successor.LoanHandler(this, e);
            }
            else
            {
                Console.WriteLine(
                "Request# {0} requires an executive meeting!",
                e.Loan.Number);
            }
        }
    }

    /// <summary>
    /// Class that holds request details
    /// </summary>
    class Loan
    {
        public double Amount { get; set; }
        public string Purpose { get; set; }
        public int Number { get; set; }
    }

    /// <summary>
    /// ChainOfResponsibility Pattern Demo
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Setup Chain of Responsibility
            Approver rohit = new Clerk();
            Approver rahul = new AssistantManager();
            Approver manoj = new Manager();

            rohit.Successor = rahul;
            rahul.Successor = manoj;

            // Generate and process loan requests
            var loan = new Loan { Number = 2034, Amount = 24000.00, Purpose = "Laptop Loan" };
            rohit.ProcessRequest(loan);

            loan = new Loan { Number = 2035, Amount = 42000.10, Purpose = "Bike Loan" };
            rohit.ProcessRequest(loan);

            loan = new Loan { Number = 2036, Amount = 156200.00, Purpose = "House Loan" };
            rohit.ProcessRequest(loan);

            // Wait for user
            Console.ReadKey();
        }
    }
}