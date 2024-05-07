namespace ApbdTest.models;

public class Book
{
    public int id { get; set; }
    public string tytle { get; set; }
    public List<Genres> geners { get; set; }
}