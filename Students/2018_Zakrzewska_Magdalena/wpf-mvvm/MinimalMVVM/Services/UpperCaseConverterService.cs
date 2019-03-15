using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinimalMVVM.Services
{
    public class UpperCaseConverterService : IUpperCaseConverterService
    {
        public string Convert(string input)
        {
            return input.ToUpper();
        }
    }
}
