using System;
using Microsoft.AspNetCore.Mvc;
using PaymentApi.Repository;
using Profile;
using ICheapPaymentGateway;
using IExpensivePaymentGateway;

namespace PaymentApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private IPaymentRepository _repo;
        private IStateRepository _stateRepository;

        public PaymentController(IPaymentRepository repo, IStateRepository stateRepository)
        {
            _repo = repo;
            _stateRepository = stateRepository;
        }



        [HttpPost]
        public ActionResult<PayState> ProcessPayment(Request request)
        {
            if (request != null)
            {
                if (request.Amount <= 20)
                {

                    var cheapPay = new CheapPay();
                    var payState = cheapPay.ChPay(request);
                    if (payState == Ok())
                    {
                        _repo.InsertRequest(request);
                        //return  payState processed
                         var paych = new PayState() { Id = request.Id, State = "Processed" };
                        _stateRepository.InsertState(paych);
                        return new PayState() { Id = request.Id, State = "Processed" }; ;

                    }
                }
                else if (request.Amount > 20 || request.Amount <= 500)
                {
                    var expPAy = new ExpensivePay();
                    var payState = expPAy.ChPay(request);
                    if (payState == Ok())
                    {
                        _repo.InsertRequest(request);
                        //return  payState processed
                         var pay = new PayState() { Id = request.Id, State = "Processed" };
                        _stateRepository.InsertState(pay);
                        return new PayState() { Id = request.Id, State = "Processed" }; 
                    }
                }
                else if (request.Amount > 500)
                {
                    var paye = new PayState() { Id = request.Id, State = "Pending" };
                    _stateRepository.InsertState(paye);
                    return new BadRequestObjectResult(new { message = "try only PremiumPaymentService and retry up to 3 times in case payment does not get processed", currentDate = DateTime.Now });
                    //try only PremiumPaymentService and retry up to 3 times in case payment does not get processed
                }
                else
                    return BadRequest();
            }
            var Reerror = new PayState() { Id = request.Id, State = "failed" };
            _stateRepository.InsertState(Reerror);
            return new PayState() { Id = request.Id, State = "failed" };
        }
    }
}
