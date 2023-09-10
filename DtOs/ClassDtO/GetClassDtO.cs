using GYMmanagement.DtOs.UsersDtO.UpdateUserDtO;
using GYMmanagement.Entities;

namespace GYMmanagement.DtOs.ClassDtO
{
    public class GetClassDtO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public int Capacity { get; set; }
        public  GetTrainerDtO Trainer { get; set; }
        //public string TrainerUserName { get; set; }
        

        
        
       

       

    }
}
