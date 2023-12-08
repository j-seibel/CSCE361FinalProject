// importing CSS
import './App.css';
import HTML5Backend from 'react-dnd-html5-backend'

import { DndContext, DndProvider, DragDropContext } from 'react-dnd';
// importing components
import Forms from './components/Forms';
import Solitaire from './components/solitaireComponents/components/solitaire.js'

// importing Bootstrap
import 'bootstrap/dist/css/bootstrap.min.css';
import { useEffect } from 'react';
import { Route, Routes } from "react-router-dom"
import { w3cwebsocket as W3CWebSocket } from "websocket";

// importing RoomPage
import RoomPage from './pages/roomPage';

const client = new W3CWebSocket('ws://localhost:5237/ws');

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
        <Route path="/" element={<Forms uuid={uuid} client = {client}/>} />
        <Route path='/:roomID' element={<RoomPage client = {client}/>} />
        <Route path='/solitaire' element={<Solitaire/>}/>
      </Routes>
    </div>
  )
}

export default DragDropContext(HTML5Backend)(App);
