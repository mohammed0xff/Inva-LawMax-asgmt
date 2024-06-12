using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Inva.LawMax.Pages;

public class Index_Tests : LawMaxWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
