import React from "react";
import "./index.css";
import Game from "../../components/game";

function RoomPage(props) {
    return (
        <div>
            <Game client = {props.client}/>
        </div>
    )
}

export default RoomPage