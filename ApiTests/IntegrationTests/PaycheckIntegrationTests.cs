using Api.Dtos.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Api.Dtos.Paycheck;
using Api.Models;

namespace ApiTests.IntegrationTests
{
    public class PaycheckIntegrationTests : IntegrationTest
    {
        // TODO expand integration tests

        [Fact]
        public async Task WhenAskedForAPayCheck_ShouldReturnCorrectPaycheck()
        {
            var response = await HttpClient.GetAsync("/api/v1/paycheck/1");
            var paycheck = new GetPaycheckDto(
                1,
                "LeBron",
                "James",
                2900.8073076923076923076923077m,
                2439.2688461538461538461538462m,
                new List<GetDeductionDto>()
                {
                    new GetDeductionDto("Base Benefit Costs", 461.53846153846153846153846154m)
                },
                461.53846153846153846153846154m
                );
            await response.ShouldReturn(HttpStatusCode.OK, paycheck);
        }
    }
}
