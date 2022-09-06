using System;
using System.Linq;

namespace ToolLibrary
{
    /// <summary>
    /// Main class where main program resides. This class contains all the main console methods
    /// as well as pre-initialised Tool and Member collections to be used.
    /// </summary>
    class MainClass
    {
        // Initialising members for testing
        public static Member angus = new Member("Angus", "Marduk", "123456789", "1234");
        public static Member wilford = new Member("Wilford", "Smolder", "223456789", "1234");
        public static Member braydon = new Member("Braydon", "Drofftick", "323456789", "1234");
        public static Member sonny = new Member("Sammy", "Bill", "423456789", "1234");
        public static Member steph = new Member("Steph", "Smith", "523456789", "1234");

        // Member for quick access to Member menus and testing
        public static Member testMember = new Member("", "", "000000000", "");

        // Initialising tools for testing
        public static Tool lineTrimmerTool = new Tool("Line Trimmer Tool 1", 5, 5, 0);
        public static Tool lineTrimmerTool2 = new Tool("Line Trimmer Tool 2", 10, 10, 0);
        public static Tool lineTrimmerTool3 = new Tool("Line Trimmer Tool 3", 20, 20, 0);

        public static Tool sandingTool1 = new Tool("Sanding Tool 1", 5, 5, 0);
        public static Tool sandingTool2 = new Tool("Sanding Tool 2", 5, 5, 0);
        public static Tool sandingTool3 = new Tool("Sanding Tool 3", 10, 10, 0);

        public static Tool laserMeasurer1 = new Tool("Laser Measurer 1", 10, 10, 0);

        public static Tool levellingTool1 = new Tool("Levelling Tool 1", 5, 5, 0);

        // Initialising the Member Collection
        public static MemberCollection members = new MemberCollection();                

        // Tool Categories for menus
        public static string[] categories = { "Gardening Tools", "Flooring Tools", "Fencing Tools",
                                    "Measuring Tools", "Cleaning Tools", "Painting Tools",
                                    "Electronic Tools", "Electricity Tools", "Automotive Tools" };

        // Tool Types for menus
        public static string[] gardeningToolTypes = { "Line Trimmers", "Lawn Mowers", "Hand Tools",
                                            "Wheelbarrows", "Garden Power Tools" };

        public static string[] flooringToolTypes = { "Scrapers", "Floor Lasers", "Floor Levelling Tools",
                                           "Floor Levelling Materials", "Floor Hand Tools",
                                           "Tiling Tools" };

        public static string[] fencingToolTypes = { "Hand Tools", "Electric Fencing", "Steel Fencing Tools",
                                          "Power Tools", "Fencing Accessories" };

        public static string[] measuringToolTypes = { "Distance Tools", "Laser Measurer", "Measuring Jugs",
                                            "Temperature & Humidity Tools", "Levelling Tools",
                                            "Markers" };

        public static string[] cleaningToolTypes = { "Draining", "Car Cleaning", "Vacuum", "Pressure Cleaners",
                                           "Pool Cleaning", "Floor Cleaning" };

        public static string[] paintingToolTypes = { "Sanding Tools", "Brushes", "Rollers", "Paint Removal Tools",
                                           "Paint Scrapers", "Sprayers" };

        public static string[] electronicToolTypes = { "Voltage Tester", "Oscilloscopes", "Thermal Imaging",
                                             "Data Test Tool", "Insulation Testers" };

        public static string[] electricityToolTypes = { "Test Equipment", "Safety Equipment", "Basic Hand Tools",
                                              "Circuit Protection", "Cable Tools"};

        public static string[] automotiveToolTypes = { "Jacks", "Air Compressors", "Battery Chargers",
                                             "Socket Tools", "Braking", "Drivetrain" };

        // Jagged straing array for holding all the above string arrays
        public static string[][] toolTypeStrings = new string[9][];

        // ToolCollection arrays for each category to hold the Tool Types
        public static ToolCollection[] gardeningTools = new ToolCollection[5];
        public static ToolCollection[] flooringTools = new ToolCollection[6];
        public static ToolCollection[] fencingTools = new ToolCollection[5];
        public static ToolCollection[] measuringTools = new ToolCollection[6];
        public static ToolCollection[] cleaningTools = new ToolCollection[6];
        public static ToolCollection[] paintingTools = new ToolCollection[6];
        public static ToolCollection[] electronicTools = new ToolCollection[5];
        public static ToolCollection[] electricityTools = new ToolCollection[5];
        public static ToolCollection[] automotiveTools = new ToolCollection[6];

        // ToolCollection jagged array to hold all the categories
        public static ToolCollection[][] toolCategories = new ToolCollection[9][];

        /**
         * Tool Collections for Tool Types
         */
        // Gardening Tools
        public static ToolCollection lineTrimmers = new ToolCollection();
        public static ToolCollection lawnMowers = new ToolCollection();
        public static ToolCollection handTools = new ToolCollection();
        public static ToolCollection wheelBarrows = new ToolCollection();
        public static ToolCollection gardenPowerTools = new ToolCollection();

        // Flooring Tools
        public static ToolCollection scrapers = new ToolCollection();
        public static ToolCollection floorLasers = new ToolCollection();
        public static ToolCollection floorLevellingTools = new ToolCollection();
        public static ToolCollection floorLevellingMaterials = new ToolCollection();
        public static ToolCollection floorHandTools = new ToolCollection();
        public static ToolCollection tilingTools = new ToolCollection();

        // Fencing Tools
        public static ToolCollection fencingHandTools = new ToolCollection();
        public static ToolCollection electricFencing = new ToolCollection();
        public static ToolCollection steelFencingTools = new ToolCollection();
        public static ToolCollection powerTools = new ToolCollection();
        public static ToolCollection fencingAccessories = new ToolCollection();

        // Measuring Tools
        public static ToolCollection distanceTools = new ToolCollection();
        public static ToolCollection laserMeasurers = new ToolCollection();
        public static ToolCollection measuringJugs = new ToolCollection();
        public static ToolCollection tempHumidityTools = new ToolCollection();
        public static ToolCollection levellingTools = new ToolCollection();
        public static ToolCollection markers = new ToolCollection();

