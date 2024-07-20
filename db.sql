
CREATE TABLE Atleta (
    Id SERIAL PRIMARY KEY,
    Nome VARCHAR(255) NOT NULL,
    Nascimento DATE NOT NULL,
    Idade INTEGER NOT NULL,
    Altura REAL NOT NULL,
    Peso REAL NOT NULL,
    Dominancia VARCHAR(255) NOT NULL,
    Posicao VARCHAR(255) NOT NULL,
);

CREATE TABLE Usuario (
    Id SERIAL PRIMARY KEY,
    Nome VARCHAR(255) NOT NULL,
    Nascimento DATE NOT NULL,
    Funcao VARCHAR(255) NOT NULL,
    Email VARCHAR(255) UNIQUE NOT NULL,
    Password VARCHAR(255) NOT NULL
);

CREATE TABLE Base (
    Id SERIAL PRIMARY KEY,
    Nome VARCHAR(255) NOT NULL,
    IdadeLimite INTEGER NOT NULL
);

CREATE TABLE TimeAtleta (
    Id SERIAL PRIMARY KEY,
    TimeId SERIAL NOT NULL REFERENCES Base(Id),
    AtletaId SERIAL NOT NULL REFERENCES Atleta(Id),
    DataAssociacao TIMESTAMP NOT NULL
);

CREATE TABLE ExameMedico (
    Id SERIAL PRIMARY KEY,
    Descricao TEXT NOT NULL,
    AtletaId SERIAL NOT NULL REFERENCES Atleta(Id),
    Data TIMESTAMP NOT NULL,
    Observacoes TEXT NOT NULL,
    DocumentUrl TEXT NOT NULL
);

CREATE TABLE GrupoPartida (
    Id SERIAL PRIMARY KEY,
    Nome TEXT NOT NULL,
    Inicio TIMESTAMP,
    Fim TIMESTAMP
);

CREATE TABLE Nota (
    Id SERIAL PRIMARY KEY,
    Valor INTEGER CHECK (Valor >= 0 AND Valor <= 10),
    Data TIMESTAMP NOT NULL,
    Observacoes TEXT NOT NULL,
    AtletaId UUID NOT NULL
);

CREATE TABLE Partida (
    Id SERIAL PRIMARY KEY,
    BaseId SERIAL NOT NULL REFERENCES Base(Id),
    GrupoPartidaId SERIAL NOT NULL REFERENCES GrupoPartida(Id),
    TimeAdversario TEXT NOT NULL,
    DataHorario TIMESTAMP NOT NULL,
    Local TEXT NOT NULL,
    GolsAFavor INTEGER NOT NULL,
    GolsContra INTEGER NOT NULL
);

CREATE TABLE PartidaAtleta (
    Id SERIAL PRIMARY KEY,
    AtletaId SERIAL NOT NULL REFERENCES Atleta(Id),
    PartidaId SERIAL NOT NULL REFERENCES Partida(Id),
    Minutagem INTEGER NOT NULL,
    CartoesAmarelos INTEGER NOT NULL,
    CartaoVermelho INTEGER NOT NULL,
    Gols INTEGER NOT NULL
);