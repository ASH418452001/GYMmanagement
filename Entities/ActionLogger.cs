namespace GYMmanagement.Entities
{
    public class ActionLogger
    {
        public Guid Id { get; set; }
        public string ActionName { get; set; }
        public string TableName { get; set; }
        public Guid CreatedBy { get; set; } 
        public Guid TableReferenceId { get; set; }
        public string JsonData { get; set; }
        public DateTime CreatedAt { get; set; }



    }
}
