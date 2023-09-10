using GYMmanagement.Entities;

namespace GYMmanagement.DtOs.MemberShipDtO
{
    public class Create_UpdateMemberShipDtO
    {
        
        public string MemberShipType { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public string Duration { get; set; }
        public string Benefits { get; set; }
        
    }
}
