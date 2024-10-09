
namespace DataAccess
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public bool IsDeleted { get; protected set; } = false;

        public DateTime? DeletedTime { get; protected set; }

        public void SetIsDeleted()
        {
            this.IsDeleted = true;
            this.DeletedTime = DateTime.Now;
        }

    }
}
