using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace Inva.LawMax.Entities
{
    public class Case : FullAuditedAggregateRoot<Guid>
    {
        public string Number { get; set; }
        public string Year { get; set; }
        public string LitigationDegree { get; set; }
        public string FinalVerdict { get; set; }
        public Guid LawyerId { get; set; }
        public Lawyer Lawyer { get; set; }
        public ICollection<Hearing> Hearings { get; set; }

        public Case()
            : base(new Guid())
        {
        }
    }
}
