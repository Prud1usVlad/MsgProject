import logo from './logo.svg';
import './App.css';
import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
import Home from "./pages/Home.jsx"

function App() {
  const isLogined = localStorage.getItem("token") !== null

  return (
    <BrowserRouter>
			<Routes>
          <Route path="/" element={<Home />} />
			</Routes>
		</BrowserRouter>
  );
}

// { isLogined ? null : <Navigate to="/Login" />}

export default App;
