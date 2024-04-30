import { useState } from 'react'

import NavBar from "./components/NavBar";

import './App.css'
import { Route, Routes } from 'react-router-dom';
import { RoutesNames } from './constants';

import Ucitelji from './pages/Ucitelji';


function App() {

  return (
    <>
      <NavBar />
      <Routes>
        <Route path={RoutesNames.UCITELJI_READ} element={<Ucitelji />} />

      </Routes>

    </>
  )
}

export default App
