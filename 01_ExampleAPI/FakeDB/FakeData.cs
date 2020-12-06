using Bogus;
using ExampleAPI.Models;
using System.Collections.Generic;

namespace ExampleAPI.FakeDB
{
    public static class FakeData
    {
        /* Bogus kütüphanesi kullanılarak Fake Data üretimi yapılmaktadır. */
        public static List<User> _users;
        public static List<User> GetUsers(int number)
        {
            if (_users == null)
            {
                _users = new Faker<User>()
                .RuleFor(u => u.Id, f => f.IndexFaker + 1)
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.Address, f => f.Address.FullAddress())
                .Generate(number);
            }
            return _users; 
        }
    }
}