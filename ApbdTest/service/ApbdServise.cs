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

    public void addBook(IConfiguration configuration, DtoAddBook book)
    {
        bookrepository.addBook(book.title,configuration);
        
    }
}