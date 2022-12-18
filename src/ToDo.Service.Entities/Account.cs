namespace ToDo.Service.Entities;

public class Account
{
    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime CreatedDate { get; set; }

    public AccountType Type { get; set; }

    public AccountStatus Status { get; set; }
}