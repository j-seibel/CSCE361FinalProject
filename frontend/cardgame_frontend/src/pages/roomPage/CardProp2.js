// CardProp2.js
import React, { Component } from 'react';

class CardProp2 extends Component {
  constructor(props) {
    super(props);

    this.state = {
      suit: props.Suit,
      value: props.Value,
      image: props.Image,
      isFacing: false,
    };
  }

  componentWillReceiveProps(nextProps) {
    this.setState({
      image: nextProps.Image,
    });
  }

  render() {
    return (
      <div style={{ width: 125, display: 'inline-block', textAlign: 'center' }}>
        <p>{`${this.state.value} of ${this.state.suit}`}</p>
        <img src={this.state.image} alt={`${this.state.value} of ${this.state.suit} card`} className="card" style={{ maxWidth: '100%' }} />
      </div>
    );
  }
}

export default CardProp2;
