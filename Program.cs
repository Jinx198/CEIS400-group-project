using System;
using System.Collections.Generic;

//This project was made by Jay Villanueva and Amanda White for their CEIS 400 group project.
// Date: 11/2//2023
// Version 2.0
public class Employee
{
    private int employeeId;
    private string name;

    public int EmployeeId
    {
        get { return employeeId; }
        private set { employeeId = value; }
    }

    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

    public Employee(int employeeId, string name)
    {
        EmployeeId = employeeId;
        SetName(name);
    }

    public void SetName(string newName)
    {
        name = newName;
    }
}

public class CheckIn
{
    private int checkInId;
    private string assetList;

    public int CheckInId
    {
        get { return checkInId; }
        private set { checkInId = value; }
    }

    public string AssetList
    {
        get { return assetList; }
        private set { assetList = value; }
    }

    public CheckIn(int checkInId, string assetList)
    {
        CheckInId = checkInId;
        SetAssetList(assetList);
    }

    public string ReturnAsset()
    {
        return assetList;
    }

    private void SetAssetList(string newAssetList)
    {
        assetList = newAssetList;
    }
}

public class CheckOut
{
    private int checkOutId;
    private string assetList;

    public int CheckOutId
    {
        get { return checkOutId; }
        private set { checkOutId = value; }
    }

    public string AssetList
    {
        get { return assetList; }
        private set { assetList = value; }
    }

    public CheckOut(int checkOutId, string assetList)
    {
        CheckOutId = checkOutId;
        SetAssetList(assetList);
    }

    public string BorrowAsset()
    {
        return assetList;
    }

    private void SetAssetList(string newAssetList)
    {
        assetList = newAssetList;
    }
}

public class Asset
{
    private int assetId;
    private int assetStock;
    private string assetLocation;
    private string assignment;

    public int AssetId
    {
        get { return assetId; }
        private set { assetId = value; }
    }

    public int AssetStock
    {
        get { return assetStock; }
        private set { assetStock = value; }
    }

    public string AssetLocation
    {
        get { return assetLocation; }
        private set { assetLocation = value; }
    }

    public string Assignment
    {
        get { return assignment; }
        private set { assignment = value; }
    }

    public Asset(int assetId, int assetStock, string assetLocation, string assignment)
    {
        AssetId = assetId;
        AssetStock = assetStock;
        AssetLocation = assetLocation;
        SetAssignment(assignment);
    }

    public string ObtainLocation()
    {
        return assetLocation;
    }

    public int ObtainStock()
    {
        return assetStock;
    }

    public void SetAssignment(string newAssignment)
    {
        assignment = newAssignment;
    }
}

// Management class

public class Management
{
    private int managementId;
    private string name;

    public int ManagementId
    {
        get { return managementId; }
        private set { managementId = value; }
    }

    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

    public Management(int managementId, string name)
    {
        ManagementId = managementId;
        SetName(name);
    }

    public void AuditAssets()
    {
        Console.WriteLine($"Asset audit performed by {Name}");
    }

    public void RemoveAsset()
    {
        Console.WriteLine($"Asset removed by {Name}");
    }

    public void AddAsset()
    {
        Console.WriteLine($"Asset added by {Name}");
    }

    public void SetName(string newName)
    {
        name = newName;
    }
}

