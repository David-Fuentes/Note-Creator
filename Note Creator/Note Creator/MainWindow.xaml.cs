using Note_Creator.Helpers;
using System;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Note_Creator
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            EventHelper.UpdateNoteContent += EventHelper_UpdateNoteContent;
            UpdateResult();
        }

        private string m_result;
        public string Result
        {
            get { return m_result; }
            set { m_result = value; OnPropertyChanged("Result"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void EventHelper_UpdateNoteContent(object sender, EventArgs e)
        {
            UpdateResult();
        }

        private void UpdateResult()
        {
            var resultBuilder = new StringBuilder();
            resultBuilder.AppendLine("INFO:");
            resultBuilder.AppendLine(Checkbox_Verified.BoxChecked ? "Verified" : "Not verified");
            if (!TextHelper.IsNullOrEmpty(Textbox_CustomerName.TextBoxContent))
                resultBuilder.AppendLine($"{Textbox_CustomerName.TextBoxContent} on phone");

            if(Expander_AccountInfo.IsExpanded)
            {
                if (Expander_Email.IsExpanded && 
                    !TextHelper.IsNullOrEmpty(Textbox_OldEmail.TextBoxContent) && 
                    !TextHelper.IsNullOrEmpty(Textbox_NewEmail.TextBoxContent))
                {
                    resultBuilder.AppendLine(
                        $"Updated email:\n" +
                        $"\tOld email: {Textbox_OldEmail.TextBoxContent}\n" +
                        $"\tNew email: {Textbox_NewEmail.TextBoxContent}");
                }
                resultBuilder.Append(Checkbox_ShippingAddress.BoxChecked ? "Updated shipping address\n" : "");
                resultBuilder.Append(Checkbox_PasswordReset.BoxChecked ? "Sent password reset\n" : "");
            }

            resultBuilder.Append(Checkbox_ComputerRestarted.BoxChecked ? "Computer restarted\n" : "");
            resultBuilder.Append(Checkbox_SignedIn.BoxChecked ? "Signed into their account\n" : "");
            if (!TextHelper.IsNullOrEmpty(Textbox_VersionNumber.TextBoxContent))
                resultBuilder.AppendLine($"Software is running version {Textbox_VersionNumber.TextBoxContent}");
            resultBuilder.Append(Checkbox_OSUpdated.BoxChecked ? "OS is up to date\n" : "");

            resultBuilder.AppendLine("\nSTEPS TAKEN:");
            resultBuilder.AppendLine($"{AdditionalNotes.Text}\n");

            resultBuilder.Append(Checkbox_SentTraining.BoxChecked ? "Sent customer training\n" : "");
            resultBuilder.AppendLine(Checkbox_Offered.BoxChecked ? "Offered" : "Did not offer");

            Result = resultBuilder.ToString();
            HideCopyMessage();
        }

        private void HideCopyMessage()
        {
            CopyMessage.Visibility = Visibility.Hidden;
        }

        private void ShowCopyMessage()
        {
            CopyMessage.Visibility = Visibility.Visible;
        }

        private void AdditionalNotes_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateResult();
        }

        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(Result);
            ShowCopyMessage();
        }

        private void NoteBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            HideCopyMessage();
        }
    }
}
