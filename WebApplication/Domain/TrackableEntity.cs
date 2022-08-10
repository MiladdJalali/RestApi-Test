namespace WebApplication.Domain
{
    public class TrackableEntity
    {
        protected TrackableEntity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        public DateTime Created { get; private set; }

        public DateTime? Updated { get; private set; }

        protected void TrackCreate()
        {
            Created = DateTime.UtcNow;
        }

        protected void TrackUpdate()
        {
            Updated = DateTime.UtcNow;
        }

        protected void CheckRule(IBusinessRule rule)
        {
            if (!rule.IsBroken()) return;

            throw new DomainException(rule.Message);
        }
    }
}
