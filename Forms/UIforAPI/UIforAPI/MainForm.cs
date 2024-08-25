using System;
using System.Windows.Forms;
using UIforAPI.ViewModels;
using UIforAPI.Models;

namespace UIforAPI
{
    public partial class MainForm : Form
    {
        private readonly ItemViewModel _itemViewModel;

        public MainForm(ItemViewModel itemViewModel)
        {
            InitializeComponent();
            _itemViewModel = itemViewModel;
            this.Shown += async (sender, e) => await _itemViewModel.LoadItemsAsync();
        }

        private async void addButton_Click(object sender, EventArgs e)
        {
            var newItem = new Item
            {
                Name = nameBox.Text,
                Price = decimal.TryParse(priceBox.Text, out var price) ? price : 0,
                Id = string.IsNullOrWhiteSpace(idBox.Text) ? (int?)null : int.TryParse(idBox.Text, out var id) ? id : (int?)null,
            };

            await _itemViewModel.AddItemAsync(newItem);

            idBox.Clear();
            nameBox.Clear();
            priceBox.Clear();
            RefreshItemsListView();
        }

        private async void updateButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(idBox.Text, out var id))
            {
                if (itemsListView.SelectedItems.Count > 0)
                {
                    var selectedItem = (Item)itemsListView.SelectedItems[0].Tag;
                    if (selectedItem != null)
                    {
                        selectedItem.Name = nameBox.Text;
                        selectedItem.Price = decimal.TryParse(priceBox.Text, out var price) ? price : 0;
                        selectedItem.Id = id;

                        await _itemViewModel.UpdateItemAsync(selectedItem);
                        RefreshItemsListView();
                    }
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

        private async void deleteButton_Click(object sender, EventArgs e)
        {
            if (itemsListView.SelectedItems.Count > 0)
            {
                var selectedItem = (Item)itemsListView.SelectedItems[0].Tag;
                if (selectedItem != null)
                {
                    await _itemViewModel.DeleteItemAsync((int)selectedItem.Id);

                    idBox.Clear();
                    nameBox.Clear();
                    priceBox.Clear();
                    RefreshItemsListView();
                }
            }
            else
            {
                MessageBox.Show("Please select an item to delete.");
            }
        }

        private async void refreshButton_Click(object sender, EventArgs e)
        {
            await _itemViewModel.LoadItemsAsync();
            RefreshItemsListView();
        }

        private void RefreshItemsListView()
        {
            itemsListView.Items.Clear();
            foreach (var item in _itemViewModel.Items)
            {
                var listViewItem = new ListViewItem(item.Id.ToString());
                listViewItem.SubItems.Add(item.Name);
                listViewItem.SubItems.Add(item.Price.ToString("C"));
                listViewItem.Tag = item;

                itemsListView.Items.Add(listViewItem);
            }
        }

        private void itemsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (itemsListView.SelectedItems.Count > 0)
            {
                var selectedItem = (Item)itemsListView.SelectedItems[0].Tag;
                if (selectedItem != null)
                {
                    idBox.Text = selectedItem.Id.ToString();
                    nameBox.Text = selectedItem.Name;
                    priceBox.Text = selectedItem.Price.ToString("F");
                }
            }
        }
    }
}
