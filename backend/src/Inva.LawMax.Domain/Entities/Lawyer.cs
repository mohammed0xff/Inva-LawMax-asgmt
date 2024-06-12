using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace Inva.LawMax.Entities
{
    public class Lawyer : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public ICollection<Case> Cases { get; set; }

        public Lawyer()
            : base(new Guid())
        {
        }
    }
}
