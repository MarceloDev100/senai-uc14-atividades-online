CREATE DATABASE ProjetoDb
GO

USE ProjetoDb
GO

CREATE TABLE Projetos
(
   ProjetoId INT PRIMARY KEY IDENTITY,
   Titulo VARCHAR(50) NOT NULL UNIQUE,
   Status INT NOT NULL,
   DataInicio DATETIME NOT NULL,
   Tecnologia VARCHAR(50),
   Requisito VARCHAR(50),	
   Area VARCHAR(20) 
)
GO

INSERT INTO Projetos VALUES ('Projeto Game Mania', 2, '20210817', 'Angular', 'E-commerce de jogos', 'Front end')
INSERT INTO Projetos VALUES ('Projeto Chapter', 2, '20220510', '.NET', 'CRUD de Livros', 'Back end') 
INSERT INTO Projetos VALUES ('Projeto ExoApi', 1, '20220527', '.NET', 'CRUD de Projetos', 'Back end')
GO

SELECT * FROM Projetos
GO

CREATE TABLE Usuarios
(
   UsuarioId INT PRIMARY KEY IDENTITY,
   Email VARCHAR(255) NOT NULL UNIQUE,
   Senha VARCHAR(120) NOT NULL,
   Tipo CHAR(1) NOT NULL
)
GO

INSERT INTO Usuarios VALUES ('email@sp.br', '1234', '0')
GO

SELECT * FROM Usuarios WHERE email = 'email@sp.br' AND senha = '1234'
