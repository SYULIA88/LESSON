using CSharp_Lesson;

// Creating a User object
User user1 = new User();

// Setting Gender for user1
user1.Gender = Gender.Male;

// Allowing the user to input data for user1
user1.InputUserDetails();

// Displaying user data on the screen
Console.WriteLine(user1);

// Stopping the console
Console.ReadLine();
