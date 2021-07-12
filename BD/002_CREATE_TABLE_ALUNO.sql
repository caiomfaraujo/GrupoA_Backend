use GrupoA;

create table Aluno(
	Id int AUTO_INCREMENT PRIMARY KEY,
    Nome varchar(500) not null,
    Identificacao varchar(15) not null,
    RegistroAcademico int not null,
    DataCriacao datetime not null,
    DataAtualizacao datetime null
);


