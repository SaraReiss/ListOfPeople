using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw_ListOfPeople.Data
{
    public class PersonManager
    {
        private string _connectionString;
        public PersonManager(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Add(Person person )
        {
            using var connection = new SqlConnection(_connectionString);
            using var cmd = connection.CreateCommand();
            
            cmd.CommandText = @"Insert Into Person VALUES (@fn, @ln, @age)";
            cmd.Parameters.AddWithValue("@fn", person.FirstName);
            cmd.Parameters.AddWithValue("@ln", person.LastName);
            cmd.Parameters.AddWithValue("@age", person.Age);
            
            connection.Open();
            cmd.ExecuteNonQuery();
        }

        public void AddMany(List<Person> people)
        {
            foreach (var person in people)
            {
                Add(person);
            }
        }

        public List<Person> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Person";
            connection.Open();
            var people = new List<Person>();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                people.Add(new Person
                {
                    Id = (int)reader["Id"],
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Age = (int)reader["Age"],

                });
            }
            return people;
        }
    }
}
