﻿using Microsoft.EntityFrameworkCore;
using SnurrtumlareWebSite.Data;
using SnurrtumlareWebSite.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnurrtumlareWebSite.Services
{
    public class UsersService
    {
        private readonly SnurrtumlareDbContext _context;

        public UsersService(SnurrtumlareDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserDetailsById(int? id)
        {
            return await _context.Users.FirstOrDefaultAsync(m => m.UserId == id);
        }

        public async Task AddNewUser(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> FindUserToEditById(int? id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task UpdateUserDetails(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public User GetUserByEmail(string userEmail)
        {
            return _context.Users.First(u => u.Email == userEmail);
        }

        public bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }

        public async Task<List<User>> GetUserProfiles(string userEmail)
        {
            return await _context.Users.Where(u => u.Email == userEmail).ToListAsync();
        }

        public User GetUserProfile(string userEmail)
        {
            CheckAndMigrateUser(userEmail);

            return _context.Users.Single(u => u.Email == userEmail);
        }

        public User UpdateProfile(User user, string firstName, string lastName, string phone, string address, string city, string zipcode)
        {
            user = _context.Users.Single(u => u.Email == user.Email);
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Phone = phone;
            user.Address = address;
            user.City = city;
            user.ZipCode = zipcode;

            _context.Update(user);
            _context.SaveChanges();

            return user;
        }

        public User CheckAndMigrateUser(string loggedInUserMail)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == loggedInUserMail);

            if (user == null)
            {
                user = new User();

                user.Email = loggedInUserMail;

                _context.Users.Add(user);
                _context.SaveChanges();
            }
            else if (loggedInUserMail == null)
            {
                user.Email = loggedInUserMail;

                _context.SaveChanges();
            }

            return user;
        }
    }
}
