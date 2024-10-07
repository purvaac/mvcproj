using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace mvcproj.Pages.Customers
{
    public class newpage : PageModel
    {
        private readonly ILogger<newpage> _logger;

        public newpage(ILogger<newpage> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}





























dotnet new console -n prac
cd YourProjectName
code .



Inheritance: 
using System;
using System.Collections.Generic;

public class Employee
{
    public string Name { get; set; }
    public int ID { get; set; }
    public double Salary { get; set; }

    public Employee(string name, int id, double salary)
    {
        Name = name;
        ID = id;
        Salary = salary;
    }

    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Name: {Name}, ID: {ID}, Salary: {Salary}");
    }
}

public class FullTimeEmployee : Employee
{
    public double Bonus { get; set; }

    public FullTimeEmployee(string name, int id, double salary, double bonus)
        : base(name, id, salary)
    {
        Bonus = bonus;
    }

    public double CalculateTotalSalary()
    {
        return Salary + Bonus;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Total Salary (with Bonus): {CalculateTotalSalary()}");
    }
}

public class PartTimeEmployee : Employee
{
    public int HoursWorked { get; set; }

    public PartTimeEmployee(string name, int id, double salary, int hoursWorked)
        : base(name, id, salary)
    {
        HoursWorked = hoursWorked;
    }

    public double CalculateHourlyWage()
    {
        return Salary / HoursWorked;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Hourly Wage: {CalculateHourlyWage()}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>();

        Console.WriteLine("Enter the number of employees to add:");
        int numberOfEmployees = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfEmployees; i++)
        {
            Console.WriteLine($"Is Employee {i + 1} full-time or part-time? (F/P)");
            string empType = Console.ReadLine().ToUpper();

            Console.WriteLine("Enter Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter ID:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Salary:");
            double salary = double.Parse(Console.ReadLine());

            if (empType == "F")
            {
                Console.WriteLine("Enter Bonus:");
                double bonus = double.Parse(Console.ReadLine());
                employees.Add(new FullTimeEmployee(name, id, salary, bonus));
            }
            else if (empType == "P")
            {
                Console.WriteLine("Enter Hours Worked:");
                int hoursWorked = int.Parse(Console.ReadLine());
                employees.Add(new PartTimeEmployee(name, id, salary, hoursWorked));
            }
            else
            {
                Console.WriteLine("Invalid employee type. Please enter F for full-time or P for part-time.");
                i--; // Decrement to repeat this iteration
            }
        }

        // Display all employee details
        Console.WriteLine("\nEmployee Details:");
        foreach (var employee in employees)
        {
            employee.DisplayDetails();
            Console.WriteLine(); // Add a line break for better readability
        }
    }
}





Occurrence count:

using System;
public class Program{
    public static int count(string s, char ch){
        int sum = 0;
        foreach(char c in s){
            if(c ==ch){
                sum++;
            }
        }
        
        return sum;
    }
    
    public static void Main(string[] args){
        Console.WriteLine("Enter string");
        string input = Console.ReadLine();
        
        Console.WriteLine("Enter char");
        char ch = Console.ReadLine()[0];
        
        int myc = count(input, ch);
        Console.WriteLine($"occurnece: {myc}");
        
    }
}


Longest prefx
using System;

public class Program
{
    // Method to find the longest common prefix among an array of strings
    public static string LongestCommonPrefix(string[] strs)
    {
        if (strs.Length == 0) return ""; 
        string prefix = strs[0]; 

        foreach (string str in strs) 
        {
            while (str.IndexOf(prefix) != 0)             {
                prefix = prefix.Substring(0, prefix.Length - 1); 
                if (prefix == "") return ""; 
            }
        }

        return prefix; 
    }

