using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ManageMyUtility
{
    /// <summary>
    /// Interaction logic for Stopwatch.xaml
    /// </summary>


    public partial class Stopwatch : Window
    {
        private DispatcherTimer _timer;
        private TimeSpan _elapsedTime;

        public Stopwatch()
        {
            InitializeComponent();
            LoadSettings();
            UpdateTimeLabels();
        }

        private void LoadSettings()
        {
            _elapsedTime = Properties.Settings.Default.ElapsedTime;
        }

        private void Button_Click_start(object sender, RoutedEventArgs e)
        {
            if (_timer == null)
            {
                _timer = new DispatcherTimer();
                _timer.Interval = TimeSpan.FromSeconds(1);
                _timer.Tick += Timer_Tick;
            }

            _timer.Start();
        }

        private void Button_Click_stop(object sender, RoutedEventArgs e)
        {
            if (_timer != null)
            {
                _timer.Stop();
            }
        }

        private void Button_Click_reset(object sender, RoutedEventArgs e)
        {
            _elapsedTime = TimeSpan.Zero;
            UpdateTimeLabels();
        }

        private void Button_Click_saveandclose(object sender, RoutedEventArgs e)
        {
            SaveTime();
            this.Close();
        }

        private void SaveTime()
        {
            Properties.Settings.Default.ElapsedTime= _elapsedTime;
            Properties.Settings.Default.Save();

            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _elapsedTime = _elapsedTime.Add(TimeSpan.FromSeconds(1));
            UpdateTimeLabels();
        }

        private void UpdateTimeLabels()
        {
            label_hours.Content = _elapsedTime.Hours.ToString();
            label_minutes.Content = _elapsedTime.Minutes.ToString();
            label_seconds.Content = _elapsedTime.Seconds.ToString();
        }
    }

}
