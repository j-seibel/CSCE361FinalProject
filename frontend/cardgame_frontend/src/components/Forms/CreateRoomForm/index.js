import { useState } from "react";

function CreateRoomForm({uuid}) {

    const [roomID, setRoomID] = useState(uuid());
    const [name,setName] = useState("");

    function handleCreateRoom(e) {
        e.preventDefault();
        const RoomData = {
            name,
            roomID,
            userId: uuid(),
            // host: true,
            // presenter: true,
        }
        
        console.log(RoomData)
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
                            onClick={() => setRoomID(uuid())}
                            type="button"
                        >
                            generate
                        </button>

                        {/* Creating the copy button */}
                        <button 
                            className="btn btn-outline-danger btn-sm me-2" 
                            type="button"
                        >
                            copy
                        </button>
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