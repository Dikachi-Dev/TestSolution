
using System.Collections.Generic;
using System.Linq;
using Database;
using Profile;

namespace PaymentApi.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentDbContext _paymentDbContext;
        public PaymentRepository (PaymentDbContext paymentDbContext)
        {
            _paymentDbContext = paymentDbContext;
        }
        //public void DeleteRequest(int RequestId)
        //{
        //    var profile = _paymentDbContext.Requests.Find(RequestId);
        //    _paymentDbContext.Requests.Remove(profile);
        //    Save();
        //}

        //public Request GetRequest(int RequestId)
        //{
        //   return _paymentDbContext.Requests.Find(RequestId);
        //}

        //public IEnumerable<Request> GetRequests()
        //{
        //    return _paymentDbContext.Requests.ToList();
        //}

        public void InsertRequest(Request request)
        {
            _paymentDbContext.Add(request);
            Save();
        }

        public void Save()
        {
            _paymentDbContext.SaveChanges();
        }

        //public void UpdateRequest(int RequestId)
        //{
        //    var profile = _paymentDbContext.Requests.Find(RequestId);
        //    _paymentDbContext.Requests.Update(profile);
        //    Save();
        //}
    }
}
