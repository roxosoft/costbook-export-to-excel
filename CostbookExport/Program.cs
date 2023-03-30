using CostbookExport;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TNE.Domain.EntityFrameworkV2;
using TNE.Domain;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using TNE.Costbooks.EntityFrameworkV2;

var config = GetConfiguration();
var servicesProvider = Build(config);

var excelExporter = servicesProvider.GetRequiredService<ICostbookExcelExporter>();

await excelExporter.ExportCostbook(2545, "2023 Construction.xlsx");

Console.WriteLine("The costbook has been exported, press any key to exit the app");
Console.ReadLine();


static IConfigurationRoot GetConfiguration()
{
    IConfigurationBuilder configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false);

    return configuration.Build();
}

static IServiceProvider Build(IConfiguration config)
{
    return new ServiceCollection()
         .AddSingleton(config)
         .AddDbContext<UnitOfWork>(options =>
             options
                 .ConfigureWarnings(x => x.Ignore(RelationalEventId.AmbientTransactionWarning))
                 .UseSqlServer(config.GetConnectionString("DefaultConnection")),
             ServiceLifetime.Transient)
         .AddTransient<IUnitOfWorkFactory, UnitOfWorkFactory>()
         .AddTransient<ICostbookExcelExporter, CostbookExcelExporter>()
         .BuildServiceProvider();
}