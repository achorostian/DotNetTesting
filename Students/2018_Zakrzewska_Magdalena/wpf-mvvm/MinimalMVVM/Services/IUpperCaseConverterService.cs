using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinimalMVVM.Services
{
    public interface IUpperCaseConverterService
    {
        String Convert(string input);
    }
}
