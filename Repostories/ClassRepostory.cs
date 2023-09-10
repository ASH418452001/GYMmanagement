using AutoMapper;
using AutoMapper.QueryableExtensions;
using GYMmanagement.Data;
using GYMmanagement.DtOs.ClassDtO;
using GYMmanagement.DtOs.UsersDtO.Create;
using GYMmanagement.Entities;
using GYMmanagement.Interfaces.RepstroyInterfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GYMmanagement.Repostories
{
    public class ClassRepostory : IClassRepostory
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        

        public ClassRepostory(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }
        public async Task<bool> ClassExist(string name)
        {
            return await _context.Classe.AnyAsync(x => x.Name.ToLower() == name.ToLower());
        }

        public  void CreateClass(Class @class)
        {
            _context.Classe.Add(@class);
            _context.SaveChanges();

        }

        public async Task<GetClassDtO> GetClassAsync(string Name)
        {
            var classDto = await _context.Classe
                .Where(x => x.Name == Name)
                .ProjectTo<GetClassDtO>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();  

            return classDto;
        }


        public async Task<ActionResult<List<GetClassDtO>>> GetClasses()
        {
          var a =  await _context.Classe.Include(a=>a.Trainer).ToListAsync();
            return  _mapper.Map<List<GetClassDtO>>(a);

        }

        public void Update(Class @class)
        {
            _context.Entry(@class)  ;
            
        }



        public async Task<Class> GetClassByIdAsync(int id)
        {
            return await _context.Classe.FindAsync(id);
        }

    }
}