    // Main method to test the LongestCommonPrefix method
    public static void Main(string[] args)
    {
        string[] strs = { "flower", "flow", "flight" }; // Example array of strings
        string result = LongestCommonPrefix(strs); // Call the method
        Console.WriteLine($"Longest Common Prefix: {result}"); // Output: Longest Common Prefix: fl

        // Additional test cases
        string[] test1 = { "dog", "racecar", "car" };
        Console.WriteLine($"Longest Common Prefix: {LongestCommonPrefix(test1)}"); // Output: Longest Common Prefix: (empty string)

        string[] test2 = { "a", "a", "a" };
        Console.WriteLine($"Longest Common Prefix: {LongestCommonPrefix(test2)}"); // Output: Longest Common Prefix: a
    }
}
Reverse

public static string ReverseString(string s)
{
    char[] charArray = s.ToCharArray();
    Array.Reverse(charArray);
    return new string(charArray);
}


public static bool IsPalindrome(string s)
{
    int left = 0;
    int right = s.Length - 1;

    while (left < right)
    {
        if (s[left] != s[right])
            return false;
        left++;
        right--;
    }
    return true;
}

public static (int vowels, int consonants) CountVowelsAndConsonants(string s)
{
    int vowelCount = 0;
    int consonantCount = 0;

    foreach (char c in s.ToLower())
    {
        if (char.IsLetter(c))
        {
            if ("aeiou".Contains(c))
                vowelCount++;
            else
                consonantCount++;
        }
    }

    return (vowelCount, consonantCount);
}

public static bool AreAnagrams(string s1, string s2)
{
    char[] arr1 = s1.ToLower().ToCharArray();
    char[] arr2 = s2.ToLower().ToCharArray();

    Array.Sort(arr1);
    Array.Sort(arr2);

    return new string(arr1) == new string(arr2);
}

public static char FirstNonRepeatingCharacter(string s)
{
    var charCount = new Dictionary<char, int>();

    foreach (char c in s)
    {
        if (charCount.ContainsKey(c))
            charCount[c]++;
        else
            charCount[c] = 1;
    }

    foreach (char c in s)
    {
        if (charCount[c] == 1)
            return c;
    }

    return '\0'; // Return null character if no non-repeating character is found
}

public static int LengthOfLongestSubstring(string s)
{
    HashSet<char> charSet = new HashSet<char>();
    int left = 0, maxLength = 0;

    for (int right = 0; right < s.Length; right++)
    {
        while (charSet.Contains(s[right]))
        {
            charSet.Remove(s[left]);
            left++;
        }
        charSet.Add(s[right]);
        maxLength = Math.Max(maxLength, right - left + 1);
    }

    return maxLength;
}

public static string RemoveDuplicates(string s)
{
    HashSet<char> charSet = new HashSet<char>();
    StringBuilder result = new StringBuilder();

    foreach (char c in s)
    {
        if (!charSet.Contains(c))
        {
            charSet.Add(c);
            result.Append(c);
        }
    }

    return result.ToString();
}

public static string LongestCommonPrefix(string[] strs)
{
    if (strs.Length == 0) return "";
    string prefix = strs[0];

    foreach (string str in strs)
    {
        while (str.IndexOf(prefix) != 0)
        {
            prefix = prefix.Substring(0, prefix.Length - 1);
            if (prefix == "") return "";
        }
    }

    return prefix;
}

public static int CountWords(string str)
{
    if (string.IsNullOrWhiteSpace(str)) return 0;
    string[] words = str.Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
    return words.Length;
}

Reverse number
using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter a number as a string:");
        string input = Console.ReadLine();

        int sumOfDigits = SumOfDigitsOfReversedNumber(input);
        Console.WriteLine($"Sum of digits of the reversed number: {sumOfDigits}");
    }

    // Method to reverse the number and find the sum of its digits
    public static int SumOfDigitsOfReversedNumber(string input)
    {
        // Reverse the input string
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        string reversedString = new string(charArray);

        // Initialize sum
        int sum = 0;

        // Sum the digits of the reversed string
        foreach (char c in reversedString)
        {
            if (char.IsDigit(c)) // Check if the character is a digit
            {
                sum += c - '0'; // Convert char to int and add to sum
            }
            else
            {
                Console.WriteLine($"Ignoring non-digit character: {c}");
            }
        }

        return sum; // Return the total sum
    }
}

