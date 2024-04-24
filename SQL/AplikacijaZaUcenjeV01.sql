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
brojMobitelja varchar(50),
korisnickoIme varchar(50) not null,
zaporka varchar(255) not null
);

create table Razredi(
id int primary key not null identity (1,1),
naziv varchar(50) not null,
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

create table kategorije(
id int primary key not null identity(1,1),
naziv varchar(100)
);

create table gradiva(
id int primary key not null identity(1,1),
naziv varchar(100),
kategorijaID int
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
Alter table gradiva add foreign key (kategorijaID) references kategorije(id);
Alter table pitanja add foreign key (gradivoID) references gradiva(id);
Alter table odgovori add foreign key (pitanjeID) references pitanja(id);
Alter table rezultati add foreign key (ucenikID) references ucenici(id);
Alter table rezultati add foreign key (odgovorID) references odgovori(id);