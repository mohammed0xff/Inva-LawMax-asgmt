using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Inva.LawMax.Entities
{
    public class Hearing : FullAuditedAggregateRoot<Guid>
    {
        public DateTime Date { get; set; }
        public string Decition { get; set; }
        public Guid CaseId { get; set; }
        public Case Case { get; set; }

        public Hearing()
            : base(new Guid())
        {

        }
    }
}
