using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities and verify the highest priority comes out first.
    // Expected Result: The item with priority 10 should be returned first.
    // Defect(s) Found: The logic didn't search the whole list and didn't remove the item.
    public void TestPriorityQueue_HighestPriorityFirst()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Low", 1);
        pq.Enqueue("High", 10);
        pq.Enqueue("Medium", 5);

        Assert.AreEqual("High", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue two items with the same high priority.
    // Expected Result: The first one added (FIFO) should be the one removed.
    // Defect(s) Found: Previous code didn't handle FIFO correctly for tied priorities.
    public void TestPriorityQueue_FIFOWithSamePriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("First", 5);
        pq.Enqueue("Second", 5);
        pq.Enqueue("Third", 3);

        Assert.AreEqual("First", pq.Dequeue());
        Assert.AreEqual("Second", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Call Dequeue on an empty queue.
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None (if your exception handling is already correct).
    public void TestPriorityQueue_EmptyException()
    {
        var pq = new PriorityQueue();
        try
        {
            pq.Dequeue();
            Assert.Fail("Should have thrown an exception.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

    [TestMethod]
    // Scenario: Enqueue and Dequeue multiple times to ensure the queue remains consistent.
    // Expected Result: Items should be returned in correct order of priority.
    // Defect(s) Found: 
    public void TestPriorityQueue_MultipleOperations()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 10);
        pq.Enqueue("C", 5);

        Assert.AreEqual("B", pq.Dequeue());
        pq.Enqueue("D", 20);
        Assert.AreEqual("D", pq.Dequeue());
        Assert.AreEqual("C", pq.Dequeue());
        Assert.AreEqual("A", pq.Dequeue());
    }
}