using System;

class Program
{
    static void Main()
    {
        int[] array1 = { 1, 3, 5 };
        int[] array2 = { 2, 4, 6 };
        int[] mergedArray = MergeSortedArrays(array1, array2);
        Console.WriteLine("Merged Array: " + string.Join(", ", mergedArray));
    }

    static int[] MergeSortedArrays(int[] array1, int[] array2)
    {
        int[] merged = new int[array1.Length + array2.Length];
        int i = 0, j = 0, k = 0;

        while (i < array1.Length && j < array2.Length)
        {
            if (array1[i] < array2[j])
                merged[k++] = array1[i++];
            else
                merged[k++] = array2[j++];
        }

        while (i < array1.Length)
            merged[k++] = array1[i++];

        while (j < array2.Length)
            merged[k++] = array2[j++];

        return merged;
    }
}

using System;


        // Question 5: Generate Fibonacci Sequence Using Recursion
        Console.Write("Fibonacci Sequence using Recursion: ");
        for (int i = 0; i < terms; i++)
        {
            Console.Write(FibonacciRecursive(i) + " ");
        }
        Console.WriteLine();
    }

    static int[] GenerateFibonacci(int terms)
    {
        int[] fibonacci = new int[terms];
        if (terms >= 1) fibonacci[0] = 0; // First term
        if (terms >= 2) fibonacci[1] = 1; // Second term

        for (int i = 2; i < terms; i++)
        {
            fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2]; // Sum of the last two terms
        }

        return fibonacci;
    }

    static int FibonacciAtPosition(int n)
    {
        if (n <= 0) return 0;
        if (n == 1) return 1;

        int a = 0, b = 1, c = 0;
        for (int i = 2; i <= n; i++)
        {
            c = a + b; // Sum of the last two terms
            a = b;
            b = c;
        }
        return c;
    }

    static bool IsFibonacci(int number)
    {
        int a = 0, b = 1, c = 0;

        while (c < number)
        {
            c = a + b; // Generate the next Fibonacci number
            a = b;
            b = c;
        }
        return c == number; // Check if the generated number equals the input
    }

    static int SumOfFibonacci(int n)
    {
        if (n <= 0) return 0;
        if (n == 1) return 0;

        int a = 0, b = 1, sum = 1; // Start with the first two terms
        for (int i = 2; i < n; i++)
        {
            int c = a + b; // Next term
            sum += c; // Add to sum
            a = b;
            b = c;
        }
        return sum;
    }

    
<?xml version="1.0" encoding="utf-8"?>


XDocument companyDoc = XDocument.Parse(xmlData);

// 1. Employees Earning Above ₹60,000
var highEarners = from employee in companyDoc.Descendants("Employee")
                  where (int)employee.Element("Salary") > 60000
                  select employee;

Console.WriteLine("Employees Earning Above ₹60,000:");
foreach (var employee in highEarners)
{
    Console.WriteLine(employee.Element("Name").Value);
}

Console.WriteLine();

// 2. Employees Who Joined After January 1, 2019
var recentJoiners = from employee in companyDoc.Descendants("Employee")
                    where DateTime.Parse(employee.Element("JoiningDate").Value) > new DateTime(2019, 1, 1)
                    select employee;

Console.WriteLine("Employees Who Joined After January 1, 2019:");
foreach (var employee in recentJoiners)
{
    Console.WriteLine(employee.Element("Name").Value);
}

Console.WriteLine();

// 3. Employees in the "Finance" Department
var financeEmployees = from department in companyDoc.Descendants("Department")
                       where (string)department.Attribute("Name") == "Finance"
                       from employee in department.Descendants("Employee")
                       select employee;

Console.WriteLine("Employees in the Finance Department:");
foreach (var employee in financeEmployees)
{
    Console.WriteLine(employee.Element("Name").Value);
}

Console.WriteLine();


