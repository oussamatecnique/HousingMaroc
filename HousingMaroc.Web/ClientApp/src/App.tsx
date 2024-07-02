import './App.css'
import Navbar from './components/Navbar'
import LoginPage from './components/LoginPage'

import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { AuthProvider } from './Auth/AuthProvider';

function App() {

  return (
    <>
    <AuthProvider>
      <Navbar></Navbar>
      <Router>
        <div>
          <Routes>
            <Route path="/login" element={<LoginPage />} />
          </Routes>
        </div>
      </Router>
      </AuthProvider>
    </>
  )
}

export default App
