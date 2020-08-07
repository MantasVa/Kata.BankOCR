using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.BankOCR.Infrastructure
{
    public static class Configuration
    {
        public static readonly string FaxInputPath = @"C:\Users\User 7\Desktop\Kata\Kata.BankOCR\BankOCR.txt";
        public static readonly string FaxWriterPath = @"C:\Users\User 7\Desktop\Kata\Kata.BankOCR\Output.txt";
        public static readonly IDictionary<string, short> NumberTemplates = new Dictionary<string, short>() 
        {
            [ "     |  |   "] = 1,
            [" _  _||_    "] = 2,
            [" _  _| _|   "] = 3,
            ["   |_|  |   "] = 4,
            [" _ |_  _|   "] = 5,
            [" _ |_ |_|   "] = 6,
            [" _   |  |   "] = 7,
            [" _ |_||_|   "] = 8,
            [" _ |_| _|   "] = 9
        };
         
    }
}
