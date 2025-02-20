
import React, { useEffect, useState } from 'react';
import "./deck.css"

import h1 from './../cards/PNG-cards-1.3/1_of_hearts.png';
import h2 from './../cards/PNG-cards-1.3/2_of_hearts.png';
import h3 from './../cards/PNG-cards-1.3/3_of_hearts.png';
import h4 from './../cards/PNG-cards-1.3/4_of_hearts.png';
import h5 from './../cards/PNG-cards-1.3/5_of_hearts.png';
import h6 from './../cards/PNG-cards-1.3/6_of_hearts.png';
import h7 from './../cards/PNG-cards-1.3/7_of_hearts.png';
import h8 from './../cards/PNG-cards-1.3/8_of_hearts.png';
import h9 from './../cards/PNG-cards-1.3/9_of_hearts.png';
import h10 from './../cards/PNG-cards-1.3/10_of_hearts.png';
import h11 from './../cards/PNG-cards-1.3/11_of_hearts.png';
import h12 from './../cards/PNG-cards-1.3/12_of_hearts.png';
import h13 from './../cards/PNG-cards-1.3/13_of_hearts.png';

import c1 from './../cards/PNG-cards-1.3/1_of_clubs.png';
import c2 from './../cards/PNG-cards-1.3/2_of_clubs.png';
import c3 from './../cards/PNG-cards-1.3/3_of_clubs.png';
import c4 from './../cards/PNG-cards-1.3/4_of_clubs.png';
import c5 from './../cards/PNG-cards-1.3/5_of_clubs.png';
import c6 from './../cards/PNG-cards-1.3/6_of_clubs.png';
import c7 from './../cards/PNG-cards-1.3/7_of_clubs.png';
import c8 from './../cards/PNG-cards-1.3/8_of_clubs.png';
import c9 from './../cards/PNG-cards-1.3/9_of_clubs.png';
import c10 from './../cards/PNG-cards-1.3/10_of_clubs.png';
import c11 from './../cards/PNG-cards-1.3/11_of_clubs.png';
import c12 from './../cards/PNG-cards-1.3/12_of_clubs.png';
import c13 from './../cards/PNG-cards-1.3/13_of_clubs.png';

import s1 from './../cards/PNG-cards-1.3/1_of_spades.png';
import s2 from './../cards/PNG-cards-1.3/2_of_spades.png';
import s3 from './../cards/PNG-cards-1.3/3_of_spades.png';
import s4 from './../cards/PNG-cards-1.3/4_of_spades.png';
import s5 from './../cards/PNG-cards-1.3/5_of_spades.png';
import s6 from './../cards/PNG-cards-1.3/6_of_spades.png';
import s7 from './../cards/PNG-cards-1.3/7_of_spades.png';
import s8 from './../cards/PNG-cards-1.3/8_of_spades.png';
import s9 from './../cards/PNG-cards-1.3/9_of_spades.png';
import s10 from './../cards/PNG-cards-1.3/10_of_spades.png';
import s11 from './../cards/PNG-cards-1.3/11_of_spades.png';
import s12 from './../cards/PNG-cards-1.3/12_of_spades.png';
import s13 from './../cards/PNG-cards-1.3/13_of_spades.png';

import d1 from './../cards/PNG-cards-1.3/1_of_diamonds.png';
import d2 from './../cards/PNG-cards-1.3/2_of_diamonds.png';
import d3 from './../cards/PNG-cards-1.3/3_of_diamonds.png';
import d4 from './../cards/PNG-cards-1.3/4_of_diamonds.png';
import d5 from './../cards/PNG-cards-1.3/5_of_diamonds.png';
import d6 from './../cards/PNG-cards-1.3/6_of_diamonds.png';
import d7 from './../cards/PNG-cards-1.3/7_of_diamonds.png';
import d8 from './../cards/PNG-cards-1.3/8_of_diamonds.png';
import d9 from './../cards/PNG-cards-1.3/9_of_diamonds.png';
import d10 from './../cards/PNG-cards-1.3/10_of_diamonds.png';
import d11 from './../cards/PNG-cards-1.3/11_of_diamonds.png';
import d12 from './../cards/PNG-cards-1.3/12_of_diamonds.png';
import d13 from './../cards/PNG-cards-1.3/13_of_diamonds.png';

const map = new Map();
map.set('h1', h1);
map.set('h2', h2);
map.set('h3', h3);
map.set('h4', h4);
map.set('h5', h5);
map.set('h6', h6);
map.set('h7', h7);
map.set('h8', h8);
map.set('h9', h9);
map.set('h10', h10);
map.set('h11', h11);
map.set('h12', h12);
map.set('h13', h13);

map.set('c1', c1);
map.set('c2', c2);
map.set('c3', c3);
map.set('c4', c4);
map.set('c5', c5);
map.set('c6', c6);
map.set('c7', c7);
map.set('c8', c8);
map.set('c9', c9);
map.set('c10', c10);
map.set('c11', c11);
map.set('c12', c12);
map.set('c13', c13);

map.set('d1', d1);
map.set('d2', d2);
map.set('d3', d3);
map.set('d4', d4);
map.set('d5', d5);
map.set('d6', d6);
map.set('d7', d7);
map.set('d8', d8);
map.set('d9', d9);
map.set('d10', d10);
map.set('d11', d11);
map.set('d12', d12);
map.set('d13', d13);
map.set('s1', s1);
map.set('s2', s2);
map.set('s3', s3);
map.set('s4', s4);
map.set('s5', s5);
map.set('s6', s6);
map.set('s7', s7);
map.set('s8', s8);
map.set('s9', s9);
map.set('s10', s10);
map.set('s11', s11);
map.set('s12', s12);
map.set('s13', s13);

