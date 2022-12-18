namespace ToDo.Service.Services.Contract.Account;

public interface IAccountService
{
    IQueryable<Entities.Account> GetAll();

    void Create(Entities.Account account);

    Entities.Account GetById(int id);
}