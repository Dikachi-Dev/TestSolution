using Profile;
using System.Collections.Generic;

namespace PaymentApi.Repository
{
    public interface IStateRepository
    {

        //IEnumerable<PayState> GetStates();
        //PayState GetState(int StateId);
        void InsertState(PayState payState);

        //void DeleteState(int StateId);
        //void UpdateState(int StateId);

        void Save();
    }
}
