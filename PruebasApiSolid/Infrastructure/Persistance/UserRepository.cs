using Microsoft.EntityFrameworkCore;
using PruebasApiSolid.Application.Dtos;
using PruebasApiSolid.Application.Interfaces;
using PruebasApiSolid.Domain.Entities;

namespace PruebasApiSolid.Infrastructure.Persistance
{
    public class UserRepository: IUserRepository
    {
        private readonly AppDataBaseContext _dataBaseContext;

        public UserRepository(AppDataBaseContext appDataBaseContext)
        {
            _dataBaseContext = appDataBaseContext;
        }
        public async Task<IEnumerable<User>> GetAll()
        {
            var response = await _dataBaseContext.users.ToListAsync();

            return response;
        }

        public async Task<User?> GetId(Guid Id)
        {
            var response = await _dataBaseContext.users.FirstOrDefaultAsync(x => x.Id == Id);
            return response;
        }

        public async Task CreateUser(User request)
        {
            await _dataBaseContext.users.AddAsync(request);
            await _dataBaseContext.SaveChangesAsync();
        }

        public async Task DeleteUser(User user)
        {
             _dataBaseContext.users.Remove(user);
             await _dataBaseContext.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            _dataBaseContext.users.Update(user);
            await _dataBaseContext.SaveChangesAsync();
        }
    }
}