const suits = ["hearts", "clubs", "diamonds", "spades"];
const values = ["ace", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "jack", "queen", "king"];

function getCardIMG({card}) {
  var val = "";
  var suit = card.suit[0].toLowerCase();
  
  for (var i = 0; i < 13; i++) {
    if (values[i] === card.value) {
      val = (i+1).toString();
    }
  }
  return suit + val;
}

function Card({card}) {
  var s = getCardIMG({card});
  return (
    <img src={map.get(s)} className = "warcard"/>
  )
}

function shuffle(array) {
  let idx = array.length,  randomIndex;

  while (idx > 0) {

    randomIndex = Math.floor(Math.random() * idx);
    idx--;

    [array[idx], array[randomIndex]] = [
      array[randomIndex], array[idx]];
  }

  return array;
}

function Deck(props){
  const [deck, setDeck] = useState( () => {
    const d = [];

    for (var i = 0; i < 4; i++) {
        for (var j = 0; j < 13; j++){
            d.push({
                "suit" : suits[i],
                "value" : values[j],
            })
        }
    }

    shuffle(d);
    return d;
  });
  const [pile1, setPile1] = useState(() => {
    return deck.slice(0, 26);
  });
  const [pile2, setPile2] = useState(() => {
    return deck.slice(26);
  });

  const [hasWon, setHasWon] = useState(0);

  const [oneScore, setOneScore] = useState(0);
  const [twoScore, setTwoScore] = useState(0);
  const [myName, setMyName] = useState("Player1");
  useEffect(() => {
    const data = {
      "won" : 5,
      "myCard" : pile1[0],
      "opCard" : pile2[0],
    }
    props.client.onopen = () => {
      console.log('WebSocket Client Connected');
      props.client.send(JSON.stringify(data));
    };

    props.client.onmessage = (message) => {
      console.log(message);
      handleUpdate(message);
    };

    
    console.log(data)
    
    

  }, []);

  const handleUpdate = (message) => {
    
    let msg = JSON.parse(message.data);
    if(msg.hasOwnProperty('opName')){
      
    }
  
    let a = msg.opCard;
    let b = msg.myCard;
    if (msg.won !== 5) {
      // Use functional form to ensure correct state update
      setTwoScore((prevScore) => prevScore + (values.indexOf(a.value) <= values.indexOf(b.value) ? 1 : 0));
      setOneScore((prevScore) => prevScore + (values.indexOf(a.value) >= values.indexOf(b.value) ? 1 : 0));
    }

    let newPile1 = pile1.slice()
    let newPile2 = pile2.slice()
    
    newPile1[0] = msg.opCard;
    newPile2[0] = msg.myCard;

    setPile1(newPile1)
    setPile2(newPile2)
    if(msg.won === 2){
      setHasWon(1)
    }else if(msg.won === 1){
      setHasWon(2)
    }else if (msg.won === 3){
      setHasWon(3)
    }
  }

  const handleNextClick = () => {
   
    
  
    const data = {
      won: hasWon,
      myCard: pile1[1],
      opCard: pile2[1],
    };
    props.client.send(JSON.stringify(data));
    
  
  
    setPile1((prevPile1) => prevPile1.slice(1));
    setPile2((prevPile2) => prevPile2.slice(1));
  
    // Access the updated values after the state has been updated
    let a = pile1[1];
    let b = pile2[1];
    setTwoScore((prevScore) => prevScore + (values.indexOf(a.value) <= values.indexOf(b.value) ? 1 : 0));
    setOneScore((prevScore) => prevScore + (values.indexOf(a.value) >= values.indexOf(b.value) ? 1 : 0));
    console.log(oneScore)
    console.log(twoScore)
    
   
      // Use functional form to ensure correct state update
    // setTwoScore((prevScore) => prevScore + (values.indexOf(a.value) >= values.indexOf(b.value) ? 1 : 0));
    // setOneScore((prevScore) => prevScore + (values.indexOf(a.value) <= values.indexOf(b.value) ? 1 : 0));
    
  };
  useEffect(() => {
    if (oneScore >= 5 && twoScore >= 5) {
      setHasWon(3);
    } else if (oneScore >= 5) {
      setHasWon(1);
    } else if (twoScore >= 5) {
      setHasWon(2);
    } else {
      setHasWon(0);
    }
  }, [oneScore, twoScore]);
  
  return (
    <div className="wargameContainer">
      <h1>YOUR SCORE: {oneScore}</h1>
      <h1>OPPONENT SCORE: {twoScore}</h1>
      
      <div className="warImager">
        <h1>P1</h1>
        {pile1.length > 0 ? <Card card = {pile1[0]}/> : <></>}
        {pile1.length > 0 ? <Card card = {pile2[0]}/> : <></>}
        <h1>P2</h1>
      </div>

      {hasWon === 1 ? <h1>PLAYER ONE HAS WON THE GAME</h1> : <></>}
      {hasWon === 2 ? <h1>PLAYER TWO HAS WON THE GAME</h1> : <></>}
      {hasWon === 3 ? <h1>THE GAME IS TIED</h1> : <></>}

      {hasWon === 0 ? <button onClick={handleNextClick} className = "btn btn-success btn-sm me-1 size-50px">Next</button> : <></>}


    </div>
  );
}

export default Deck