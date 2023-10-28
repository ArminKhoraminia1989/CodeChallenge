namespace CodeChallenge.Core.Entities.BasicInfo
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
