DROP DATABASE AplikacijaZaUcenje;

CREATE DATABASE AplikacijaZaUcenje;
ALTER DATABASE AplikacijaZaUcenje CHARACTER SET utf8 COLLATE utf8_general_ci; 

USE AplikacijaZaUcenje;

-- --------------------------TABLES----------------------------------------

CREATE TABLE Ucitelji(	
	
	id							INT  				NOT NULL PRIMARY KEY AUTO_INCREMENT,
	ime 						VARCHAR(30) 	NOT NULL,
	prezime 					VARCHAR(30) 	NOT NULL,
	email 					VARCHAR (255)  NOT NULL,
	brojMobitela 			VARCHAR(50),
	korisnickoIme 			VARCHAR(50) 	NOT NULL,
	zaporka 					VARCHAR(255) 	NOT NULL
); 

CREATE TABLE Razredi (

   id 						INT 				NOT NULL PRIMARY KEY AUTO_INCREMENT,
   naziv						VARCHAR(50) 	NOT NULL,
   maksimalnoUcenika 	INT,
   uciteljID				INT

);

CREATE TABLE Ucenici (

	id 						INT 				NOT NULL PRIMARY KEY AUTO_INCREMENT,
	ime 						VARCHAR(30) 	NOT NULL,
	prezime 					VARCHAR(30)    NOT NULL,
	korisnickoIme 			VARCHAR(50)   	NOT NULL,
	zaporka 					VARCHAR(255)	NOT NULL,
	razredID 				INT 				

);

CREATE TABLE Predmeti (

	id							INT				NOT NULL PRIMARY KEY AUTO_INCREMENT,
	naziv 					VARCHAR(100) 	NOT NULL,
	uciteljID				INT 

);

CREATE TABLE Gradiva (

	id 						INT 				NOT NULL PRIMARY KEY AUTO_INCREMENT,
	naziv						VARCHAR(100)	NOT NULL,
	predmetID            INT

);

CREATE TABLE Pitanja (

	id 						INT 				NOT NULL PRIMARY KEY AUTO_INCREMENT,
	opis 						VARCHAR(500)   NOT NULL,
	gradivoID				INT				NOT NULL

);

CREATE TABLE Odgovori (

	id 						INT				NOT NULL PRIMARY KEY AUTO_INCREMENT,
	opis						VARCHAR(500)	NOT NULL,
	jeTocno					BIT				NOT NULL,
	bodovi 					INT 				NOT NULL,
	pitanjeID				INT				NOT NULL

);

CREATE TABLE Rezultati(

ucenikID 					INT,
odgovorID					INT

);

-- ------------------------DODAVANJE VANJSKIH KLJUCEVA -------------------------------------------


ALTER TABLE Razredi ADD FOREIGN KEY (uciteljID) REFERENCES ucitelji(id);
ALTER TABLE Ucenici ADD FOREIGN KEY (razredID) 	REFERENCES razredi(id); 
ALTER TABLE Predmeti ADD FOREIGN KEY (uciteljID) REFERENCES ucitelji(id);
ALTER TABLE Gradiva ADD FOREIGN KEY (predmetID) REFERENCES predmeti(id);
ALTER TABLE Pitanja ADD FOREIGN KEY (gradivoID) REFERENCES gradiva(id);
ALTER TABLE Odgovori ADD FOREIGN KEY (pitanjeID) REFERENCES pitanja(id);
ALTER TABLE Rezultati ADD FOREIGN KEY (ucenikID) REFERENCES ucenici(id);
ALTER TABLE Rezultati ADD FOREIGN KEY (odgovorID) REFERENCES odgovori(id); 


-- ---------------------- INSERT INFORMACIJA --------------------------------------------------------


insert into Ucitelji (ime, prezime, email, brojMobitela, korisnickoIme, zaporka) values
('Dražen', 'Mesarić', 'neki@gmail.com', '091-121-2210' ,'LeProf', 'test'),
('Test', 'Test', 'test@gmail.com', '','test', 'test'),
('Tester', 'Tester', 'tester@gmail.com', '','tester', 'tester'),
('Maria', 'DB', 'm@yahoo.com', '','m&m', 'tnt');

insert into razredi(naziv, maksimalnoUcenika, uciteljID) values
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
('Pitanje 9', 3),
('Pitanje 10', 3),
('Pitanje 11', 3),
('Pitanje 12', 3);

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


