using InformCPISolution.Data;
using InformCPISolution.Models;
using Microsoft.EntityFrameworkCore;

namespace InformCPISolution.Tests.Repositories
{
    [TestFixture]
    public class ContactRepositoryTests
    {
        private DbContextOptions<InformCPIDbContext> _options;

        [SetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<InformCPIDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

        [Test]
        public void GetAllContacts_WithContacts_ReturnsAllContacts()
        {
            using (var context = new InformCPIDbContext(_options))
            {
                var repository = new ContactRepository(context);
                var contacts = new List<Contact>
                {
                    new Contact { Name = "John Doe", Email = "john@example.com", Phone = "1234567890" },
                    new Contact { Name = "Jane Smith", Email = "jane@example.com", Phone = "9876543210" }
                };
                context.Contact.AddRange(contacts);
                context.SaveChanges();

                var result = repository.GetAllContacts();

                Assert.AreEqual(2, result.Count);
                Assert.IsTrue(result.Any(c => c.Name == "John Doe"));
                Assert.IsTrue(result.Any(c => c.Name == "Jane Smith"));
            }
        }
    }
}
