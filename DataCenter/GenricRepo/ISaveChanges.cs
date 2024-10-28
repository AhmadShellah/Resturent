namespace DataCenter.GenricRepo
{
    public interface ISaveChanges
    {
        void SaveChanges();

        Task SaveChangesAsync(bool autoSave = false);
    }
}