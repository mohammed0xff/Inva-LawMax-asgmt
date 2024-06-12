using Inva.LawMax.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace Inva.LawMax
{
    public class LawMaxDataSeeder : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public LawMaxDataSeeder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWorkManager = scope.ServiceProvider.GetRequiredService<IUnitOfWorkManager>();
                using (var uow = unitOfWorkManager.Begin(requiresNew: true))
                {
                    var lawyerRepository = scope.ServiceProvider.GetRequiredService<IRepository<Lawyer, Guid>>();
                    var caseRepository = scope.ServiceProvider.GetRequiredService<IRepository<Case, Guid>>();
                    var hearingRepository = scope.ServiceProvider.GetRequiredService<IRepository<Hearing, Guid>>();


                    if (await caseRepository.GetCountAsync() == 0)
                    {
                        var lawyers = new List<Lawyer>()
                        {
                            new Lawyer() { Name = "John Doe", Position = "Senior Lawyer", Mobile = "123-456-7890", Address = "123 Main St" },
                            new Lawyer() { Name = "Jane Smith", Position = "Associate Lawyer", Mobile = "987-654-3210", Address = "456 Elm St" },
                            new Lawyer() { Name = "joe Smith", Position = "Junior Lawyer", Mobile = "368-258-7410", Address = "632 Wl St" }
                        };

                        await lawyerRepository.InsertManyAsync(lawyers);

                        var cases = new List<Case>
                        {
                            new Case() { Number = "2024-001", Year = "2024", LitigationDegree = "High", FinalVerdict = "Guilty", LawyerId = lawyers[0].Id },
                            new Case() { Number = "2024-002", Year = "2024", LitigationDegree = "Low", FinalVerdict = "Not Guilty", LawyerId = lawyers[1].Id },
                            new Case() { Number = "2024-003", Year = "2024", LitigationDegree = "Mid", FinalVerdict = "Guilty", LawyerId = lawyers[2].Id }
                        };

                        await caseRepository.InsertManyAsync(cases);

                        var hearings = new List<Hearing>()
                        {
                            new Hearing() { Date = DateTime.Now.AddDays(-10), Decition = "Adjourned", CaseId = cases[0].Id },
                            new Hearing() { Date = DateTime.Now.AddDays(-5), Decition = "Dismissed", CaseId = cases[1].Id },
                            new Hearing() { Date = DateTime.Now.AddDays(-2), Decition = "Dismissed", CaseId = cases[2].Id }
                        };

                        await hearingRepository.InsertManyAsync(hearings);
                    }

                    await uow.CompleteAsync();
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
