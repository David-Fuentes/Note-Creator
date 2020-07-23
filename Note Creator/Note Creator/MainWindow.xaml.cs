using Note_Creator.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Note_Creator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            Result = "Nothing yet";
            DataContext = this;
            InitializeComponent();
            EventHelper.UpdateNoteContent += EventHelper_UpdateNoteContent;
            UpdateResult();
        }

        private void EventHelper_UpdateNoteContent(object sender, EventArgs e)
        {
            UpdateResult();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            UpdateResult();
        }

        private void UpdateResult()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("INFO:");
            stringBuilder.Append(Verified.BoxChecked ? "Verified" : "Not Verified");
            if (CustomerName.TextBoxContent != null || CustomerName.TextBoxContent.Trim() == "")
                stringBuilder.Append($"{CustomerName.TextBoxContent} on phone");

            Result = stringBuilder.ToString();
            Console.WriteLine("Updated content");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        

        private bool? wasValidated = false;

        private string m_result;
        public string Result
        {
            get { return m_result; }
            set { m_result = value; OnPropertyChanged("Result"); }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
