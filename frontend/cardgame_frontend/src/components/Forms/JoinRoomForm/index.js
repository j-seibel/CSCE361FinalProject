import { useState } from "react";
import { useNavigate } from "react-router-dom";
import useWebSocket from 'react-use-websocket';

function JoinRoomForm({uuid}) {

    const [roomID, setRoomID] = useState("");
    const [name,setName] = useState("");
    const navigate = useNavigate()

    function handleRoomJoin(e) {
        e.preventDefault();
        const RoomData = {
            name,
            roomID,
            userId: uuid(),
        }

        navigate(roomID)
        const ws_URL = 'ws://localhost:5237/ws';
        useWebSocket(ws_URL, {onOpen: ()=>{console.log("CONNECTED TO WEBSOCKET")}});

        const createRoom = async () => {
            try {
                const room = RoomData
            const response = await fetch('http://localhost:8080/api/Room', {
                method: 'POST',
                headers: {
                'Accept': '*/*',
                'Content-Type': 'application/json',
                },
                body: JSON.stringify(room),
            });
            console.log(room)
            console.log('Response status:', response.status);
            console.log('Response headers:', response.headers);
                console.log('Response body:', await response.text());
        
            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
        
            console.log('Post request successful');
            }
            
            
            catch (error) {
                console.error('Error during POST request:', error.message);
            }
        };
        createRoom()
    }


    return (
        <form className="form col-md-12 mt-5">
            {/* Create Input to Enter Name */}
            <div className="form-group">
                <input 
                type="text"
                className="form-control my-2"
                placeholder="Kindly enter your name"
                value={name}
                onChange={(e) => setName(e.target.value)}
                />
            </div>

            <div className="form-group">
                    {/* Create Input to Enter Room Code */}
                    <input
                        type="text"
                        className="form-control my-2"
                        placeholder="Enter Room Code"
                        value={roomID}
                        onChange={(e) => setRoomID(e.target.value)}
                    />
            </div>

            {/* Create Submit Button */}
            <button 
                type="submit" 
                className="mt-4 btn btn-success btn-block form-control"
                onClick={handleRoomJoin}
            >
                Join Room
            </button>
        </form>
    );
}

export default JoinRoomForm