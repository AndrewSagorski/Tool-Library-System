using System;
namespace ToolLibrary
{
    /// <summary>
    /// The main class to be utilised by the main program. Uses methods that hookup
    /// functionality between Tool Collections and Member Collections, as well as between
    /// Member and Tool objects. Facilitates the menu functionalities of the main program
    /// menus.
    /// </summary>
    public class ToolLibrarySystem : iToolLibrarySystem
    {
        private MemberCollection members;
        private ToolCollection tools;
        private Tool[] top3Tools = new Tool[1];
        private int category, toolType;

        // String parallel jagged array for indexing program.cs collection
        private string[][] stringCategories;

        // Tool Collection jagged array for indexing program.cs collection
        private ToolCollection[][] toolCategories;

        public ToolLibrarySystem(MemberCollection members)
        {
            this.members = members;
        }       

        // Takes string jagged array from program.cs
        public string[][] StringCategories
        {
            get
            {
                return stringCategories;
            }
            set
            {
                stringCategories = value;
            }
        }

        // Takes tool collection jagged array from program.cs
        public ToolCollection[][] ToolCategories
        {
            get
            {
                return toolCategories;
            }
            set
            {
                toolCategories = value;
            }
        }

        // Takes category index from program.cs
        public int Category
        {
            get
            {
                return category;
            }
            set
            {
                category = value;
            }
        }

        // Takes tool type index from program.cs
        public int ToolType
        {
            get
            {
                return toolType;
            }
            set
            {
                toolType = value;
            }
        }


        /// <summary>
        /// Method for adding a single new Tool to the library system for the
        /// main program functionality.
        /// </summary>
        /// <param name="aTool">Tool to be added</param>
        public void add(Tool aTool)
        {
            bool duplicate = false;            
            Tool[] toolArray = toolCategories[category][toolType].toArray();

            // Checking if tool already exists
            for (int i = 0; i < toolArray.Length; i++)
            {
                if (toolArray[i] == null)
                {
                    break;
                }
                else if (toolArray[i].Name == aTool.Name)
                {
                    duplicate = true;

                    Console.WriteLine("\nTool already exists in " + stringCategories[category][toolType] + "...\n");                    
                }
            }

            // Tool does not already exist
            if (duplicate == false)
            {
                Console.WriteLine("\nSuccessfully added " + aTool.Name + " to " +
                                  stringCategories[category][toolType]);
                Console.WriteLine();

                // Using indexing from program.cs the tool is added to the
                // correct collection and position
                toolCategories[category][toolType].add(aTool);
            }

        }

        /// <summary>
        /// Adds a given quantity to an existing Tool within the library
        /// system.
        /// </summary>
        /// <param name="aTool">Tool to have quantity updated</param>
        /// <param name="quantity">Quantity to add to Tool</param>
        public void add(Tool aTool, int quantity)
        {
            // Runs the ToolCollection add() method to the entered
            // quantity
            for (int i = 0; i < quantity; i++)
            {
                toolCategories[category][toolType].add(aTool);
            }

            Console.WriteLine("\nQuantity of " + aTool.Name + " successfully updated to " +
                aTool.Quantity + ".\n");
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }

        /// <summary>
        /// Adds a Member to the library's Member Collection.
        /// </summary>
        /// <param name="aMember">Member object to be added</param>
        public void add(Member aMember)
        {            
            // Member collection add() already checks if member exists,
            // so all that needs to be done is to call the method and
            // notify of member already existing if so
            if (members.search(aMember))
            {
                Console.WriteLine("\n\t" + aMember.FirstName + " " + aMember.LastName +
                    " already exists in the system...\n");
                return;
            }

            Console.WriteLine("\nSuccessfully added " + aMember.FirstName +
                                  " to the system.");
            members.add(aMember);
        }

