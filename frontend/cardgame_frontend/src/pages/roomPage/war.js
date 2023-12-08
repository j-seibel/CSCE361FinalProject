// war.js
import React, { useState } from 'react';
import CardProp2 from './CardProp2';
import cards4War from '.cards4War';

const War = () => {

  const generateImage = (value, suit) => {
        const imageName = `${value.toLowerCase()}_of_${suit.toLowerCase()}.png`;
        return cards4War + imageName;
  };

  const [card1, setCard1] = useState({ Suit: 'Spades', Value: 'Ace', Image: generateImage('Spades', 'Ace') });
  const [card2, setCard2] = useState({ Suit: 'Spades', Value: 'King', Image: generateImage('Spades', 'Ace') });

  const handleNextClick = () => {
    const newCard = generateRandomCard();
    setCard1(newCard);
    setCard2(newCard);
  };

  const generateRandomCard = () => {
    const suits = ['Hearts', 'Diamonds', 'Clubs', 'Spades'];
    const values = ['Ace', '2', '3', '4', '5', '6', '7', '8', '9', '10', 'Jack', 'Queen', 'King'];
  
    const randomSuit = suits[Math.floor(Math.random() * suits.length)];
    const randomValue = values[Math.floor(Math.random() * values.length)];
  
    return {
      Suit: randomSuit,
      Value: randomValue,
      Image: `../cards/${randomValue.toLowerCase()}_of_${randomSuit.toLowerCase()}.png`,
    };
  };

  
  return (
    <div>
      <CardProp2 {...card1} />
      <CardProp2 {...card2} />
      <button onClick={handleNextClick}>Next</button>
    </div>
  );
};

export default War;
