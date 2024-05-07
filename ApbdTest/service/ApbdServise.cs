using ApbdTest.models.Dto;
using ApbdTest.repositori;

namespace ApbdTest.service;

public class ApbdServise
{
    Bookrepository bookrepository = new Bookrepository();
    public DtoBookInf getbook(IConfiguration _configuration,int id)
    {
       
        var book= bookrepository.getinf(_configuration, id);
        bookrepository.getgenre(_configuration,id,book);
        return book;
    }

    public DtoBookInf addBook(IConfiguration configuration, DtoAddBook book)
    {
        bookrepository.addBook(book.title,configuration);
        var id = bookrepository.id(book.title, configuration);
        Console.WriteLine(id);
        var booknew= bookrepository.getinf(configuration, id);
        bookrepository.addcat(configuration,book.id[0],id);
        bookrepository.getgenre(configuration,id,booknew);
        return booknew;
    }
    
}