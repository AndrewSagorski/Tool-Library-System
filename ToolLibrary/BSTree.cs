using System;

namespace ToolLibrary
{
	/// <summary>
    /// Class for representing tree node objects to be used in binary
    /// search tree class.
    /// </summary>
	public class BTreeNode
	{
		private Member member;

		private BTreeNode lchild; // reference to its left child 
		private BTreeNode rchild; // reference to its right child

		public BTreeNode(Member member) 
		{
			this.member = member; 
			lchild = null;
			rchild = null;
		}

		public Member Member
        {
            get
            {
				return member;
            }
            set
            {
				member = value;
            }
        }

		public BTreeNode LChild
		{
			get { return lchild; }
			set { lchild = value; }
		}

		public BTreeNode RChild
		{
			get { return rchild; }
			set { rchild = value; }
		}
	}


	/// <summary>
    /// Class that formats a Member storage and indexing system in the form
    /// of a Binary Search Tree.
    /// </summary>
	public class BSTree
	{
		private BTreeNode root;

		public BSTree()
		{
			root = null;
		}

		/// <summary>
        /// Checks if root of binary search tree is empty, returns true if so
        /// and false otherwise.
        /// </summary>
        /// <returns>True or false</returns>
		public bool IsEmpty()
		{
			return root == null;
		}

		/// <summary>
        /// Calls separate Search() method with entered Member object and
        /// current binary search tree root, and returns bool value.
        /// </summary>
        /// <param name="member">Member object to be sent to other search method</param>
        /// <returns>True if member is in tree, false otherwise</returns>
		public bool Search(Member member) 
		{
			return Search(member, root);
		}

		/// <summary>
        /// Compares entered Member object with root and all nodes of the binary search
        /// tree and returns true if a match is found.
        /// </summary>
        /// <param name="member">Member object to be compared</param>
        /// <param name="r">Binary Search Tree root node</param>
        /// <returns>True if member is in tree, false otherwise</returns>
		private bool Search(Member member, BTreeNode r) 
		{
			if(r != null)
			{
				if(member.CompareTo(r.Member) == 0)
					return true;
				else
					if(member.CompareTo(r.Member) < 0 )
					return Search(member, r.LChild);
				else
					return Search(member, r.RChild);
			}
			else
				return false;
		}

		/// <summary>
        /// Adds a member object to the binary search tree root if root
        /// is currently empty.
        /// </summary>
        /// <param name="member">Member object to be added</param>
		public void Insert(Member member) 
		{
			if(root == null)
				root = new BTreeNode(member);
			else
				Insert(member, root);	
		}

		/// <summary>
        /// Inserts a member object relative to a given tree node.
        /// </summary>
        /// <param name="member">Member to be added</param>
        /// <param name="ptr">Parent node relative to member</param>
		private void Insert (Member member, BTreeNode ptr)
		{
			if (member.CompareTo(ptr.Member) < 0)
			{
				if (ptr.LChild == null)
					ptr.LChild = new BTreeNode(member);
				else 
					Insert(member, ptr.LChild);
			}
			else 
			{
				if (ptr.RChild == null)			
					ptr.RChild = new BTreeNode(member);
				else 
					Insert(member, ptr.RChild);
			}
		} 
	
		// there are three cases to consider:
		// 1. the node to be deleted is a leaf
		// 2. the node to be deleted has only one child 
		// 3. the node to be deleted has both left and right children
		public void Delete(Member member) 
		{
			// Search for item and its parent
			BTreeNode ptr = root; // search reference
			BTreeNode parent = null; // parent of ptr
			while((ptr!=null)&&(member.CompareTo(ptr.Member)!=0))
			{
				parent = ptr;
				if(member.CompareTo(ptr.Member) < 0) // move to the left child of ptr
					ptr = ptr.LChild;
				else
					ptr = ptr.RChild;
			}

			if(ptr != null) // if the search was successful
			{
				// case 3: item has two children
				if((ptr.LChild != null)&&(ptr.RChild != null))
				{
					// find the right-most node in left subtree of ptr
					if(ptr.LChild.RChild == null) // a special case: the right subtree of ptr.LChild is empty
					{
						ptr.Member = ptr.LChild.Member;
						ptr.LChild = ptr.LChild.LChild;
					}
					else 
					{
						BTreeNode p = ptr.LChild;
						BTreeNode pp = ptr; // parent of p
						while(p.RChild != null)
						{
							pp = p;
							p = p.RChild;
						}
						// copy the item at p to ptr
						ptr.Member = p.Member;
						pp.RChild = p.LChild;
					}
				}
				else // cases 1 & 2: item has no or only one child
				{
					BTreeNode c;
					if(ptr.LChild != null)
						c = ptr.LChild;
					else
						c = ptr.RChild;

					// remove node ptr
					if(ptr == root) //need to change root
						root = c;
					else
					{
						if(ptr == parent.LChild)
							parent.LChild = c;
						else
							parent.RChild = c;
					}
				}

			}
		}

		public void PreOrderTraverse()
		{
			Console.Write("PreOrder: ");
			PreOrderTraverse(root);
			Console.WriteLine();
		}

		private void PreOrderTraverse(BTreeNode root)
		{
			if(root != null)
			{
				Console.Write(root.Member);
				PreOrderTraverse(root.LChild);
				PreOrderTraverse(root.RChild);
			}
		}

		public void InOrderTraverse()
		{
			Console.Write("InOrder: ");
			InOrderTraverse(root);
			Console.WriteLine();
		}

		private void InOrderTraverse(BTreeNode root)
		{
			if(root != null)
			{
				InOrderTraverse(root.LChild);
				Console.Write(root.Member);
				InOrderTraverse(root.RChild);
			}
		}

		public void PostOrderTraverse()
		{
			Console.Write("PostOrder: ");
			PostOrderTraverse(root);
			Console.WriteLine();
		}

		private void PostOrderTraverse(BTreeNode root)
		{
			if(root != null)
			{
				PostOrderTraverse(root.LChild);
				PostOrderTraverse(root.RChild);
				Console.Write(root.Member); 
			}
		}

		public void Clear()
		{
			root = null;
		}
	}
}




