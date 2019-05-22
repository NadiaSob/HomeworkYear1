﻿using System;

namespace hw3._2
{
    /// <summary>
    /// Implementation of singly linked list, a linear collection of string values.
    /// </summary>
    public class List : IList
    {
        private class Node
        {
            public string Data { get; set; }
            public Node Next { get; set; }

            public Node(string data, Node next)
            {
                Data = data;
                Next = next;
            }
        }

        private Node head;

        /// <summary>
        /// Number of elements in list.
        /// </summary>
        public uint Size { get; private set; }

        /// <summary>
        /// Checks if the list has no elements in it.
        /// </summary>
        /// <returns>True if the list is empty, else false.</returns>
        public bool IsEmpty() => head == null;

        private bool IsCorrectPositionToAdd(uint position) => position > 0 && position <= Size + 1;

        private bool IsCorrectPosition(uint position) => position > 0 && position <= Size;

        private Node GetNode(uint position)
        {
            Node current = head;
            for (var i = 1; i < position; ++i)
            {
                current = current.Next;
            }
            return current;
        }

        /// <summary>
        /// Adds new element in list by its position.
        /// </summary>
        /// <param name="position">Position of the element to add.</param>
        /// <param name="data">Element to add.</param>
        /// <returns>True if the element is added, false if the given position is incorrect.</returns>
        public bool AddElement(uint position, string data)
        {
            if (!IsCorrectPositionToAdd(position))
            {
                return false;
            }

            var newNode = new Node(data, null);

            if (position == 1)
            {
                newNode.Next = head;
                head = newNode;
            }
            else
            {
                var current = GetNode(position - 1);
                newNode.Next = current.Next;
                current.Next = newNode;
            }
            ++Size;
            return true;
        }

        /// <summary>
        /// Deletes an element from the list by its position.
        /// </summary>
        /// <param name="position">Position of the element to delete.</param>
        /// <returns>True if the element is deleted, false if the given position is incorrect.</returns>
        public bool DeleteElementByPosition(uint position)
        {
            if (!IsCorrectPosition(position))
            {
                return false;
            }

            if (position == 1)
            {
                head = head.Next;
            }
            else
            {
                Node current = GetNode(position - 1);
                current.Next = current.Next.Next;
            }
            --Size;
            return true;
        }

        /// <summary>
        /// Deletes an element from the list by its data.
        /// </summary>
        /// <param name="data">Data of the element to delete.</param>
        public void DeleteElementByData(string data)
        {
            if (head.Data == data)
            {
                head = head.Next;
                --Size;
                return;
            }

            Node previous = head;
            Node current = head.Next;

            for (var i = 0; i < Size; ++i)
            {
                if (current.Data == data)
                {
                    previous.Next = current.Next;
                    --Size;
                    return;
                }
                previous = current;
                current = current.Next;
            }
        }

        /// <summary>
        /// Gets data of the list element by its position.
        /// </summary>
        /// <param name="position">Position of the element.</param>
        /// <returns>Data of the element.</returns>
        public string GetData(uint position)
        {
            if (!IsCorrectPosition(position))
            {
                throw new IndexOutOfRangeException("The given position is incorrect");
            }
            Node node = GetNode(position);
            return node.Data;
        }

        /// <summary>
        /// Sets data of the list element by its position.
        /// </summary>
        /// <param name="position">Position of the element.</param>
        /// <param name="data">Data of the element.</param>
        /// <returns>True if data is set successfully, false if the given position is incorrect.</returns>
        public bool SetData(uint position, string data)
        {
            if (!IsCorrectPosition(position))
            {
                return false;
            }

            Node node = GetNode(position);
            node.Data = data;
            return true;
        }

        /// <summary>
        /// Prints the list.
        /// </summary>
        public void PrintList()
        {
            Node current = head;
            while (current != null)
            {
                Console.Write($"{current.Data} ");
                current = current.Next;
            }
        }

        /// <summary>
        /// Checks if the list element exists.
        /// </summary>
        /// <param name="data">Element to check.</param>
        /// <returns>True if the list element is found, else false</returns>
        public bool Exists(string data)
        {
            Node current = head;
            for (var i = 0; i < Size; ++i)
            {
                if (current.Data == data)
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }
    }
}
