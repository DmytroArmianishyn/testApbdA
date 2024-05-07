using ApbdTest.models.Dto;
using ApbdTest.repositori;
using ApbdTest.service;
using Microsoft.AspNetCore.Mvc;

namespace ApbdTest.conttroller;
[ApiController]

public class BookController:ControllerBase
{
 
    private readonly IConfiguration _configuration;
    private ApbdServise _servise = new ApbdServise();
    
    public BookController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet("/api/books/{id}/geners")]
    public IActionResult searchbook(int id)
    {
       var book= _servise.getbook(_configuration,id);
        
       return Ok(book);
    }

    [HttpPost("api/books")]
    public IActionResult addBook(DtoAddBook addBook)
    {

        _servise.addBook(_configuration, addBook);
        return Ok(1);
    }
    
}