using AutoMapper;
using AutoMapper.Execution;
using GYMmanagement.DtOs.ClassDtO;
using GYMmanagement.DtOs.PaymentDtO;
using GYMmanagement.DtOs.UsersDtO.UpdateUserDtO;
using GYMmanagement.Entities;
using GYMmanagement.Extension;
using GYMmanagement.Filters;
using GYMmanagement.Helpers;
using GYMmanagement.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GYMmanagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public PaymentController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _uow = unitOfWork;
            _mapper = mapper;
        }



        //[Authorize(Policy = "RequireEmplyeeRole")]
        [HttpPost]
        public async Task<ActionResult> CreatePaymentAsync(CreateUpdatePaymentDtO createPaymentDtO)
        {
            var member = await _uow.UserRepostory.GetUserByIdAsync(createPaymentDtO.MemberId);
            if (member == null) return BadRequest();
            var payment = _mapper.Map<Payment>(createPaymentDtO);

            _uow.PaymentRepostory.CreatePayment(payment);
            if (await _uow.Complete())return Ok();
            return BadRequest("Failed to Create class");

        }



        //[Authorize(Policy = "RequireEmplyeeRole")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetPaymentDtO>>> GetAllPayment([FromQuery] BasicMemberFilterParams basicMemberFilterParams)
        {

            var payments = await _uow.PaymentRepostory.GetPayment(basicMemberFilterParams);
            Response.AddPaginationHeader(new PaginationHeader(payments.CurrentPage, payments.PageSize,
           payments.TotalCount, payments.TotalPages));

            return Ok(payments);
        }

        //[Authorize(Policy = "RequireEmplyeeRole")]
        [HttpPut]
        public async Task<ActionResult> UpdatePayment(CreateUpdatePaymentDtO updatePaymentDtO, Guid Id)
        {
            
           await _uow.PaymentRepostory.Update(updatePaymentDtO,Id);

            if (await _uow.Complete()) 
                return Ok();
            return BadRequest("Failed to update class");


        }


        //[Authorize(Policy = "RequireEmplyeeRole")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePayment(Guid id)
        {
            

            var payment = await _uow.PaymentRepostory.GetPaymentsById(id);

            _uow.PaymentRepostory.DeletePayment(payment); 

           

            if (await _uow.Complete()) return Ok("Been Deleted");

            return BadRequest("Problem deleting this Payment");
        }

    }
}