// Program class
class Program
{
    static void Main()
    {

        do
        {
            // Create new manager
            Management manager = new Management(1, "John Manager");

            List<Employee> employees = new List<Employee>
            {
                new Employee(1, "John Doe"),
                new Employee(2, "Jane Smith"),
                new Employee(3, "Bob Johnson"),
                new Employee(4, "John Manager")
                // Add more employees as needed
            };

            // List of available assets
            List<Asset> availableAssets = new List<Asset>
            {
                new Asset(1, 10, "Laptop", "In Use"),
                new Asset(2, 5, "Keyboard", "Available"),
                new Asset(3, 3, "Mouse", "In Use")
                // Add more assets as needed
            };

            // Display Employees
            Console.WriteLine("Available Employees:");
            foreach (var employee in employees)
            {
                Console.WriteLine($"Employee ID: {employee.EmployeeId}, Name: {employee.Name}");
            }


            // Find the selected employee
            Employee selectedEmployee = GetSelectedEmployee(employees);

            if (selectedEmployee != null)
            {
                Console.WriteLine($"Selected Employee: {selectedEmployee.Name}");

                if (selectedEmployee.Name.Equals(manager.Name, StringComparison.OrdinalIgnoreCase))
                {
                    // Manager Options
                    DisplayManagerOptions();
                    int selectedOption = GetSelectedOption();
                    PerformManagerAction(selectedOption, manager, availableAssets);
                }
                else
                {
                    // Regular Employee Options
                    DisplayRegularEmployeeOptions();
                    int selectedOption = GetSelectedOption();
                    PerformRegularEmployeeAction(selectedOption, selectedEmployee, availableAssets);
                }
            }
            else
            {
                Console.WriteLine("Invalid Employee ID. Please choose a valid employee.");
            }

            Console.Write("Do you want to perform another action? (y/n): ");
            char repeatChoice = Console.ReadKey().KeyChar;

            if (repeatChoice != 'y' && repeatChoice != 'Y')
            {
                break; // Exit the loop if the user doesn't want to repeat
            }

            Console.Clear();
        } while (true);
    } 


        static void DisplayManagerOptions()
        {
            Console.WriteLine("Manager Options:");
            Console.WriteLine("1. Audit Assets");
            Console.WriteLine("2. Remove Asset");
            Console.WriteLine("3. Add Asset");
        }

        static void PerformManagerAction(int selectedOption, Management manager, List<Asset> availableAssets)
        {
            switch (selectedOption)
            {
                case 1:
                    // Audit Assets
                    Console.WriteLine("Auditing Assets...");

                    // Display all assets and their assignments
                    Console.WriteLine("All Assets and Assignments:");
                    foreach (var asset in availableAssets)
                    {
                        Console.WriteLine($"Asset ID: {asset.AssetId}, Name: {asset.AssetLocation}, Assignment: {asset.Assignment}");
                    }
                    break;

                case 2:
                    // Remove Asset
                    Console.WriteLine("Removing Asset...");

                    // Display available assets
                    Console.WriteLine("Available Assets:");
                    foreach (var asset in availableAssets)
                    {
                        Console.WriteLine($"Asset ID: {asset.AssetId}, Name: {asset.AssetLocation}, Assignment: {asset.Assignment}");
                    }

                    // User input for removing an asset
                    Console.Write("Enter Asset ID to remove: ");
                    int assetToRemoveId = int.Parse(Console.ReadLine());

                    // Find the asset to remove
                    Asset assetToRemove = availableAssets.Find(asset => asset.AssetId == assetToRemoveId);

                    if (assetToRemove != null)
                    {
                        // Remove the asset from the list
                        availableAssets.Remove(assetToRemove);

                        // Display a message confirming the removal of the asset
                        Console.WriteLine($"Asset '{assetToRemove.AssetLocation}' removed successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Asset ID. Please choose a valid asset to remove.");
                    }
                    break;

                case 3:
                    // Add Asset
                    Console.WriteLine("Adding Asset...");

                    // User input for new asset details
                    Console.Write("Enter Asset ID: ");
                    int newAssetId = int.Parse(Console.ReadLine());

                    Console.Write("Enter Asset Stock: ");
                    int newAssetStock = int.Parse(Console.ReadLine());

                    Console.Write("Enter Asset Location: ");
                    string newAssetLocation = Console.ReadLine();

                    // Create a new Asset instance
                    Asset newAsset = new Asset(newAssetId, newAssetStock, newAssetLocation, "Available");

                    // Add the new asset to the list of available assets
                    availableAssets.Add(newAsset);

                    // Display a message confirming the addition of the new asset
                    Console.WriteLine($"Asset '{newAssetLocation}' added successfully.");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please choose a valid option.");
                    break;
            }
        }

        static void DisplayRegularEmployeeOptions()
        {
            Console.WriteLine("Regular Employee Options:");
            Console.WriteLine("1. Check Out Asset");
            Console.WriteLine("2. Check In Asset");
        }

