using System;
using System.Collections.Generic;

//This project was made by Jay Villanueva and Amanda White for their CEIS 400 group project.
// Date: 11/21/2023
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
        // Test your classes here
        Management manager = new Management(1, "John Manager");
        manager.AuditAssets();
        manager.RemoveAsset();
        manager.AddAsset();
        manager.SetName("Jane Manager");

        Employee employee = new Employee(1, "John Doe");
        employee.SetName("Jane Smith");

        CheckIn checkIn = new CheckIn(1, "Laptop, Mouse, Keyboard");
        string returnedAssetList = checkIn.ReturnAsset();

        CheckOut checkOut = new CheckOut(1, "Laptop, Mouse, Keyboard");
        string borrowedAssetList = checkOut.BorrowAsset();

        Asset asset = new Asset(1, 10, "Room 101", "In Use");
        string obtainedLocation = asset.ObtainLocation();
        int obtainedStock = asset.ObtainStock();
        asset.SetAssignment("Not In Use");
    }
}
