use master;
go;

drop database if exists musicparty_db_2;
go;

create database musicparty_db_2;
go;

use musicparty_db_2;
go;

create table users
(
    id int identity primary key,
    pseudo varchar(100) not null unique
);
go;

create table musics
(
    id int identity primary key,
    title varchar(100) not null,
	author varchar(100) not null,
    type varchar(50) not null,
    youtubeUrl varchar(500) not null,
    userId int not null references users
);
go;

create table votes
(
    userId int not null references users,
    musicId int not null references musics on delete cascade,
    creationDate datetime not null default getdate(),
    primary key (userId, musicId)
);
go;

insert into users(pseudo)
values
    ('Thisma'),
    ('Arisu'),
    ('Pyokoon');
go;

insert into musics(title, type, youtubeUrl, userId)
values
    ('Billie Jean', 'Disco', 'https://www.youtube.com/watch?v=Zi_XLOBDo_Y', 1),
    ('Bohemian Rhapsody', 'Rock', 'https://www.youtube.com/watch?v=fJ9rUzIMcZQ', 2)
go;

insert into votes(userId, musicId)
values
    (2, 1);
go;

select * from users;
go;

select * from musics;
go;

select * from votes;
go;