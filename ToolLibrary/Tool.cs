using System;
namespace ToolLibrary
{
    /// <summary>
    /// Base tool object class for representing tools in the system.
    /// Contains methods that affect availble quantity and members that
    /// are borrowing it.
    /// </summary>
    public class Tool : iTool, IComparable<Tool>
    {
        private string name;
        private int quantity;
        private int availableQuantity;
        private int noBorrowings;

        private MemberCollection borrowers;

        public Tool(string name, int quantity, int availableQuantity, int noBorrowings)
        {
            this.name = name;
            this.quantity = quantity;
            this.availableQuantity = availableQuantity;
            this.noBorrowings = noBorrowings;

            borrowers = new MemberCollection(); 
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
            }
        }

        public int AvailableQuantity
        {
            get
            {
                return availableQuantity;
            }
            set
            {
                availableQuantity = value;
            }
        }

        public int NoBorrowings
        {
            get
            {
                return noBorrowings;
            }
            set
            {
                noBorrowings = value;
            }
        }

        public MemberCollection GetBorrowers
        {
            get
            {
                return borrowers; 
            }
        }


        /// <summary>
        /// Adds a member to the tool's member collection and decreases
        /// its available quantity.
        /// </summary>
        /// <param name="aMember">Member object to be added</param>
        public void addBorrower(Member aMember)
        {
            // First checks if tool has any availble quantity
            if (availableQuantity != 0)
            {
                availableQuantity--;
                noBorrowings++;

                borrowers.add(aMember);                
            }
            else
            {
                Console.WriteLine("\nUnfortunately there are no " + name + "'s available.\n");
            }
        }

        /// <summary>
        /// Removes a member from this tool's member collection and
        /// increases its available quantity
        /// </summary>
        /// <param name="aMember">Member object to be removed</param>
        public void deleteBorrower(Member aMember)
        {
            // Checking if member exists in member collection
            if (borrowers.search(aMember))
            {
                availableQuantity++;
                borrowers.delete(aMember);
            }
            else
            {
                Console.WriteLine(aMember.FirstName + " " + aMember.LastName +
                    " does not currently have this tool borrowed.");
            }
        }

        /// <summary>
        /// CompareTo() override that allows tool names to be compared
        /// </summary>
        /// <param name="other">Tool object to be compared</param>
        /// <returns>An integer representing alphabetical positioning</returns>
        public int CompareTo(Tool other)
        {
            if (name.CompareTo(other.name) < 0)
            {
                return -1;
            }
            // Tool names are the same
            else if (name.CompareTo(other.name) == 0)
            {
                return 0;
            }

            return 1;
        }

        /// <summary>
        /// ToString() override that formats the Console output for Tool objects
        /// </summary>
        /// <returns>Formatted string</returns>
        public override string ToString()
        {
            return "Tool name: " + name +
                "\n\t    Quantity: " + quantity +
                "\n\t    Total available: " + availableQuantity + "\n";            
        }
    }
}
