using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedListWithErrors
{
    public class DLList
    {
        public DLLNode head; // pointer to the head of the list
        public DLLNode tail; // pointer to the tail of the list
        public DLList() { head = null; tail = null; } // constructor
        /*-------------------------------------------------------------------
        * The methods below includes several errors. Your  task is to write
        * unit test to discover these errors. During delivery the tutor may
        * add or remove errors to adjust the scale of the effort required by
        */
        public void addToTail(DLLNode p)
        {
            if (p == null) return;
            p.next = null;
            if (this.head == null)//if empty list
            {
                this.head = p;
                this.tail = p;
            }
            else
            {
                p.previous = this.tail;
                this.tail.next = p;
                this.tail = p;

            }
            /*
             * p.previous = tail;
                tail.next = p;
                tail = p;
            test case 17

             */
        } // end of addToTail

        public void addToHead(DLLNode p)
        {
            if (p == null) return;
            p.previous = null;
            if (this.head == null)
            {
                this.head = p;
                this.tail = p;
            }
            else
            {
                p.next = this.head;
                this.head.previous = p;
                this.head = p;
            }
        } // end of addToHead

        public void removHead()//needs to be removeHead(). Original is removHead
        {
            if (this.head == null) return;
            if (this.head == this.tail)
            {
                this.head = null;
                this.tail = null;
                return;
            }
            this.head = this.head.next;//move head node to next
            this.head.previous = null;//remove reference to old head
        } // removeHead
        /* test 5
         * if (this.head != null)
             this.head.previous = null;  line 60 should be replaced with this
        if its an emty list then line 60 will thorw a null pointer reference
         */

        public void removeTail()
        {
            if (this.tail == null) return;
            if (this.head == this.tail)
            {
                this.head = null;
                this.tail = null;
                return;
            }
            this.tail = this.tail.previous;
            this.tail.next = null;
        } // remove tail
        /*
         * tail = tail.previous;     // More than one node in the list..    this.tail = this.tail.prev; // Move tail pointer to the previous node..    this.tail.next = null; // Set the new tail's next pointer to null
            tail.next = null; should be added at line 77 
            doesnt acually remove the tail.
        test 4 and 14
         */
        /*-------------------------------------------------
         * Return null if the string does not exist.
         * ----------------------------------------------*/
        public DLLNode search(int num)
        {
            DLLNode p = this.head;
            while (p != null)
            {
                if (p.num == num)
                    return p;
                p = p.next;
            }
            return (null);
        } // end of search (return pionter to the node);
        /*
         * skips first node without checking it
         * swap line 93 and 94
         * if (p.num == num) return p;
                p = p.next;
         test 7 and 8
         */

        public void removeNode(DLLNode p)
        { // removing the node p.
            if (p == null) return;
            if (p.next == null)
            {
                this.tail = this.tail.previous;
                this.tail.next = null;
                p.previous = null;//cut all links
                return;//since void statement no need for return
            }
            else if (p.previous == null)
            {
                this.head = p.next;
                this.head.previous = null;
                return;//since void statement no need for return
            }
            else
            {
                p.previous.next = p.next;
                p.next.previous = p.previous;
            }

            return;//since void statement no need for return
        } // end of remove a node
        /*
         * If tail.previous is null, this.tail.next = null will crash. test 13
         * line 112 should be
         * if (this.tail != null)
                this.tail.next = null;

         If this.head.next == null, setting this.head.previous = null will cause a crash.
        if (this.head != null) line 120
            this.head.previous = null;
         */

        public int total()
        {
            DLLNode p = head;
            int tot = 0;
            while (p != null)
            {
                tot += p.num;
                p = p.next; //should be p.next  current one is skipping an element
            }
            return (tot);
        } // end of total
        /*
         * p.next.next should be p.next test 16
         */
    } // end of DLList class
}
