using System;
using System.Collections.Generic;

namespace ToolLibrary
{
    /// <summary>
    /// This class works as a storage system for Member objects, makes use of
    /// a Binary Search Tree as a class member.
    /// Contains methods for adding, removing and indexing members.
    /// </summary>
    public class MemberCollection : iMemberCollection
    {
        private List<Member> memberList;         
        private int number = 0;               
        private BSTree membersTree;

        public MemberCollection()
        {            
            memberList = new List<Member>();
            membersTree = new BSTree();
        }
        
        public int Number
        {
            get
            {
                return number;
            }
        }


        /// <summary>
        /// Adds member objects to this collection by adding them to both
        /// the binary search tree and member list.
        /// </summary>
        /// <param name="aMember">Member object to be added</param>
        public void add(Member aMember)
        {            
            // If member does not already exist in binary search tree
            if (!membersTree.Search(aMember))
            {
                membersTree.Insert(aMember);
                // Increase the int that represents the number of members in collection
                number++;                 
                memberList.Add(aMember);
            }            
        }

        /// <summary>
        /// Removes a member object from this collection, affects both the binary
        /// search tree and member list.
        /// </summary>
        /// <param name="aMember">Member object to be removed</param>
        public void delete(Member aMember)
        {
            // If member exists in the binary search tree
            if (membersTree.Search(aMember))
            {
                membersTree.Delete(aMember);
                number--;
                memberList.Remove(aMember);         
            }
            else
            {
                Console.WriteLine(aMember.FirstName + " " + aMember.LastName +
                    " could not be found.");
            }
        }

        /// <summary>
        /// Searches the binary search tree for the given member.
        /// </summary>
        /// <param name="aMember">Member object to be searched for</param>
        /// <returns>True if found, false otherwise</returns>
        public bool search(Member aMember)
        {
            return membersTree.Search(aMember);
        }

        /// <summary>
        /// Takes current members in the member collection and outputs them
        /// in a Member array.
        /// </summary>
        /// <returns>Member array of existing members</returns>
        public Member[] toArray()
        {
            return memberList.ToArray();
        }
    }
}
