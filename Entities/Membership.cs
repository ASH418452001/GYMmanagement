namespace GYMmanagement.Entities
{
    public class Membership
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public string Duration { get; set; }
        public string Benefits { get; set; }
        public ICollection<User> UsersMemberShipType { get; set; }
    }
}