        // Cleaning Tools
        public static ToolCollection draining = new ToolCollection();
        public static ToolCollection carCleaning = new ToolCollection();
        public static ToolCollection vacuum = new ToolCollection();
        public static ToolCollection pressureCleaners = new ToolCollection();
        public static ToolCollection poolCleaning = new ToolCollection();
        public static ToolCollection floorCleaning = new ToolCollection();

        // Painting Tools
        public static ToolCollection sandingTools = new ToolCollection();
        public static ToolCollection brushes = new ToolCollection();
        public static ToolCollection rollers = new ToolCollection();
        public static ToolCollection paintRemovalTools = new ToolCollection();
        public static ToolCollection paintScrapers = new ToolCollection();
        public static ToolCollection sprayers = new ToolCollection();

        // Electronic Tools
        public static ToolCollection voltageTester = new ToolCollection();
        public static ToolCollection oscilloscopes = new ToolCollection();
        public static ToolCollection thermalImaging = new ToolCollection();
        public static ToolCollection dataTestTool = new ToolCollection();
        public static ToolCollection insulationTesters = new ToolCollection();

        // Electricity Tools
        public static ToolCollection testEquipment = new ToolCollection();
        public static ToolCollection safetyEquipment = new ToolCollection();
        public static ToolCollection basicHandTools = new ToolCollection();
        public static ToolCollection circuitProtection = new ToolCollection();
        public static ToolCollection cableTools = new ToolCollection();

        // Automotive Tools
        public static ToolCollection jacks = new ToolCollection();
        public static ToolCollection airCompressors = new ToolCollection();
        public static ToolCollection batteryChargers = new ToolCollection();
        public static ToolCollection socketTools = new ToolCollection();
        public static ToolCollection braking = new ToolCollection();
        public static ToolCollection drivetrain = new ToolCollection();

        // Initialising the ToolLibrarySystem
        public static ToolLibrarySystem librarySystem = new ToolLibrarySystem(members);

        /// <summary>
        /// Main method that runs the console program.
        /// </summary>
        /// <param name="args">String array for additional data</param>
        public static void Main(string[] args)
        {
            // Main based console app
            bool menu = true;
            Console.Clear();
            initVaribles();
           
            while (menu)
            {
                menu = mainMenu();

            }
        }

        /// <summary>
        /// Initialises all pre-ordered variables, adds Members and Tools to their
        /// respective collections, and adds tool collections to their relevant indexed
        /// positions.
        /// To be run before the Console application starts.
        /// </summary>
        public static void initVaribles()
        {
            // Adding pre-initialised members to system MemberCollection
            members.add(angus);
            members.add(braydon);
            members.add(wilford);
            members.add(steph);
            members.add(sonny);

            // Adding test member
            //members.add(testMember);

            // Adding category ToolCollection arrays to ToolCollection jagged array
            toolCategories[0] = gardeningTools;
            toolCategories[1] = flooringTools;
            toolCategories[2] = fencingTools;
            toolCategories[3] = measuringTools;
            toolCategories[4] = cleaningTools;
            toolCategories[5] = paintingTools;
            toolCategories[6] = electronicTools;
            toolCategories[7] = electricityTools;
            toolCategories[8] = automotiveTools;

            // String jagged array
            toolTypeStrings[0] = gardeningToolTypes;
            toolTypeStrings[1] = flooringToolTypes;
            toolTypeStrings[2] = fencingToolTypes;
            toolTypeStrings[3] = measuringToolTypes;
            toolTypeStrings[4] = cleaningToolTypes;
            toolTypeStrings[5] = paintingToolTypes;
            toolTypeStrings[6] = electronicToolTypes;
            toolTypeStrings[7] = electricityToolTypes;
            toolTypeStrings[8] = automotiveToolTypes;

            // Adding pre-initialised tools to lineTrimmers ToolCollection
            lineTrimmers.add(lineTrimmerTool);
            lineTrimmers.add(lineTrimmerTool2);
            lineTrimmers.add(lineTrimmerTool3);

            // Adding tool type ToolCollections to their respective category
            // ToolCollection arrays
            gardeningTools[0] = lineTrimmers;
            gardeningTools[1] = lawnMowers;
            gardeningTools[2] = handTools;
            gardeningTools[3] = wheelBarrows;
            gardeningTools[4] = gardenPowerTools;

            flooringTools[0] = scrapers;
            flooringTools[1] = floorLasers;
            flooringTools[2] = floorLevellingTools;
            flooringTools[3] = floorLevellingMaterials;
            flooringTools[4] = floorHandTools;
            flooringTools[5] = tilingTools;

            fencingTools[0] = fencingHandTools;
            fencingTools[1] = electricFencing;
            fencingTools[2] = steelFencingTools;
            fencingTools[3] = powerTools;
            fencingTools[4] = fencingAccessories;

            laserMeasurers.add(laserMeasurer1);
            levellingTools.add(levellingTool1);

            measuringTools[0] = distanceTools;
            measuringTools[1] = laserMeasurers;
            measuringTools[2] = measuringJugs;
            measuringTools[3] = tempHumidityTools;
            measuringTools[4] = levellingTools;
            measuringTools[5] = markers;

            cleaningTools[0] = draining;
            cleaningTools[1] = carCleaning;
            cleaningTools[2] = vacuum;
            cleaningTools[3] = pressureCleaners;
            cleaningTools[4] = poolCleaning;
            cleaningTools[5] = floorCleaning;
            
            sandingTools.add(sandingTool1);
            sandingTools.add(sandingTool2);
            sandingTools.add(sandingTool3);

            paintingTools[0] = sandingTools;
            paintingTools[1] = brushes;
            paintingTools[2] = rollers;
            paintingTools[3] = paintRemovalTools;
            paintingTools[4] = paintScrapers;
            paintingTools[5] = sprayers;

            electronicTools[0] = voltageTester;
            electronicTools[1] = oscilloscopes;
            electronicTools[2] = thermalImaging;
            electronicTools[3] = dataTestTool;
            electronicTools[4] = insulationTesters;

            electricityTools[0] = testEquipment;
            electricityTools[1] = safetyEquipment;
            electricityTools[2] = basicHandTools;
            electricityTools[3] = circuitProtection;
            electricityTools[4] = cableTools;

            automotiveTools[0] = jacks;
            automotiveTools[1] = airCompressors;
            automotiveTools[2] = batteryChargers;
            automotiveTools[3] = socketTools;
            automotiveTools[4] = braking;
            automotiveTools[5] = drivetrain;

            // Adding ToolCollection jagged array to ToolLibrarySystem
            librarySystem.ToolCategories = toolCategories;

            // Adding string arrays to ToolLibrarySystem
            librarySystem.StringCategories = toolTypeStrings;
        }

