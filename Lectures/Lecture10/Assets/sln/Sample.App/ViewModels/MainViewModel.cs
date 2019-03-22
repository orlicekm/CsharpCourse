using System.Windows.Input;
using Sample.App.Commands;
using Sample.App.ViewModels.Base;

namespace Sample.App.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string leftText;
        private string rightText;

        public MainViewModel()
        {
            WriteLeftTextCommand = new RelayCommand(WriteLeftText);
            WriteRightTextCommand = new SendRightTextCommand(this);

            LeftText = "Relay Command Sample";
            RightText = "Command Class Sample";
        }

        public string LeftText
        {
            get => leftText;
            set
            {
                leftText = value;
                OnPropertyChanged();
            }
        }

        public string RightText
        {
            get => rightText;
            set
            {
                rightText = value;
                OnPropertyChanged();
            }
        }

        public ICommand WriteLeftTextCommand { get; set; }
        public ICommand WriteRightTextCommand { get; set; }

        private void WriteLeftText(object obj)
        {
            LeftText = obj as string;
        }
    }
}