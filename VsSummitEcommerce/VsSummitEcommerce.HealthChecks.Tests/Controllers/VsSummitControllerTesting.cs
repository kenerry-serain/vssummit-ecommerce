using VsSummitEcommerce.HealthChecks.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace VsSummitEcommerce.HealthChecks.Tests.Controllers
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
