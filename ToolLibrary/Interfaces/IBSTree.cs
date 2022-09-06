using System;
//using BSTreeClass;
//using BSTreeADT;

/**
 * CAN DELETE THIS INTERFACE, NOT NECESSARILY NEEDED
 */
namespace ToolLibrary 
{
	// invariants: every node?s left subtree contains values less than or equal to 
	// the node?s value, and every node?s right subtree contains values 
	// greater than or equal to the node?s value
	public interface IBSTree
	{
		// pre: true
		// post: return true if the binary tree is empty; otherwise, return false.
		bool IsEmpty();

		// pre: true
		// post: item is added to the binary search tree
		//void Insert(IComparable item);

        void Insert(Member member);

        // pre: true
        // post: an occurrence of item is removed from the binary search tree 
        //		 if item is in the binary search tree
        //void Delete(IComparable item);

        void Delete(Member member);

        // pre: true
        // post: return true if item is in the binary search true;
        //	     otherwise, return false.
        //bool Search(IComparable item);

        bool Search(Member member);

        // pre: true
        // post: all the nodes in the binary tree are visited once and only once in pre-order
        void PreOrderTraverse();

		// pre: true
		// post: all the nodes in the binary tree are visited once and only once in in-order
		void InOrderTraverse();

		// pre: true
		// post: all the nodes in the binary tree are visited once and only once in post-order
		void PostOrderTraverse();

		// pre: true
		// post: all the nodes in the binary tree are removed and the binary tree becomes empty
		void Clear();

	}
}
