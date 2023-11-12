import React, { useEffect, useState } from 'react';

const suits = ["Hearts", "Clubs", "Diamonds", "Spades"];
const values = ["Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King"];

const importAll = (r) => {
  return r.keys().map(r);
};

const cardImages = importAll(require.context('./../cards/PNG-cards-1.3', false, /\.(png)$/));

const CardComponent = () => {

  const cardNames = Array.from({ length: 52 }, (_, index) => `${(index % 13) + 1}_of_${['hearts', 'diamonds', 'clubs', 'spades'][Math.floor(index / 13)]}.png`);

  return (
    <div>
      {/* Map over card names and generate images */}
      {cardNames.map((card, index) => (
        <img key={index} src={cardImages[index].default}/>
      ))}
    </div>
  );
};

function Card({card}){
    return (
        <CardComponent/>
    )
};



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
        console.log(deck);
    }, []);

    return (
        <div>
            as;ldfja;lsdjfl;kjs
            {deck.length > 0 ? <Card card={deck[0]}/> : <></>}
        </div>
    )
}
    
export default Deck
