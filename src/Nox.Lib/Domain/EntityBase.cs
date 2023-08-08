namespace Nox.Domain
{
    public partial class EntityBase : IEntity
    {
        /// <summary>
        /// The state of the entity as at this date.
        /// </summary>
        public DateTime AsAt { get; set; }
    }
}
