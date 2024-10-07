namespace DataAccess.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public bool IsDeleted { get; protected set; } = false;

        public DateTime? DeleteTime { get; protected set; }

        public void SetIsDeleted()
        {
            IsDeleted = true;
            DeleteTime = DateTime.Now;
        }
    }
}
