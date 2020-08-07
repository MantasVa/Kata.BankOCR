using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.BankOCR.Infrastructure
{
    public static class FaxFileReader
    {
        public static string[] GetInputText()
        {
            return System.IO.File.ReadAllLines(Configuration.FaxInputPath);
        }
    }
}
