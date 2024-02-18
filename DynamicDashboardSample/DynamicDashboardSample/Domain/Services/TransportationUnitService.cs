using Bogus;
using DynamicDashboardSample.Domain.Models;
using DynamicDashboardSample.Domain.Services.Interfaces;

namespace DynamicDashboardSample.Domain.Services
{
    public class TransportationUnitService : IService<TransportationUnit>
    {

        public List<TransportationUnit> GetList()
        {

            Random rnd = new();

            int carId = 0;
            var fake = new Faker<TransportationUnit>()
                .RuleFor(c => c.Id, f => "UT" + ++carId)
                .RuleFor(c => c.Minutes, f => rnd.Next(1, 100));

            return fake.Generate(rnd.Next(1, 11));
        }
        public void Delete(TransportationUnit input)
        {
            throw new NotImplementedException();
        }
        public TransportationUnit GetValue(TransportationUnit input)
        {
            throw new NotImplementedException();
        }

        public void Insert(TransportationUnit input)
        {
            throw new NotImplementedException();
        }

        public void Update(TransportationUnit input)
        {
            throw new NotImplementedException();
        }

    }
}
