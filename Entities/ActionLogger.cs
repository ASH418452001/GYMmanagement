namespace GYMmanagement.Entities
{
    public class ActionLogger
    {
        public int Id { get; set; }
        public string ActionName { get; set; }
        public string TableName { get; set; }
        public int UserId { get; set; }
        public int ReferenceId { get; set; }
        public string JsonData { get; set; }
        public  DateTime CreateDataTime { get; set; }


    }
}
