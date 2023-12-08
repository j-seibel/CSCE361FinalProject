import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { CopyToClipboard } from "react-copy-to-clipboard";
import { toast } from "react-toastify";


function CreateRoomForm(props) {

    const [roomID, setRoomID] = useState(props.uuid());
    const [name,setName] = useState("");
    const navigate = useNavigate()

    function handleCreateRoom(e) {
        e.preventDefault();
        const RoomData = {
            name,
            roomID,
            userId: props.uuid(),
            // host: true,
            // presenter: true,
        }
        
        navigate(roomID);
        console.log(RoomData);

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

            props.client.send("SDLFKJSDL:FKJ")

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

            {/* Create input for Enter your Name */}
            <div className="form-group">
                <input 
                type="text"
                className="form-control my-2"
                placeholder="Kindly enter your name"
                value={name}
                onChange={(e) => setName(e.target.value)}
                />
            </div>

            <div className="form-group border">
                <div className="input-group d-flex align-items-center justify-content-center">
                    {/* Create Input to Generate Room Code */}
                    <input
                        type="text"
                        value={roomID}
                        className="form-control my-2 border-0"
                        disabled
                        placeholder="Generate Room Code"
                    />

                    <div className="input-group-append">
                        {/* Creating the generate button */}
                        <button 
                            className="btn btn-success btn-sm me-1" 
                            onClick={() => setRoomID(props.uuid())}
                            type="button"
                        >
                            generate
                        </button>

                        {/* Creating the copy button */}
                        <CopyToClipboard
                            text={roomID}
                            onCopy={() => toast.success("Room Id Copied To Clipboard!")}
                            >
                        <button 
                            className="btn btn-outline-danger btn-sm me-2" 
                            type="button"
                        >
                            copy
                        </button>
                        </CopyToClipboard>
                    </div>
                </div>
            </div>

            {/* Create Submit Button */}
            <button 
                type="submit" 
                onClick={handleCreateRoom}
                className="mt-4 btn btn-success btn-block form-control"
            >
                Generate Room
            </button>
        </form>
    );
}

export default CreateRoomForm