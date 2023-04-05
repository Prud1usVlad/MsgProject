import logo from './logo.svg';
import './App.css';
import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
import Home from "./pages/Home.jsx"
import DataPieces from './pages/DataPieces';
import Substrates from './pages/Substrates';
import Plants from './pages/Plants'

function App() {
  const isLogined = localStorage.getItem("token") !== null

  return (
    <BrowserRouter>
			<Routes>
          <Route path="/" element={<Home />} />
          <Route path="/DataPieces" element={<DataPieces />} />
          <Route path="/Substrates" element={<Substrates />} />
          <Route path="/Plants" element={<Plants />} />
			</Routes>
		</BrowserRouter>
  );
}

// { isLogined ? null : <Navigate to="/Login" />}

export default App;
