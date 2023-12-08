import React, { useEffect, useState } from 'react';
import "./deck.css"

import back from './../cards/PNG-cards-1.3/back.png';
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
    <img src={map.get(s)}/>
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



function Deck(){

  // state of the deck component
  const [deck, setDeck] = useState([]);
  const [pile1, setPile1] = useState([]);
  const [pile2, setPile2] = useState([]);

  // this is a constructor for the deck component
  useEffect(() => {
      const initializeDeck = () => {
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
          setDeck(d);
      }

      initializeDeck();
      setPile1(deck.slice(0, 26));
      setPile2(deck.slice(26));
      
  }, []);


  const handleNextClick = () => {



    if (values.indexOf(a.value) > values.indexOf(b.value)) {
      let newPile1 = pile1.slice()
      let newPile2 = pile2.slice()
      newPile1.push(newPile2[0])
      newPile2 = newPile2.slice(1)
      setPile1(newPile1)
      setPile2(newPile2)
    } else {
      let newPile2 = pile2.slice()
      let newPile1 = pile1.slice()
      newPile2.push(newPile1[0])
      newPile1 = newPile1.slice(1)
      setPile1(newPile2)
      setPile2(newPile1)
    }
  };
  
  return (
    <div>
      
      <div>
        {pile1.length > 0 ? <Card card = {pile1[0]}/> : <></>}
        {pile1.length > 0 ? <Card card = {pile2[0]}/> : <></>}
      </div>
      
      <div>
        <button onClick={handleNextClick} className = "btn btn-success btn-sm me-1 size-20px">Next</button>
      </div>
      
    </div>

  );
}

export default Deck
