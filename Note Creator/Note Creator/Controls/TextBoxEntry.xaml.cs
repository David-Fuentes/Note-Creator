using Note_Creator.Helpers;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Note_Creator.Controls
{
    public partial class TextBoxEntry : UserControl, INotifyPropertyChanged
    {
        public TextBoxEntry()
        {
            DataContext = this;
            TextBoxContent = "";
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string LabelContent
        {
            get { return (string)GetValue(LabelContentProperty); }
            set { SetValue(LabelContentProperty, value); }
        }

        private string m_textBoxContent;
        public string TextBoxContent
        {
            get { return m_textBoxContent; }
            set { m_textBoxContent = value; OnPropertyChanged("TextBoxContent"); }
        }

        public static readonly DependencyProperty LabelContentProperty =
            DependencyProperty.Register("LabelContent", typeof(string), typeof(TextBoxEntry), new PropertyMetadata("Please Change me"));

        private void InputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBoxContent = InputBox.Text;
            InputBox.Focus();
        }

        private void InputBox_LostFocus(object sender, RoutedEventArgs e)
        {
            EventHelper.OnUpdateNoteContent(this, new EventArgs());
        }
    }
}