        /// <summary>
        /// Runs base main menu for access to either the staff or member menus.
        /// </summary>
        /// <returns>True to remain in program, false otherwise</returns>
        public static bool mainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Tool Library\n");
            Console.WriteLine("===============Main Menu===============");
            Console.WriteLine("1. Staff Login");
            Console.WriteLine("2. Member Login");
            Console.WriteLine("0. Exit");
            Console.WriteLine("=======================================\n");

            Console.WriteLine("Please make a selection (1-2, or 0 to exit.)");
         
            switch (Console.ReadLine())
            {
                case "1":
                    staffLogin();
                    return true;
                case "2":
                    memberLogin();
                    return true;
                case "0":
                    return false;
                default:
                    Console.WriteLine("Please use a correct input.");
                    Console.ReadLine();
                    return true;
            }
        }

        /// <summary>
        /// Runs menu screen for staff login. Staff has an existing user and password
        /// to check.
        /// </summary>
        public static void staffLogin()
        {
            string loginName;
            string password;

            Console.Clear();
            Console.WriteLine("===============Staff Login===============");
            Console.Write("Login: ");
            loginName = Console.ReadLine().Trim();

            if (loginName != "staff")
            {
                Console.WriteLine("\nThat user does not exist, press 1 to try again or 0 to exit...");

                if (Console.ReadLine() == "1")
                {
                    staffLogin();
                    return;
                }
                else if (Console.ReadLine() == "0")
                {
                    mainMenu();
                    return;
                }
            }
            else
            {
                Console.Write("\nPassword: ");
                password = Console.ReadLine().Trim();

                if (password != "today123")
                {
                    Console.WriteLine("\nIncorrect password, press 1 to try again or 0 to exit...");

                    if (Console.ReadLine() == "1")
                    {
                        staffLogin();
                        return;
                    }
                    else if (Console.ReadLine() == "0")
                    {
                        mainMenu();
                        return;
                    }
                }
                else
                {
                    staffMenu();
                }
            }
        }

        /// <summary>
        /// Runs menu screen for member login, grants access to member menus or user
        /// can return to main menu.
        /// </summary>
        public static void memberLogin()
        {
            string firstName;
            string lastName;
            string pin;            

            Console.Clear();
            Console.WriteLine("===============Member Login===============");
            Console.Write("First Name: ");
            firstName = Console.ReadLine().Trim();

            Console.Write("\nLast Name: ");
            lastName = Console.ReadLine().Trim();

            Console.Write("\nPIN: ");
            pin = Console.ReadLine().Trim();

            // Creates temporary member for comparison to existing members
            Member temp = new Member(firstName, lastName);
            Member[] memberArray = members.toArray();

            // Runs temporary member through existing members to see if they
            // exist
            for (int i = 0; i < memberArray.Length; i++)
            {
                // If names match up
                if (memberArray[i].CompareTo(temp) == 0)
                {
                    // If pins match up
                    if (memberArray[i].PIN == pin)
                    {                        
                        // User gains access to member menu, specific member object
                        // is sent to member menu method
                        memberMenu(memberArray[i]);
                        return;
                    }                    
                }
            }
            
            Console.WriteLine("Incorrect details, press 1 to try again or any key to exit.\n");
            if (Console.ReadLine() == "1")
            {
                memberLogin();
                return;
            }
            else 
            {
                mainMenu();
            }            
        }

