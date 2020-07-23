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
    /// Interaction logic for CollapsibleContent.xaml
    /// </summary>
    public partial class CollapsibleContent : UserControl, INotifyPropertyChanged
    {
        public CollapsibleContent()
        {
            ContentIsVisible = ControlIsChecked = false;
            DataContext = this;
            InitializeComponent();
        }

        public object CollapseContent
        {
            get { return (object)GetValue(CollapseContentProperty); }
            set { SetValue(CollapseContentProperty, value); }
        }
        public static readonly DependencyProperty CollapseContentProperty =
            DependencyProperty.Register("CollapseContent", typeof(object), typeof(CollapsibleContent), new PropertyMetadata("Content"));

        public string LabelContent
        {
            get { return (string)GetValue(LabelContentProperty); }
            set { SetValue(LabelContentProperty, value); }
        }
        public static readonly DependencyProperty LabelContentProperty =
            DependencyProperty.Register("LabelContent", typeof(string), typeof(CollapsibleContent), new PropertyMetadata("Change me"));

        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }
        public static readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.Register("IsChecked", typeof(bool), typeof(CollapsibleContent), new PropertyMetadata(false));

        private bool m_isVisible;
        public bool ContentIsVisible
        {
            get { return m_isVisible; }
            set { m_isVisible = value; OnPropertyChanged("ContentIsVisible"); }
        }

        private bool m_controlIsChecked;
        public bool ControlIsChecked
        {
            get { return m_controlIsChecked; }
            set { m_controlIsChecked = value; OnPropertyChanged("ControlIsChecked"); }
        }


        private void EnablerCheckBox_Toggle(object sender, RoutedEventArgs e)
        {
            ControlIsChecked = ContentIsVisible = !ContentIsVisible;
            EventHelper.OnUpdateNoteContent(this, new EventArgs());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
