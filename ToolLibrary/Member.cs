using System;
namespace ToolLibrary
{
    /// <summary>
    /// Base member object class for representing members in the system.
    /// Contains methods that affect tools held by this member.
    /// </summary>
    public class Member : iMember, IComparable<Member>
    {
        private string firstName;
        private string lastName;
        private string contactNumber;
        private string pin;
        private int toolCount, index = 0;
        private string[] tools = new string[3];
        private Tool[] toolArray = new Tool[3];

        public Member(string firstName, string lastName, string contactNumber, string pin)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.contactNumber = contactNumber;
            this.pin = pin;                    
        }

        // Second constructor for comparisons in certain methods
        public Member(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        public string ContactNumber
        {
            get
            {
                return contactNumber;
            }
            set
            {
                contactNumber = value;
            }
        }

        public string PIN
        {
            get
            {
                return pin;
            }
            set
            {
                pin = value;
            }
        }
        
        public string[] Tools
        {
            get
            {
                return tools;
            }
        }

        public Tool[] ToolArray
        {
            get
            {
                return toolArray;
            }
        }


        /// <summary>
        /// Adds a tool object to both a string array and tool collection
        /// held by this member.     
        /// </summary>
        /// <param name="aTool">Tool object to be added</param>
        public void addTool(Tool aTool)
        {
            // If member has reached their max tool allowance
            if (toolCount == 3)
            {
                Console.WriteLine("You've reached your borrow limit of 3 items max.");
            }
            else
            {                
                Console.WriteLine("\nSuccessfully added " + aTool.Name + " to your borrowed tools.");

                // Add tool to both the member's string tool array and tool object array
                toolArray[index] = aTool;
                tools[index] = aTool.Name;
                
                toolCount++;
                index++; // Move the array index up one
            }            
        }        

        /// <summary>
        /// Removes a given tool object from both the member's string array
        /// and personal tool collection.
        /// </summary>
        /// <param name="aTool">Tool object to be removed</param>
        public void deleteTool(Tool aTool)
        {
            bool found = false;

            for (int i = 0; i < Tools.Length; i++)
            {
                // Checks if entered tool's name matches any of the names in
                // this member's tool string array
                if (aTool.Name == Tools[i] && found == false)
                {
                    Console.WriteLine(aTool.Name + " has been successfully removed from" +
                    " your borrowed items.\n");

                    // Remove tool from both arrays and update count and index
                    toolArray[i] = null;
                    Tools[i] = null;
                    toolCount--;
                    index--;

                    // Changes bool check so error message below doesn't show
                    found = true;                    
                }
                // If any remaining array items after deleted value, shift them all
                // forward one place
                if (found == true && Tools[i] != null)
                {
                    Tools[i - 1] = Tools[i];
                    toolArray[i - 1] = toolArray[i];
                }
            }

            if (found == true)
            {
                // Removes the duplicate final value of both arrays after shift
                Tools[index] = null;
                toolArray[index] = null;
            }
            else 
            {
                Console.WriteLine("Could not find " + aTool.Name + " in your borrowed items.");
            }
        }

        /// <summary>
        /// CompareTo() override that compares members last names first,
        /// then first names.
        /// </summary>
        /// <param name="other">Member object to be compared</param>
        /// <returns>An integer representing alphabetical positioning</returns>
        public int CompareTo(Member other)
        {            
            // If last name comes before
            if (this.lastName.CompareTo(other.lastName) < 0)
            {
                return -1;
            }
            // Last names are the same, so compare first names
            else if (this.lastName.CompareTo(other.lastName) == 0)
            {
                // First name comes before
                if (this.firstName.CompareTo(other.firstName) < 0)
                {
                    return -1;
                }
                // Both first and last names are the same
                else if (this.firstName.CompareTo(other.firstName) == 0)
                {
                    return 0;
                }
            }
            return 1;
        }

        /// <summary>
        /// ToString() override that formats Console output for Member objects
        /// </summary>
        /// <returns>Formatted string</returns>
        public override string ToString()
        {
            return "Member Name: " + firstName + " " + lastName + "\n" +
                "\tContact Number: " + contactNumber + "\n" +
                "\tPIN: " + pin;
        }
    }
}
