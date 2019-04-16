//GRADING ID: D4823 
//PROGRAM: Prog5 
//DUE DATE: 11 / 4 / 2018
//CLASS-SEC: CIS 200-01

//DESCRIPTION: This program demonstrates use of binary Tree to sort <T> type data. We
//             use types of int double and string as T. 

using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTreeLibrary2
{
    class Program
    {
        static void Main(string[] args)
        {
            // intTree is instance of Tree of ints
            Tree<int> intTree = new Tree<int>(new int[] 
                { 3, 5, 8, 4, 31, 7, 87, 564, 334, 22 });
            intTree.InorderTraversal();
            OutputInfo();

            // doubleTree is instance of Tree of doubles
            Tree<double> doubleTree = new Tree<double>(new double[] 
                { 23.32, 665, 64.5, 46.2, 1.0001, .321, 98, 116516.01, 65, 93.1 });
            doubleTree.InorderTraversal();
            OutputInfo();

            // stringTree is instance of Tree of strings
            Tree<string> stringTree = new Tree<string>(new string[] 
                { "aaa", "A-80", "Bobcat", "Nine", "Crocs", "Penny", "Tempo", "Whiskey", "Cows", "tullip" });
            stringTree.InorderTraversal();
            OutputInfo();
        }

        // Precondition:    none
        // Postcondition:   pauses console logs until user continues. Clears console for next output.
        public static void OutputInfo()
        {
            Console.WriteLine("\n\nPress Any Key to Continue...");
            Console.ReadLine();
            Console.Clear();
        }
    }

    // class represents a node within a Tree Instance
    class TreeNode<T> where T : IComparable<T>
    {
        public TreeNode<T> LeftNode { get; set; }          // pointer to left TreeNode
        public T Data { get; private set; }   // value of data that is IComparable type
        public TreeNode<T> RightNode { get; set; }         // pointer to right TreeNode

        // Precondition:    nodeData of IComparable that is comparable to the data of other nodes
        // Postcondition:   An instance of a TreeNode is created with the data set to the parameter that was passed
        public TreeNode(T nodeData)
        {
            Data = nodeData;
        }

        // Precondition:    nodeData of IComparable that is comparable to the data of other nodes
        // Postcondition:   Node that was passed is positioned in the Tree in its proper position
        public void Insert(T newNode)
        {
            if (newNode.CompareTo(Data) < 0)
            {
                if (LeftNode == null)
                    LeftNode = new TreeNode<T>(newNode);
                else
                    LeftNode.Insert(newNode);
            }
            else if (newNode.CompareTo(Data) > 0)
            {
                if (RightNode == null)
                    RightNode = new TreeNode<T>(newNode);
                else
                    RightNode.Insert(newNode);
            }
        }
    }

    // Class that holds TreeNodes in a binary tree, allowing the nodes to be traversed.
    public class Tree<T> where T : IComparable<T>
    {
        // Precondition:    NONE
        // Postcondition:   An instance of Tree is created without any starting data
        public Tree() {/*paramaterless constructor*/}

        // Precondition:    an enumerable data set to populate the Tree with on instantiation
        // Postcondition:   Tree instance is created with the enumarable data set as the TreeNodes
        public Tree(IEnumerable<T> enumeratedData)
        {
            foreach (var item in enumeratedData)
                this.InsertNode(item);
        }

        // root holds the root TreeNode
        private TreeNode<T> root;
        
        // Precondition:    a value that is comparable to the other types contained within the Tree
        // Postcondition:   the passed value is inserted in its correct position in the Tree
        public void InsertNode(T insertValue)
        {
            if (root == null)
                root = new TreeNode<T>(insertValue);
            else
                root.Insert(insertValue);
        }

        // Precondition:    none
        // Postcondition:   lists value of the nodes in preorder
        public void PreorderTraversal()
        {
            PreorderHelper(root);
        }

        // Precondition:    Instance of a TreeNode
        // Postcondition:   Node data is written to the console, then recurrsively call 
        //                  left nodes, then recurrsively call PreorderHelper with right node
        private void PreorderHelper(TreeNode<T> node)
        {
            if (node != null)
            {
                Console.Write($"{node.Data} ");
                PreorderHelper(node.LeftNode);
                PreorderHelper(node.RightNode);
            }
        }

        // Precondition:    none
        // Postcondition:   lists value of the nodes in Inorder
        public void InorderTraversal()
        {
            InorderHelper(root);
        }

        // Precondition:    Instance of a TreeNode
        // Postcondition:   node values are written to the console Inorder
        private void InorderHelper(TreeNode<T> node)
        {
            if (node != null)
            {
                InorderHelper(node.LeftNode);
                Console.Write($"{node.Data} ");
                InorderHelper(node.RightNode);
            }
        }

        // Precondition:    none
        // Postcondition:   lists value of the nodes in postorder
        public void PostorderTraversal()
        {
            PostorderHelper(root);
        }

        // Precondition:    none
        // Postcondition:   lists value of the nodes in preorder
        private void PostorderHelper(TreeNode<T> node)
        {
            if (node != null)
            {
                PostorderHelper(node.LeftNode);
                PostorderHelper(node.RightNode);
                Console.Write($"{node.Data} ");
            }
        }
    }
}