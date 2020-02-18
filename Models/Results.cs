using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    public static class Results
    {
        private static Dictionary<(string operation, string framework), TimeSpan> 
            _results = new Dictionary<(string operation, string framework), TimeSpan>();

        public static void Add(string operation, string framework, TimeSpan elapsed)
        {
            _results.Add((operation, framework), elapsed);
        }

        public static void Show()
        {
            ShowOperation("AddCustomers");
            ShowOperation("AddAllCustomers");
            ShowOperation("QueryCustomers");
        }

        private static void ShowOperation(string operation)
        {
            Console.WriteLine();
            Console.WriteLine($"--- The best of {operation} ---");

            TimeSpan? firstTime = null;
            foreach (var ((_, framework), value) in _results
                .Where(r => r.Key.operation.Equals(operation))
                .OrderBy(r => r.Value))
            {
                if (firstTime == null)
                {
                    firstTime = value;

                    Console.WriteLine($"{framework} - {value}");
                }
                else
                {
                    Console.WriteLine($"{framework} - {value} - {Math.Round((double)(value / firstTime), 2)} times more slow");
                }
            }
        }
    }
}
