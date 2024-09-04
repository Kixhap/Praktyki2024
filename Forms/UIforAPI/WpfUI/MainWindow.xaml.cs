using ClassLibrary.Models;
using ClassLibrary.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace WpfUI
{
    public partial class MainWindow : Window
    {
        private readonly ItemViewModel _itemViewModel;


        public MainWindow(ItemViewModel itemViewModel)
        {
            InitializeComponent();
            _itemViewModel = itemViewModel;
            this.DataContext = _itemViewModel;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await _itemViewModel.LoadItemsAsync();
            RefreshItemsListView();
        }

        private async void addButton_Click(object sender, RoutedEventArgs e)
        {
            var newItem = new Item
            {
                Name = nameBox.Text,
                Price = decimal.TryParse(priceBox.Text, out var price) ? price : 0,
            };

            await _itemViewModel.AddItemAsync(newItem);

            idBox.Clear();
            nameBox.Clear();
            priceBox.Clear();
            RefreshItemsListView();
        }

        private async void updateButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(idBox.Text, out var id))
            {
                if (itemsListView.SelectedItem is Item selectedItem)
                {
                    selectedItem.Name = nameBox.Text;
                    selectedItem.Price = decimal.TryParse(priceBox.Text, out var price) ? price : 0;
                    selectedItem.Id = id;

                    await _itemViewModel.UpdateItemAsync(selectedItem);
                    RefreshItemsListView();
                }
                else
                {
                    MessageBox.Show("Please select an item to update.");
                }
            }
            else
            {
                MessageBox.Show("Invalid ID. Please enter a valid number.");
            }
        }

        private async void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (itemsListView.SelectedItem is Item selectedItem)
            {
                await _itemViewModel.DeleteItemAsync((int)selectedItem.Id);

                idBox.Clear();
                nameBox.Clear();
                priceBox.Clear();
                RefreshItemsListView();
            }
            else
            {
                MessageBox.Show("Please select an item to delete.");
            }
        }

        private async void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            await _itemViewModel.LoadItemsAsync();
            RefreshItemsListView();
        }

        private void RefreshItemsListView()
        {
            itemsListView.Items.Clear();
            foreach (var item in _itemViewModel.Items)
            {
                itemsListView.Items.Add(item);
            }
        }

        private void itemsListView_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (itemsListView.SelectedItem is Item selectedItem)
            {
                idBox.Text = selectedItem.Id.ToString();
                nameBox.Text = selectedItem.Name;
                priceBox.Text = selectedItem.Price.ToString("F");
            }
        }
    }
}
