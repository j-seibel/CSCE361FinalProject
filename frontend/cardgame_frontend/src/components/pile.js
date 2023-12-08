import React from 'react';

export default function Card(props) {
  

  return (
    <div className='div4'>
      <h1 id='card'>{props.cardValue()}</h1>
    </div>
  )
}
