create database bdecommerce
go

use bdecommerce
go

create table Categoria
(
    IdCategoria INT             IDENTITY    PRIMARY KEY,
    Nome        varchar(200)    not null,
)

create table Produto
(
    IdProduto   int             IDENTITY    PRIMARY key,
    Nome        varchar(max)    not null,
    Descricao   varchar(max)    not null,
    Valor       decimal(9,2)    not null,
    IdCategoria INT             references Categoria (IdCategoria), -- FK
)

insert into Categoria values('Informática')
insert into Categoria values('Brinquedos')

select * from Categoria

insert into Produto values ('Computador', 'Intel i9', 2000.00, 1)
insert into Produto values ('Computador', 'Intel i5', 2000.00, 1)
insert into Produto values ('Computador', 'Intel i3', 2000.00, 1)
insert into Produto values ('Hot Wheels', 'Carrinho', 10.00, 2)

select * from Produto

create view v_produto as
    select Produto.*, Categoria.Nome as Categoria
        from Produto
        join Categoria On Produto.IdCategoria = Categoria.IdCategoria

select * from v_produto