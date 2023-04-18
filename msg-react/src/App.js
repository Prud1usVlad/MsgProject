import logo from './logo.svg';
import './App.css';
import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
import Home from "./pages/Home.jsx"
import DataPieces from './pages/DataPieces';
import Substrates from './pages/Substrates';
import Plants from './pages/Plants'
import { Grid, Typography } from '@mui/joy';
import GrassIcon from '@mui/icons-material/Grass';
import SideMenue from './components/SideMenue';
import { green } from '@mui/material/colors';
import { CssVarsProvider } from '@mui/joy/styles';
import Login from './pages/Login';
import { CustomProvider } from 'rsuite';
import "rsuite/dist/rsuite.min.css";



function App() {
  const isLogined = localStorage.getItem("session") !== null

  return (
    <>

    <CssVarsProvider defaultMode="dark">
    <CustomProvider theme="dark">
    <BrowserRouter>
    <Grid container sx={{ height: '100vh'}}>
      <Grid sm={2.5}>
        <SideMenue />
      </Grid>
      <Grid sm={9.5} bgcolor={"background.level1"}>

        <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/DataPieces" element={ isLogined ? <DataPieces /> : <Home />} />
            <Route path="/Substrates" element={ isLogined ? <Substrates /> : <Home />} />
            <Route path="/Plants" element={ isLogined ? <Plants /> : <Home />} />
            <Route path="/Login" element={<Login />} />
        </Routes>

      </Grid>
    </Grid>
    </BrowserRouter>
    </CustomProvider>
    </CssVarsProvider>
    


      
    
    </>
  );
}

// { isLogined ? null : <Navigate to="/Login" />}

export default App;
