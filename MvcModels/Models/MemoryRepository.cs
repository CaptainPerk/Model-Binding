using MvcModels.Models.Enumerations;
using MvcModels.Models.Interfaces;
using System.Collections.Generic;

namespace MvcModels.Models
{
    public class MemoryRepository : IRepository
    {
        private readonly Dictionary<int, Person> people = new Dictionary<int, Person>
        {
            [1] = new Person { PersonId = 1, FirstName = "Bob", LastName = "Smith", Role = Role.Admin},
            [2] = new Person { PersonId = 2, FirstName = "Anne", LastName = "Douglas", Role = Role.User},
            [3] = new Person { PersonId = 3, FirstName = "Joe", LastName = "Able", Role = Role.User},
            [4] = new Person { PersonId = 4, FirstName = "Mary", LastName = "Peters", Role = Role.Guest}
        };

        public IEnumerable<Person> People => people.Values;

        public Person this[int id]
        {
            get => people.ContainsKey(id) ? people[id] : null;
            set => people[id] = value;
        }
    }
}
