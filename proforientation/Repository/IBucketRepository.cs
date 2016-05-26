using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proforientation.Models;

namespace proforientation.Repository
{
    public interface IBucketRepository
    {
        IEnumerable<Profession> GettAllOrders(string user);
        void AddToBucket(Bucket bucket);
        void ClearOrders(string user);
    }
}
