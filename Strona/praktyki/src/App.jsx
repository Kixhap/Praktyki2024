import React, { useState } from 'react';
import Login from './Login';
import Dashboard from './Dashboard';

function App() {
  const [credentials, setCredentials] = useState('');
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  const handleLogin = (encodedCredentials) => {
    setCredentials(encodedCredentials);
    setIsLoggedIn(true);
  };

  return (
    <div className="App">
      {isLoggedIn ? (
        <Dashboard credentials={credentials} />
      ) : (
        <Login onLogin={handleLogin} />
      )}
    </div>
  );
}

export default App;
