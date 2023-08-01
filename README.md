

# Exemplo de Aplicativo de Gerenciamento de Clientes C# .NET com PostgreSQL usando Npgsql

# Descrição:
Este é um exemplo de um aplicativo de console C# .NET que demonstra como interagir com um banco de dados PostgreSQL usando o Npgsql.
O aplicativo permite cadastrar, editar, excluir e listar clientes em uma tabela "clientes" no banco de dados "allog_clientes".
O código também inclui validação de e-mail antes do cadastro.

# Recursos:
- C# .NET
- Npgsql (provedor de acesso ao PostgreSQL para .NET)

# Instruções de Uso:
1. Certifique-se de ter o .NET SDK instalado em seu computador.
2. Instale o pacote Npgsql via NuGet usando o comando: `dotnet add package Npgsql`.
3. Substitua as informações de conexão (Host, Port, Database, Username e Password) na variável `connectionString` na classe `PostgresHelper` pelos valores correspondentes ao seu ambiente PostgreSQL.
4. Execute o aplicativo usando o comando: `dotnet run`.
5. Escolha uma opção no menu (Cadastrar, Editar, Excluir ou Listar Todos) e siga as instruções no console para interagir com o banco de dados.

# Observação:
Lembre-se de ter o PostgreSQL instalado e configurado corretamente no seu sistema antes de executar o aplicativo. Certifique-se de criar a tabela "clientes" no banco de dados "allog_clientes" com as colunas "nome", "endereco", "telefone" e "email".



![alllog](https://github.com/leandro-guimaraes/AllogEnter_Exercicios_Modulo_01/assets/85081592/c62c8d57-f214-49d5-a99d-107885af3366)


