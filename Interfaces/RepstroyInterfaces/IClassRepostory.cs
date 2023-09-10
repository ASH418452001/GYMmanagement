using GYMmanagement.DtOs.ClassDtO;
using GYMmanagement.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GYMmanagement.Interfaces.RepstroyInterfaces
{
    public interface IClassRepostory
    {
        Task<Class> GetClassByIdAsync(int id);

        Task<bool> ClassExist(string name);
        Task<GetClassDtO> GetClassAsync(string Name);
        Task<ActionResult<List<GetClassDtO>>> GetClasses();
        void CreateClass(Class @class);
        void Update(Class @class);


    }
}
