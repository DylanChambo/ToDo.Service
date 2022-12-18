namespace ToDo.Service.Requests.Models;

public class AccountModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime CreatedDate { get; set; }

    public int Type { get; set; }

    public int Status { get; set; }
}