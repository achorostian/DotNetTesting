using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1.Services
{
    public class DialogBoxService : IDialogBoxService
    {
        public bool AreYouSureQuestion(string content)
        {
            return MessageBox.Show(content, "Are you sure?", MessageBoxButton.YesNo) == MessageBoxResult.Yes;
        }
    }
}
