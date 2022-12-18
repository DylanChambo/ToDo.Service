using ToDo.Service.Entities;
using ToDo.Service.Entities.Exceptions;
using ToDo.Service.Services.Contract.Account;

namespace ToDo.Service.Services.Account;

public class AccountService : IAccountService
{
    private static List<Entities.Account> _accounts;

    public AccountService()
    {
        _accounts = new List<Entities.Account>
        {
            new ()
            {
                Id = 1, Name = "Account 1", Status = AccountStatus.Active, Type = AccountType.Full,
                CreatedDate = new DateTime(2022, 10, 12)
            },
            new ()
            {
                Id = 2, Name = "Account 2", Status = AccountStatus.Inactive, Type = AccountType.Trial,
                CreatedDate = new DateTime(2022, 10, 13)
            },
            new ()
            {
                Id = 3, Name = "Account 3", Status = AccountStatus.Active, Type = AccountType.Trial,
                CreatedDate = new DateTime(2022, 10, 14)
            },
        };
    }

    public IQueryable<Entities.Account> GetAll()
    {
        return _accounts.AsQueryable();
    }

    public void Create(Entities.Account account)
    {
        _accounts.Add(account);
    }

    public Entities.Account GetById(int id)
    {
        var account = _accounts.FirstOrDefault(a => a.Id == id);
        if (account is null)
        {
            throw new AccountNotFoundException();
        }

        return account;
    }
}