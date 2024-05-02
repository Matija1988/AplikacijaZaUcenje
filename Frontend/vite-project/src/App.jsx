import { useState } from 'react'

import NavBar from "./components/NavBar";

import './App.css'
import { Route, Routes } from 'react-router-dom';
import { RoutesNames } from './constants';

import Ucitelji from './pages/ucitelji/Ucitelji';
import Home from './pages/Home';



function App() {

  return (
    <>
      <NavBar />
      <Routes>
        <Route path={RoutesNames.HOME} element={<Home />} />
        <Route path={RoutesNames.UCITELJI_READ} element={<Ucitelji />} />
      </Routes>

    </>
  )
}

export default App
