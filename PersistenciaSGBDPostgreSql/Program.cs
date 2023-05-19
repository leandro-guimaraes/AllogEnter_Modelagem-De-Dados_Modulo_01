using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace exercicio_sgbdPstgree
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(@"                           _______");
            Console.WriteLine(@"                         | ___  o|");
            Console.WriteLine(@"                         |[_-_]_ |");
            Console.WriteLine(@"      ______________     |[_____]|");
            Console.WriteLine(@"     |.------------.|    |[_____]|");
            Console.WriteLine(@"     ||            ||    |[====o]|");
            Console.WriteLine(@"     ||            ||    |[_.--_]|");
            Console.WriteLine(@"     ||            ||    |[_____]|");
            Console.WriteLine(@"     ||            ||    |      :|");
            Console.WriteLine(@"     ||____________||    |      :|");
            Console.WriteLine(@" .==.|""  ......    |.==.|      :|");
            Console.WriteLine(@" |::| '-.________.-' |::||      :|");
            Console.WriteLine(@" |''|  (__________)-.|''||______:|");
            Console.WriteLine(@" `""`_.............._\""`______");
            Console.WriteLine(@"    /:::::::::::'':::\`;'-.-.  `\");
            Console.WriteLine(@"   /::=========.:.-::"\ \ \--\   \");
            Console.WriteLine(@"   \`""""""""""""""""`/  \ \__)   \");
            Console.WriteLine(@"    `""""""""""""""""`    '========'");



            Console.WriteLine("Bem-vindo!");
            Console.WriteLine("Informe uma opção:  \n 1 (Cadastrar) \n 2 (Editar) \n 3 (Excluir) \n 4 (Listar Todos): ");
            int opcao = Convert.ToInt32(Console.ReadLine());

            var postgresHelper = new PostgresHelper();

            switch (opcao)
            {
                case 1: // Cadastrar
                    postgresHelper.AdicionarCliente();
                    break;
                case 2: // Editar
                    postgresHelper.EditarCliente();
                    break;
                case 3: // Excluir
                    postgresHelper.ExcluirCliente();
                    break;
                case 4: // Listar Todos
                    postgresHelper.ListarTodosClientes();
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }

    public class PostgresHelper
    {
        private readonly string connectionString = "Host=localhost;Port=5432;Database=database_name;Username=username;Password=password";

        public void ListarTodosClientes()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("SELECT * FROM clientes", connection);
                var reader = command.ExecuteReader();

                Console.WriteLine("ID \t Nome \t\t\t Endereço \t\t\t Telefone \t\t E-mail");

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string nome = reader.GetString(1);
                    string endereco = reader.GetString(2);
                    string telefone = reader.GetString(3);
                    string email = reader.GetString(4);

                    Console.WriteLine($"{id} \t {nome} \t\t\t {endereco} \t\t\t {telefone} \t\t {email}");
                }
            }
        }

        public void AdicionarCliente()
        {
            Cliente cliente = CriarCliente();

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("INSERT INTO clientes (nome, endereco, telefone, email) VALUES (@nome, @endereco, @telefone, @email)",
                                                connection);

                command.Parameters.AddWithValue("@nome", cliente.nome);
                command.Parameters.AddWithValue("@endereco", cliente.endereco);
                command.Parameters.AddWithValue("@telefone", cliente.telefone);
                command.Parameters.AddWithValue("@email", cliente.email);

                command.ExecuteNonQuery();

                Console.WriteLine("Cliente cadastrado!");
            }
        }

        public void EditarCliente()
        {
            Console.WriteLine("Informe o ID do cliente que deseja editar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("SELECT * FROM clientes WHERE id = @id", connection);
                command.Parameters.AddWithValue("@id", id);

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Cliente cliente = CriarCliente();

                    using (var updateConnection = new NpgsqlConnection(connectionString))
                    {
                        updateConnection.Open();
                        var updateCommand = new NpgsqlCommand("UPDATE clientes SET nome = @nome, endereco = @endereco, telefone = @telefone, email = @email WHERE id = @id",
                                                              updateConnection);

                        updateCommand.Parameters.AddWithValue("@id", id);
                        updateCommand.Parameters.AddWithValue("@nome", cliente.nome);
                        updateCommand.Parameters.AddWithValue("@endereco", cliente.endereco);
                        updateCommand.Parameters.AddWithValue("@telefone", cliente.telefone);
                        updateCommand.Parameters.AddWithValue("@email", cliente.email);

                        updateCommand.ExecuteNonQuery();
                    }

                    Console.WriteLine("Cliente editado!");
                }
                else
                {
                    Console.WriteLine("ID do cliente não cadastrado!");
                }
            }
        }

        public void ExcluirCliente()
        {
            Console.WriteLine("Informe o ID do cliente que deseja excluir: ");
            int id = Convert.ToInt32(Console.ReadLine());

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("SELECT * FROM clientes WHERE id = @id", connection);
                command.Parameters.AddWithValue("@id", id);

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    using (var deleteConnection = new NpgsqlConnection(connectionString))
                    {
                        deleteConnection.Open();
                        var deleteCommand = new NpgsqlCommand("DELETE FROM clientes WHERE id = @id", deleteConnection);
                        deleteCommand.Parameters.AddWithValue("@id", id);

                        deleteCommand.ExecuteNonQuery();
                    }

                    Console.WriteLine("Cliente excluído!");
                }
                else
                {
                    Console.WriteLine("ID do cliente não cadastrado!");
                }
            }
        }

        private Cliente CriarCliente()
        {
            Cliente cliente = new Cliente();
            Console.WriteLine("Informe o nome: ");
            cliente.nome = Console.ReadLine();
            Console.WriteLine("Informe o endereço: ");
            cliente.endereco = Console.ReadLine();
            Console.WriteLine("Informe o telefone: ");
            cliente.telefone = Console.ReadLine();
            bool emailValido = false;
            string email = "";
            while (!emailValido)
            {
                Console.WriteLine("Informe o e-mail: ");
                email = Console.ReadLine();
                emailValido = validarEmail(email);
                if (!emailValido)
                {
                    Console.WriteLine("E-mail inválido, informe novamente!");
                }
            }
            cliente.email = email;
            return cliente;
        }

        private bool validarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            try
            {
                var endereco = new System.Net.Mail.MailAddress(email);
                return endereco.Address == email.Trim();
            }
            catch
            {
                return false;
            }
        }
    }

    public class Cliente
    {
        public string nome { get; set; }
        public string endereco { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
    }
}
