import './App.css'
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import Layout from './pages/Layout'
import HeroesList from './pages/HeroesList'
import Dashboard from './pages/Dashboard'
import { OpenAPI } from "./generated";

function App() {

  OpenAPI.BASE =  import.meta.env.VITE_APP_API_HOST;
  OpenAPI.WITH_CREDENTIALS = true;

  return (
    <>
      <BrowserRouter>
        <Routes>
          <Route path='/' element={<Layout/>}>
            <Route path='/' element={<Dashboard/>}></Route>
            <Route path='Heroes' element={<HeroesList/>}></Route>
            <Route path='*' element={<div>404 page not found</div>}></Route>
          </Route>
        </Routes>
      </BrowserRouter>
    </>
  )
}

export default App
