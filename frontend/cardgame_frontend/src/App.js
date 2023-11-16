import './App.css';
import Home from "./pages/home.js"
import Deck from './components/deck'
import { Navigate, BrowserRouter as Router, Routes, Route } from "react-router-dom";


function App() {
  return (
    <Router>
      <Routes>
        <Route path = '/home' element={<Home/>} /> 
        <Route path = '/deck' element={<Deck/>} />
        <Route path = '*' element={<Navigate to ='/'/>}/>
      </Routes>
    </Router>
    // <Deck/>
  );
}

export default App;
