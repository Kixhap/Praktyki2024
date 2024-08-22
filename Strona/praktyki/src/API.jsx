const getAuthHeader = (credentials) => {
  return `Basic ${credentials}`;
};

export const fetchItems = async (credentials) => {
  const response = await fetch('https://localhost:7217/api/items', {
    headers: {
      'Authorization': getAuthHeader(credentials),
    },
  });
  if (!response.ok) {
    throw new Error(`Failed to fetch items: ${response.statusText}`);
  }
  return await response.json();
};

export const postItem = async (newItem, credentials) => {
  const response = await fetch('https://localhost:7217/api/items', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
      'Authorization': getAuthHeader(credentials),
    },
    body: JSON.stringify(newItem)
  });
  if (!response.ok) {
    throw new Error(`Failed to add item: ${response.statusText}`);
  }
  try {
    return await response.json();
  } catch {
    return null;
  }
};

export const deleteItem = async (id, credentials) => {
  const response = await fetch(`https://localhost:7217/api/items/${id}`, {
    method: 'DELETE',
    headers: {
      'Authorization': getAuthHeader(credentials),
    },
  });
  if (!response.ok) {
    throw new Error(`Failed to delete item: ${response.statusText}`);
  }
  try {
    return await response.text();
  } catch {
    return null;
  }
};

export const putItem = async (updatedItem, credentials) => {
  const response = await fetch(`https://localhost:7217/api/items/${updatedItem.id}`, {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json',
      'Authorization': getAuthHeader(credentials),
    },
    body: JSON.stringify(updatedItem),
  });
  try {
    return await response.text();
  } catch {
    return null;
  }
};

export const editItem = async (updatedItem, credentials) => {
  const response = await fetch(`https://localhost:7217/api/items/${updatedItem.id}`, {
    method: 'PATCH',
    headers: {
      'Content-Type': 'application/json',
      'Authorization': getAuthHeader(credentials),
    },
    body: JSON.stringify(updatedItem),
  });
  try {
    return await response.text();
  } catch {
    return null;
  }
};
