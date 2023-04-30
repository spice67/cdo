using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using ME.Core2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

[assembly: FunctionsStartup(typeof(ME.AppModrnzDemo.Startup))]

namespace ME.AppModrnzDemo
{
    public class AccountService
    {
        private readonly ITransactionRepository _transactionRepository;

        public AccountService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        [FunctionName("TransactionInfoService")]
        public async Task<IActionResult> TransactionInfoService(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "transactioninfo")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            int _span = Convert.ToInt16(req.Headers["span"]);
            //int _span = 100;

            string _account = req.Headers["accountNo"];
            //string _account = "LV39 TCLW URQQ ZVPF 1UFC C";

            var responseMessage = await _transactionRepository.GetTransactions(_span, _account);

            return new OkObjectResult(responseMessage);
        }
    }

    class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddDbContext<CustomerAccntCtx>(
            options => options.UseCosmos(accountEndpoint: Environment.GetEnvironmentVariable("Cosmosdb_ae"),
            accountKey: Environment.GetEnvironmentVariable("Cosmosdb_ak"),
            databaseName: Environment.GetEnvironmentVariable("Cosmosdb")));

            builder.Services.AddDbContext<CustomerCtx>(
            options => options.UseCosmos(accountEndpoint: Environment.GetEnvironmentVariable("Cosmosdb_ae"),
            accountKey: Environment.GetEnvironmentVariable("Cosmosdb_ak"),
            databaseName: Environment.GetEnvironmentVariable("Cosmosdb")));

            builder.Services.AddDbContext<TransactionCtx>(
            options => options.UseCosmos(accountEndpoint: Environment.GetEnvironmentVariable("Cosmosdb_ae"),
            accountKey: Environment.GetEnvironmentVariable("Cosmosdb_ak"),
            databaseName: Environment.GetEnvironmentVariable("Cosmosdb")));

            builder.Services.AddTransient<ICustomerAccntRepository, CustomerAccntRepository>();
            builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
            builder.Services.AddTransient<ITransactionRepository, TransactionRepository>();
        }
    }
}
