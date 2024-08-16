import React, { useEffect, useState } from 'react';

const Dashboard = () => {
  const [items, setItems] = useState([]);
  const [error, setError] = useState(null);
  const [newItem, setNewItem] = useState({ name: '', price: '' });
  const [editingItem, setEditingItem] = useState(null);

  const fetchItems = () => {
    fetch('https://localhost:7217/api/items')
      .then(response => {
        if (!response.ok) {
          throw new Error(`Failed to fetch items: ${response.statusText}`);
        }
        return response.json();
      })
      .then(data => setItems(data))
      .catch(error => {
        console.error('Fetch items failed:', error);
        setError(error.message);
      });
  };

  useEffect(() => {
    fetchItems();
  }, []);

  const handleAddItem = () => {
    fetch('https://localhost:7217/api/items', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(newItem),
    })
      .then(response => {
        if (!response.ok) {
          throw new Error(`Failed to add item: ${response.statusText}`);
        }
        return response.json();
      })
      .then(data => {
        setItems([...items, data]);
        setNewItem({ name: '', price: '' });
      })
      .catch(error => {
        console.error('Add item failed:', error);
        setError(error.message);
      });
  };

  const handleDeleteItem = (id) => {
    fetch(`https://localhost:7217/api/items/${id}`, {
      method: 'DELETE',
    })
      .then(response => {
        if (!response.ok) {
          throw new Error(`Failed to delete item: ${response.statusText}`);
        }
        return response.text(); // Oczekuj na odpowiedź tekstową
      })
      .then(() => {
        setItems(items.filter(item => item.id !== id));
      })
      .catch(error => {
        console.error('Delete item failed:', error);
        setError(error.message);
      });
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

    fetch(`https://localhost:7217/api/items/${editingItem.id}`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(updatedItem),
    })
      .then(response => {
        console.log('Response status:', response.status); // Debugging
        console.log('Response headers:', response.headers); // Debugging
        return response.text(); // Read response as text first
      })
      .then(text => {
        console.log('Response text:', text); // Debugging
        if (!text) {
          // If response is empty, just update the list without data
          setItems(items.map(item => (item.id === updatedItem.id ? updatedItem : item)));
          setEditingItem(null);
        } else {
          // Otherwise, parse the response as JSON
          try {
            const data = JSON.parse(text);
            setItems(items.map(item => (item.id === data.id ? data : item)));
            setEditingItem(null);
          } catch (e) {
            setError('Error parsing JSON response');
            console.error('Error parsing JSON:', e);
          }
        }
      })
      .catch(error => {
        console.error('Edit item failed:', error);
        setError(error.message);
      });
  };

  return (
    <div style={{ display: 'flex', justifyContent: 'space-between' }}>
      <div>
        <h2>Dashboard</h2>
        {error ? (
          <p style={{ color: 'red' }}>Error: {error}</p>
        ) : (
          <div>
            <button onClick={fetchItems}>Odśwież listę</button>
            <ul style={{ textAlign: 'left' }}>
              {items.map(item => (
                <li key={item.id}>
                  ID: {item.id} - {item.name} - {item.price} PLN
                  <button onClick={() => handleDeleteItem(item.id)}>Usuń</button>
                  <button onClick={() => setEditingItem(item)}>Edytuj</button>
                </li>
              ))}
            </ul>
          </div>
        )}
      </div>

      <div style={{ marginLeft: '20px' }}>
        <h3>Dodaj nowy element</h3>
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
        <button onClick={handleAddItem}>Dodaj</button>
      </div>

      {editingItem && (
        <div style={{ marginLeft: '20px' }}>
          <h3>Edytuj element</h3>
          <input
            type="text"
            placeholder='ID'
            value={editingItem.id || ''}
            onChange={(e) => setEditingItem({...editingItem, id: e.target.value })}
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
