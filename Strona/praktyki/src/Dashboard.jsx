import React, { useEffect, useState } from 'react';
import { fetchItems, postItem, deleteItem, editItem, putItem } from './API';

const Dashboard = ({ credentials }) => {
  const [items, setItems] = useState([]);
  const [error, setError] = useState(null);
  const [newItem, setNewItem] = useState({ id: '', name: '', price: '' });
  const [editingItem, setEditingItem] = useState(null);
  const [isPutMethod, setIsPutMethod] = useState(false);
  const [isAuthenticated, setIsAuthenticated] = useState(true); // Track authentication status

  useEffect(() => {
    loadItems();
  }, [credentials]);

  const loadItems = () => {
    fetchItems(credentials)
      .then(data => {
        setItems(data);
        setError(null);
        setIsAuthenticated(true); // Set authenticated status to true on successful fetch
      })
      .catch(error => {
        console.error('Fetch items failed:', error);
        setError(error.message);
        setIsAuthenticated(false); // Set authenticated status to false on error
      });
  };

  const handleAddItem = () => {
    if (isPutMethod && !newItem.id) {
      setError('ID is required for PUT method');
      return;
    }

    const addOrUpdateItem = isPutMethod ? putItem : postItem;

    const itemToSend = isPutMethod 
      ? newItem 
      : { name: newItem.name, price: newItem.price };

    addOrUpdateItem(itemToSend, credentials)
      .then(data => {
        if (data) {
          setItems([...items, data]);
        }
        setNewItem({ id: '', name: '', price: '' });
        loadItems();
      })
      .catch(error => {
        console.error('Add item failed:', error);
        setError(error.message);
      });
  };

  const handleDeleteItem = (id) => {
    deleteItem(id, credentials)
      .then(() => {
        setItems(items.filter(item => item.id !== id));
      })
      .catch(error => {
        console.error('Delete item failed:', error);
        setError(error.message);
      });
  };

  const startEditingItem = (item) => {
    setEditingItem(item);
    setError(null);
  };

  const handleEditItem = () => {
    if (!editingItem || !editingItem.id) {
      setError('ID is required for editing');
      return;
    }

    const updatedItem = {
      id: editingItem.id,
      name: editingItem.name,
      price: editingItem.price
    };

    editItem(updatedItem, credentials)
    .then((updatedData) => {
      setItems(items.map(item => (item.id === updatedData.id ? updatedData : item)));
      setEditingItem(null);
      loadItems();
    })
    .catch(error => {
      console.error('Edit item failed:', error);
      setError(error.message);
    });
  }  

  return (
    <div style={{ display: 'flex', justifyContent: 'space-between' }}>
      <div>
        <h2>Dashboard</h2>
        {!isAuthenticated && (
          <p style={{ color: 'red' }}>You are not logged in. Please log in to access the items.</p>
        )}
        <button onClick={loadItems}>Odśwież listę</button>
        {error && (
          <p style={{ color: 'red' }}>Error: {error}</p>
        )}
        <div>
          <ul style={{ textAlign: 'left' }}>
            {items.map(item => (
              <li key={item.id}>
                ID: {item.id} - {item.name} - {item.price} PLN
                <button onClick={() => handleDeleteItem(item.id)}>Usuń</button>
                <button onClick={() => startEditingItem(item)}>Edytuj</button>
              </li>
            ))}
          </ul>
        </div>
      </div>

      <div style={{ marginLeft: '20px' }}>
        <h3>Dodaj nowy element</h3>
        <label>
          <input
            type="checkbox"
            checked={isPutMethod}
            onChange={() => setIsPutMethod(!isPutMethod)}
          />
          Użyj metody PUT
        </label>
        {isPutMethod && (
          <input
            type="text"
            placeholder="ID"
            value={newItem.id}
            onChange={(e) => setNewItem({ ...newItem, id: e.target.value })}
          />
        )}
        <input
          type="text"
          placeholder="Nazwa"
          value={newItem.name}
          onChange={(e) => setNewItem({ ...newItem, name: e.target.value })}
        />
        <input
          type="number"
          placeholder="Cena"
          value={newItem.price}
          onChange={(e) => setNewItem({ ...newItem, price: e.target.value })}
        />
        <button onClick={handleAddItem}>
          {isPutMethod ? 'Zaktualizuj lub Dodaj (PUT)' : 'Dodaj (POST)'}
        </button>
      </div>

      {editingItem && (
        <div style={{ marginLeft: '20px' }}>
          <h3>Edytuj element</h3>
          <input
            type="text"
            placeholder='ID'
            value={editingItem.id || ''}
            onChange={(e) => setEditingItem({ ...editingItem, id: e.target.value })}
            disabled
          />
          <input
            type="text"
            placeholder="Nazwa"
            value={editingItem.name}
            onChange={(e) => setEditingItem({ ...editingItem, name: e.target.value })}
          />
          <input
            type="number"
            placeholder="Cena"
            value={editingItem.price}
            onChange={(e) => setEditingItem({ ...editingItem, price: e.target.value })}
          />
          <button onClick={handleEditItem}>Zapisz zmiany</button>
        </div>
      )}
    </div>
  );
};

export default Dashboard;
