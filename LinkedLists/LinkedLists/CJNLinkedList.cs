using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Simple Double linked list class
 */

namespace CJNLinkedLists
{
    class Node // A Node holds the data for one item plus forward and backward references
    {
        public object item;
        public Node previous; // Point to previous record
        public Node next; // Point to next record

        public Node() // Node constructor
        {
            item = null;
            previous = null;
            next = null; 
        }
    }

    class Header // Head of list data type
    {
        public Node firstNode; // Head node
        public int listSize; // Number of elements in the list
    }

    class CJNLinkedList<BaseType> // Linked list of type BaseType using generics
    {
        private Header head; // List information and pointer to first element on in list (head of list)
        private Node next; // Pointer to next item
        private Node prev; // Pounter to previous item

        // Construct empty linked list of type BaseType
        public CJNLinkedList() 
        {
            head = new Header(); // Create header record
            head.firstNode = null;  // No record to point to as yet
            head.listSize = 0;   // No records in list
        }

        // Returns the size of the list
        public int sizeOf() 
        {
            return head.listSize; // Simply return listSize 
        }

        // Append new record to end of the list
        public BaseType appendRecord(BaseType obj) { 
            Node temp = head.firstNode; // Point at head of the list
            Node node = new Node();  // Create new node

            head.listSize++; // Increment the size of the list counter

            node.item = obj; // point node item at obj;
            
            if (temp == null) // If the head is not pointing at a node (empty list) add first node and update head
            {
                node.previous = null;   // As this is first record, no previous
                node.next = null;       // As this is first record, no next (yet)

                head.firstNode = node; // Point the head at this first record

                // Console.WriteLine("Head of list added, List size = " + head.listSize + " Object: "+ obj); // Debug printout

                return (BaseType)node.item; // Head object populated, return
            } 
             
            // locate last node
            while (temp.next != null) // Iterate through nodes until at the end
            {
                temp = temp.next; // Move to next node
            }

            // temp now points at last node in list
            node.previous = temp;   // Point to previous node (temp)

            node.next = null;       // Mark as the end of the list

            temp.next = node;       // Point old end of list at new end of list

            // Console.WriteLine("New node added, List size = " + head.listSize + " Object: " + obj); // Debug Printout

            return obj;             // Return the object
        }

        // Gets the node at [index]
        public BaseType getRecord(int index)
        {
            int count = 0; // Counter to calculate correct element
            Node temp = head.firstNode; // Point temp at start of the list

            if (index < 0 || index >= head.listSize) // Index out of bounds
            {
                throw new IndexOutOfRangeException(); // Throw index out of range exception
            }

            while (temp != null && count++ < index) // Run through list to find the element
            {
                temp = temp.next;
            }

            return (BaseType)temp.item; // Return the element at [index]
        }

        // Insert a record at element [index]
        public Boolean insertRecord(BaseType obj, int index)
        {
            int count = 0;
            Node temp = head.firstNode;
            Node node = new Node(); // Instantiate new empty node;

            head.listSize++; // Increment the size of the list counter

            node.item = obj; // Assign the new object to record.item

            if (index < 0 || index >= head.listSize) // Index out of bounds
            {
                throw new IndexOutOfRangeException(); // Throw index out of range exception
            }

            if (index == 0) // New head
            {
                temp = head.firstNode; // Point temp at old head record

                head.firstNode = node; // point head at new record
                node.previous = null; // No previous record for the head
                node.next = temp;
                
                temp.previous = node;
                return true;
            }

            while (count++ < index-1) // Iterate through the nodes to locate required node
            {
                temp = temp.next;
            }

            // Adjust pointers to insert new record into list
            node.previous = temp; // Point at previous node
            node.next = temp.next; // point at next node
            temp.next = node; // update previous record to point here

            if(node.next != null) // If this is not a new last record in list
                node.next.previous = node; // point next record's previous pointer here
            
            return true;
        }


        // Delete the record at element [index]
        public Boolean deleteRecord(int index)
        {
            Node temp = head.firstNode; // Point temp at head
            int count = 0; // Counter to calculate the correct element

            if (index < 0 || index >= head.listSize) // Index out of bounds
            {
                throw new IndexOutOfRangeException(); // Throw index out of range exception
            }

            while (count++ < index) // Iterate through the nodes to locate required node
            {
                temp = temp.next; 
            }
            // temp now points at the node to be deleted

            // Console.WriteLine("Node chosen for deletion = " + temp.item); // Debug printout

            // Updte previous node links and head
            if (temp.previous != null) // If there is a previous node
            {
                temp.previous.next = temp.next; // Point the previous node's next at the next node (skipping this node - unlink left to right)
            }
            else // No previous node, this must be the first so update it
            {
                head.firstNode = temp.next; // Point head.firstNode at the next record (this may be null if there are no more items in list)
                temp.previous = null; // Unlink this node's previous pointer
            }

            // Update next node links
            if (temp.next != null) // if there is a next node
            {
                // Console.WriteLine("Updating next reference "); // Debug Printout
                temp.next.previous = temp.previous; // Point the next record.previous at previous (skipping this node - unlink right to left)
                temp.next = null; // Unlink this node's next pointer
            }

            head.listSize--; // Decrement the list size

            return true; // Node deleted successfully
        }

        // Displaye the list to the console - testing purposes
        public void displayList() 
        {
            Node temp = head.firstNode;

            if (temp == null)
                Console.WriteLine("List empty\n");

            while (temp != null) // Iterate through nodes until at the end
            {
                Console.WriteLine("Obejct = " + temp.item);
                temp = temp.next; // Move to next node
            }
        }
    }

}