// 5. Employee with the Highest Salary
var highestPaidEmployee = companyDoc.Descendants("Employee")
                                    .OrderByDescending(employee => (int)employee.Element("Salary"))
                                    .FirstOrDefault();

Console.WriteLine($"Employee with the Highest Salary: {highestPaidEmployee.Element("Name").Value}");

Console.WriteLine();

// 6. Employee with the Longest Tenure
var longestTenureEmployee = companyDoc.Descendants("Employee")
                                      .OrderBy(employee => DateTime.Parse(employee.Element("JoiningDate").Value))
                                      .FirstOrDefault();

Console.WriteLine($"Employee with the Longest Tenure: {longestTenureEmployee.Element("Name").Value}");

Console.WriteLine();

// 7. Employees in IT Department Earning More Than ₹80,000
var highEarnersInIT = from department in companyDoc.Descendants("Department")
                      where (string)department.Attribute("Name") == "IT"
                      from employee in department.Descendants("Employee")
                      where (int)employee.Element("Salary") > 80000
                      select employee;

Console.WriteLine("Employees in IT Department Earning More Than ₹80,000:");
foreach (var employee in highEarnersInIT)
{
    Console.WriteLine(employee.Element("Name").Value);
}

Console.WriteLine();

// 8. Average Salary of Employees
var averageSalary = companyDoc.Descendants("Employee")
                              .Average(employee => (int)employee.Element("Salary"));

Console.WriteLine($"Average Salary of Employees: ₹{averageSalary}");

Console.WriteLine();

// 9. Count of Employees in Each Department
var employeeCountByDepartment = from department in companyDoc.Descendants("Department")
                                select new {
                                    DepartmentName = department.Attribute("Name").Value,
                                    EmployeeCount = department.Descendants("Employee").Count()
                                };

Console.WriteLine("Employee Count by Department:");
foreach (var dept in employeeCountByDepartment)
{
    Console.WriteLine($"{dept.DepartmentName}: {dept.EmployeeCount}");
}

Console.WriteLine();

// 10. Employees Joined Between 2016 and 2019
var employeesJoinedInRange = from employee in companyDoc.Descendants("Employee")
                             where DateTime.Parse(employee.Element("JoiningDate").Value) >= new DateTime(2016, 1, 1)
                             && DateTime.Parse(employee.Element("JoiningDate").Value) <= new DateTime(2019, 12, 31)
                             select employee;

Console.WriteLine("Employees Joined Between 2016 and 2019:");
foreach (var employee in employeesJoinedInRange)
{
    Console.WriteLine(employee.Element("Name").Value);
}




LINQEND
using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // Example array of integers
        int[] numbers = { 5, 10, 15, 20, 25, 30, 35, 40 };

        // Calculate the maximum value
        int maxValue = numbers.Max();
        Console.WriteLine($"Maximum value: {maxValue}");

        // Calculate the average value
        double averageValue = numbers.Average();
        Console.WriteLine($"Average value: {averageValue}");

        // Calculate the count of elements
        int count = numbers.Count();
        Console.WriteLine($"Count of elements: {count}");

        // Calculate the sum of elements
        int sum = numbers.Sum();
        Console.WriteLine($"Sum of elements: {sum}");
    }
}

using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // Example array of integers
        int[] numbers = { 3, 6, 9, 12, 15, 18, 21 };

        // Query using LINQ to get even numbers
        var evenNumbers = from num in numbers
                          where num % 2 == 0
                          select num;

        Console.WriteLine("Even numbers in the array:");
        foreach (var num in evenNumbers)
        {
            Console.WriteLine(num);
        }

        // Query to get numbers greater than 10
        var greaterThanTen = numbers.Where(num => num > 10);

        Console.WriteLine("\nNumbers greater than 10:");
        foreach (var num in greaterThanTen)
        {
            Console.WriteLine(num);
        }

        // Query to get the sum of the array
        var sum = numbers.Sum();

        Console.WriteLine($"\nSum of the numbers: {sum}");
    }
}


