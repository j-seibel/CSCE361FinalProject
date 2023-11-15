drop table if exists Player;
drop table if exists Room;

create table Player(
    playerId int not null identity primary key,
    roomId int,
    username VARCHAR(50),
    password VARCHAR(50),
    gamesPlayed int,
    gamesWon int,
    solitaireELO int,
    warELO int
);

create table Room(
    roomId int not null identity primary key,
    roomCode VARCHAR(8),
    gameType varchar(20),
    numPlayers int
);

insert into Player(username, password, gamesPlayed, gamesWon, solitaireELO, warELO) values ('cjdimes', 'jpxfrd', 5 , 4, 1300, 2500);
-- insert into Player(gamesPlayed, gamesWon, solitaireELO, warELO) values (201 , 8, 2300, 2000);

-- insert into Room(roomCode, gameType, numPlayers) values ('AMOGUS', 'Solitaire', 1);

Select * from Player;
Select * from Room;