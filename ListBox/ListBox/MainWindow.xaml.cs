using System;
using System.Collections.Generic;
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

namespace ListBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            itemTextBox.Focus();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem newItem = new ListBoxItem();
            newItem.Content = itemTextBox.Text;
            shoppingListBox.Items.Add(newItem);
            aantalTextBlock.Text = "aantal: " + shoppingListBox.Items.Count;
            itemTextBox.Clear();
            itemTextBox.Focus();
        }

        private void shoppingListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            numberTextBlock.Text = Convert.ToString(shoppingListBox.SelectedIndex);
            int index = Convert.ToInt32(numberTextBlock.Text);
            ListBoxItem item = (ListBoxItem)shoppingListBox.Items[index];
            waardeTextBlock.Text = Convert.ToString(item.Content);
            TextBlockItem.Text = Convert.ToString(shoppingListBox.SelectedItem);
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            shoppingListBox.Items.RemoveAt(Convert.ToInt32(numberTextBlock.Text));
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            int index = Convert.ToInt32(insertIndexTextBox.Text);
            string item = itemTextBox.Text;
            shoppingListBox.Items.Insert(index, item);
        }

        private void findButton_Click(object sender, RoutedEventArgs e)
        {
            int length = shoppingListBox.Items.Count;
            int index = 0;
            bool found = false;
            string itemWanted = findTextBox.Text;
            ListBoxItem item;

            while ((!found) && (index < length))
            {
                item = (ListBoxItem)shoppingListBox.Items[index];
                if (Convert.ToString(item.Content) == itemWanted)
                {
                    found = true;
                    FoundTextBox.Text = "Item found, index: " + index;
                }
                else
                {
                    index++;
                }
            }
        }
    }
}
