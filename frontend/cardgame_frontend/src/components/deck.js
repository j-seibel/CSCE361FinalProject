import React, { useEffect, useState } from 'react';

const suits = ["Hearts", "Clubs", "Diamonds", "Spades"];
const values = ["Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King"];

function Card({card}){
    return (
        <div>
            {card.suit}
            
        </div>
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
        console.log(deck);
    }, []);

    return (
        <div>
            {deck.length > 0 ? <Card card={deck[0]}/> : <></>}
        </div>
    )

}
    
export default Deck