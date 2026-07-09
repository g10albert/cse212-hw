public class CustomerService {
    public static void Run() {
        // Test 1: Test valid max size and verify it limits at 2
        Console.WriteLine("Test 1: Check Max Size");
        var cs = new CustomerService(2);
        cs.AddNewCustomerManual("A", "1", "P1");
        cs.AddNewCustomerManual("B", "2", "P2"); 
        cs.AddNewCustomerManual("C", "3", "P3");
        Console.WriteLine(cs); 
        Console.WriteLine("=================");

        // Test 2: Test Serving from an empty queue
        Console.WriteLine("Test 2: Serve Empty Queue");
        var cs2 = new CustomerService(2);
        cs2.ServeCustomer(); 
        Console.WriteLine("=================");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        _maxSize = (maxSize <= 0) ? 10 : maxSize;
    }

    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }
        public string Name { get; }
        public string AccountId { get; }
        public string Problem { get; }
        public override string ToString() => $"{Name} ({AccountId}) : {Problem}";
    }

    // Helper for testing purposes to avoid Console.ReadLine()
    private void AddNewCustomerManual(string n, string a, string p) {
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }
        _queue.Add(new Customer(n, a, p));
    }

    private void ServeCustomer() {
        // FIX: Check if empty before removing
        if (_queue.Count == 0) {
            Console.WriteLine("Queue is empty.");
            return;
        }
        // FIX: Get the customer first, then remove
        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}