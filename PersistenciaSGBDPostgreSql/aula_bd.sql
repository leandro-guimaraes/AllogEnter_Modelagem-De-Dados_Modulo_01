-- Criar o banco de dados
CREATE DATABASE aula_bd ENCODING 'UTF8';

-- Usar o banco de dados criado
\c aula_bd

-- Criar a tabela cidade
CREATE TABLE cidade (
  id serial PRIMARY KEY,
  nome varchar(100),
  uf varchar(2)
);

-- Criar a tabela cliente
CREATE TABLE cliente (
  id serial PRIMARY KEY,
  id_cidade int,
  nome varchar(100),
  endereco varchar(100),
  telefone varchar(20),
  FOREIGN KEY (id_cidade) REFERENCES cidade (id)
);

-- Inserir as cidades com suas respectivas UFs
INSERT INTO cidade (nome, uf) VALUES
  ('Brusque', 'SC'),
  ('Itajaí', 'SC'),
  ('Curitiba', 'PR'),
  ('São Paulo', 'SP'),
  ('Santos', 'SP');

-- Inserir os clientes
INSERT INTO cliente (id_cidade, nome, endereco, telefone) VALUES
  (1, 'Cliente 1 de Brusque', 'Endereço 1', '111111'),
  (2, 'Cliente 1 de Itajaí', 'Endereço 2', '222222'),
  (2, 'Cliente 2 de Itajaí', 'Endereço 3', '333333'),
  (2, 'Cliente 3 de Itajaí', 'Endereço 4', '444444'),
  (4, 'Cliente 1 de São Paulo', 'Endereço 5', '555555'),
  (3, 'Cliente 1 de Curitiba', 'Endereço 6', '666666'),
  (3, 'Cliente 2 de Curitiba', 'Endereço 7', '777777');

-- Atualizar o nome da cidade de "Brusque" para "Bruxque"
UPDATE cidade SET nome = 'Bruxque' WHERE nome = 'Brusque';

-- Atualizar o nome das cidades da UF 'SC' colocando o prefixo "SC-"
UPDATE cidade SET nome = 'SC-' || nome WHERE uf = 'SC';

-- Excluir a cidade de "Santos"
DELETE FROM cidade WHERE nome = 'Santos';

-- Excluir o cliente de id = 2
DELETE FROM cliente WHERE id = 2;

-- Excluir as cidades com UF igual a 'SC' e 'SP'
DELETE FROM cidade WHERE uf IN ('SC', 'SP');

-- Mostre o nome das cidades em ordem alfabética
SELECT nome FROM cidade ORDER BY nome;

-- Mostre o Nome do Cliente e Nome da Cidade dos clientes cadastrados do estado 'SC'
SELECT c.nome AS cliente, ci.nome AS cidade
FROM cliente c
JOIN cidade ci ON c.id_cidade = ci.id
WHERE ci.uf = 'SC';

-- Mostre apenas os clientes que começam com a letra B
SELECT nome FROM cliente WHERE nome ILIKE 'B%';

-- Mostre a quantidade de clientes que existem por cidade. Colocar o nome da cidade e a quantidade.
SELECT ci.nome AS cidade, COUNT(*) AS quantidade_clientes
FROM cliente c
JOIN cidade ci ON c.id_cidade = ci.id
GROUP BY ci.nome;

-- Mostre a quantidade de clientes da UF = 'SC'
SELECT COUNT(*) AS quantidade_clientes_SC
FROM cliente c
JOIN cidade ci ON c.id_cidade = ci.id
WHERE ci.uf = 'SC';

-- Mostre o nome dos clientes concatenando com o nome da cidade e UF (exemplo: Lucas-Brusque-SC)
SELECT c.nome || '-' || ci.nome || '-' || ci.uf AS cliente_cidade_uf
FROM cliente c
JOIN cidade ci ON c.id_cidade = ci.id;

-- Mostre o nome dos clientes de Santa Catarina e do Paraná, em dois comandos separadamente, e junte-os utilizando o comando UNION.
SELECT c.nome
FROM cliente c
JOIN cidade ci ON c.id_cidade = ci.id
WHERE ci.uf = 'SC'
UNION
SELECT c.nome
FROM cliente c
JOIN cidade ci ON c.id_cidade = ci.id
WHERE ci.uf = 'PR';

-- Crie uma visão para mostrar apenas o nome dos clientes de São Paulo
CREATE VIEW clientes_sp AS
SELECT c.nome
FROM cliente c
JOIN cidade ci ON c.id_cidade = ci.id
WHERE ci.uf = 'SP';
