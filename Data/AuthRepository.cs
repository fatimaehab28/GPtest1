﻿using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using tbackendgp.Data.IRepository;
using tbackendgp.Models;
using Microsoft.Extensions.Configuration;

namespace tbackendgp.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _db;
        private readonly IConfiguration _config;

        public AuthRepository(DataContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        public async Task<User> Login(string email, string password)
        {
            var user = await _db.User
                .Include(u => u.UserType)  // 🔥 Ensures UserType is included in the query
                .FirstOrDefaultAsync(x => x.Email == email);

            if (user == null || !VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }


        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _db.User.AddAsync(user);
            await _db.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExist(string email)
        {
            return await _db.User.AnyAsync(x => x.Email == email);
        }

        
    }
}
