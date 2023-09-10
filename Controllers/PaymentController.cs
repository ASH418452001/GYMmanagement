using AutoMapper;
using GYMmanagement.DtOs.ClassDtO;
using GYMmanagement.DtOs.PaymentDtO;
using GYMmanagement.DtOs.UsersDtO.UpdateUserDtO;
using GYMmanagement.Entities;
using GYMmanagement.Extension;
using GYMmanagement.Filters;
using GYMmanagement.Helpers;
using GYMmanagement.Interfaces;
using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult> CreatePaymentAsync(CreatePaymentDtO createPaymentDtO)
        {
            var member = await _uow.UserRepostory.GetUserByIdAsync(createPaymentDtO.MemberId);
            if (member == null) return BadRequest();
            var payment = _mapper.Map<Payment>(createPaymentDtO);

            _uow.PaymentRepostory.CreatePayment(payment);
            return Ok();

        }



        //[Authorize(Policy = "RequireEmplyeeRole")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetPaymentDtO>>> GetAllPayment([FromQuery] FilterParams filterParams)
        {

            var payments = await _uow.PaymentRepostory.GetPayment(filterParams);
            Response.AddPaginationHeader(new PaginationHeader(payments.CurrentPage, payments.PageSize,
           payments.TotalCount, payments.TotalPages));

            return Ok(payments);
        }



    

    }
}
