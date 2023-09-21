using AutoMapper;
using AutoMapper.QueryableExtensions;
using GYMmanagement.Data;
using GYMmanagement.DtOs.ClassDtO;
using GYMmanagement.Entities;
using GYMmanagement.Extension;
using GYMmanagement.Filters;
using GYMmanagement.Helpers;
using GYMmanagement.Interfaces.RepstroyInterfaces;
using Microsoft.EntityFrameworkCore;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace GYMmanagement.Repostories
{
    public class ClassRepostory :ServiceForActionLogger<Class>, IClassRepostory
    {


        public ClassRepostory(DataContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        :base(context,httpContextAccessor,mapper)
        {
        }
        public async Task<bool> ClassExist(string name)
        {
            return await _context.Classe.AnyAsync(x => x.Name.ToLower() == name.ToLower());
        }

        public  void CreateClass(Class @class)
        {
            @class.SetCreateInfo(GetUserId());
            _context.Classe.Add(@class);
            AddActionLogger("CreateClass", @class);
            //_context.actionLoggers.Add(new ActionLogger()
            //{
            //    ActionName = "CreateClass",
            //    CreateDataTime = DateTime.UtcNow,
            //    ReferenceId = @class.Id,
            //    JsonData = JsonConvert.SerializeObject(@class),
            //    TableName = "Class",
            //    UserId = UserId
            //});
            //_context.SaveChanges();

        }

       


        public async Task<PagedList<GetClassDtO>> GetClassAsync(ClassFilterParams classFilterParams)
        {
         var a =  _context.Classe.AsQueryable().Include(a => a.Trainer)
                .Where(a => classFilterParams.TrainerId == null || a.TrainerId == classFilterParams.TrainerId)
                .Where(a => classFilterParams.ClassName == null || a.Name == classFilterParams.ClassName)
                .Where(x=> !x.IsDeleted)
                .AsNoTracking();

            return await PagedList<GetClassDtO>.CreateAsync(a
           .ProjectTo<GetClassDtO>(_mapper.ConfigurationProvider),
               classFilterParams.PageNumber, classFilterParams.PageSize);

        }

        public void Update(Class @class)
        {
            @class.SetUpdateInfo(GetUserId());
            _context.Entry(@class).State = EntityState.Modified  ;
            AddActionLogger("UpdateClass", @class);
        }



        public async Task<Class> GetClassByIdAsync(Guid id)
        {
            return await _context.Classe.FindAsync(id);
        }


        public void DeleteClass(Class @class)
        {

            @class.SetDeleteInfo(GetUserId());
            @class.IsDeleted = true;
            _context.Classe.Remove(@class);
            AddActionLogger("DeleteClass", @class);
        }

    }


         

}
