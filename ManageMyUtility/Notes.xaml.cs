using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Path = System.IO.Path;

namespace ManageMyUtility
{
    /// <summary>
    /// Interaction logic for Notes.xaml
    /// </summary>
    public partial class Notes : Window
    {
        private string currentFilePath;

        public Notes()
        {
            InitializeComponent();
            listNotes();
        }

        private void listNotes()
        {
            listBox_notes.Items.Clear();

            string dir = Properties.Settings.Default.Path;
            DirectoryInfo dinfo = new DirectoryInfo(@dir);
            FileInfo[] Files = dinfo.GetFiles("*.txt");

            foreach (FileInfo file in Files)
            {
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file.Name);
                listBox_notes.Items.Add(fileNameWithoutExtension);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            updateTextFile();
            this.Close();
        }

        private void Button_addNotes(object sender, RoutedEventArgs e)
        {
            string dir = Properties.Settings.Default.Path;
            string newFilePath = Path.Combine(dir, "New Note.txt");

            using (File.Create(newFilePath)) { }

            listNotes();

            listBox_notes.SelectedItem = "New Note";
        }

        private void Button_deleteNotes(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(currentFilePath))
            {                
                listBox_notes.UnselectAll();
                textBox_notes.Text = String.Empty;
                textBox_notes.IsEnabled= false;
                textBox_name.Text = String.Empty;
                textBox_name.IsEnabled= false;
                File.Delete(currentFilePath);

                listNotes();
            }
        }

        private void textBox_name_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentFilePath))
            {
                string newFileName = textBox_name.Text + ".txt";
                string newFilePath = Path.Combine(Properties.Settings.Default.Path, newFileName);

                label_error.Visibility = Visibility.Collapsed;

                try
                {
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(currentFilePath);
                    int index = listBox_notes.Items.IndexOf(fileNameWithoutExtension);
                    if (index != -1)
                    {
                        listBox_notes.Items[index] = textBox_name.Text;
                    }

                    File.Move(currentFilePath, newFilePath);
                    currentFilePath = newFilePath;

                }
                catch (Exception)
                {
                    label_error.Visibility = Visibility.Visible;
                    label_error.Content = "Name not allowed";
                }

                listNotes();
            }
        }

        private void listBox_notes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textBox_name.IsEnabled= true;
            textBox_notes.IsEnabled= true;
            changeBoxName();
            changeBoxText();
            updateTextFile();
        }

        private void updateTextFile()
        {
            if (!String.IsNullOrEmpty(currentFilePath))
            {
                File.WriteAllText(currentFilePath, textBox_notes.Text);
            }
        }

        private void changeBoxText()
        {
            if (File.Exists(currentFilePath))
            {
                string fileContents = File.ReadAllText(currentFilePath);
                textBox_notes.Text = fileContents;
            }
            else
            {
                textBox_notes.Text = "Something went wrong, this should never appear";
            }
        }

        private void changeBoxName()
        {
            if (listBox_notes.SelectedItem != null)
            {
                string selectedFileName = listBox_notes.SelectedItem.ToString();
                string dir = Properties.Settings.Default.Path;
                string fileWithPath = Path.Combine(dir, selectedFileName + ".txt");

                currentFilePath = fileWithPath;
                textBox_name.Text = selectedFileName;
            }
        }

        private void textBox_notes_TextChanged(object sender, TextChangedEventArgs e)
        {

            updateTextFile();
        }

        private void Button_Click_save(object sender, RoutedEventArgs e)
        {
            updateTextFile();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
