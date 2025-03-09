CREATE DATABASE ZbirkaIgara;
USE ZbirkaIgara;

CREATE TABLE Zanr (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ImeZanra VARCHAR(255) NOT NULL
);

CREATE TABLE Igre (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Naslov VARCHAR(255) NOT NULL,
    Opis VARCHAR(MAX),
    hltb INT,
    ocjena DECIMAL(4,2),
    DatumIzdavanja DATE,
    Platforme VARCHAR(255),
    Trailer VARCHAR(MAX),
    UrlSlike VARCHAR(MAX) 
);
