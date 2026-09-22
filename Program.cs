namespace Week4Assignment4._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Part1
            Console.WriteLine("Part 1");
            int usage, custID;
            string custName;
            double billTotal, rate;
            Console.Write("What is your customer ID: ");
            custID = int.Parse(Console.ReadLine());
            Console.Write("What is the name on your account: ");
            custName = Console.ReadLine();
            Console.Write("What was your usage for the month: ");
            usage = int.Parse(Console.ReadLine());
            billTotal = ElectricBill(usage, out rate);
            DisplayBill(custID, custName, usage, rate, billTotal);
            #endregion

            #region Part2
            Console.WriteLine("\nPart 2");
            int n;
            Console.Write("Enter a size for the array: ");
            n = int.Parse(Console.ReadLine());
            int[] numArray = new int[n];
            
            Dictionary<int, int> arrayOccurrence = new Dictionary<int, int>();
            
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Enter a number for array index [{i+1}]: ");
                numArray[i] = int.Parse(Console.ReadLine());
            }
            
            foreach (int num in numArray)
            {
                if (!arrayOccurrence.ContainsKey(num))
                    arrayOccurrence.Add(num, 1);
                else
                    arrayOccurrence[num] += 1;
            }
            foreach (var occurence in arrayOccurrence)
                Console.WriteLine($"{occurence.Key} appears {occurence.Value} times.");
            #endregion

            Console.WriteLine("\nPart 3");

            Console.Write("Enter a size for the array: ");
            n = int.Parse(Console.ReadLine());
            int[] numArray2 = new int[n];
            HashSet<int> unique = new HashSet<int>();
            HashSet<int> duplicates = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Enter a number for array index [{i+1}]: ");
                numArray2[i] = int.Parse(Console.ReadLine());
            }

            foreach (int number in numArray2)
            {
                if (!unique.Add(number))
                {
                    duplicates.Add(number);
                }
            }

            Console.WriteLine("The unique elements found in the array are:");

            foreach (int number in unique)
            {
                if (!duplicates.Contains(number))
                {
                    Console.Write(number + " ");
                }
            }
        }

        static double ElectricBill(int usage, out double rate)
        {
            if (usage < 199)
            {
                rate = 1.20d;
                return (double)usage * 1.2;
            }
            else if(usage < 400)
            {
                rate = 1.50d;
                return (double)usage * 1.5;
            }
            else if( usage < 600)
            {
                rate = 1.80d;
                return (double)usage * 1.8;
            }
            else
            {
                rate = 2.00d;
                return (double)usage * 2.0;
            }
        }
        static void DisplayBill(int custID, string custName, int usage, double rate, double billTotal)
        {
            Console.Write($"Customer ID:\t\t{custID}");
            Console.Write($"\nCustomer Name:\t\t{custName}");
            Console.Write($"\nCustomer Usage:\t\t{usage}\n");
            Console.WriteLine(new string('-',30));
            Console.WriteLine($"Usage charges @{rate:C} per unit: {billTotal:C}");
            if (billTotal > 400.00)
            {
                double surcharge = billTotal * .15;
                Console.WriteLine($"Surcharge amount: {surcharge:C}");
                billTotal += surcharge;
                Console.WriteLine($"Total Bill: {billTotal:C}");
            }
            
        }
    }
}
