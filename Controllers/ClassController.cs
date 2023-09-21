using AutoMapper;
using GYMmanagement.DtOs.ClassDtO;
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
    public class ClassController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;


        public ClassController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _uow = unitOfWork;

        }

        //[Authorize(Policy = "RequireEmplyeeRole")]
        [HttpPost]
        public async Task<ActionResult> CreateClassAsync(CreateClassDtO createClassDtO)
        {
            if (await _uow.ClassRepostory.ClassExist(createClassDtO.Name))
                return BadRequest("this ClassName been taken");


            var @class = _mapper.Map<Class>(createClassDtO);

            _uow.ClassRepostory.CreateClass(@class);
            if (await _uow.Complete()) return NoContent();
            return BadRequest("Failed to Create class");

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetClassDtO>>> GetClassAsync([FromQuery] ClassFilterParams classFilterParams)
        {
            var classs = await _uow.ClassRepostory.GetClassAsync(classFilterParams);
            Response.AddPaginationHeader(new PaginationHeader(classs.CurrentPage, classs.PageSize,
           classs.TotalCount, classs.TotalPages));

            return Ok(classs);

        }



      

        //[Authorize(Policy = "RequireEmplyeeRole")]
        [HttpPut]
        public async Task<ActionResult> UpdateClass(UpdateClassDtO updateClassDtO)
        {

            var classToUpdate = await _uow.ClassRepostory.GetClassByIdAsync(updateClassDtO.Id);

            if (classToUpdate == null)
            {
                return NotFound();
            }


            _mapper.Map(updateClassDtO, classToUpdate);
            _uow.ClassRepostory.Update(classToUpdate);

            if (await _uow.Complete()) return NoContent();
            return BadRequest("Failed to update class");


        }
        //[Authorize(Policy = "RequireEmplyeeRole")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClass (Guid id)
        {


            var @class = await _uow.ClassRepostory.GetClassByIdAsync(id);

            _uow.ClassRepostory.DeleteClass(@class);



            if (await _uow.Complete()) return Ok("Been Deleted");

            return BadRequest("Problem deleting the Class");
        }


    }
}
