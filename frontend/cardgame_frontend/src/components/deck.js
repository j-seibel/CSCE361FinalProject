import React, { useEffect, useState } from 'react';
// import h2 from "../cards/PNG-cards-1.3/2_of_hearts.png"
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



const suits = ["Hearts", "Clubs", "Diamonds", "Spades"];
const values = ["Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King"];

function getCardIMG({card}) {
  var val = "";
  var suit = card.suit[0].lower();

  for (var i = 0; i < 13; i++) {
    if (values[i] === card.value) {
      val = (i+1).toString();
    }
  }
  
  return suit + val;

}

function Card({card}) {
  console.log(card)
  return (
    <img src={h2}/>
  )
}


function Deck(){

    const [deck, setDeck] = useState([]);
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
            setDeck(d);
        }
        initializeDeck();
    }, []);

    return (
        <div>
            {deck.length > 0 ? <Card card={deck[2]}/> : <></>}
        </div>
    )
}
    
export default Deck