        /// <summary>
        /// Method runs the relevant functionality for updating both the
        /// entered Member and Tool's details for when a tool is borrowed
        /// in the system.
        /// </summary>
        /// <param name="aMember">Member that is borrowing the Tool</param>
        /// <param name="aTool">Tool to be borrowed</param>
        public void borrowTool(Member aMember, Tool aTool)
        {
            // Checks if the member doesn't already hold 3 tools and if the
            // tool to be borrowed has any available quantity
            if (aMember.Tools[2] == null && aTool.AvailableQuantity > 0)
            {
                aTool.addBorrower(aMember);
                aMember.addTool(aTool);

                // Runs method to add the borrowed tool to a local Tool array
                // for later top three tool functionality
                addToBorrowedTools(aTool);
            }
            else if (aMember.Tools[2] != null)
            {
                // Member already has three tools, the Member addTool()
                // method contains the relevant error message
                aMember.addTool(aTool);
            }
            else
            {
                // Tool has no available pieces, Tool method has relevant
                // error message
                aTool.addBorrower(aMember);
            }            
        }

        /// <summary>
        /// Method for removing a single piece of an existing Tool from the
        /// library system.
        /// </summary>
        /// <param name="aTool">Tool object to be updated</param>
        public void delete(Tool aTool)
        {
            if (aTool.AvailableQuantity == 0)
            {
                Console.WriteLine("\n\tThere are no " + aTool.Name + "'s available to remove...\n");
            }
            else
            {
                Console.WriteLine("\n\tSuccessfully removed one " + aTool.Name + ".\n");

                aTool.Quantity--;
                aTool.AvailableQuantity--;                
            }
        }

        /// <summary>
        /// Method for removing a given quantity of the given Tool from
        /// the library system.
        /// </summary>
        /// <param name="aTool">Tool object to be updated</param>
        /// <param name="quantity">Quantity to remove</param>
        public void delete(Tool aTool, int quantity)
        {
            // First check the tool's available quantity
            if (aTool.AvailableQuantity == 0)
            {
                Console.WriteLine("\n\tThere are no " + aTool.Name + "'s available to remove...\n");
            }
            else if (aTool.AvailableQuantity < quantity)
            {
                Console.WriteLine("\n\tThe quantity you wish to remove exceeds the amount of " + aTool.Name + "'s available...\n");
            }
            else
            {
                aTool.Quantity -= quantity;
                aTool.AvailableQuantity -= quantity;

                Console.WriteLine("\n\tUpdated the quantity of " + aTool.Name + " to " + aTool.Quantity + ".\n");
            }            
        }

        /// <summary>
        /// Method for removing a Member from the library system.
        /// </summary>
        /// <param name="aMember">Member to be removed</param>
        public void delete(Member aMember)
        {
            // Retrieve the list of tools currently held by the member
            string[] tools;            
            tools = aMember.Tools;

            // If member currently holds no tools
            if (tools[0] == null)
            {
                members.delete(aMember);
                Console.WriteLine("\nSuccessfully removed " + aMember.FirstName +
                    " " + aMember.LastName + " from the system.");
            }
            // Member is currently holding tools, so they cannot be deleted
            else
            {
                Console.WriteLine("Cannot remove " + aMember.FirstName +
                    " " + aMember.LastName + " as they currently have tools borrowed.");
            }
        }

        /// <summary>
        /// Given a Member, this method displays the names of the tools they currently
        /// have on loan.
        /// </summary>
        /// <param name="aMember">Member whose tools are to be displayed</param>
        public void displayBorrowingTools(Member aMember)
        {
            bool toolsBorrowed = false;

            for (int i = 0; i < aMember.Tools.Length; i++)
            {
                // Member contains tools, they're displayed
                if (aMember.Tools[i] != null)
                {
                    toolsBorrowed = true;
                    Console.WriteLine("\t- " + aMember.Tools[i]);
                }
            }

            if (toolsBorrowed == false)
            {
                Console.WriteLine("\n\tYou currently have no tools borrowed...\n");
            }
        }

