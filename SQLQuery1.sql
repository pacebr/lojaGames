--criação database
use master
go
drop database if exists exodusDb
go
create database exodusDb
go
use exodusDb
go

--Drop das tabelas

drop table if exists funcionarios.dados
go
drop table if exists clientes.dados
go
drop table if exists carousel.dados
go
drop table if exists jogos.dados
go

--drop dos schemas

drop schema if exists funcionarios
go
drop schema if exists clientes
go
drop schema if exists carousel
go
drop schema if exists jogos
go

--create dos schemas

create schema funcionarios authorization dbo
go
create schema clientes authorization dbo
go
create schema jogos authorization dbo
go
--criação das tabelas

--funcionarios

create table funcionarios.dados
(
id int primary key identity(1,1) not null,
nome varchar(50) not null,
cargo varchar(50) not null,
usuario varchar(12) unique not null,
cpf varchar(11) unique not null,
senha varchar(max) not null,
foto varbinary(max) not null,
genero varchar(20) not null
)
go

--clientes

create table clientes.dados
(
id int primary key identity (1,1)not null,
nome varchar(50) not null,
sobrenome varchar (50) not null,
usuario varchar(12) unique not null,
senha varchar(max) not null,
idade varchar(255) not null,
genero varchar(255) not null,
cpf varchar(11) unique not null,
telefone varchar(11) unique not null,
endereco varchar(255) not null,
foto varbinary(max) not null
)
go

--jogos

create table jogos.dados
(
id int primary key identity(1,1),
jogo varchar(100) unique not null,
imagem varbinary(max) not null,
descricao varchar(500) unique not null,
icone varbinary(max) not null,
carousel varbinary(max) not null,
trailer varchar(255) not null,
preco float not null,
genero varchar(255) not null,
desconto float,
)
go

--Select das tabelas

select * from funcionarios.dados
select * from clientes.dados
select * from jogos.dados