using Microsoft.AspNetCore.Mvc;
using VsSummitEcommerce.Principal.Controllers;
using Xunit;

namespace VsSummitEcommerce.Principal.Tests.Controllers
{
    public class VsSummitControllerTesting
    {
        [Fact]
        public void ShouldReturnOk()
        {
            var getMethod =(OkObjectResult)new VsSummitController()
                .Get();

            Assert.Equal(getMethod.StatusCode, getMethod.StatusCode);
        }
    }
}
