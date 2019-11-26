CREATE DATABASE BiblioteccAccenturE;
GO

USE BiblioteccAccenture;
GO

CREATE TABLE Genero
(
Id_Genero INT PRIMARY KEY IDENTITY (1,1),	
Genero varchar(30) UNIQUE
);
GO

CREATE TABLE Editorial
(	
Id_Editorial INT PRIMARY KEY IDENTITY (1,1),	
Editorial varchar(30) UNIQUE
);
GO

CREATE TABLE Libro
(	
Id_Libro INT PRIMARY KEY IDENTITY (1,1),		
Titulo varchar(50) NOT NULL,
ISBN varchar(15) UNIQUE,
Id_Genero INT NOT NULL,	
Id_Editorial INT NOT NULL,	
CONSTRAINT FK_Libro_Genero FOREIGN KEY (Id_Genero) REFERENCES Genero(Id_Genero) ON DELETE CASCADE,	
CONSTRAINT FK_Libro_Editorial FOREIGN KEY (Id_Editorial) REFERENCES Editorial(Id_Editorial)	ON DELETE CASCADE,
CONSTRAINT UQ_ISBN_LIBRO UNIQUE(ISBN,Titulo)
);
GO

CREATE TABLE Autor
(	
Id_Autor INT PRIMARY KEY IDENTITY (1,1),	
Nombre varchar(30),	
Apellido varchar(30),	
CONSTRAINT UQ_Autor_Nombre_Apellido UNIQUE (Nombre,Apellido)
);
GO

CREATE TABLE EscritoPor
( 
Id_EscritoPor INT PRIMARY KEY IDENTITY(1,1), 
Id_Libro INT not null, 
Id_Autor INT not null, 
CONSTRAINT UQ_Autor_Libro UNIQUE (Id_Libro,Id_Autor), 
CONSTRAINT FK_Book FOREIGN KEY (Id_Libro) REFERENCES Libro(Id_Libro),
CONSTRAINT FK_Author FOREIGN KEY (Id_Autor) REFERENCES Autor(Id_Autor)
);