use master; 
go
drop database DidakticnaAplikacija;
go
create database DidakticnaAplikacija collate Croatian_CI_AS;
go
use DidakticnaAplikacija;
go

-------------- TABLICE -----------------------

create table Ucitelji (
id int primary key not null identity(1,1),
ime varchar(30) not null,
prezime varchar(30) not null,
email varchar(255) not null,
brojMobitela varchar(50),
korisnickoIme varchar(50) not null,
zaporka varchar(255) not null
);

create table Razredi(
id int primary key not null identity (1,1),
naziv varchar(50) not null,
maksimalnoUcenika int,
uciteljRazrednikID int
);

create table ucenici(
id int primary key not null identity(1,1),
ime varchar(30),
prezime varchar(30),
korisnickoIme varchar(50) not null,
zaporka varchar(255) not null,
razredID int not null
);

create table Predmeti(
id int primary key not null identity(1,1),
naziv varchar(100),
uciteljID int
);

create table gradiva(
id int primary key not null identity(1,1),
naziv varchar(100),
predmetID int
);

create table pitanja(
id int primary key not null identity(1,1),
opis varchar(500) not null,
gradivoID int not null
);

create table odgovori(
id int primary key not null identity(1,1),
opis varchar(500) not null,
jeTocno bit not null,
bodovi int not null,
pitanjeID int not null
);

create table rezultati(
ucenikID int,
odgovorID int
);

-------- DODAVANJE VANJSKIH KLJUCEVA U TABLICE ------------

Alter table Razredi add foreign key (UciteljRazrednikID) references ucitelji(id);
Alter table ucenici add foreign key (razredID) references razredi(id);
Alter table gradiva add foreign key (predmetID) references predmeti(id);
Alter table pitanja add foreign key (gradivoID) references gradiva(id);
Alter table odgovori add foreign key (pitanjeID) references pitanja(id);
Alter table rezultati add foreign key (ucenikID) references ucenici(id);
Alter table rezultati add foreign key (odgovorID) references odgovori(id);


------------------ INSERT INFORMACIJA -------------------------

insert into Ucitelji (ime, prezime, email, korisnickoIme, zaporka) values
('Dražen', 'Mesarić', 'neki@gmail.com', 'LeProf', 'test'),
('Test', 'Test', 'test@gmail.com', 'test', 'test'),
('Tester', 'Tester', 'tester@gmail.com', 'tester', 'tester');

insert into razredi(naziv, maksimalnoUcenika, uciteljRazrednikID) values
('1.a',20, 1),
('1.b', 22, 1),
('2.a', 22, 1),
('2.b', 20, 1);

insert into ucenici (ime, prezime, korisnickoIme, zaporka, razredID) values 
('Marko', 'Malenica', 'MM01-1a', 'markec', 1),
('Zoran', 'Zoric', 'ZZ02-01a', 'zorco', 1),
('Ivan', 'Ivic', 'II03-01a', 'ivko', 1),
('Marica', 'Maric', 'MM04-01a', 'mara',1),
('Tamara', 'Tamic', 'TT01-01b', 'tama', 2),
('Tomo', 'Tomic', 'TT02-01b', 'tomo', 2),
('Lucija', 'Lucic', 'TT03-01b', 'luce', 2),
('Tiho', 'Tihic', 'TT04-01b', 'tiho', 2),
('Petar', 'Perica', 'TT01-02a', 'pero', 3),
('Sime', 'Simic', 'TT02-02a', 'sime', 3),
('Luka', 'Lukic', 'TT03-02a', 'luka', 3),
('Andrej', 'Andric', 'TT04-02a', 'andre', 3),
('Ivan', 'Perica', 'TT01-02b', 'perica', 4),
('Sime', 'Simic', 'TT02-02b', 'sime', 4),
('Luka', 'Lukic', 'TT03-02b', 'luka', 4),
('Andrej', 'Andric', 'TT04-02b', 'andre', 4);

insert into predmeti(naziv, uciteljID) values 
('Povijest umjetnosti', 1);

insert gradiva (naziv, predmetID) values 
('Antika', 1),
('Renesansa', 1),
('Barok', 1);

insert into pitanja (opis, gradivoID) values 
('Pitanje 1', 1),
('Pitanje 2', 1),
('Pitanje 3', 1),
('Pitanje 4', 1),
('Pitanje 5', 2),
('Pitanje 6', 2),
('Pitanje 7', 2),
('Pitanje 8', 2),
('Pitanje 9', 1),
('Pitanje 10', 1),
('Pitanje 11', 1),
('Pitanje 12', 1);

insert into odgovori(opis, jeTocno, bodovi, pitanjeID) values 
('Odgovor 1', 1, 10, 1),
('Odgovor 2', 0, 0, 1),
('Odgovor 3', 0, 0, 1),
('Odgovor 4', 0, 0, 1),
('Odgovor 1', 0, 0, 2),
('Odgovor 2', 0, 0, 2),
('Odgovor 3', 1, 10, 2),
('Odgovor 4', 0, 0, 2),
('Odgovor 1', 0, 0, 3),
('Odgovor 2', 0, 0, 3),
('Odgovor 3', 0, 0, 3),
('Odgovor 4', 1, 10, 3),
('Odgovor 1', 0, 0, 4),
('Odgovor 2', 0, 0, 4),
('Odgovor 3', 0, 0, 4),
('Odgovor 4', 0, 10, 4);

insert into rezultati (ucenikID, odgovorID) values 
(1,1),
(1,7),
(1,10),
(1,12),
(2,2),
(2,4),
(2,9),
(2,11);

select * from Ucitelji;
