using ApbdTest.models;
using ApbdTest.models.Dto;
using Microsoft.Data.SqlClient;

namespace ApbdTest.repositori;

public class Bookrepository
{


    public DtoBookInf getinf(IConfiguration configuration, int id)
    {
        using SqlConnection connection = new SqlConnection(configuration.GetConnectionString("Default"));
        connection.Open();
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText =
            "select b.PK,b.title from books b \njoin books_genres bg on bg.FK_book = b.PK\njoin genres g on g.PK=bg.FK_genre\nwhere b.PK=@i";
        command.Parameters.AddWithValue("@i", id);
       

        var reader = command.ExecuteReader();
        DtoBookInf book = new DtoBookInf();
        while (reader.Read())
        {
          
            book.id = reader.GetInt32(0);
            book.tytle = reader.GetString(1);
            Console.WriteLine(book.id);
            return book;
            
        }

        return book;
    }

    public void getgenre(IConfiguration configuration, int id,DtoBookInf bookInf)
    {
        using SqlConnection connection = new SqlConnection(configuration.GetConnectionString("Default"));
        connection.Open();
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText =
            "Select g.name from books b join books_genres bg on bg.FK_book = b.PK  join genres g on g.PK=bg.FK_genre where b.PK = @i; ";
        command.Parameters.AddWithValue("@i", id);

        List<DtoGeners> genres = new List<DtoGeners>();

        var reader = command.ExecuteReader();
        DtoBookInf book = new DtoBookInf();
        while (reader.Read())
        {

          DtoGeners genre = new DtoGeners();
            genre.name = reader.GetString(0);
            
            genres.Add(genre);

        }

        bookInf.genres = genres;
    }

    public void addBook(string name,IConfiguration _configuration)
    {
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        connection.Open();
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "INSERT INTO books VALUES(@name)";
        command.Parameters.AddWithValue("@name", name);
        command.ExecuteNonQuery();
    }

    public int id(string name,IConfiguration configuration)
    {
        using SqlConnection connection = new SqlConnection(configuration.GetConnectionString("Default"));
        connection.Open();
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText =
            "Select b.PK from books b where b.title=@name; ";
        command.Parameters.AddWithValue("@name", name);
        int index = 0;
        var reader = command.ExecuteReader();
        while (reader.Read())
        {

            index = reader.GetInt32(0);
        }

        return index;
    }

    public void addcat(IConfiguration _configuration, int id,int idbook)
    {
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        connection.Open();
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "INSERT INTO books_genres VALUES(@name,@i)";
        command.Parameters.AddWithValue("@name", idbook);
        command.Parameters.AddWithValue("@i", id);
        command.ExecuteNonQuery();
        
    }
    
}