        /// <summary>
        /// Given the name of a tool type, this method displays all tools within
        /// said type.
        /// </summary>
        /// <param name="aToolType">Name of Tool Type to be displayed</param>
        public void displayTools(string aToolType)
        {
            bool found = false;
            Console.WriteLine();

            // Runs through jagged string array containing tool categories and tool
            // types
            for (int i = 0; i < stringCategories[category].Length; i++)
            {
                // If searched name matches any existing tool types
                if (stringCategories[category][i] == aToolType)
                {
                    toolType = i;

                    // Takes indexes from found name in string arrays and uses them
                    // to retrieve Tool Array for displaying to console
                    Tool[] toolArray = toolCategories[category][toolType].toArray();
                    found = true;

                    Console.WriteLine("Tools currently in " + aToolType + ":\n");

                    for (int j = 0; j < toolArray.Length; j++)
                    {
                        if (toolArray[0] == null)
                        {
                            Console.WriteLine("\t--There are currently no tools available in " +
                                              stringCategories[category][toolType] + "--");
                            return;
                        }
                        else if (toolArray[j] != null)
                        {                            
                            Console.WriteLine("\tTool Name: " + toolArray[j].Name);
                            Console.WriteLine("\tQuantity: " + toolArray[j].Quantity);
                            Console.WriteLine("\tAvailable Quantity: " + toolArray[j].AvailableQuantity);
                            Console.WriteLine("\tNumber of Borrowings: " + toolArray[j].NoBorrowings);
                            Console.WriteLine("--------------------------------------------------------------");
                        }
                    }                    
                }
            }

            if (found == false)
            {
                Console.WriteLine("Could not find " + aToolType + " in the library.");
                return;
            }                       
        }

        /// <summary>
        /// Adds Tools that have been borrowed by members to a local Tool array.
        /// This array is used for finding the top three most borrowed tools in the
        /// system.
        /// </summary>
        /// <param name="aTool">Tool object to be added</param>
        private void addToBorrowedTools(Tool aTool)
        {            
            for (int i = 0; i < top3Tools.Length; i++)
            {
                // Checks if Tool already exists in array and adds it in if not
                if (top3Tools[i] == null) 
                {
                    top3Tools[i] = aTool;
                    break;
                }
                // If tool already exists in array, do nothing
                else if (top3Tools[i].CompareTo(aTool) == 0)
                {
                    return;
                }
            }

            // Increase array size of top3Tools by one
            top3Tools = increaseArraySize(top3Tools);
        }

        /// <summary>
        /// Increases the size of a given array by one position.
        /// </summary>
        /// <param name="oldArray">Array to be increased</param>
        /// <returns>An array with the same contents, one position larger</returns>
        private Tool[] increaseArraySize(Tool[] oldArray)
        {
            Tool[] newArray = new Tool[oldArray.Length + 1];

            for (int i = 0; i < oldArray.Length; i++)
            {
                if (oldArray[i] != null)
                {
                    newArray[i] = oldArray[i];
                }
            }

            return newArray;
        }

        /// <summary>
        /// Using the heap sort functionality, this method displays the top 3 tools
        /// from the top3Tools array with the most number of borrowings in decreasing
        /// order.
        /// </summary>
        public void displayTopThree()
        {
            Tool[] topThreeTools;

            if (top3Tools[0] == null)
            {
                Console.WriteLine("\tCurrently no tools have been borrowed.\n");
                return;
            }

            // Passing top three tools from heap sort method to a Tool array
            topThreeTools = HeapSort(top3Tools);

            for (int i = 0; i < topThreeTools.Length; i++)
            {
                if (topThreeTools[i] != null)
                {
                    Console.WriteLine("\t" + (i+1) + ". " + topThreeTools[i].ToString() +
                        "\t    Number of Borrowings: " + topThreeTools[i].NoBorrowings + "\n");
                }                
            }            
        }
        
        /// <summary>
        /// This method retrieves the string array of tools currently held by a given
        /// member.
        /// </summary>
        /// <param name="aMember">Member whose tools are to be retrieved</param>
        /// <returns>String array containing the names of the borrowed tools</returns>
        public string[] listTools(Member aMember)
        {
            return aMember.Tools;
        }

        /// <summary>
        /// This method allows the functionality needed for when a member returns
        /// a tool. 
        /// </summary>
        /// <param name="aMember">Member returning tool</param>
        /// <param name="aTool">Tool to be returned</param>
        public void returnTool(Member aMember, Tool aTool)
        {
            int toolNum = 0;

            // Check how many times member has specific tool
            string[] memberTools = aMember.Tools;

            for (int i = 0; i < memberTools.Length; i++)
            {
                if (aTool.Name == memberTools[i])
                {
                    toolNum++;
                }
            }

            // If member has multiple of given tool, only update the
            // available quantity not remove them from the tool's
            // member collection
            if (toolNum > 1)
            {
                aMember.deleteTool(aTool);
                aTool.AvailableQuantity++;

                return;
            }
           
            // Else run both the Tool and Member methods to remove each other
            // from their held items
            aTool.deleteBorrower(aMember);
            aMember.deleteTool(aTool);
        }

