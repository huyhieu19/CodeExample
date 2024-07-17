using System.Linq.Expressions;

namespace SearchGeneric
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var peoples = new List<Person>
            {
                new Person { FirstName = "John", LastName = "Doe", Email = "john@test.com", Age = 25, Salary = 4.5 },
                new Person { FirstName = "Jane", LastName = "Test", Email = "Test@example.com", Salary = 5.5 },
                new Person { FirstName = "Test", LastName = "User", Email = "test1@user.com", Age = 30 }
            };

            var searchTerm = "4.5";
            // create list expresstion
            var predicates = new List<Expression<Func<Person, object>>>
            {
                // List properties must check
                p => p.FirstName,
                p => p.LastName,
                p => p.Email,
                p => p.Age,
                p => p.Salary,
            };
            var predicate123 = SearchGeneric_V1.CreateSearchPredicate(searchTerm, predicates);

            var result = peoples.AsQueryable().Where(predicate123).ToList();
            foreach (var person in result)
            {
                Console.WriteLine($"{person.FirstName} {person.LastName} - {person.Email}");
            }

        }
    }
}