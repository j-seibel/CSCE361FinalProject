

function JoinRoomForm() {
    return (
        <form className="form col-md-12 mt-5">
            {/* Create Input to Enter Name */}
            <div className="form-group">
                <input 
                type="text"
                className="form-control my-2"
                placeholder="Kindly enter your name"
                />
            </div>

            <div className="form-group">
                    {/* Create Input to Enter Room Code */}
                    <input
                        type="text"
                        className="form-control my-2"
                        placeholder="Enter Room Code"
                    />
            </div>

            {/* Create Submit Button */}
            <button 
                type="submit" 
                className="mt-4 btn btn-success btn-block form-control"
            >
                Generate Room
            </button>
        </form>
    );
}

export default JoinRoomForm