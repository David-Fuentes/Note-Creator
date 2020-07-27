using Note_Creator.Helpers;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

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

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
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
            DependencyProperty.Register("LabelContent", typeof(string), typeof(CheckBoxEntry), new PropertyMetadata("Adjust Label Content"));

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            EventHelper.OnUpdateNoteContent(this, new EventArgs());
        }
    }
}
