import "./index.css";
import CreateRoomForm from "./CreateRoomForm";
import JoinRoomForm from "./JoinRoomForm";
import Solitaire from "../solitaireComponents/components/solitaire"

function Forms({uuid}) {

    return (
        <div>

            <div className="row">
                <div className="col-md-4 mt-5 form-box py-5 border border-4 rounded-2 mx-auto d-flex flex-column align-items-center">
                    <h1 className=" header">Create Room</h1>
                    <CreateRoomForm uuid={uuid}/>
                </div>
                <div className="col-md-4 mt-5 form-box py-5 border border-4 rounded-2 mx-auto d-flex flex-column align-items-center">
                    <h1 className=" header">Join Room</h1>
                    <JoinRoomForm uuid={uuid}/>
                </div>
            </div>
            <div className="container">
                <div className="center">
                    <button onClick={() => {window.location="/solitaire"}} className = "btn btn-success btn-sm me-1 size-100px">Play Solitaire Solo!</button>
                </div>
            </div>
        </div>
    )
}

export default Forms;