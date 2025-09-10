using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create a queue with the following items (value, priority): ("A",1), ("B",3), ("C",2)
    // Expected Result: A, B, C
    // Defect(s) Found: No defects found.
    public void TestPriorityQueue_Enqueue()
    {
        var priorityQueue = new PriorityQueue();

        var item1 = new PriorityItem("A", 1);
        var item2 = new PriorityItem("B", 3);
        var item3 = new PriorityItem("C", 2);

        string expectedResult = $"[{item1}, {item2}, {item3}]";

        priorityQueue.Enqueue(item1.Value, item1.Priority);
        priorityQueue.Enqueue(item2.Value, item2.Priority);
        priorityQueue.Enqueue(item3.Value, item3.Priority);

        Assert.AreEqual(expectedResult, priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Create a queue with the following items (value, priority): ("A",1), ("B",3), ("C",2), ("D", 2). 
    // Then call Dequeue two times. Compare the results of the two Dequeue calls to expected values.
    // Check if the queue is have items A and D.
    // Expected Result: B, C and queue contains A and D
    // Defect(s) Found: Change line 27 to remove the "- 1" to loop through the last item in the list.
    // Defect(s) Found: Add line 35 "_queue.RemoveAt(highPriorityIndex);" to remove the item from the list.
    // Defect(s) Found: Change line from ">=" to ">" to the first item of equal priority be removed
    public void TestPriorityQueue_Dequeue()
    {
        var priorityQueue = new PriorityQueue();

        var item1 = new PriorityItem("A", 1);
        var item2 = new PriorityItem("B", 2);
        var item3 = new PriorityItem("C", 2);
        var item4 = new PriorityItem("D", 3);

        string expectedResult1 = item4.Value;
        string expectedResult2 = item2.Value;
        string expectedQueue = $"[{item1}, {item3}]";

        priorityQueue.Enqueue(item1.Value, item1.Priority);
        priorityQueue.Enqueue(item2.Value, item2.Priority);
        priorityQueue.Enqueue(item3.Value, item3.Priority);
        priorityQueue.Enqueue(item4.Value, item4.Priority);

        var result1 = priorityQueue.Dequeue();
        var result2 = priorityQueue.Dequeue();
        var resultQueue = priorityQueue.ToString();
        Assert.AreEqual(expectedResult1, result1);
        Assert.AreEqual(expectedResult2, result2);
        Assert.AreEqual(expectedQueue, resultQueue);
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue
    // Expected Result: Exception should be thrown with "The queue is empty." message
    // Defect(s) Found: No defects found.
    public void TestPriorityQueue_Empty()
    {
        var items = new PriorityQueue();

        try
        {
            items.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }
}