using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Test enqueue and dequeue with values: Bob (2), Tim (5), Sue (3)
    // Expected Result: tim, sue
    // Defect(s) Found: Dequeue didn't remove from the queue, and index should start at 0
    public void TestPriorityQueue_1()
    {
        var bob = new PriorityItem("Bob", 2);
        var tim = new PriorityItem("Tim", 5);
        var sue = new PriorityItem("Sue", 3);

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(bob.Value, bob.Priority);
        priorityQueue.Enqueue(tim.Value, tim.Priority);
        priorityQueue.Enqueue(sue.Value, sue.Priority);

        PriorityItem[] expectedResult = [tim, sue];

        int i = 0;
        for (; i < 2; i++)
        {
            var queue = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, queue);
        }
    }

    [TestMethod]
    // Scenario: more than one item with the highest priority, item closest to front gets dequeued
    // Expected Result: tim (5), bob (5), sue (3)
    // Defect(s) Found: usage of a >= instead of a >
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        var sue = new PriorityItem("Sue", 3);
        var tim = new PriorityItem("Tim", 5);
        var bob = new PriorityItem("Bob", 5);

        priorityQueue.Enqueue(sue.Value, sue.Priority);
        priorityQueue.Enqueue(tim.Value, tim.Priority);
        priorityQueue.Enqueue(bob.Value, bob.Priority);

        PriorityItem[] expectedResult = [tim, bob, sue];

        int i = 0;
        for (; i < 3; i++)
        {
            var queue = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, queue);
        }
    }


    [TestMethod]
    // Scenario: try to dequeue with no one in queue
    // Expected Result: error
    // Defect(s) Found: none
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        Assert.ThrowsException<InvalidOperationException>(() =>
        {
           priorityQueue.Dequeue(); 
        });
    }
}