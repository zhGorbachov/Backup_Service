namespace PresentationLayer.DTO;

public class AccountDTO
{
    public int IdUser { get; set; }
    public int IdStorage { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public int TariffType { get; set; }
}