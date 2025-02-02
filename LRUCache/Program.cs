namespace LRUCache
{
    public static class Program
    {
        private static LRUCache? cache = null;
        private static int cacheSize;

        public static void Main(string[] args)
        {
            bool isValidSize;

            do
            {
                Console.WriteLine($"Enter a cache size greater than 0");
                Console.WriteLine();

                isValidSize = int.TryParse(Console.ReadLine()!, out cacheSize);

                if (isValidSize && cacheSize < 1)
                {
                    isValidSize = false;
                }
            }
            while (!isValidSize);

            cache = new LRUCache(cacheSize);

            BeginProcess();
        }

        public static void BeginProcess()
        {
            bool isValidOperationSelection,
                 isValidTermnationSelection;

            int selectedOperation;

            do
            {
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("Select an Operation by entering the number.");
                    Console.WriteLine("If not, Press 0 to Exit the App");
                    Console.WriteLine();
                    Console.WriteLine("1. Insert into Cache");
                    Console.WriteLine("2. Retrieve from Cache");
                    Console.WriteLine();

                    isValidOperationSelection = int.TryParse(Console.ReadLine()!, out selectedOperation);
                    isValidTermnationSelection = isValidOperationSelection;

                    if (isValidOperationSelection)
                    {
                        if (selectedOperation == 0)
                        {
                            isValidOperationSelection = false;
                        }
                        else
                        {
                            isValidTermnationSelection = false;

                            if (selectedOperation < 0 || selectedOperation > 2)
                            {
                                isValidOperationSelection = false;
                            }
                        }
                    }
                }
                while (!isValidOperationSelection && !isValidTermnationSelection);

                if (isValidOperationSelection)
                {
                    HandleOperation(selectedOperation);
                }
            }
            while (!isValidTermnationSelection);

            Console.WriteLine();
            Console.WriteLine("App exited gracefully");
            Console.WriteLine();
        }

        public static void HandleOperation(int selectedOperation)
        {
            var operationName = selectedOperation switch
            {
                1 => "Put",
                2 => "Get",
                _ => ""
            };

            bool isValidKey,
                 isValidValue;

            int key,
                value;

            do
            {
                Console.WriteLine();
                Console.WriteLine($"Enter the valid integer key for the {operationName} operation");
                Console.WriteLine();

                isValidKey = int.TryParse(Console.ReadLine()!, out key);
            }
            while (!isValidKey);

            if (selectedOperation == 1)
            {
                do
                {
                    Console.WriteLine();
                    Console.WriteLine($"Enter the valid integer value for the {operationName} operation");
                    Console.WriteLine();

                    isValidValue = int.TryParse(Console.ReadLine()!, out value);
                }
                while (!isValidValue);

                cache!.Put(key, value);
            }
            else
            {
                value = cache!.Get(key);
            }

            PrintResult(operationName, key, value);
        }

        public static void PrintResult(string operationName, int key, int value)
        {
            Console.WriteLine();
            Console.WriteLine("The {0} operation returns a value of {1} with key {2}", operationName, value, key);
            Console.WriteLine();
        }
    }
}