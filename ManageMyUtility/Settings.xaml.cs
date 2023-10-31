
using System;
using System.IO;
using System.Windows;

namespace ManageMyUtility
{
    /// <summary>
    /// Interaktionslogik für Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
            LoadSettings();

        }

        private void LoadSettings()
        {
            textBox_path.Text = Properties.Settings.Default.Path;
            textBox_passwords.Text = Properties.Settings.Default.PasswordPath;

            string theme = Properties.Settings.Default.Theme;

            if (theme.Equals("Dark"))
            {
                radio_darkmode.IsChecked = true;
            }
            else if (theme.Equals("Light"))
            {
                radio_lightmode.IsChecked = true;
            }
            else if (theme.Equals("HCD"))
            {
                radio_HCD.IsChecked= true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (PathChecker())
            {
                SaveSettings();
                //MainWindow mainWindow = new MainWindow();
                //mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("The directory path for the notes does not exist.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool PathChecker()
        {
            string path = textBox_path.Text;
            if (Directory.Exists(path))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.Path = textBox_path.Text;
            Properties.Settings.Default.Save();

            Properties.Settings.Default.PasswordPath = textBox_passwords.Text;
            Properties.Settings.Default.Save();

            if (radio_darkmode.IsChecked == true)
            {
                Properties.Settings.Default.Theme = "Dark";
                Properties.Settings.Default.Save();
            }
            else if (radio_lightmode.IsChecked == true)
            {
                Properties.Settings.Default.Theme = "Light";
                Properties.Settings.Default.Save();
            }
            else if(radio_HCD.IsChecked == true)
            {
                Properties.Settings.Default.Theme = "HCD";
                Properties.Settings.Default.Save();
            }
            else if(radio_forest.IsChecked == true)
            {
                Properties.Settings.Default.Theme = "Forest";
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.Theme = "Dark";
                Properties.Settings.Default.Save();
            }
        }

        private void Radio_darkmode_Checked(object sender, RoutedEventArgs e)
        {
            ResourceDictionary darkMode = new ResourceDictionary();
            darkMode.Source = new Uri("DarkMode.xaml", UriKind.Relative);
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(darkMode);
        }

        private void Radio_lightmode_Checked(object sender, RoutedEventArgs e)
        {
            ResourceDictionary lightMode = new ResourceDictionary();
            lightMode.Source = new Uri("LightMode.xaml", UriKind.Relative);
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(lightMode);
        }

        private void Radio_hcd_Checked(object sender, RoutedEventArgs e)
        {
            ResourceDictionary hcd = new ResourceDictionary();
            hcd.Source = new Uri("HCD.xaml", UriKind.Relative);
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(hcd);
        }

        private void Radio_forest_Checked(object sender, RoutedEventArgs e)
        {
            ResourceDictionary greenOnBlue = new ResourceDictionary();
            greenOnBlue.Source = new Uri("GreenOnBlue.xaml", UriKind.Relative);
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(greenOnBlue);
        }
    }
}
