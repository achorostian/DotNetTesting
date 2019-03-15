using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MinimalMVVM.Models;
using MinimalMVVM.Services;

namespace MinimalMVVM.ViewModels
{
    public class Presenter : ObservableObject
    {
        private string _someText;
        private readonly ObservableCollection<string> _history = new ObservableCollection<string>();

        public Presenter(IUpperCaseConverterService upperCaseConverterService, string someText)
        {
            SomeText = someText;
            ConverterService = upperCaseConverterService;
        }

        public IUpperCaseConverterService ConverterService { get; set; }

        public string SomeText
        {
            get { return _someText; }
            set
            {
                _someText = value;
                RaisePropertyChangedEvent("SomeText");
            }
        }

        public IEnumerable<string> History
        {
            get { return _history; }
        }

        public ICommand ConvertTextCommand
        {
            get { return new DelegateCommand(ConvertText); }
        }

        public void ConvertText()
        {
            if (string.IsNullOrWhiteSpace(SomeText)) return;
            AddToHistory(ConverterService.Convert(SomeText));
            SomeText = string.Empty;
        }

        public void AddToHistory(string item)
        {
            if (!_history.Contains(item))
                _history.Add(item);
        }
    }
}
