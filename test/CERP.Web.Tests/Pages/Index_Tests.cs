using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace CERP.Pages
{
    public class Index_Tests : CERPWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
