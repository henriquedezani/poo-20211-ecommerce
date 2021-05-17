create database bdecommerce
go

use bdecommerce
go

create table Produto
(
    IdProduto   int             IDENTITY    PRIMARY key,
    Nome        varchar(max)    not null,
    Descricao   varchar(max)    not null,
    Valor       decimal(9,2)    not null,
)