-- drop table if exists Player;
-- drop table if exists Room;

-- create table Player(
--     playerId int not null identity primary key,
--     username VARCHAR(50),
--     password VARCHAR(50),
--     gamesPlayed int,
--     gamesWon int,
--     solitaireELO int,
--     warELO int
-- );

create table Room(
    roomId int not null identity primary key,
    hostId VARCHAR(26),
    roomCode VARCHAR(26),
    numPlayers int
);
