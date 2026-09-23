using System.Collections;

namespace Assignment5._3
{
    internal class Program
    {

        static bool flowerBedChecker(int[] arr, int n)
        {
            int count = 0;
            if (n > ((arr.Length + 1) / 2))
            {
                Console.WriteLine($"Cannot fit {n} flowers ");
                return false;
            }

            //checks for the first and last position of the array
            if ((arr[0] == 0 && arr[1] == 0))
            {
                arr[0] = 1;
                count++;
            }
            if (arr[arr.Length - 1] == 0 && arr[arr.Length - 2] == 0)
            {
                arr[arr.Length - 1] = 1;
                count++;
            }

            for (int i = 0; i < arr.Length; i++)
            {   

                if (arr[i] != 0) 
                {
                    i++;
                } 
                else if (arr[i] == 0 && arr[i + 1] != 0)
                {
                     i += 2;
                } 
                else if (arr[i] == 0 && arr[i - 1] == 0 && arr[i + 1] == 0)
                {
                    arr[i] = 1;
                    i++;
                    count++;
                }
            }

            if (count == n)
            {
                return true;
            }
            return false;
        }

        static int stepsCounter(int stairs)
        {
            int[] steps = new int[stairs + 1];
            steps[1] = 1;
            steps[2] = 2;
            for (int i = 3; i <= stairs; i++)
            {
                steps[i] = steps[i - 1] + steps[i - 2];
            }
            return steps[stairs];
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter an array of 0s an 1s, separated by commas...");
            int[] arr = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            Console.WriteLine("Enter a positive integer");
            int n = int.Parse(Console.ReadLine());
            if (n > 0 && arr.Length > 2)
            {
                Console.WriteLine(flowerBedChecker(arr, n));
            } else
            {
                Console.WriteLine("Invalid input");
            }

            //****question 2****
            Console.WriteLine("Input the number of stairs: ");
            int stairs = int.Parse(Console.ReadLine());
            Console.WriteLine("output: " + stepsCounter(stairs));
        }
    }
}
