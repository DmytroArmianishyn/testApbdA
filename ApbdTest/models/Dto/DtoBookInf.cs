namespace ApbdTest.models.Dto;

public class DtoBookInf
{
    public int id { get; set; }
    public string tytle { get; set; }
   public List<DtoGeners> genres { get; set; }
}