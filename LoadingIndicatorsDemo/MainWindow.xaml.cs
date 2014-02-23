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
            bool isdoublebounceactive;
            bool isflipplaneactive;
            bool ispulseactive;
            bool isringactive;
            bool isthreedotsactive;
            bool iswaveactive;

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
            public bool IsDoubleBounceActive
            {
                get { return isdoublebounceactive; }
                set
                {
                    if (isdoublebounceactive != value) {
                        isdoublebounceactive = value;
                        OnPropertyChanged("IsDoubleBounceActive");
                    }
                }
            }
            public bool IsFlipPlaneActive
            {
                get { return isflipplaneactive; }
                set
                {
                    if (isflipplaneactive != value) {
                        isflipplaneactive = value;
                        OnPropertyChanged("IsFlipPlaneActive");
                    }
                }
            }
            public bool IsPulseActive
            {
                get { return ispulseactive; }
                set
                {
                    if (ispulseactive != value) {
                        ispulseactive = value;
                        OnPropertyChanged("IsPulseActive");
                    }
                }
            }
            public bool IsRingActive
            {
                get { return isringactive; }
                set
                {
                    if (isringactive != value) {
                        isringactive = value;
                        OnPropertyChanged("IsRingActive");
                    }
                }
            }
            public bool IsThreeDotsActive
            {
                get { return isthreedotsactive; }
                set
                {
                    if (isthreedotsactive != value) {
                        isthreedotsactive = value;
                        OnPropertyChanged("IsThreeDotsActive");
                    }
                }
            }
            public bool IsWaveActive
            {
                get { return iswaveactive; }
                set
                {
                    if (iswaveactive != value) {
                        iswaveactive = value;
                        OnPropertyChanged("IsWaveActive");
                    }
                }
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
                this.IsDoubleBounceActive = true;
            }
        }
    }
}
