import { useState } from "react";
import Deck from "./deck";

export default function Game(props) {
    return (
        <div>
            <Deck client = {props.client}/>
        </div>
    )
}


