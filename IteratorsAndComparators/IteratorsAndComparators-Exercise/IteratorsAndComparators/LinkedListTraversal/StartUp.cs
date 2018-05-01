using System;

 public  class StartUp
    {
       public static void Main()
        {
            CustomLinkedList<int>elements=new CustomLinkedList<int>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split();
                string command = input[0];
                int element = int.Parse(input[1]);

                switch (command)
                {
                case "Add":
                    elements.Add(element);
                    break;
                case "Remove":
                    elements.Remove(element);
                    break;
                }
            }

            Console.WriteLine(elements.Count);
            Console.WriteLine(string.Join(" ",elements));
        }
    }

