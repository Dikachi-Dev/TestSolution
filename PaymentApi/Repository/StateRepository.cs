
using System.Collections.Generic;
using System.Linq;
using Database;
using Profile;

namespace PaymentApi.Repository
{
    public class StateRepository : IStateRepository
    {
        private readonly PaymentDbContext _paymentDbContext;
        public StateRepository(PaymentDbContext paymentDbContext)
        {
            _paymentDbContext = paymentDbContext;
        }
        //public PayState GetState(int StateId)
        //{
        //    return _paymentDbContext.PayStates.Find(StateId);
        //}

        //public IEnumerable<PayState> GetStates()
        //{
        //    return _paymentDbContext.PayStates.ToList();
        //}

        public void InsertState(PayState payState)
        {
            _paymentDbContext.Add(payState);
            Save();
        }

        //public void UpdateState(int StateId)
        //{
        //    var State = _paymentDbContext.PayStates.Find(StateId);
        //    _paymentDbContext.PayStates.Update(State);
        //    Save();
        //}

        //public void DeleteState(int StateId)
        //{
        //    var State = _paymentDbContext.PayStates.Find(StateId);
        //    _paymentDbContext.PayStates.Remove(State);
        //    Save();
        //}

        public void Save()
        {
            _paymentDbContext.SaveChanges();
        }
    }
}