        /// <summary>
        /// Finds the number of elements in a given Tool array, ignoring null
        /// values.
        /// </summary>
        /// <param name="toolArray">Tool array to be checked</param>
        /// <returns>Number of Tool items in array</returns>
        private int getToolArrayLength(Tool[] toolArray)
        {
            int length = 0;            
            for (int i = 0; i < toolArray.Length; i++)
            {
                if (toolArray[i] != null)
                {
                    length++;
                }
            }

            return length;
        }

        /// <summary>
        /// Sorts a given Tool array into a heap with each Tool's number of
        /// borrowings as the key.
        /// </summary>
        /// <param name="data">Tool array to be sorted</param>
        private void HeapBottomUp(Tool[] data)
        {
            // Passing in the number of elements from the given tool array
            int numElements = getToolArrayLength(data);

            // Starting from the middle of the array, moving to the left
            for (int i = (numElements - 1) / 2; i >= 0; i--) 
            {
                int index = i;
                Tool indexTool = data[i];
                bool heap = false;

                while ((!heap) && ((2 * index + 1) <= (numElements - 1)))
                {
                    int leftChild = 2 * index + 1;  // The left child of the index

                    if (leftChild < (numElements - 1))   // index has two children
                        if (data[leftChild].NoBorrowings < data[leftChild + 1].NoBorrowings)
                            leftChild = leftChild + 1;  // leftChild is the larger child of the index

                    if (indexTool.NoBorrowings >= data[leftChild].NoBorrowings)
                        heap = true;

                    else
                    {
                        data[index] = data[leftChild];
                        index = leftChild;
                    }
                }
                data[index] = indexTool;
            }
        }        

        /// <summary>
        /// The main sorting algorithm method for retrieving the top three most
        /// borrowed tools of the system.
        /// </summary>
        /// <param name="data">Array to be sorted</param>
        /// <returns>
        /// Tool array containing top three most borrowed tools in descending order
        /// </returns>
        private Tool[] HeapSort(Tool[] data)
        {
            int arrayLength = getToolArrayLength(data);
            // Array to hold top three tools from system
            Tool[] topThree = new Tool[3];

            // Use the HeapBottomUp procedure to convert the given array into a heap
            HeapBottomUp(data);

            // If the current number of tools to sort is less than three, maximum
            // key deletion is only called in regards to the number of elements
            if (arrayLength < 3)
            {
                for (int i = 0; i < arrayLength; i++) 
                {
                    topThree[i] = MaxKeyDelete(data, arrayLength - i); 
                }
            }
            // Otherwise maximum key deletion is called three times only to retrieve
            // the top three most borrowed tools
            else
            {
                for (int i = 0; i < 3; i++) 
                {
                    topThree[i] = MaxKeyDelete(data, arrayLength - i);
                }
            }

            return topThree;            
        }
        
        /// <summary>
        /// Method to delete the maximum key of a given sorted heap.
        /// Largest key is moved to the end of the unsorted array each time this
        /// is run.
        /// </summary>
        /// <param name="data">Tool array to be sorted</param>
        /// <param name="size">Size of the heap</param>
        /// <returns>
        /// The Tool with the largest number of borrowings in the given
        /// array
        /// </returns>
        private Tool MaxKeyDelete(Tool[] data, int size)
        {            
            // Exchange the root’s key with the last key K of the heap;
            Tool temp = data[0];
            data[0] = data[size - 1];
            data[size - 1] = temp;

            // Decrease the heap’s size by 1;
            int heapSize = size - 1;

            // “Heapify” the complete binary tree.
            bool heap = false;
            int k = 0;
            Tool v = data[0];

            while ((!heap) && ((2 * k + 1) <= (heapSize - 1)))
            {
                int j = 2 * k + 1; // The left child of k

                if (j < (heapSize - 1))   // k has two children
                    if (data[j].NoBorrowings < data[j + 1].NoBorrowings)
                        j = j + 1;  // j is the larger child of k

                if (v.NoBorrowings >= data[j].NoBorrowings)
                    heap = true;

                else
                {
                    data[k] = data[j];
                    k = j;
                }
            }
            data[k] = v;

            return data[heapSize];            
        }
    }
}
