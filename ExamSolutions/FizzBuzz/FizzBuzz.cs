namespace FizzBuzz
{
    using System;

    public class FizzBuzz
    {
        public static void Main()
        {
            string inputString = Console.ReadLine();

            int.TryParse(inputString, out int input);

            if (input >= 1)
            {
                for (int i = 1; i <= input; i++)
                {
                    if (i % 15 == 0)
                    {
                        Console.WriteLine("FizzBuzz");
                    }
                    else if (i % 3 == 0)
                    {
                        Console.WriteLine("Fizz");
                    }
                    else if (i % 5 == 0)
                    {
                        Console.WriteLine("Buzz");
                    }
                    else
                    {
                        Console.WriteLine(i);
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}
