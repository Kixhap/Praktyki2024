using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WindowsFormsApp.Models;

namespace UIforAPI.ViewModels
{
    public class ItemViewModel : ObservableObject
    {
        private readonly HttpClient _httpClient;
        private string _username;
        private string _password;
        private bool _isAuthenticated;

        public ObservableCollection<Item> Items { get; private set; }
        public ICommand LoadItemsCommand { get; }
        public ICommand AddItemCommand { get; }
        public ICommand UpdateItemCommand { get; }
        public ICommand DeleteItemCommand { get; }

        public ItemViewModel()
        {
            _httpClient = new HttpClient { BaseAddress = new System.Uri("https://localhost:5001/api/") };
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new RelayCommand(async () => await LoadItemsAsync(), () => _isAuthenticated);
            AddItemCommand = new RelayCommand(async () => await AddItemAsync(new Item { Name = "New Item", Description = "Description" }), () => _isAuthenticated);
            UpdateItemCommand = new RelayCommand(async () => await UpdateItemAsync(new Item { Id = 1, Name = "Updated Item", Description = "Updated Description" }), () => _isAuthenticated);
            DeleteItemCommand = new RelayCommand(async () => await DeleteItemAsync(1), () => _isAuthenticated);
        }

        public void SetCredentials(string username, string password)
        {
            _username = username;
            _password = password;
            var authToken = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_username}:{_password}"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);
            _isAuthenticated = true;
        }

        private async Task LoadItemsAsync()
        {
            var response = await _httpClient.GetStringAsync("items");
            var items = JsonConvert.DeserializeObject<List<Item>>(response);
            Items.Clear();
            foreach (var item in items)
            {
                Items.Add(item);
            }
        }

        private async Task AddItemAsync(Item item)
        {
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await _httpClient.PostAsync("items", content);
            await LoadItemsAsync();
        }

        private async Task UpdateItemAsync(Item item)
        {
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await _httpClient.PutAsync($"items/{item.Id}", content);
            await LoadItemsAsync();
        }

        private async Task DeleteItemAsync(int id)
        {
            await _httpClient.DeleteAsync($"items/{id}");
            await LoadItemsAsync();
        }
    }
}
