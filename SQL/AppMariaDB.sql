DROP DATABASE if EXISTS vjezba;

CREATE DATABASE vjezba; 

USE vjezba; 

CREATE TABLE vjezbe(

							id 		INT NOT NULL PRIMARY KEY AUTO_INCREMENT, 
							userName VARCHAR(50),
							money 	DECIMAL(12,5),
							isGood 	bool

						);	
						
CREATE TABLE testovi(

							id 		INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
							testName VARCHAR(50),
							vjezba 	int
							);
							
							
ALTER TABLE testovi ADD FOREIGN KEY (vjezba) REFERENCES vjezbe(id);

INSERT INTO vjezbe(userName, money) VALUES ('Bobo', '123.32');

SELECT a.userName, b.testName
FROM vjezbe a INNER JOIN test b ON a.id = b.vjezba;

