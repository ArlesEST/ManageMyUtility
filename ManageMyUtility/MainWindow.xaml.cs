using System;
using System.Windows;

namespace ManageMyUtility
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            SetTheme();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
            //this.Close();
        }

        private void SetTheme()
        {
            string theme = Properties.Settings.Default.Theme;
            if (theme.Equals("Dark"))
            {
                ResourceDictionary darkMode = new ResourceDictionary();
                darkMode.Source = new Uri("DarkMode.xaml", UriKind.Relative);
                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(darkMode);
            }
            else if (theme.Equals("Light"))
            {
                ResourceDictionary lightMode = new ResourceDictionary();
                lightMode.Source = new Uri("LightMode.xaml", UriKind.Relative);
                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(lightMode);
            }
            else if (theme.Equals("HCD"))
            {
                ResourceDictionary hcd = new ResourceDictionary();
                hcd.Source = new Uri("HCD.xaml", UriKind.Relative);
                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(hcd);
            }
            else if (theme.Equals("Forest"))
            {
                ResourceDictionary greenOnBlue = new ResourceDictionary();
                greenOnBlue.Source = new Uri("GreenOnBlue.xaml", UriKind.Relative);
                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(greenOnBlue);
            }
        }

        

        private void Button_Click_stopwatch(object sender, RoutedEventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Show();
        }

        private void Button_Click_notes(object sender, RoutedEventArgs e)
        {
            string path = Properties.Settings.Default.Path;
            if (!path.Equals(""))
            {
                Notes notes = new Notes();
                notes.Show();
            }
            else
            {
                MessageBox.Show("Set a file path in the settings first.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
