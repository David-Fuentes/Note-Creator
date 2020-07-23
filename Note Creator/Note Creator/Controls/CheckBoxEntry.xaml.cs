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
    public partial class CheckBoxEntry : UserControl , INotifyPropertyChanged
    {
        public CheckBoxEntry()
        {
            DataContext = this;
            BoxChecked = false;
            InitializeComponent();
        }

        private bool m_boxChecked;
        public bool BoxChecked
        {
            get { return m_boxChecked; }
            set { m_boxChecked = value; OnPropertyChanged("BoxChecked"); }
        }

        public string LabelContent
        {
            get { return (string)GetValue(LabelContentProperty); }
            set { SetValue(LabelContentProperty, value); }
        }
        public static readonly DependencyProperty LabelContentProperty =
            DependencyProperty.Register("LabelContent", typeof(string), typeof(CheckBoxEntry), new PropertyMetadata("Change me"));

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            EventHelper.OnUpdateNoteContent(this, new EventArgs());
        }
    }
}
