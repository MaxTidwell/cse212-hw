using System.Diagnostics;

/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        //var cs = new CustomerService(10);
        //Console.WriteLine(cs);



        // Test Cases

        // Test 1
        // Scenario: test max size of queue
        // Expected Result: 10
        Console.WriteLine("Test 1");

        var cs = new CustomerService(0) ;
        Console.WriteLine($"Max Size should be 10: {cs}");

        // Defect(s) Found: 


        Console.WriteLine("=================");

        // Test 2
        // Scenario: Queue a customer and display info
        // Expected Result: displays a customer
        Console.WriteLine("Test 2");

        cs.AddNewCustomer();
        cs.ServeCustomer();

        // Defect(s) Found: 


        Console.WriteLine("=================");


        // Test 3
        // Scenario: Dequeue a customer in correct order and display info
        // Expected Result: displays customer in same order as entered
        Console.WriteLine("Test 3");

        cs.AddNewCustomer();
        cs.AddNewCustomer();
        Console.WriteLine($"Before serving customers: {cs}");
        cs.ServeCustomer();
        cs.ServeCustomer();
        Console.WriteLine($"After serving customers: {cs}");

        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below
    
    
        // Test 4
        // Scenario: Can I serve a customer if there is no customer?
        // Expected Result: This should display some error message
        Console.WriteLine("Test 4");

        cs.ServeCustomer();
        // Defect(s) Found: This found that I need to check the length in serve_customer and display an error message

        Console.WriteLine("=================");



        // Test 5
        // Scenario: Is max queue size enforced?
        // Expected Result: Should display error message when the 11th is added
        Console.WriteLine("Test 5");
        cs.AddNewCustomer();
        cs.AddNewCustomer();
        cs.AddNewCustomer();
        cs.AddNewCustomer();
        cs.AddNewCustomer();
        cs.AddNewCustomer();
        cs.AddNewCustomer();
        cs.AddNewCustomer();
        cs.AddNewCustomer();
        cs.AddNewCustomer();
        cs.AddNewCustomer();

        Console.WriteLine($"Service Queue: {cs}");
        // Defect(s) Found: This found that I need to do >= instead of > in AddNewCustomer

        Console.WriteLine("=================");

    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    protected void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {             // it needs to be a >= to verify the correct size
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    protected void ServeCustomer() {
        if (_queue.Count <= 0)  // Need to check if queue is empty
        {
            Console.WriteLine("No customers in Queue");
        }
        else{
        var customer = _queue[0]; // order of saving and deleting was wrong
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
        }
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}