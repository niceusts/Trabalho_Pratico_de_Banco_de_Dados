using System;
using System.Runtime.ConstrainedExecution;
using Npgsql;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DatabaseActivity
{
    class Program
    {
        static string connectionString = "Host=localhost;Port=5432;Username=niceu;Password=2050;Database=UfsCommerce;";

        static void Main(string[] args)
        {
            InserirAluno("Miguel Sobrinho", "miguel@example.com", "senha123");

            //ExcluirAlunoPorNome("Miguel SObrinho");
            ConsultarAlunos();

        }

        static void InserirAluno(string nome, string email, string senha)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO aluno (nome, email, senha) VALUES (@nome, @email, @senha)";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(@matricula, matricula);
                    command.Parameters.AddWithValue(@nome, nome);
                    command.Parameters.AddWithValue(@data_nascimemento, data_nascimemento);
                    command.Parameters.AddWithValue(@email, email);
                    command.Parameters.AddWithValue(@tipo_logradouro, tipo_logradouro);
                    command.Parameters.AddWithValue(@nome_logradouro, nome_logradouro);
                    command.Parameters.AddWithValue(@numero, numero);
                    command.Parameters.AddWithValue(@bairro, bairro);
                    command.Parameters.AddWithValue(@cidade, cidade);
                    command.Parameters.AddWithValue(@uf, uf);
                    command.Parameters.AddWithValue(@cep, cep);
                    command.Parameters.AddWithValue(@telefone, telefone);
                    command.Parameters.AddWithValue(@cpf, cpf);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Aluno inserido com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Não foi possível inserir o aluno.");
                    }
                }
            }
        }

        static void ConsultarAlunos()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT nome, email FROM aluno";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("Alunos:");
                    while (reader.Read())
                    {
                        string nome = reader.GetString(0);
                        string email = reader.GetString(1);

                        Console.WriteLine($"Nome: {nome}, Email: {email}");
                    }
                }
            }
        }

        //static void ExcluirAlunoPorNome(string nome)
        //{
        //    using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        string query = "DELETE FROM aluno WHERE nome = @nome";

        //        using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@nome", nome);

        //            int rowsAffected = command.ExecuteNonQuery();
        //            if (rowsAffected > 0)
        //            {
        //                Console.WriteLine($"Aluno {nome} excluído com sucesso!");
        //            }
        //            else
        //            {
        //                Console.WriteLine($"Aluno {nome} não encontrado ou não pôde ser excluído.");
        //            }
        //        }
        //    }
        //}
    }
}
