namespace DataLayer.DTO;

public class AccountDTO
{
    public int Id { get; set; }
    public int IdUser { get; set; }
    public int IdStorage { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string TarrifType { get; set; }
}