        /// <summary>
        /// Method to run through Tool Collection parallel string arrays.
        /// Displays the tool categories and tool types in menu form, retrieves
        /// indexing of tools from the user for staff functionality.
        /// </summary>
        /// <returns>Integer array containing indexing for jagged arrays</returns>
        public static int[] staffIndexing()
        {
            int[] output = new int[2];
            int categoryInt = 0, toolType = 0;
            string entry;
            bool error = true;

            // Printing out Tool Categories
            Console.WriteLine("\nPlease select a tool category from below:\n");
            for (int i = 0; i < categories.Length; i++)
            {
                Console.WriteLine("\t" + (i + 1) + ". " + categories[i]);
            }
            
            Console.WriteLine("\nPlease make a selection 1-" + categories.Length +
                ", or 0 to exit...");

            switch (Console.ReadLine())
            {
                case "0":
                    staffMenu();
                    break;
                case "1":
                    categoryInt = 0;
                    break;
                case "2":
                    categoryInt = 1;
                    break;
                case "3":
                    categoryInt = 2;
                    break;
                case "4":
                    categoryInt = 3;
                    break;
                case "5":
                    categoryInt = 4;
                    break;
                case "6":
                    categoryInt = 5;
                    break;
                case "7":
                    categoryInt = 6;
                    break;
                case "8":
                    categoryInt = 7;
                    break;
                case "9":
                    categoryInt = 8;
                    break;
                default:
                    Console.WriteLine("Please enter a valid input...");
                    Console.ReadLine();
                    staffIndexing();
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("Please select a tool type from below:\n");

            // Printing out selected tool types
            for (int i = 0; i < toolTypeStrings[categoryInt].Length; i++)
            {                
                Console.WriteLine("\t" + (i + 1) + ". " + toolTypeStrings[categoryInt][i]);
            }

            Console.WriteLine("\nPlease make a selection 1-" + toolTypeStrings[categoryInt].Length +
                              ", or 0 to exit.");
           
            // Error handling for user input
            while (error == true)
            {
                entry = Console.ReadLine();

                // If entry is not a number
                if (!int.TryParse(entry, out toolType))
                {
                    Console.WriteLine("Please enter a valid input...");                    
                }
                else if (int.Parse(entry) == 0)
                {
                    staffMenu();

                    return null;                    
                }
                // If entry is a negative number or outside the bounds of the array
                else if (int.Parse(entry) < 0 || int.Parse(entry) > toolTypeStrings[categoryInt].Length)
                {
                    Console.WriteLine("Please enter a valid input...");                    
                }
                else
                {
                    toolType = int.Parse(entry);                    
                    error = false;
                }
            }

            // Decrease the output number of the tool type index by one to match array
            // indexing
            toolType--;

            output[0] = categoryInt;
            output[1] = toolType;                
            
            return output;
        }

        /// <summary>
        /// Method to run through Tool Collection parallel string arrays.
        /// Displays the tool categories and tool types in menu form, retrieves
        /// indexing of tools from the user for member functionality.
        /// </summary>
        /// <returns>Integer array containing indexing for jagged arrays</returns>
        /// <param name="aMember">Member object representing logged in user</param>
        public static int[] memberIndexing(Member aMember)
        {
            int[] output = new int[2];
            int categoryInt = 0, toolType = 0;
            string entry;
            bool error = true;
            
            Console.WriteLine("\nPlease select a tool category from below:\n");

            // Prints out tool categories
            for (int i = 0; i < categories.Length; i++)
            {
                Console.WriteLine("\t" + (i + 1) + ". " + categories[i]);
            }

            Console.WriteLine("\nPlease make a selection 1-" + categories.Length +
                ", or 0 to exit...");

            switch (Console.ReadLine())
            {
                case "0":
                    memberMenu(aMember);
                    break;
                case "1":
                    categoryInt = 0;
                    break;
                case "2":
                    categoryInt = 1;
                    break;
                case "3":
                    categoryInt = 2;
                    break;
                case "4":
                    categoryInt = 3;
                    break;
                case "5":
                    categoryInt = 4;
                    break;
                case "6":
                    categoryInt = 5;
                    break;
                case "7":
                    categoryInt = 6;
                    break;
                case "8":
                    categoryInt = 7;
                    break;
                case "9":
                    categoryInt = 8;
                    break;
                default:
                    Console.WriteLine("Please enter a valid input...");
                    Console.ReadLine();
                    memberIndexing(aMember);
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("Please select a tool type from below:\n");

            // Printing out selected tool types
            for (int i = 0; i < toolTypeStrings[categoryInt].Length; i++)
            {                                
                Console.WriteLine("\t" + (i+1) + ". " + toolTypeStrings[categoryInt][i]);
            }

            Console.WriteLine("\nPlease make a selection 1-" + toolTypeStrings[categoryInt].Length);
            
            // Error handling for user input
            while (error == true)
            {
                entry = Console.ReadLine();
                                
                if (!int.TryParse(entry, out toolType))
                {
                    Console.WriteLine("Please enter a valid input...");                    
                }
                else if (int.Parse(entry) < 0 || int.Parse(entry) > toolTypeStrings[categoryInt].Length)
                {
                    Console.WriteLine("Please enter a valid input...");                    
                }
                else
                {
                    toolType = int.Parse(entry);
                    error = false;
                }
            }

            toolType--;

            output[0] = categoryInt;
            output[1] = toolType;

            return output;
        }

        /// <summary>
        /// Method for handling main staff menu, gives access to all available
        /// staff functionality.
        /// </summary>
        public static void staffMenu()
        {
            Console.Clear();
            Console.WriteLine("===============Staff Menu===============\n");
            Console.WriteLine("1. Add a new tool");
            Console.WriteLine("2. Add new pieces of an existing tool");
            Console.WriteLine("3. Remove some pieces of a tool");
            Console.WriteLine("4. Register a new member");
            Console.WriteLine("5. Remove a member");
            Console.WriteLine("6. Find the contact number of a member");
            Console.WriteLine("0. Return to main menu");
            Console.WriteLine("\n========================================\n");


            Console.WriteLine("Please make a selection 1-6, or 0 to exit.");

            switch (Console.ReadLine())
            {                
                case "0":
                    mainMenu();
                    break;
                case "1":
                    addANewTool();
                    break;
                case "2":
                    staffAddExistingTool();
                    break;
                case "3":
                    staffRemoveTools();
                    break;
                case "4":
                    staffRegisterMember();
                    break;
                case "5":
                    staffRemoveMember();
                    break;
                case "6":
                    staffFindNumber();
                    break;
                default:
                    Console.WriteLine("Please enter a valid input...");
                    Console.ReadLine();
                    staffMenu();
                    break;
            }
        }

        /// <summary>
        /// This method allows staff to add a new Tool to the Tool Library.
        /// </summary>
        public static void addANewTool()
        {
            int quantity = new int();
            string toolName, entry;            
            bool error = true;
            Tool[] toolArray;

            Console.Clear();

            // Initialise integer array to hold jagged array indexing from the
            // staff indexing method
            int[] indexNumbers = staffIndexing();

            // Display current tools in the tool type
            toolArray = toolCategories[indexNumbers[0]][indexNumbers[1]].toArray();
            Console.WriteLine("Tools currently in " + toolTypeStrings[indexNumbers[0]][indexNumbers[1]] + ":\n");

            for (int i = 0; i < toolArray.Length; i++)
            {
                if (toolArray[0] == null)
                {
                    Console.WriteLine("\tThis tool type is currently empty...\n");
                    break;
                }
                else if (toolArray[i] != null)
                {
                    Console.WriteLine("\tTool Name: " + toolArray[i].Name);
                    Console.WriteLine("\tQuantity: " + toolArray[i].Quantity);
                    Console.WriteLine("\tAvailable Quantity: " + toolArray[i].AvailableQuantity);
                    Console.WriteLine("\tNumber of Borrowings: " + toolArray[i].NoBorrowings);
                    Console.WriteLine("--------------------------------------------------------------");
                }
            }
            Console.WriteLine();

            // Taking user input name for new tool
            Console.Write("Please enter tool name: ");
            toolName = Console.ReadLine().Trim();            
            Console.WriteLine();
            
            Console.Write("Please enter a quantity for this tool: ");

            // Error handling for user input tool quantity
            while (error == true)
            {
                entry = Console.ReadLine();

                if (!int.TryParse(entry, out quantity))
                {
                    Console.WriteLine("Please enter a valid input...");                    
                }
                else if (int.Parse(entry) <= 0)
                {
                    Console.WriteLine("Please enter a number greater than 0...");                    
                }
                else
                {
                    quantity = int.Parse(entry);
                    error = false;
                }
            }

            // Create tool object from user entered details
            Tool newTool = new Tool(toolName, quantity, quantity, 0);

            // Send indexing to ToolLibrarySystem variables
            librarySystem.Category = indexNumbers[0];
            librarySystem.ToolType = indexNumbers[1];

            librarySystem.add(newTool);

            // Displaying tools after addition of new tool
            for (int i = 0; i < toolArray.Length; i++)
            {               
                if (toolArray[i] != null)
                {
                    Console.WriteLine("\tTool Name: " + toolArray[i].Name);
                    Console.WriteLine("\tQuantity: " + toolArray[i].Quantity);
                    Console.WriteLine("\tAvailable Quantity: " + toolArray[i].AvailableQuantity);
                    Console.WriteLine("\tNumber of Borrowings: " + toolArray[i].NoBorrowings);
                    Console.WriteLine("--------------------------------------------------------------");
                }
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();

            staffMenu();
        }

        /// <summary>
        /// Allows staff to add to the quantity of an existing tool within the
        /// system.
        /// </summary>
        public static void staffAddExistingTool()
        {
            bool error = true;
            string entry;
            int toolIndex = new int(), quantity = new int(), numTools = 0;

            Console.Clear();

            // Retrieve tool type index in jagged array 
            int[] indexNumbers = staffIndexing();

            // Send jagged array indexing to ToolLibrarySystem for chosen tool
            // type
            librarySystem.Category = indexNumbers[0];
            librarySystem.ToolType = indexNumbers[1];

            // Local tool array to hold the tools for later display
            Tool[] toolArray = toolCategories[indexNumbers[0]][indexNumbers[1]].toArray();

            Console.WriteLine("Please select the tool the tool you wish to add quantity to:\n");

            // Prints out the tools within chosen collection if they exist
            for (int i = 0; i < toolArray.Length; i++)
            {
                // if indexed tool type contains no tools
                if (toolArray[0] == null)
                {
                    Console.WriteLine("Currently no tools exist in " + toolTypeStrings[indexNumbers[0]][indexNumbers[1]] + ".");
                    Console.WriteLine("\nPress enter to continue...");
                    Console.ReadLine();

                    staffMenu();
                    return;
                }
                else if (toolArray[i] != null)
                {
                    Console.WriteLine("\t" + (i+1)+ ". " + toolArray[i].ToString());
                    numTools++;
                }
            }

            Console.WriteLine("Make a selection by entering the number index, or 0 to exit...");

            // Error handling for chosen tool index
            while (error == true)
            {
                entry = Console.ReadLine();

                if (!int.TryParse(entry, out toolIndex))
                {
                    Console.WriteLine("Please enter a valid input...");                   
                }
                else if (int.Parse(entry) == 0)
                {
                    staffMenu();
                    return;                    
                }
                else if (int.Parse(entry) < 0 || int.Parse(entry) > numTools)
                {
                    Console.WriteLine("Please enter a valid input...");                    
                }
                else
                {
                    toolIndex = int.Parse(entry);
                    Console.Write("\nNow enter the quantity you wish to add, or 0 to exit: ");
                    
                    error = false;
                }
            }

            // Now have the chosen tool index
            toolIndex--;

            // Resetting boolean for next error handling
            error = true;

            // Error handling for user entered tool quantity to add
            while (error == true) 
            {
                entry = Console.ReadLine();

                if (!int.TryParse(entry, out quantity))
                {
                    Console.WriteLine("Please enter a valid input...");                    
                }
                else if (int.Parse(entry) < 0)
                {
                    Console.WriteLine("Please enter a positive number...");
                }
                else if (int.Parse(entry) == 0)
                {
                    staffMenu();
                    return;                    
                }
                else
                {
                    quantity = int.Parse(entry);
                    error = false;                    
                }
            }

            // Library system add tool function now receives relevant tool object
            // and quantity to add
            librarySystem.add(toolArray[toolIndex], quantity);
            staffMenu();            
        }

        /// <summary>
        /// Allows staff to remove a chosen quantity from existing tools within
        /// the system.
        /// </summary>
        public static void staffRemoveTools()
        {
            int numTools = new int(), toolIndex = new int(), quantity = new int();
            string entry;
            bool error = true;

            Console.Clear();
            Console.WriteLine("===============Remove Pieces of a Tool===============");

            int[] indexNumbers = staffIndexing();

            // Send indexing of tool type to ToolLibrarySystem
            librarySystem.Category = indexNumbers[0];
            librarySystem.ToolType = indexNumbers[1];

            // Tool array to hold retrieved tools from the indexed tool type
            Tool[] toolArray = toolCategories[indexNumbers[0]][indexNumbers[1]].toArray();

            Console.WriteLine("Please select the tool the tool you wish to remove items from:\n");

            // Display tools within chosen tool type if they exist
            for (int i = 0; i < toolArray.Length; i++)
            {
                // If indexed tool type contains no tools
                if (toolArray[0] == null)
                {
                    Console.WriteLine("\tCurrently no tools exist in " + toolTypeStrings[indexNumbers[0]][indexNumbers[1]] + ".");
                    Console.WriteLine("\nPress enter to continue...");
                    Console.ReadLine();

                    staffMenu();
                    return;
                }
                else if (toolArray[i] != null)
                {
                    Console.WriteLine("\t" + (i + 1) + ". " + toolArray[i].ToString());
                    numTools++;
                }
            }

            Console.WriteLine("Make a selection by entering the number index, or 0 to exit...");

            // Error handling for user input index of chosen tool to remove pieces
            // from
            while (error == true)
            {
                entry = Console.ReadLine();

                if (!int.TryParse(entry, out toolIndex))
                {
                    Console.WriteLine("Please enter a valid input...");                    
                }
                else if (int.Parse(entry) == 0)
                {
                    staffMenu();
                    return;                    
                }
                else if (int.Parse(entry) < 0 || int.Parse(entry) > numTools)
                {
                    Console.WriteLine("Please enter a valid input...");                    
                }
                else
                {
                    Console.Write("Finally, enter the quantity you would like to remove, or 0 to exit: ");

                    toolIndex = int.Parse(entry);
                    toolIndex--;
                    error = false;
                }
            }

            // Resetting boolean check for user entered quantity
            error = true;

            // Error handling for user entered quantity to remove
            while (error == true)
            {
                entry = Console.ReadLine();

                if (!int.TryParse(entry, out quantity))
                {
                    Console.WriteLine("Please enter a valid input...");
                }
                else if (int.Parse(entry) == 0)
                {
                    staffMenu();
                    return;                   
                }
                else if (int.Parse(entry) < 0)
                {
                    Console.WriteLine("Please enter a positive number...");
                }
                else
                {
                    quantity = int.Parse(entry);
                    error = false;                    
                }
            }

            // Selected tool and quantity are sent to library system method
            librarySystem.delete(toolArray[toolIndex], quantity);
            
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
            staffMenu();
        }

        /// <summary>
        /// Allows staff to register new members to the system, if they do not
        /// already exist.
        /// </summary>
        public static void staffRegisterMember()
        {
            string firstName, lastName, mobile, pin, entry;
            Member newMember;
            bool error = true;

            Console.Clear();
            Console.WriteLine("===============Register New Member===============\n");

            Console.Write("Please enter the member's first name: ");
            firstName = Console.ReadLine().Trim();
            Console.WriteLine();

            Console.Write("Please enter the member's last name: ");
            lastName = Console.ReadLine().Trim();
            Console.WriteLine();

            // Running string concat to remove all whitespace from entered value
            Console.Write("Please enter the member's mobile number: ");
            mobile = String.Concat(Console.ReadLine().Where(c => !Char.IsWhiteSpace(c)));
            Console.WriteLine();

            Console.Write("Finally, please enter the member's PIN: ");
            pin = String.Concat(Console.ReadLine().Where(c => !Char.IsWhiteSpace(c)));
            Console.WriteLine();

            // Display the created member and ask if want confirmation
            newMember = new Member(firstName, lastName, mobile, pin);

            Console.WriteLine("New member details:\n");
            Console.WriteLine("\t" + newMember.ToString());
            Console.WriteLine("\nPress enter to confirm member, 1 to quit to menu or 0 to reset if details are incorrect...");

            // Error handling for inputs
            while (error == true)
            {
                entry = Console.ReadLine();

                if (entry == "0")
                {
                    staffRegisterMember();
                    return;                    
                }
                else if (entry == "1")
                {
                    staffMenu();
                    return;
                }
                else if (entry != "")
                {
                    Console.WriteLine("Please enter a valid input...\n");
                }
                else
                {
                    error = false;                    
                }
            }

            // Calling ToolLibrarySystem method here to try and add member to
            // system
            librarySystem.add(newMember);

            Console.WriteLine("\nPress enter to continue...");
            Console.ReadLine();
            staffMenu();          
        }

        /// <summary>
        /// Allows staff to remove members from the system given they do not
        /// currently hold any tools.
        /// </summary>
        public static void staffRemoveMember()
        {
            Member[] memberArray;
            int memberIndex = new int();
            bool error = true;
            string entry;

            Console.Clear();
            Console.WriteLine("===============Remove Member===============\n");

            Console.WriteLine("Current members in the system:\n");

            // Display current members in the system
            memberArray = members.toArray();
            for (int i = 0; i < memberArray.Length; i++)
            {
                Console.WriteLine("\t" + (i + 1) + ". " + memberArray[i].ToString());
                Console.WriteLine("--------------------------------------------------------------");
            }

            Console.WriteLine("\nPlease enter the index (1-" + memberArray.Length +
                ") of the member you wish to remove, or 0 to exit...");

            // Error handling user input index for member to be removed
            while (error == true)
            {
                entry = Console.ReadLine();

                if (!int.TryParse(entry, out memberIndex))
                {
                    Console.WriteLine("Please enter a valid input...\n");
                }
                else if (int.Parse(entry) == 0)
                {
                    staffMenu();
                    return;
                }
                else if (int.Parse(entry) < 0 || int.Parse(entry) > memberArray.Length)
                {
                    Console.WriteLine("Please enter a valid input...\n");
                }
                else
                {
                    memberIndex = int.Parse(entry);
                    memberIndex--;
                    error = false;
                }
            }

            // Now have the index for member array
            librarySystem.delete(memberArray[memberIndex]);

            Console.WriteLine("\nPress enter to continue...");
            Console.Read();
            staffMenu();
        }

        /// <summary>
        /// Allows staff to retrieve the contact number of a Member given their
        /// name.
        /// </summary>
        public static void staffFindNumber()
        {
            // Given the name of a member, display their mobile
            string firstName, lastName;
            Member queryMember;
            Member[] memberArray;

            Console.Clear();
            Console.WriteLine("===============Retrieve Member Contact Number===============\n");

            Console.Write("Please enter member's first name: ");
            firstName = Console.ReadLine().Trim();
            Console.WriteLine();

            Console.Write("Please enter member's last name: ");
            lastName = Console.ReadLine().Trim();
            Console.WriteLine();

            // Create member for comparisons
            queryMember = new Member(firstName, lastName);

            // Retrieve current members
            memberArray = members.toArray();

            // Parse through members to see if a match is found
            foreach (Member m in memberArray)
            {
                // If member is found
                if (m.CompareTo(queryMember) == 0)
                {
                    Console.WriteLine("\tContact number of " + queryMember.FirstName + " " +
                        queryMember.LastName + ": " + m.ContactNumber);

                    Console.Write("\nPress any key to continue...");
                    Console.Read();
                    staffMenu();
                    return;
                }
            }

            // Else member was not found
            Console.WriteLine("Could not find " + queryMember.FirstName + " " +
                queryMember.LastName + " in the system...");

            Console.Write("\nPress any key to continue...");
            Console.Read();
            staffMenu();
        }


        //--------------------------------------------------------------------------//
        //----------------------------- Member Methods -----------------------------//
        //--------------------------------------------------------------------------//

        /// <summary>
        /// Main method for running base member menu. Allows access to all member
        /// functionality.
        /// </summary>
        /// <param name="aMember">Logged in Member</param>
        public static void memberMenu(Member aMember)
        {
            Console.Clear();
            Console.WriteLine("===============Member Menu===============");

            Console.WriteLine("\nCurrently logged in as: " + aMember.FirstName + " " + aMember.LastName + "\n");

            Console.WriteLine("1. Display all tools of a tool type");
            Console.WriteLine("2. Borrow a tool");
            Console.WriteLine("3. Return a tool");
            Console.WriteLine("4. List all the tools that I am renting");
            Console.WriteLine("5. Display the top three (3) most frequently rented tools");            
            Console.WriteLine("0. Return to main menu\n");
            
            Console.WriteLine("=========================================\n");


            Console.WriteLine("Please make a selection 1-5, or 0 to exit.");

            switch (Console.ReadLine())
            {
                case "1":
                    memberDisplayTools(aMember);
                    break;
                case "2":
                    memberBorrowTool(aMember);
                    break;
                case "3":
                    memberReturnTool(aMember);
                    break;
                case "4":
                    memberDisplayBorrowing(aMember);
                    break;
                case "5":
                    memberDisplayTopThree(aMember);
                    break;
                case "0":
                    mainMenu();
                    break;
                default:
                    Console.WriteLine("Please enter a valid input...");
                    Console.ReadLine();
                    memberMenu(aMember);
                    break;
            }
        }

        /// <summary>
        /// Handles the menu functionality that allows a member to display all
        /// the tools of a searched tool type.
        /// </summary>
        /// <param name="aMember">Logged in Member</param>
        public static void memberDisplayTools(Member aMember)
        {
            int categoryInt = new int();            

            Console.Clear();
            Console.WriteLine("Please select a category:\n");

            // Printing out Tool categories
            for (int i = 0; i < categories.Length; i++)
            {
                Console.WriteLine("\t" + (i + 1) + ". " + categories[i]);
            }

            Console.WriteLine("\nPlease make a selection 1-9, or 0 to exit.");

            // Error handling user input category index
            switch (Console.ReadLine())
            {
                case "0":
                    memberMenu(aMember);
                    break;
                case "1":
                    categoryInt = 0;
                    break;
                case "2":
                    categoryInt = 1;
                    break;
                case "3":
                    categoryInt = 2;
                    break;
                case "4":
                    categoryInt = 3;
                    break;
                case "5":
                    categoryInt = 4;
                    break;
                case "6":
                    categoryInt = 5;
                    break;
                case "7":
                    categoryInt = 6;
                    break;
                case "8":
                    categoryInt = 7;
                    break;
                case "9":
                    categoryInt = 8;
                    break;
                default:
                    Console.WriteLine("Please enter a valid input...");
                    Console.ReadLine();
                    memberDisplayTools(aMember);
                    break;
            }

            // Sending chosen category index to ToolLibrarySystem
            librarySystem.Category = categoryInt;

            Console.WriteLine();

            // Displaying tool types of chosen tool category
            for (int i = 0; i < toolTypeStrings[categoryInt].Length; i++)
            {
                Console.WriteLine("\t" + toolTypeStrings[categoryInt][i]);
            }

            Console.Write("\nPlease type the category you would like to see: ");            

            // Takes user input string of chosen tool type and sends to tool
            // library method
            librarySystem.displayTools(Console.ReadLine().Trim());            

            Console.WriteLine("\nPress enter to continue...");
            Console.ReadLine();
            memberMenu(aMember);          
        }

        /// <summary>
        /// Handles the menu functionality that allows a member to borrow a tool
        /// from the system.
        /// </summary>
        /// <param name="aMember">Logged in Member</param>
        public static void memberBorrowTool(Member aMember)
        {
            int toolIndex = new int(), categoryInt = new int(), toolType = new int();
            Tool[] toolArray;
            bool error = true, found = false;
            string entry, toolName;

            Console.WriteLine("\nPlease select a tool category from below:\n");

            // Prints out tool categories
            for (int i = 0; i < categories.Length; i++)
            {
                Console.WriteLine("\t" + (i + 1) + ". " + categories[i]);
            }

            Console.WriteLine("\nPlease make a selection 1-" + categories.Length +
                ", or 0 to exit...");

            // Error handling for user input indexing
            switch (Console.ReadLine())
            {
                case "0":
                    memberMenu(aMember);
                    break;
                case "1":
                    categoryInt = 0;
                    break;
                case "2":
                    categoryInt = 1;
                    break;
                case "3":
                    categoryInt = 2;
                    break;
                case "4":
                    categoryInt = 3;
                    break;
                case "5":
                    categoryInt = 4;
                    break;
                case "6":
                    categoryInt = 5;
                    break;
                case "7":
                    categoryInt = 6;
                    break;
                case "8":
                    categoryInt = 7;
                    break;
                case "9":
                    categoryInt = 8;
                    break;
                default:
                    Console.WriteLine("Please enter a valid input...");
                    Console.ReadLine();
                    memberIndexing(aMember);
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("Please select a tool type from below:\n");

            // Printing out selected tool types
            for (int i = 0; i < toolTypeStrings[categoryInt].Length; i++)
            {
                Console.WriteLine("\t" + (i + 1) + ". " + toolTypeStrings[categoryInt][i]);
            }

            Console.WriteLine("\nPlease make a selection 1-" + toolTypeStrings[categoryInt].Length);

            // Error handling for user input tool type index
            while (error == true)
            {
                entry = Console.ReadLine();

                if (!int.TryParse(entry, out toolType))
                {
                    Console.WriteLine("Please enter a valid input...");
                }
                else if (int.Parse(entry) < 0 || int.Parse(entry) > toolTypeStrings[categoryInt].Length)
                {
                    Console.WriteLine("Please enter a valid input...");
                }
                else
                {
                    toolType = int.Parse(entry);
                    toolType--;
                    error = false;
                }
            }

            toolArray = toolCategories[categoryInt][toolType].toArray();

            // If array is empty
            if (toolArray[0] == null)
            {
                Console.WriteLine("Sorry, there are currently no tools available in " +
                                  toolTypeStrings[categoryInt][toolType]);                
                Console.ReadLine();

                // Return to member menu
                memberMenu(aMember);
                return;
            }
            else
            {
                Console.WriteLine("\nTools within " + toolTypeStrings[categoryInt][toolType] + ":\n");

                // Display available tools in collection
                for (int i = 0; i < toolArray.Length; i++)
                {
                    if (toolArray[i] != null)
                    {                        
                        Console.WriteLine("\t" + toolArray[i].ToString());
                    }
                }
            }

            Console.Write("\nEnter the name of the tool you wish to borrow: ");

            // Take the user input tool name
            toolName = Console.ReadLine().Trim();

            // Check the indexed Tools to see if there's a match
            for (int i = 0; i < toolArray.Length; i++)
            {
                if (toolArray[i] != null && toolName == toolArray[i].Name)
                {
                    found = true;
                    toolIndex = i;
                    break;
                }
            }

            if (found == false)
            {
                Console.WriteLine();
                Console.WriteLine(toolName + " could not be found in this tool type...\n");
                Console.WriteLine("Press enter to continue...");
                Console.Read();
                memberMenu(aMember);
                return;
            }

            // Call to librarySystem method
            librarySystem.borrowTool(aMember, toolArray[toolIndex]);

            Console.ReadLine();
            memberMenu(aMember);          
        }

        /// <summary>
        /// Allows member to see which tools they are currently borrowing.
        /// </summary>
        /// <param name="aMember">Logged in Member</param>
        public static void memberDisplayBorrowing(Member aMember)
        {
            Console.Clear();

            Console.WriteLine("Currently logged in as: " + aMember.FirstName +
                          " " + aMember.LastName + "\n");

            Console.WriteLine("===============Currently Borrowed Tools===============");

            // Call to ToolLibrarySystem method
            librarySystem.displayBorrowingTools(aMember);

            Console.WriteLine("======================================================");

            Console.ReadLine();
            memberMenu(aMember);
        }

        /// <summary>
        /// Allows member to return any tools they are currently holding back to
        /// the system.
        /// </summary>
        /// <param name="aMember">Logged in Member</param>
        public static void memberReturnTool(Member aMember)
        {
            int toolNum = new int(), toolNameIndex = new int();
            string entry;
            bool error = true, empty = true;

            // Retrieve the tools currently held by member
            Tool[] toolCollection = aMember.ToolArray;

            // Retrieve names of the tools held by Member
            string[] heldTools = librarySystem.listTools(aMember);

            Console.Clear();
            Console.WriteLine("===============Return Tools===============\n");

            // Check if any tools are currently held
            for (int i = 0; i < heldTools.Length; i++)
            {
                if (heldTools[i] != null)
                {
                    empty = false;
                }
            }

            if (empty == true)
            {
                Console.WriteLine("\tYou currently have no tools borrowed...\n");

                Console.WriteLine("Press enter to continue...");
                Console.Read();
                memberMenu(aMember);
                return;
            }
            
            // If member holds tools, display them to console
            for (int i = 0; i < toolCollection.Length; i++)
            {
                if (toolCollection[i] != null)
                {
                    toolNum++;
                    Console.WriteLine("\t" + (i+1) + ". " + toolCollection[i].ToString());
                }
            }

            Console.WriteLine("\nSelect the tool you wish to return with 1-" + toolNum + ", or 0 to exit...");

            // Error handling user chosen tool index
            while (error == true)
            {
                entry = Console.ReadLine();

                if (!int.TryParse(entry, out toolNameIndex) || int.Parse(entry) < 0 ||
                    int.Parse(entry) > toolNum)
                {
                    Console.WriteLine("Please enter a valid input...");
                }
                else if (int.Parse(entry) == 0)
                {
                    memberMenu(aMember);
                    return;
                }
                else
                {
                    toolNameIndex = int.Parse(entry);
                    toolNameIndex--;

                    error = false;
                }
            }

            // Get reference to tool to be returned 
            Tool toolToReturn = toolCollection[toolNameIndex];

            // Call to Library System method
            librarySystem.returnTool(aMember, toolToReturn);

            Console.WriteLine("\nPress enter to continue...");
            Console.Read();
            memberMenu(aMember);
        }

        /// <summary>
        /// Allows a member to see the top three most borrowed tools of the
        /// system.
        /// </summary>
        /// <param name="aMember">Logged in Member</param>
        public static void memberDisplayTopThree(Member aMember)
        {
            // Can uncomment the below calls to borrowTool() if you would
            // like to quickly test top three borrowed tools output

            //librarySystem.borrowTool(wilford, lineTrimmerTool);
            //librarySystem.borrowTool(wilford, lineTrimmerTool);
            //librarySystem.borrowTool(wilford, lineTrimmerTool);
            //librarySystem.borrowTool(angus, lineTrimmerTool);

            //librarySystem.borrowTool(angus, lineTrimmerTool2);
            //librarySystem.borrowTool(angus, lineTrimmerTool2);

            //librarySystem.borrowTool(sonny, lineTrimmerTool3);

            //librarySystem.borrowTool(sonny, sandingTool1);
            //librarySystem.borrowTool(sonny, sandingTool1);
            //librarySystem.borrowTool(testMember, sandingTool1);

            Console.Clear();
            Console.WriteLine("================Top 3 Most Borrowed Tools================\n");

            librarySystem.displayTopThree();

            Console.WriteLine("Press enter to continue...");
            Console.Read();
            memberMenu(aMember);
        }
    }
}
