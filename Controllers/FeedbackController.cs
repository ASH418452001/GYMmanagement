using AutoMapper;
using GYMmanagement.DtOs.FeedBacksDtO;
using GYMmanagement.DtOs.PaymentDtO;
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
    public class FeedbackController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public FeedbackController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _uow = unitOfWork;
            _mapper = mapper;
        }



        //[Authorize(Policy = "RequireMemberRole")]
        [HttpPost]
        public async Task<ActionResult> CreateFeedbackAsync(Create_UpdateFeedBacksDtO create_UpdateFeed)
        {
            var member = await _uow.UserRepostory.GetUserByIdAsync(create_UpdateFeed.MemberId);
            if (member == null) return BadRequest();
            var feedback = _mapper.Map<Feedback>(create_UpdateFeed);

            _uow.FeedbackRepostory.CreateFeedback(feedback);
            return Ok();

        }



        //[Authorize(Policy = "RequireEmplyeeRole")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetFeedBacksDtO>>> GetFeedback([FromQuery] FilterParams filterParams)
        {

            var feedback = await _uow.FeedbackRepostory.GetFeedback(filterParams);
            Response.AddPaginationHeader(new PaginationHeader(feedback.CurrentPage, feedback.PageSize,
           feedback.TotalCount, feedback.TotalPages));

            return Ok(feedback);
        }



    }
}
