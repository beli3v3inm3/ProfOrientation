using System.Collections.Generic;
using System.Linq;
using proforientation.Models;
using WebGrease.Css.Extensions;

namespace proforientation.Repository
{
    public class BucketRepository : IBucketRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BucketRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Profession> GettAllOrders(string user)
        {
            var getOrders = from data in _dbContext.Buckets.Where(_ => _.UserId == user)
                from order in _dbContext.Professions.Where(_ => _.Id == data.ProfId)
                select order;

            foreach (var order in getOrders)
            {
                yield return order;
            }

        }

        public void AddToBucket(Bucket bucket)
        {
            var order = new Bucket
            {
                UserId = bucket.UserId,
                ProfId = bucket.ProfId
            };

            _dbContext.Buckets.Add(order);
            _dbContext.SaveChanges();
        }

        public void ClearOrders(string user)
        {
            var getOrders = from orders in _dbContext.Buckets
                where orders.UserId == user
                select orders;

            foreach (var bucket in getOrders)
            {
                _dbContext.Buckets.Remove(bucket);
            }
        }
    }
}