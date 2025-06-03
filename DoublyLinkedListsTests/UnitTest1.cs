using DoublyLinkedListWithErrors;

namespace DoublyLinkedListTests
{
    [TestClass]
    public class DLListTests
    {
        [TestMethod] // Test 1: Adding a node to an empty list should set both head and tail to the new node.
        public void Test_01_AddToTail_EmptyList()
        {
            DLList list = new DLList();//null
            DLLNode node = new DLLNode(5);
            list.addToTail(node);//null

            Assert.AreEqual(node, list.head);
            Assert.AreEqual(node, list.tail);
        }

        [TestMethod] // Test 2: Adding a node to a non-empty list should update the tail and link nodes correctly.
        public void Test_02_AddToTail_NonEmptyList()
        {
            DLList list = new DLList();
            DLLNode node1 = new DLLNode(5);
            DLLNode node2 = new DLLNode(10);
            list.addToTail(node1);
            list.addToTail(node2);

            Assert.AreEqual(node1, list.head);
            Assert.AreEqual(node2, list.tail);
            Assert.AreEqual(node1.next, node2);
            Assert.AreEqual(node2.previous, node1);
        }

        [TestMethod] // Test 3: Adding multiple nodes to the list should maintain the correct ordering.
        public void Test_03_AddToTail_MultipleElements()
        {
            DLList list = new DLList();
            DLLNode node1 = new DLLNode(5);
            DLLNode node2 = new DLLNode(10);
            DLLNode node3 = new DLLNode(15);
            list.addToTail(node1);
            list.addToTail(node2);
            list.addToTail(node3);

            Assert.AreEqual(node1, list.head);
            Assert.AreEqual(node3, list.tail);
            Assert.AreEqual(node2.previous, node1);
            Assert.AreEqual(node2.next, node3);
        }

        [TestMethod] // Test 4: Removing the tail from a single-element list should make it empty.
        public void Test_04_RemoveTail_SingleElementList()
        {
            DLList list = new DLList();
            DLLNode node = new DLLNode(5);
            list.addToTail(node);
            list.removeTail();

            Assert.IsNull(list.head);
            Assert.IsNull(list.tail);
        }

        [TestMethod] // Test 5: Removing the head from a single-element list should make it empty.
        public void Test_05_RemoveHead_SingleElementList()
        {
            DLList list = new DLList();
            DLLNode node = new DLLNode(5);
            list.addToHead(node);
            list.removHead();

            Assert.IsNull(list.head);
            Assert.IsNull(list.tail);
        }

        [TestMethod] // Test 6: Searching in an empty list should return null.
        public void Test_06_Search_EmptyList()
        {
            DLList list = new DLList();
            Assert.IsNull(list.search(5));
        }

        [TestMethod] // Test 7: Searching for an existing element should return the correct node.
        public void Test_07_Search_ExistingElement()
        {
            DLList list = new DLList();
            DLLNode node1 = new DLLNode(5);
            DLLNode node2 = new DLLNode(10);
            list.addToTail(node1);
            list.addToTail(node2);

            Assert.AreEqual(node2, list.search(10));
        }

        [TestMethod] // Test 8: Searching for a non-existing element should return null.
        public void Test_08_Search_NonExistingElement()
        {
            DLList list = new DLList();
            DLLNode node = new DLLNode(5);
            list.addToTail(node);

            Assert.IsNull(list.search(10));
        }

        [TestMethod] // Test 9: The total of an empty list should be zero.
        public void Test_09_Total_EmptyList()
        {
            DLList list = new DLList();
            Assert.AreEqual(0, list.total());
        }

        [TestMethod] // Test 10: The total of a list with one element should be its value.
        public void Test_10_Total_SingleElementList()
        {
            DLList list = new DLList();
            DLLNode node = new DLLNode(5);
            list.addToTail(node);

            Assert.AreEqual(5, list.total());
        }

       

        [TestMethod] // Test 11: Negative numbers should not be prime.
        public void Test_11_IsPrime_NegativeNumbers()
        {
            DLLNode node = new DLLNode(0);
            Assert.IsFalse(node.isPrime(-5));
            Assert.IsFalse(node.isPrime(-17));
        }

        [TestMethod] // Test 12: Large prime numbers should be identified correctly.
        public void Test_12_IsPrime_LargePrimeNumber()
        {
            DLLNode node = new DLLNode(0);
            //Assert.IsTrue(node.isPrime(1000000000000066600000000000001));  too large number build is failing
            Assert.IsTrue(node.isPrime(30011));
        }

