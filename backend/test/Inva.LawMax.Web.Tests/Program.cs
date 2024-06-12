using Microsoft.AspNetCore.Builder;
using Inva.LawMax;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<LawMaxWebTestModule>();

public partial class Program
{
}
