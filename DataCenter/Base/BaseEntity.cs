using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataCenter.Base
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public bool IsDeleted { get; set; } = false;

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public DateTime? DeleteTime { get; set; }

        [NotMapped]
        public bool SaveChange { get; set; } = false;

        public void SetIsDeleted()
        {
            IsDeleted = true;
            DeleteTime = DateTime.Now;
        }
    }
}
