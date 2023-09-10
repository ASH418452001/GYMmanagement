using GYMmanagement.Entities;

namespace GYMmanagement.DtOs.ClassDtO
{
    public class UpdateClassDtO
    {
        public int Id { get; set; }
       
        public string Description { get; set; }
        public int Duration { get; set; }
        public int Capacity { get; set; }

        public int TrainerId { get; set; }
        

      

    }
}
