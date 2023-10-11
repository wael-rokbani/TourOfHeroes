import "./App.css";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Layout from "./pages/Layout";
import HeroesList from "./pages/HeroesList";
import Dashboard from "./pages/Dashboard";
import { Hero, OpenAPI } from "./generated";
import { HeroPreview } from "./pages/HeroPreview";
import { AppContext } from "./AppContext";
import { useState} from "react"

function App() {
  OpenAPI.BASE = import.meta.env.VITE_APP_API_HOST;
  OpenAPI.WITH_CREDENTIALS = true;

  const [lastViewedHeroes, setLastViewedHeroes] = useState<Hero[]>([]);


  return (
    <>
    <AppContext.Provider value={{lastViewedHeroes, setLastViewedHeroes}} > 
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Layout />}>
            <Route path="/" element={<Dashboard />}></Route>
            <Route path="Heroes" element={<HeroesList />}></Route>
            <Route path="Heroes/new" element={<HeroPreview />}></Route>
            <Route path="Heroes/:id" element={<HeroPreview />}></Route>
            <Route path="*" element={<div>404 page not found</div>}></Route>
          </Route>
        </Routes>
       </BrowserRouter>
      </AppContext.Provider>
    </>
  );
}

export default App;
