import React from 'react';

const CardProp2 = ({ Suit, Value, Image }) => {
  return (
    <div>
      <img src={Image} alt={`Card: ${Value} of ${Suit}`} />
      <p>{Value} of {Suit}</p>
    </div>
  );
};

export default CardProp2;