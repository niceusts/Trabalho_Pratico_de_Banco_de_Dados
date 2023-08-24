using Npgsql;

namespace DatabaseActivity
{
    class Program
    {
        static readonly string connectionString = "Host=ufsconnect.cyxm3yeteyof.us-east-1.rds.amazonaws.com;Port=5432;Username=niceu;Password=dbBiriba2023.1;Database=ufsconnect;SearchPath=ufsconnect;SSL Mode=Disable;";

        static void Main(string[] args)
        {
            InserirAluno(3, "casinha", "joias");

            //ExcluirAlunoPorNome("Miguel SObrinho");
            ConsultarAlunos();

        }

        static void InserirAluno(int id, string nome, string descricao)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO ufsconnect.categoria (id, nome, descricao) VALUES (@id, @nome, @descricao)";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    command.Parameters.AddWithValue("nome", nome);
                    command.Parameters.AddWithValue("descricao", descricao);

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
                string query = "SELECT id, nome, descricao FROM categoria";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("Categorias:");
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string nome = reader.GetString(1);
                        string descricao = reader.GetString(2);
                     


                        Console.WriteLine($"Matricula {id}, nome {nome}, data_nascimemento {descricao}");
                       
                    }
                }
            }
        }
    }
}
