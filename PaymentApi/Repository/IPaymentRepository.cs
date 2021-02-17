using Profile;
using System.Collections.Generic;

namespace PaymentApi.Repository
{
    public interface IPaymentRepository
    {

        //IEnumerable<Request> GetRequests();
        //Request GetRequest(int ProfileId);
        void InsertRequest(Request request);

        //void DeleteRequest(int RequestId);
        //void UpdateRequest(int RequestId);

        void Save();
    }
}
