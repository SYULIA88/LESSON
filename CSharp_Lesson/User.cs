using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Lesson
{
    /// <summary>
    /// User class with properties, constructors, and methods
    /// </summary>
    public class User
    {
        // Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; private set; }
        public Gender Gender { get; set; }

        // Default constructor
        public User() => Age = 0;

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="firstName">First Name</param>
        /// <param name="lastName">Last Name</param>
        /// <param name="age">Age</param>
        /// <param name="gender">Gender</param>
        public User(string firstName, string lastName, int age, Gender gender)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Gender = gender;
        }

        /// <summary>
        /// Method for user input
        /// </summary>
        public void InputUserDetails()
        {
            Console.Write("Enter First Name: ");
            FirstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            LastName = Console.ReadLine();

            // Using the combined validation method for age
            Age = InputValidData<int>("Enter Age: ", ValidatePositiveNumber);

            // Using the combined validation method for gender
            Gender = InputValidData<Gender>("Enter Gender (Male/Female): ", ValidateGender);
        }

        // Generic method for combined input validation
        private T InputValidData<T>(string prompt, Func<string, (bool, T)> validationFunction)
        {
            while (true)
            {
                Console.Write(prompt);
                string userInput = Console.ReadLine();
                var (isValid, value) = validationFunction(userInput);

                if (isValid)
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
        }

        // Validation function for positive numbers
        private (bool, int) ValidatePositiveNumber(string input)
        {
            if (int.TryParse(input, out int number) && number > 0)
            {
                return (true, number);
            }
            else
            {
                return (false, default);
            }
        }

        // Validation function for gender
        private (bool, Gender) ValidateGender(string input)
        {
            if (Enum.TryParse(input, out Gender gender) && Enum.IsDefined(typeof(Gender), gender))
            {
                return (true, gender);
            }
            else
            {
                return (false, default);
            }
        }

        /// <summary>
        /// Override ToString() method for custom string representation
        /// </summary>
        /// <returns>Information for Users</returns>
        public override string ToString()
        {
            return $"Hi, my name is {FirstName} and last name {LastName}. I am {Age} years old. I am {Gender}.";
        }
    }

    /// <summary>
    /// Enumeration for Gender with two possible values: Male and Female
    /// </summary>
    public enum Gender
    {
        Male,
        Female
    }
}
