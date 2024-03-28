using conjuring.Models;
using conjuring.Database;
using Microsoft.EntityFrameworkCore;

namespace conjuring.Services;

public class UserService(ConjuringDbContext dbContext) {
    private readonly ConjuringDbContext db = dbContext;

    public async Task<IEnumerable<UserEntity>> GetUsers() {
        return await db.Users.ToListAsync();
    }

    public async Task<UserEntity?> GetUser(int id) {
        return await db.Users.FindAsync(id);
    }

    public async Task<bool> Create(UserEntity user) {
        UserEntity? check = await db.Users.FirstOrDefaultAsync(u => u.Username == user.Username);

        if (check != null) {
            return false;
        }

        await db.Users.AddAsync(user);
        await db.SaveChangesAsync();

        return true;
    }

    public async Task<bool> Update(int id, UserEntity user) {
        UserEntity? check = await db.Users.FindAsync(id);

        if (check != null) {
            check.Username = user.Username;
            check.Password = user.Password;
            await db.SaveChangesAsync();

            return true;
        }

        return false;
    }

    public async Task<bool> Delete(int id) {
        UserEntity? check = await db.Users.FindAsync(id);

        if (check != null) {
            db.Users.Remove(check);
            await db.SaveChangesAsync();

            return true;
        }

        return false;
    }
}