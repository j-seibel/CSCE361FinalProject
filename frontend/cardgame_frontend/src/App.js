// importing CSS
import './App.css';

// importing components
import Deck from './components/deck';
import Forms from './components/Forms';

// importing Bootstrap
import 'bootstrap/dist/css/bootstrap.min.css';

import { Route, Routes } from "react-router-dom"

// importing RoomPage
import RoomPage from './pages/roomPage';

function App() {

  function uuid() {
    var S4 = () => {
      return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
    };
    return (
      S4() +
      S4() +
      "-" +
      S4() +
      "-" +
      S4() +
      "-" +
      S4() +
      "-" +
      S4() +
      S4() +
      S4()
    );
  };

  return (
    <div className='container'>
      <Routes>
        <Route path="/" element={<Forms uuid={uuid}/>} />
        <Route path='/:roomID' element={<RoomPage />} />
      </Routes>
    </div>
  )
}

export default App;