        [TestMethod] // Test 13: Removing the head should update head to the next node.
        public void Test_13_RemoveNode_Head()
        {
            DLList list = new DLList();
            DLLNode node1 = new DLLNode(5);
            DLLNode node2 = new DLLNode(10);
            list.addToTail(node1);
            list.addToTail(node2);
            list.removeNode(node1);

            Assert.AreEqual(node2, list.head);
            Assert.IsNull(node2.previous);
        }

        [TestMethod] // Test 14: Removing the tail should update tail to the previous node.
        public void Test_14_RemoveNode_Tail()
        {
            DLList list = new DLList();
            DLLNode node1 = new DLLNode(5);
            DLLNode node2 = new DLLNode(10);
            list.addToTail(node1);
            list.addToTail(node2);
            list.removeNode(node2);

            Assert.AreEqual(node1, list.tail);
            Assert.IsNull(node1.next);
        }
        [TestMethod] // Test 15: Edge case for incorrect loop condition in isPrime
        public void Test_15_IsPrime_LoopCondition()
        {
            DLLNode node = new DLLNode(0);

            // 49 is not a prime (7 * 7), but due to incorrect condition, it might return true
            Assert.IsFalse(node.isPrime(49));
        }

        [TestMethod] // Test 16: total() should sum all nodes correctly
        public void Test_16_Total_SkippingNodes()
        {
            DLList list = new DLList();
            list.addToTail(new DLLNode(5));
            list.addToTail(new DLLNode(10));
            list.addToTail(new DLLNode(15));

            // Expected: 5 + 10 + 15 = 30
            Assert.AreEqual(30, list.total(), "total() incorrectly skips every second node.");
        }

        [TestMethod] // Test 17: addToTail should correctly set p.previous before updating tail
        public void Test_17_AddToTail_PreviousIncorrectlySet()
        {
            DLList list = new DLList();
            DLLNode node1 = new DLLNode(5);
            DLLNode node2 = new DLLNode(10);

            list.addToTail(node1);
            list.addToTail(node2);

            // node2.previous should point to node1, not node2 itself.
            Assert.AreEqual(node1, node2.previous, "addToTail incorrectly sets p.previous after tail has changed.");
        }


        [TestMethod] // Test 18: addToHead(null) and addToTail(null) should not crash
        public void Test_18_AddNullNode_ShouldNotCrash()
        {
            DLList list = new DLList();

            list.addToHead(null);
            list.addToTail(null);

            // Ensure head and tail remain null and no exceptions occur
            Assert.IsNull(list.head);
            Assert.IsNull(list.tail);
        }

        [TestMethod] // Test 19: removeHead() and removeTail() on empty list should not modify head and tail
        public void Test_19_RemoveFromEmptyList_ShouldNotModify()
        {
            DLList list = new DLList();

            list.removHead();
            list.removeTail();

            // Head and tail should remain null
            Assert.IsNull(list.head);
            Assert.IsNull(list.tail);
        }
        [TestMethod] // Test 20: Remove a middle node from a list with three nodes
        public void Test_20_RemoveMiddleNode_ShouldMaintainLinks()
        {
            DLList list = new DLList();
            DLLNode node1 = new DLLNode(5);
            DLLNode node2 = new DLLNode(10);
            DLLNode node3 = new DLLNode(15);
            list.addToTail(node1);
            list.addToTail(node2);
            list.addToTail(node3);

            list.removeNode(node2);

            // The remaining nodes should be correctly linked
            Assert.AreEqual(node1.next, node3);
            Assert.AreEqual(node3.previous, node1);
        }

        [TestMethod] // Test 21: Add multiple elements, remove head and tail, check middle node
        public void Test_21_RemoveHeadAndTail_ShouldLeaveMiddleAsHeadAndTail()
        {
            DLList list = new DLList();
            DLLNode node1 = new DLLNode(5);
            DLLNode node2 = new DLLNode(10);
            DLLNode node3 = new DLLNode(15);
            list.addToTail(node1);
            list.addToTail(node2);
            list.addToTail(node3);

            list.removeNode(node1);
            list.removeNode(node3);

            // The middle node should now be both head and tail
            Assert.AreEqual(node2, list.head);
            Assert.AreEqual(node2, list.tail);
            Assert.IsNull(node2.previous);
            Assert.IsNull(node2.next);
        }
        
    }
}
