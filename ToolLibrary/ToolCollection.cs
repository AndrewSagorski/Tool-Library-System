using System;
namespace ToolLibrary
{
    /// <summary>
    /// This class works as the storage system for Tool objects, makes
    /// use of an array.
    /// Contains methods for adding, removing and indexing tools.
    /// </summary>
    public class ToolCollection : iToolCollection
    {
        private Tool[] collection;
        private int number = 0; 
        private int index = 0;

        public ToolCollection()
        {
            collection = new Tool[1];
        }

        // Returns the number of tools within the Tool Collection
        public int Number
        {
            get
            {
                return number;
            }
        }
        
        /// <summary>
        /// Adds a given tool to the Tool Collection array and updates
        /// relevant quantities.
        /// </summary>
        /// <param name="aTool">Tool object to be added</param>
        public void add(Tool aTool)
        {
            bool found = false;

            // First search array if tool already exists
            for (int i = 0; i < collection.Length; i++)
            {
                if (collection[i] == aTool)
                {
                    found = true;

                    collection[i].Quantity++;
                    collection[i].AvailableQuantity++;
                }

            }

            // If tool doesn't already exist, add to array and update the
            // array index
            if (found == false)
            {                
                collection[index] = aTool;

                // Increasing array size
                collection = increaseArraySize(collection);

                index++;                
                number++;
            }
        }

        /// <summary>
        /// Deletes a given tool from the tool collection array and updates
        /// relevant quantities.
        /// </summary>
        /// <param name="aTool">Tool object to be removed</param>
        public void delete(Tool aTool)
        {
            // Bool check for if tool is found within tool collection
            bool found = false;

            for (int i = 0; i < collection.Length; i++)
            {
                if (collection[i] == aTool && found == false) 
                {
                    found = true;
                    
                    collection[i] = null;
                    index--;
                    number--;
                }
                // If any remaining values after removed tool object, this
                // shifts them all one position to the left
                if (found == true && collection[i] != null)
                {
                    collection[i - 1] = collection[i];
                }
            }

            // if found, make the copy of the final value in the array null
            if (found == true)
            {
                collection[index] = null;
            }
            else
            {
                Console.WriteLine("Could not find " + aTool.Name + " in the tool collection\n");
            }
        }

        /// <summary>
        /// A search method for finding out if a given tool exists
        /// within this tool collection.
        /// </summary>
        /// <param name="aTool">Tool object to be found</param>
        /// <returns>True if tool exists in system, false otherwise</returns>
        public bool search(Tool aTool)
        {
            for (int i = 0; i < collection.Length; i++)
            {
                if (collection[i] == aTool)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Outputs the tools in this collection to an array of Tool
        /// </summary>
        /// <returns>Tool array</returns>
        public Tool[] toArray()
        {
            return collection;
        }

        /// <summary>
        /// Method for increasing the size of the existing Tool array.
        /// Useful for not creating arrays of sizes too large for the
        /// user's needs.
        /// </summary>
        /// <param name="oldArray">Existing Tool array to be increased</param>
        /// <returns>A Tool array with one new position at the end</returns>
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
    }
}
