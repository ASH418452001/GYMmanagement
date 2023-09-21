using GYMmanagement.DtOs.ClassDtO;
using GYMmanagement.Entities;
using GYMmanagement.Filters;
using GYMmanagement.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace GYMmanagement.Interfaces.RepstroyInterfaces
{
    public interface IClassRepostory
    {
        Task<Class> GetClassByIdAsync(Guid id);
        void DeleteClass(Class @class);
        Task<bool> ClassExist(string name);
        Task<PagedList<GetClassDtO>> GetClassAsync(ClassFilterParams classFilterParams);
        void CreateClass(Class @class);
        void Update(Class @class);


    }
}
