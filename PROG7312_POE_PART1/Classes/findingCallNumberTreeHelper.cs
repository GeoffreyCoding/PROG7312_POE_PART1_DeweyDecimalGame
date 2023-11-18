﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace PROG7312_POE_PART1.Classes
{
    /// <summary>
    /// Enumeration Defining Colors
    /// </summary>
    enum Color
    {
        Red,
        Black
    }

    internal class findingCallNumberTreeHelper
    {
        //--------------------------------------------------------------------------------------------------//
        ///Class defining a Node - Be careful of defining a clASs within  Class!
        /// <summary>
        /// Object of type Node contains 4 properties
        /// Colour
        /// Left
        /// Right
        /// Parent
        /// Data
        /// </summary>
        public class Node
        {
            public Color colour;
            public Node left;
            public Node right;
            public Node parent;
            public int data; // Assuming this is the Dewey Decimal number
            public string description; // Description of the Dewey Decimal category
            public int level; // Level in the Dewey Decimal hierarchy

            public Node(int data, string description, int level, Color colour)
            {
                this.data = data;
                this.description = description;
                this.level = level;
                this.colour = colour;
            }
        }

        //--------------------------------------------------------------------------------------------------//


        /// <summary>
        /// Root node of the tree (both reference & pointer)
        /// </summary>
        private Node root;

        //-------------------------------------------------------------------------------------------------//
        ///Constructor
        /// <summary>
        /// New instance of a Red-Black tree object
        /// </summary>
        public findingCallNumberTreeHelper()
        {
        }
        #region Rotating data on the tree
        //-------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Left Rotate
        /// </summary>
        /// <param name="X"></param>
        /// <returns>void</returns>
        private void LeftRotate(Node X)
        {
            Node Y = X.right; // set Y
            X.right = Y.left; // turn Y's left subtree into X's right subtree
            if (Y.left != null)
            {
                Y.left.parent = X;
            }

            // link X's parent to Y
            Y.parent = X.parent;
            if (X.parent == null) // X was the root
            {
                root = Y;
            }
            else if (X == X.parent.left) // X was a left child
            {
                X.parent.left = Y;
            }
            else // X was a right child
            {
                X.parent.right = Y;
            }

            // Put X on Y's left
            Y.left = X;
            X.parent = Y;
        }

        //-------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Rotate Right
        /// </summary>
        /// <param name="Y"></param>
        /// <returns>void</returns>
        private void RightRotate(Node Y)
        {
            Node X = Y.left; // set X
            Y.left = X.right; // turn X's right subtree into Y's left subtree

            if (X.right != null)
            {
                X.right.parent = Y;
            }

            // Link Y's parent to X
            X.parent = Y.parent;
            if (Y.parent == null) // Y was the root
            {
                root = X;
            }
            else if (Y == Y.parent.right) // Y was a right child
            {
                Y.parent.right = X;
            }
            else // Y was a left child
            {
                Y.parent.left = X;
            }

            // Put Y on X's right
            X.right = Y;
            Y.parent = X;
        }
        #endregion

        //-------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Display Tree
        /// </summary>
        public void DisplayTree()
        {
            if (root == null)
            {
                Console.WriteLine("The tree is empty.");
            }
            else
            {
                InOrderDisplay(root);
            }
        }
        #region Basic tree functions Get, Find, Insert, Delete
        //-------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Find item in the tree
        /// </summary>
        /// <param name="key"></param>
        public Node Find(int key)
        {
            bool isFound = false;
            Node temp = root;
            Node item = null;
            while (!isFound)
            {
                if (temp == null)
                {
                    break;
                }
                if (key < temp.data)
                {
                    temp = temp.left;
                }
                if (key > temp.data)
                {
                    temp = temp.right;
                }
                if (key == temp.data)
                {
                    isFound = true;
                    item = temp;
                }
            }
            if (isFound)
            {
                Console.WriteLine("{0} was found", key);
                return temp;
            }
            else
            {
                Console.WriteLine("{0} not found", key);
                return null;
            }
        }

        //-------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Insert a new object into the RB Tree
        /// </summary>
        /// <param name="item"></param>
        public void Insert(int data, string description, int level)
        {
            Node newItem = new Node(data, description, level, Color.Red);
            if (root == null)
            {
                root = newItem;
                root.colour = Color.Black;
                return;
            }

            Node Y = null;
            Node X = root;
            while (X != null)
            {
                Y = X;
                if (newItem.data < X.data || (newItem.data == X.data && newItem.level < X.level))
                {
                    X = X.left;
                }
                else
                {
                    X = X.right;
                }
            }

            newItem.parent = Y;
            if (Y == null) // This should never be true since the root case is handled above
            {
                root = newItem;
            }
            else if (newItem.data < Y.data || (newItem.data == Y.data && newItem.level < Y.level))
            {
                Y.left = newItem;
            }
            else
            {
                Y.right = newItem;
            }

            InsertFixUp(newItem); // Fix potential violations after insert
        }


        //-------------------------------------------------------------------------------------------------//
        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        private void InOrderDisplay(Node current)
        {
            if (current != null)
            {
                InOrderDisplay(current.left);
                Console.WriteLine("Number: {0}, Description: {1}, Level: {2}", current.data, current.description, current.level);
                InOrderDisplay(current.right);
            }
        }

        //-------------------------------------------------------------------------------------------------//
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        private void InsertFixUp(Node item)
        {
            //Checks Red-Black Tree properties
            while (item != root && item.parent.colour == Color.Red)
            {
                /*We have a violation*/
                if (item.parent == item.parent.parent.left)
                {
                    Node Y = item.parent.parent.right;
                    if (Y != null && Y.colour == Color.Red)//Case 1: uncle is red
                    {
                        item.parent.colour = Color.Black;
                        Y.colour = Color.Black;
                        item.parent.parent.colour = Color.Red;
                        item = item.parent.parent;
                    }
                    else //Case 2: uncle is black
                    {
                        if (item == item.parent.right)
                        {
                            item = item.parent;
                            LeftRotate(item);
                        }
                        //Case 3: recolour & rotate
                        item.parent.colour = Color.Black;
                        item.parent.parent.colour = Color.Red;
                        RightRotate(item.parent.parent);
                    }

                }
                else
                {
                    // Mirror image of code above
                    Node X = item.parent.parent.left; // This should be left, not right as in the "if" part
                    if (X != null && X.colour == Color.Red) // Case 1: uncle is red
                    {
                        item.parent.colour = Color.Black;
                        X.colour = Color.Black;
                        item.parent.parent.colour = Color.Red;
                        item = item.parent.parent;
                    }
                    else // Case 2: uncle is black
                    {
                        if (item == item.parent.left)
                        {
                            item = item.parent;
                            RightRotate(item);
                        }
                        // Case 3: recolor and rotate
                        item.parent.colour = Color.Black;
                        item.parent.parent.colour = Color.Red;
                        LeftRotate(item.parent.parent);
                    }
                }
                root.colour = Color.Black;//re-colour the root black as necessary
            }
        }

        //-------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Deletes a specified value from the tree
        /// </summary>
        /// <param name="item"></param>
        public void Delete(int key)
        {
            //first find the node in the tree to delete and assign to item pointer/reference
            Node item = Find(key);
            Node X = null;
            Node Y = null;

            if (item == null)
            {
                Console.WriteLine("Nothing to delete!");
                return;
            }
            if (item.left == null || item.right == null)
            {
                Y = item;
            }
            else
            {
                Y = TreeSuccessor(item);
            }
            if (Y.left != null)
            {
                X = Y.left;
            }
            else
            {
                X = Y.right;
            }
            if (X != null)
            {
                X.parent = Y;
            }
            if (Y.parent == null)
            {
                root = X;
            }
            else if (Y == Y.parent.left)
            {
                Y.parent.left = X;
            }
            else
            {
                Y.parent.left = X;
            }
            if (Y != item)
            {
                item.data = Y.data;
            }
            if (Y.colour == Color.Black)
            {
                DeleteFixUp(X);
            }

        }

        //-------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Checks the tree for any violations after deletion and performs a fix
        /// </summary>
        /// <param name="X"></param>
        private void DeleteFixUp(Node X)
        {

            while (X != null && X != root && X.colour == Color.Black)
            {
                if (X == X.parent.left)
                {
                    Node W = X.parent.right;
                    if (W.colour == Color.Red)
                    {
                        W.colour = Color.Black; //case 1
                        X.parent.colour = Color.Red; //case 1
                        LeftRotate(X.parent); //case 1
                        W = X.parent.right; //case 1
                    }
                    if (W.left.colour == Color.Black && W.right.colour == Color.Black)
                    {
                        W.colour = Color.Red; //case 2
                        X = X.parent; //case 2
                    }
                    else if (W.right.colour == Color.Black)
                    {
                        W.left.colour = Color.Black; //case 3
                        W.colour = Color.Red; //case 3
                        RightRotate(W); //case 3
                        W = X.parent.right; //case 3
                    }
                    W.colour = X.parent.colour; //case 4
                    X.parent.colour = Color.Black; //case 4
                    W.right.colour = Color.Black; //case 4
                    LeftRotate(X.parent); //case 4
                    X = root; //case 4
                }
                else //mirror code from above with "right" & "left" exchanged
                {
                    Node W = X.parent.left;
                    if (W.colour == Color.Red)
                    {
                        W.colour = Color.Black;
                        X.parent.colour = Color.Red;
                        RightRotate(X.parent);
                        W = X.parent.left;
                    }
                    if (W.right.colour == Color.Black && W.left.colour == Color.Black)
                    {
                        W.colour = Color.Black;
                        X = X.parent;
                    }
                    else if (W.left.colour == Color.Black)
                    {
                        W.right.colour = Color.Black;
                        W.colour = Color.Red;
                        LeftRotate(W);
                        W = X.parent.left;
                    }
                    W.colour = X.parent.colour;
                    X.parent.colour = Color.Black;
                    W.left.colour = Color.Black;
                    RightRotate(X.parent);
                    X = root;
                }
            }
            if (X != null)
                X.colour = Color.Black;
        }

        //-------------------------------------------------------------------------------------------------//
        /// <summary>
        /// 
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        private Node Minimum(Node X)
        {
            while (X.left.left != null)
            {
                X = X.left;
            }
            if (X.left.right != null)
            {
                X = X.left.right;
            }
            return X;
        }

        //-------------------------------------------------------------------------------------------------//
        /// <summary>
        /// 
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        private Node TreeSuccessor(Node X)
        {
            if (X.left != null)
            {
                return Minimum(X);
            }
            else
            {
                Node Y = X.parent;
                while (Y != null && X == Y.right)
                {
                    X = Y;
                    Y = Y.parent;
                }
                return Y;
            }
        }
        #endregion

        #region getting data from the tree
        /// <summary>
        /// Gets all the entries linked to a specific level of the Dewey Decimal System and then randomly chooses 4, excluding those in correctAnswersList.
        /// </summary>
        /// <param name="level"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<Node> GetRandomEntriesByLevel(int level, int count = 4)
        {
            List<Node> allEntries = new List<Node>();
            //gets all the entries of the level
            GetAllEntriesByLevelHelper(root, level, allEntries);
            List<Node> randomEntries = new List<Node>();
            // Retrieve the list of correct answers to exclude them from random selection
            var correctAnswersList = findingCallNumberObject.Instance.CorrectAnswersList;

            Random rnd = new Random();
            int entriesCount = allEntries.Count;

            // If there are not enough entries, return them all (excluding correct answers)
            if (entriesCount <= count)
            {
                return allEntries.Except(correctAnswersList).ToList();
            }

            // Randomly select 'count' unique entries, excluding correct answers
            while (randomEntries.Count < count)
            {
                int index = rnd.Next(entriesCount);
                Node selectedEntry = allEntries[index];

                // Ensure the entry is not in the correct answers list and is unique in the randomEntries list
                if (!correctAnswersList.Contains(selectedEntry) && !randomEntries.Contains(selectedEntry))
                {
                    randomEntries.Add(selectedEntry);
                }
            }

            return randomEntries;
        }

        /// <summary>
        /// Gets all the entries linked to a specific level of the Dewey Decimal System and then randomly chooses 4, excluding those in correctAnswersList.
        /// </summary>
        /// <param name="level"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<Node> GetIncorrectEntriesByLevel(int level, int count = 3)
        {
            List<Node> allEntries = new List<Node>();
            GetAllEntriesByLevelHelper(root, level, allEntries);
            List<Node> randomEntries = new List<Node>();

            // Retrieve the list of correct answers to exclude them from random selection
            var correctAnswersList = findingCallNumberObject.Instance.CorrectAnswersList;

            Random rnd = new Random();
            int entriesCount = allEntries.Count;

            // If there are not enough entries, return them all (excluding correct answers)
            if (entriesCount <= count)
            {
                return allEntries.Except(correctAnswersList).ToList();
            }

            // Randomly select 'count' unique entries, excluding correct answers
            while (randomEntries.Count < count)
            {
                int index = rnd.Next(entriesCount);
                Node selectedEntry = allEntries[index];
                

                // Ensure the entry is not in the correct answers list and is unique in the randomEntries list
                if (!correctAnswersList.Contains(selectedEntry) && !randomEntries.Contains(selectedEntry))
                {
                    var selectedEntryData = selectedEntry.data.ToString();
                    var isTrue = false;
                    if (correctAnswersList[2].data.ToString().Length == 3)
                    {
                        isTrue = isDivisible(selectedEntryData, level);
                    }
                    else
                    {
                        isTrue = true;
                    }


                    if (isTrue)
                    {
                        randomEntries.Add(selectedEntry);
                    }
                    
                }
            }

            return randomEntries;
        }
        /// <summary>
        /// ensures that the selected number is divisible by the correct answer in order to match the leveling system of the DDC system
        /// </summary>
        /// <param name="ddcNumber"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        private bool isDivisible(string ddcNumber, int level)
        {
            var correctAnswer = findingCallNumberObject.Instance.CorrectAnswer.data.ToString();
            switch (level)
            {
                //level 1
                case 1:
                    if (ddcNumber.Length == 3)
                    {
                        //ensures only level 1 categories are selected
                        var result = Convert.ToInt32(ddcNumber) / 100;
                        //getting first digit of correct answer
                        var element = ddcNumber.Substring(0,1);
                        //converting to int
                        var temp = Convert.ToInt32(element);
                        //the number of times they are divided by 0 is the same as the first digit of the ddc number selected
                        //e.g 100/100 = 1, 200/100 = 2, 300/100 = 3
                        if (result == temp)
                        {
                            return true;
                        }
                       
                    }
                    break;
                    //level 2
                case 2:
                    if (ddcNumber.Length >= 1)
                    {
                        //gets the first digit of the correct answer
                        string firstDigitOfCorrectAnswer = correctAnswer.Substring(0, 1);
                        //gets the first digit of the selected number
                        string firstDigitOfDdcNumber = ddcNumber.Substring(0, 1);
                        int ddcNumberInt = Convert.ToInt32(ddcNumber);
                        // Check if divisible by 10 and results in a whole number. Also check if it is not divisible by 100 to ensure no level 1 categories are mixed in
                        if (firstDigitOfDdcNumber == firstDigitOfCorrectAnswer && ddcNumberInt % 10 == 0 && ddcNumberInt % 100 != 0)
                        {
                            return true;
                        }
                    }
                    break;
                    //level 3
                case 3:
                    //if level == 3 and the length is < 3
                    //this means that the correct answer is 000
                    //all the numbers in level 2 and 3 for 000 are under 100
                    if (Convert.ToInt32(correctAnswer) < 100)
                    {
                        if (Convert.ToInt32(ddcNumber) < 100)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        //category is anything except 000
                        if (ddcNumber.Length ==3)
                        {
                            //getting the first 2 digits of the ddc number
                            string firstDigitOfDdcNumber = ddcNumber.Substring(0, 2);
                            //getting the first 2 digits of the correct answer
                            string firstDigitOfCorrectAnswer = correctAnswer.Substring(0, 2);
                            int ddcNumberInt = Convert.ToInt32(ddcNumber);
                            // Check if divisible by 10 and results in a whole number. Also check if it is not divisible by 100 to ensure no level 1 categories are mixed in
                            if (firstDigitOfDdcNumber == firstDigitOfCorrectAnswer && ddcNumberInt % 10 != 0 && ddcNumberInt % 100 != 0)
                            {
                                return true;
                            }
                        }
                        //extra check incase 1 slipped through somehow???
                        else
                        {
                            //if level == 3 and the length is < 3
                            if(correctAnswer.Length != 3)
                            {
                                return true;
                            }
                        }
                    }
                    break;
            }
            return false;
        }
        #endregion

        /// <summary>
        /// gets all the entries linked to a specific level of the dewey decimal system
        /// </summary>
        /// <param name="current"></param>
        /// <param name="level"></param>
        /// <param name="allEntries"></param>
        private void GetAllEntriesByLevelHelper(Node current, int level, List<Node> allEntries)
        {
            if (current == null)
            {
                return;
            }
            GetAllEntriesByLevelHelper(current.left, level, allEntries);
            if (current.level == level)
            {
                allEntries.Add(current);
            }
            GetAllEntriesByLevelHelper(current.right, level, allEntries);
        }

        #region getting the parent of a level 3 node
        /// <summary>
        /// Returns all the parent nodes of a child node.
        /// </summary>
        /// <param name="childNode">The level 3 node for which to find the parents.</param>
        /// <returns>A list of parent nodes, including the root (level 1), a level 2 node, and the given level 3 node.</returns>
        public List<Node> GetAllParents(Node childNode)
        {
            if (childNode == null || childNode.level != 3)
            {
                throw new ArgumentException("The provided node must be a level 3 node.");
            }

            List<Node> parents = new List<Node>();
            //gets the parents of the level 1 linked to the chid node
            Node level1Parent = FindLevel1Parent(childNode);
            //gets the parents of th level 2 linked to the child node
            Node level2Parent = FindLevel2Parent(childNode);
            //adding the level 1 parent to the list
            if (level1Parent != null) parents.Add(level1Parent);
            //adding the level 2 parent to the list
            if (level2Parent != null) parents.Add(level2Parent);
            //adding the level 3 node to the list
            parents.Add(childNode); // Add the level 3 node itself
            return parents;
        }
        /// <summary>
        /// Finds the level 1 parent of a given level 3 node
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private Node FindLevel1Parent(Node node)
        {
            //looks for a category with a mathing first digit
            int firstDigit = node.data / 100;
            return FindNodeByFirstDigit(root, firstDigit, 1);
        }
        /// <summary>
        /// Finds the level 2 parent of a given level 3 nodes
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private Node FindLevel2Parent(Node node)
        {
            //looks for a category with a mathing first 2 digits
            int firstTwoDigits = node.data / 10;
            return FindNodeByFirstTwoDigits(root, firstTwoDigits, 2);
        }
        /// <summary>
        /// searches till it finds the level 1 node
        /// </summary>
        /// <param name="currentNode"></param>
        /// <param name="firstDigit"></param>
        /// <param name="targetLevel"></param>
        /// <returns></returns>
        private Node FindNodeByFirstDigit(Node currentNode, int firstDigit, int targetLevel)
        {
            if (currentNode == null) return null;
            //finds the node with the same first digit and level
            if (currentNode.level == targetLevel && currentNode.data / 100 == firstDigit)
            {
                return currentNode;
            }
            //recursively calls itself to find the node
            Node leftResult = FindNodeByFirstDigit(currentNode.left, firstDigit, targetLevel);
            if (leftResult != null) return leftResult;
            //recursively calls itself to find the node
            return FindNodeByFirstDigit(currentNode.right, firstDigit, targetLevel);
        }
        /// <summary>
        /// searches till it finds the level 2 node
        /// </summary>
        /// <param name="currentNode"></param>
        /// <param name="firstTwoDigits"></param>
        /// <param name="targetLevel"></param>
        /// <returns></returns>
        private Node FindNodeByFirstTwoDigits(Node currentNode, int firstTwoDigits, int targetLevel)
        {
            if (currentNode == null) return null;
            //finds the node with the same first 2 digits and level
            if (currentNode.level == targetLevel && currentNode.data / 10 == firstTwoDigits)
            {
                return currentNode;
            }
            //recursively calls itself to find the node
            Node leftResult = FindNodeByFirstTwoDigits(currentNode.left, firstTwoDigits, targetLevel);
            if (leftResult != null) return leftResult;
            //recursively calls itself to find the node
            return FindNodeByFirstTwoDigits(currentNode.right, firstTwoDigits, targetLevel);
        }
        #endregion



    }
}
