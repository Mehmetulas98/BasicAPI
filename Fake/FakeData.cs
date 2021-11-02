using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Fake
{
    public static class FakeData
    {
        private static List<User> _users;
        
        public static List<User> GetUsers(int number)
        {
            if (_users == null)
            {   _users = new Faker<User>()
                .RuleFor(u => u.FirstName, u => u.Name.FirstName())
                .RuleFor(u => u.Surname, u => u.Name.LastName())
                .Generate(number);
            return _users;

            }
            return _users;
        }
    }
}
