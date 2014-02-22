using LoadingIndicators.WPF;
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

namespace LoadingIndicatorsDemo
{
    public partial class MainWindow : Window
    {
        // Properties
        private MainWindowViewModel ViewModel
        {
            get { return (DataContext as MainWindowViewModel); }
            set { DataContext = value; }
        }

        // Handlers
        private void LoadingIndicator_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            LoadingIndicator li = (LoadingIndicator) sender;

            if (li.SpeedRatio == 1.0) {
                li.SpeedRatio = 0.3;
            } else {
                li.SpeedRatio = 1.0;
            }
        }

        // Constructors
        public MainWindow()
        {
            this.ViewModel = new MainWindowViewModel();

            InitializeComponent();
        }

        // Classes
        class MainWindowViewModel : INotifyPropertyChanged
        {
            // Variables
            double speedratio;

            // Properties
            public double SpeedRatio
            {
                get { return speedratio; }
                set
                {
                    if (speedratio != value) {
                        speedratio = value;
                        OnPropertyChanged("SpeedRatio");
                        OnPropertyChanged("SpeedRatioText");
                    }
                }
            }
            public string SpeedRatioText
            {
                get { return this.SpeedRatio.ToString(); }
            }

            // Events
            public event PropertyChangedEventHandler PropertyChanged;

            // Protected
            protected void OnPropertyChanged(string propertyname)
            {
                if (this.PropertyChanged != null) {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
                }
            }

            // Constructors
            public MainWindowViewModel()
            {
                this.SpeedRatio = 1.0;
            }
        }
    }
}
