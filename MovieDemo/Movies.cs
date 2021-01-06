using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MovieDemo
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Movies" in both code and config file together.
    public class Movies : IMovies
    {
        public void DoWork()
        {
            throw new NotImplementedException();
        }

        public Movies_classcs GetMovie(int Id)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MovieDB;Integrated Security=True;
                Connect Timeout=30;Encrypt=False;
                TrustServerCertificate=False;
                ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
            cmd.CommandText = "SELECT * FROM Movies WHERE Id=@id";
            SqlParameter parameter = new SqlParameter("@id", Id);
            cmd.Parameters.Add(parameter);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            Movies_classcs movies_Classcs = new Movies_classcs();
            while(sqlDataReader.Read())
            {
                movies_Classcs.Id = sqlDataReader.GetInt32(0);
                movies_Classcs.Name = sqlDataReader.GetString(1);
                movies_Classcs.ReleaseDate = sqlDataReader.GetDateTime(2);
                movies_Classcs.Genre = sqlDataReader.GetString(3);
            }
            sqlDataReader.Close();
            sqlConnection.Close();
            return movies_Classcs;
        }

        public void SaveMovie(Movies_classcs movie)
        {

            SqlConnection sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MovieDB;Integrated Security=True;
                Connect Timeout=30;Encrypt=False;
                TrustServerCertificate=False;
                ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
            cmd.CommandText = "INSERT INTO Movies (Name,DateofRelease,Genre)VALUES(@Name,@DateofRelease,@Genre) ";
            SqlParameter Name = new SqlParameter("@Name", movie.Name);
            SqlParameter DateofRelease = new SqlParameter("@DateofRelease", movie.ReleaseDate);
            SqlParameter Genre = new SqlParameter("@Genre", movie.Genre);
            cmd.Parameters.Add(Name);
            cmd.Parameters.Add(DateofRelease);
            cmd.Parameters.Add(Genre);
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            
            sqlConnection.Close();
        }
    }
}
