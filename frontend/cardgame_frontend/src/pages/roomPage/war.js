import React, { useState } from 'react';
import CardProp2 from './CardProp2';

const War = () => {
  const [card1, setCard1] = useState({ Suit: 'Hearts', Value: 'Ace', Image: 'path/to/card1.png' });
  const [card2, setCard2] = useState({ Suit: 'Spades', Value: 'King', Image: 'path/to/card2.png' });

  const handleNextClick = () => {
    setCard1({ Suit: 'Diamonds', Value: '7', Image: 'path/to/card3.png' });
    setCard2({ Suit: 'Clubs', Value: 'Queen', Image: 'path/to/card4.png' });
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
