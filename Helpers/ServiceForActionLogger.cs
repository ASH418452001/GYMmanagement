using AutoMapper;
using GYMmanagement.Data;
using GYMmanagement.Entities;
using GYMmanagement.Extension;
using GYMmanagement.Interfaces;
using Newtonsoft.Json;
using System.Security.Claims;

namespace GYMmanagement.Helpers
{
    public class ServiceForActionLogger<Entity> where Entity : BaseEntity

    {
        public readonly IHttpContextAccessor _httpContextAccessor;
        public readonly IMapper _mapper;
        public readonly DataContext _context;
        public Guid UserId { get; set; }

        public ServiceForActionLogger(DataContext context, IHttpContextAccessor httpContextAccessor,IMapper mapper)
        {
            _context = context;
            //UserId = userId;
           _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        public void AddActionLogger(string action, Entity entity)
        {
            var serializerSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            _context.actionLoggers.Add(new ActionLogger
            {
                Id = Guid.NewGuid(),
                ActionName = action,
                TableName = typeof(Entity).Name,
                CreatedAt = DateTime.Now,
                CreatedBy = GetUserId(),
                TableReferenceId = entity.Id,
                JsonData = JsonConvert.SerializeObject(entity, serializerSettings),
            });

        }


        public  Guid GetUserId( )
        {
            return Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }
    }
}
