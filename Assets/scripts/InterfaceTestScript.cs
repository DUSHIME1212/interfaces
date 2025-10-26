using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceTestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TestShapes();
    }

    void TestShapes()
    {
        Debug.Log("=== Testing Shape Classes ===");

        // Create instances of each shape
        IShape trapezium = new Trapezium(10, 6, 4, 5, 3);
        IShape circle = new Circle(7);
        IShape nonagon = new Nonagon(5);

        // Test Trapezium
        Debug.Log("--- Trapezium ---");
        trapezium.CalculateArea();
        trapezium.CalculatePerimeter();

        // Test Circle
        Debug.Log("--- Circle ---");
        circle.CalculateArea();
        circle.CalculatePerimeter();

        // Test Nonagon
        Debug.Log("--- Nonagon ---");
        nonagon.CalculateArea();
        nonagon.CalculatePerimeter();

        Debug.Log("=== Testing Complete ===");
    }

    // Update is called once per frame
    void Update()
    {
    }
}

public interface IShape
{
    void CalculateArea();
    void CalculatePerimeter();
}

public class Trapezium : IShape
{
    private float base1;
    private float base2;
    private float height;
    private float side1;
    private float side2;

    public Trapezium(float base1, float base2, float height, float side1, float side2)
    {
        this.base1 = base1;
        this.base2 = base2;
        this.height = height;
        this.side1 = side1;
        this.side2 = side2;
    }

    public void CalculateArea()
    {
        float area = ((base1 + base2) / 2) * height;
        Debug.Log($"Trapezium Area: {area}");
    }

    public void CalculatePerimeter()
    {
        float perimeter = base1 + base2 + side1 + side2;
        Debug.Log($"Trapezium Perimeter: {perimeter}");
    }

    public void CalculateUnknownSides()
    {
        // Simulate calculating unknown sides
        Debug.Log("Calculating unknown sides of trapezium...");
        float unknownSide = Mathf.Abs(base1 - base2) / 2;
        Debug.Log($"Estimated unknown side length: {unknownSide}");
    }
}

public class Circle : IShape
{
    private float radius;

    public Circle(float radius)
    {
        this.radius = radius;
    }

    public void CalculateArea()
    {
        float area = Mathf.PI * radius * radius;
        Debug.Log($"Circle Area: {area:F2}");
    }

    public void CalculatePerimeter()
    {
        float perimeter = 2 * Mathf.PI * radius;
        Debug.Log($"Circle Perimeter (Circumference): {perimeter:F2}");
    }

    public void CalculateRadius()
    {
        Debug.Log($"Circle Radius: {radius}");
    }
}

public class Nonagon : IShape
{
    private int numberOfSides = 9;
    private float sideLength;

    public Nonagon(float sideLength)
    {
        this.sideLength = sideLength;
    }

    public void CalculateArea()
    {
        float area = (9f / 4f) * sideLength * sideLength * (1f / Mathf.Tan(Mathf.PI / 9f));
        Debug.Log($"Nonagon Area: {area:F2}");
    }

    public void CalculatePerimeter()
    {
        float perimeter = numberOfSides * sideLength;
        Debug.Log($"Nonagon Perimeter: {perimeter}");
    }

    public int CalculateNumberOfSides()
    {
        Debug.Log($"Nonagon has {numberOfSides} sides");
        return numberOfSides;
    }
}