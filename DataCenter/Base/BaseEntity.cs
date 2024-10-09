using System.ComponentModel.DataAnnotations;

namespace DataCenter.Base
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public bool IsDeleted { get; set; } = false;

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public DateTime? DeleteTime { get; set; }

        public void SetIsDeleted()
        {
            IsDeleted = true;
            DeleteTime = DateTime.Now;
        }
    }
}