        static void PerformRegularEmployeeAction(int selectedOption, Employee selectedEmployee, List<Asset> availableAssets)
        {
            switch (selectedOption)
            {
                case 1:
                    // Check Out Asset
                    Console.WriteLine("Checking Out Asset...");

                    // Display available assets
                    Console.WriteLine("Available Assets:");
                    foreach (var asset in availableAssets)
                    {
                        Console.WriteLine($"Asset ID: {asset.AssetId}, Name: {asset.AssetLocation}, Assignment: {asset.Assignment}");
                    }

                    // User input for CheckOut
                    Console.Write("Enter CheckOut ID: ");
                    int checkOutId = int.Parse(Console.ReadLine());

                    Console.Write("Choose Asset ID from the list: ");
                    int chosenAssetId = int.Parse(Console.ReadLine());

                    // Find the selected asset
                    Asset selectedAsset = availableAssets.Find(asset => asset.AssetId == chosenAssetId);

                    if (selectedAsset != null && selectedAsset.Assignment != "In Use")
                    {
                        // Update asset status
                        selectedAsset.SetAssignment("In Use");

                        // Create CheckOut instance with user input
                        CheckOut checkOut = new CheckOut(checkOutId, selectedAsset.AssetLocation);

                        // Record the check-out transaction (you might want to store this information somewhere)
                        Console.WriteLine($"Asset '{selectedAsset.AssetLocation}' checked out by employee '{selectedEmployee.Name}'.");

                        // Simulate borrowing asset and display the result
                        string borrowedAssetList = checkOut.BorrowAsset();
                        Console.WriteLine($"Borrowed Asset List: {borrowedAssetList}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Asset ID or the selected asset is currently in use. Please choose a valid asset.");
                    }
                    break;

                case 2:
                    // Check In Asset
                    Console.WriteLine("Checking In Asset...");

                    // Display assets
                    Console.WriteLine($"Assets currently checked out by {selectedEmployee.Name}:");
                    foreach (var asset in availableAssets)
                    {
                        if (asset.Assignment == selectedEmployee.Name)
                        {
                            Console.WriteLine($"Asset ID: {asset.AssetId}, Name: {asset.AssetLocation}");
                        }
                    }

                    // User input for CheckIn
                    Console.Write("Enter CheckIn ID: ");
                    int checkInId = int.Parse(Console.ReadLine());

                    Console.Write("Choose Asset ID from the list to check in: ");
                    chosenAssetId = int.Parse(Console.ReadLine());

                    // Find the selected asset
                    selectedAsset = availableAssets.Find(asset => asset.AssetId == chosenAssetId);

                    if (selectedAsset != null && selectedAsset.Assignment == selectedEmployee.Name)
                    {
                        // Update asset status
                        selectedAsset.SetAssignment("Available");

                        // Create CheckIn instance with user input
                        CheckIn checkIn = new CheckIn(checkInId, selectedAsset.AssetLocation);

                        // Record the check-in transaction (you might want to store this information somewhere)
                        Console.WriteLine($"Asset '{selectedAsset.AssetLocation}' checked in by employee '{selectedEmployee.Name}'.");

                        // Simulate returning the asset and display the result
                        string returnedAssetList = checkIn.ReturnAsset();
                        Console.WriteLine($"Returned Asset List: {returnedAssetList}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Asset ID or the selected asset is not currently checked out by the employee. Please choose a valid asset.");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid option. Please choose a valid option.");
                    break;
            }
        }

    static Employee GetSelectedEmployee(List<Employee> employees)
    {
        Console.Write("Choose Employee ID from the list: ");
        int chosenEmployeeId = int.Parse(Console.ReadLine());

        // Find the selected employee
        return employees.Find(employee => employee.EmployeeId == chosenEmployeeId);
    }

    static int GetSelectedOption()
        {
            int selectedOption;

            while (true)
            {
                Console.Write("Choose an option: ");
                if (int.TryParse(Console.ReadLine(), out selectedOption))
                {
                    return selectedOption;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a numeric option.");
                }
            }
        }
    }

