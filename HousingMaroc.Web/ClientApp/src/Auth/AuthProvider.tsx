import React, { createContext, useContext, useState, useEffect } from 'react';
import axiosInstance from '../api/axiosConfig';

const AuthContext = createContext(null);

// AuthProvider Component
const AuthProvider = ({ children }) => {
  const [user, setUser] = useState(null);
  const [isLoading, setIsLoading] = useState(true);

  // Function to handle user login
  const login = async (email, password) => {
    try {
      const response = await axiosInstance.post('/users/signin', {
        email,
        password
      });
      const token = response.data;
      localStorage.setItem('authToken', token);
      axiosInstance.defaults.headers.common['Authorization'] = `Bearer ${token}`;
      //setUser(response.data.user); // Assuming user data is in the response
    } catch (error) {
      console.error('Login error:', error);
    }
  };

  // Function to handle user logout
  const logout = () => {
    localStorage.removeItem('authToken');
    delete axiosInstance.defaults.headers.common['Authorization'];
    setUser(null);
  };

  // Load user data on component mount (if a token exists)
  useEffect(() => {
    const token = localStorage.getItem('authToken');
    if (token) {
        axiosInstance.defaults.headers.common['Authorization'] = `Bearer ${token}`;
    } else {
      setIsLoading(false);
    }
  }, []);


  return (
    <AuthContext.Provider value={{ user, isLoading, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
};

// Custom Hook to access the AuthContext
const useAuth = () => useContext(AuthContext);

export { AuthProvider, useAuth };