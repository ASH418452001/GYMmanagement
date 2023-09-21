using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GYMmanagement.Entities
{
    public class BaseEntity
    {
        [Key] public Guid Id { get; set; } = Guid.NewGuid();
        public bool IsDeleted { get; set; } = false; 
        public DateTime? CreatedAt { get; set; }
        public Guid? CreatedBy { get; set; }
        public User? CreatedByUser { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        [ForeignKey("LastUpdatedByUser")] public Guid? LastUpdatedBy { get; set; }
        public User? LastUpdatedByUser { get; set; }
        public DateTime? LastDeletedAt { get; set; }
        [ForeignKey("LastDeletedByUser")] public Guid? LastDeletedBy { get; set; }
        public User? LastDeletedByUser { get; set; }
        public int? VersionNumber { get; set; } = 1;
        [Timestamp] public byte[] RowVersion { get; set; }

        public void SetCreateInfo(Guid userid)
        {
            CreatedBy = userid; CreatedAt = DateTime.Now;
            IsDeleted = false;
        }
        public void SetUpdateInfo(Guid userid)
        {
            LastUpdatedBy = userid; LastUpdatedAt = DateTime.Now;
            VersionNumber++;
        }
        public void SetDeleteInfo(Guid userid)
        {
            LastDeletedBy = userid; LastDeletedAt = DateTime.Now;
            IsDeleted = true; VersionNumber++;
        }


    }
}
