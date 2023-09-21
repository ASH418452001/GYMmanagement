using GYMmanagement.DtOs.UsersDtO.UpdateUserDtO;

namespace GYMmanagement.DtOs.ClassDtO
{
    public class GetClassDtO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public int Capacity { get; set; }
        public  GetTrainerDtO Trainer { get; set; }
        

        
        
       

       

    }
}
