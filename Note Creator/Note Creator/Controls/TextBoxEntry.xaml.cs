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

namespace Note_Creator.Controls
{
    /// <summary>
    /// Interaction logic for TextBoxEntry.xaml
    /// </summary>
    public partial class TextBoxEntry : UserControl, INotifyPropertyChanged
    {
        public TextBoxEntry()
        {
            DataContext = this;
            TextBoxContent = "";
            InitializeComponent();
        }

        public string LabelContent
        {
            get { return (string)GetValue(LabelContentProperty); }
            set { SetValue(LabelContentProperty, value); }
        }
        public static readonly DependencyProperty LabelContentProperty =
            DependencyProperty.Register("LabelContent", typeof(string), typeof(TextBoxEntry), new PropertyMetadata("Please Change me"));

        private string m_textBoxContent;
        public string TextBoxContent
        {
            get { return m_textBoxContent; }
            set { m_textBoxContent = value; OnPropertyChanged("TextBoxContent"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        private void InputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            EventHelper.OnUpdateNoteContent(this, new EventArgs());
        }
    }
}
