# ProyectoBiblioteca
CREATE DATABASE Biblioteca
GO

CREATE TABLE Libro(
Id int primary key identity (1,1),
Titulo varchar(60) not null,

)

CREATE TABLE Editorial(
Id int primary key identity (1,1),
IdLibro int not null,
Titulo varchar(60)not null

)

CREATE TABLE Autor(
Id int primary key identity (1,1),
IdLibro int not null,
Titulo varchar(60) not null

)

CREATE TABLE Genero(
Id int primary key identity (1,1),
IdLibro int not null,
Titulo varchar(60) not null

)
