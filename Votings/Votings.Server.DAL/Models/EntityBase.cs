namespace Votings.Server.DAL.Models
{
    public abstract class EntityBase : EntityBase<int>
    {
        
    }

    public abstract class EntityBase<T>
    {
        public T Id { get; set; }
    }
}
