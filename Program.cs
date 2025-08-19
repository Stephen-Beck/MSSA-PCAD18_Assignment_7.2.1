//Implement shell sort on an unsorted array of numbers. Take the array input from user.

namespace Assignment_7._2._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] userIntArray = GetUserArray();
            ShellSort(userIntArray);
        }

        static int[] GetUserArray()
        {
            string userInput;
            int[] userIntArray = [];
            bool validInput = false;

            while (!validInput)
            {
                Console.Write($"Enter an array of integers separated by commas (e.g., \"1,2,3\"): ");
                userInput = Console.ReadLine();
                string[] userStringArray = userInput.Split(',');
                userIntArray = new int[userStringArray.Length];

                bool valid = true;
                for (int i = 0; i < userStringArray.Length; i++)
                {
                    if (int.TryParse(userStringArray[i].Trim(), out int number))
                    {
                        userIntArray[i] = number;
                    }
                    else
                    {
                        Console.WriteLine($"Value \"{userStringArray[i]}\" was not a valid integer!");
                        validInput = false;
                        break;
                    }

                    validInput = true;
                }
            }
            return userIntArray;
        }

        static void ShellSort(int[] nums)
        {
            // Display original array
            DisplayArray(nums);

            // Shell Sort array
            int gap = nums.Length / 2;
            int i, j = 0;
            
            while (gap > 0)
            {
                i = gap;

                while (i < nums.Length)
                {
                    // set temp to "+gap" number
                    int temp = nums[i];

                    // set j to "current" number
                    j = i - gap;

                    // if "current" > "+gap", swap
                    // implement insertion sort, stepping backwards by "gap" each time
                    while (j >= 0 && nums[j] > temp)
                    {
                        nums[j + gap] = nums[j];
                        j -= gap;
                    }
                    
                    // set temp to new "+gap" number and move to next number
                    nums[j + gap] = temp;
                    i++;
                }
                
                // reduce gap
                gap /= 2;
            }

            // Display sorted array
            DisplayArray(nums);
        }

        static void DisplayArray(int[] array)
        {
            Console.WriteLine($"[{String.Join(',', array)}]");
        }
    }
}
