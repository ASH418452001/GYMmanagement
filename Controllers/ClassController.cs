using AutoMapper;
using GYMmanagement.DtOs.ClassDtO;
using GYMmanagement.Entities;
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
       

        public ClassController(IMapper mapper,IUnitOfWork unitOfWork)
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
            return Ok();

        }

        [HttpGet]
        public  Task<ActionResult<List<GetClassDtO>>>GetAllClasses()
        {
              
            return  _uow.ClassRepostory.GetClasses();
        }



        [HttpGet("ByclassName")]
        public async Task<ActionResult<GetClassDtO>> GetUser(string className)
        {
            return await _uow.ClassRepostory.GetClassAsync(className);
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

           
            _mapper.Map(updateClassDtO, classToUpdate );
            _uow.ClassRepostory.Update(classToUpdate);

            if (await _uow.Complete())  return NoContent(); 
            return BadRequest("Failed to update class");
            
            
        }



    }
}
