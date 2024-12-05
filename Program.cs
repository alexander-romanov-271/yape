using newyape.DataLayer.Contexts;
using newyape.BusinessLogicLayer.ConfigurationProfiles;
using newyape.BusinessLogicLayer.Services.ReadAllServices;
using newyape.BusinessLogicLayer.Services.ReadServices;
using newyape.BusinessLogicLayer.Services.CreateServices;
using newyape.BusinessLogicLayer.Services.UpdateServices;
using newyape.DataLayer.Models;
using newyape.BusinessLogicLayer.DataTransferObjects;
using Microsoft.EntityFrameworkCore;
using newyape.DataLayer.Repositories;
using Serilog;


namespace yape;

public class Program
{
    public static void Main(string [] args)
    {  
        var log = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File(
                "logs.txt", 
                rollOnFileSizeLimit: true, 
                fileSizeLimitBytes: 2048,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}"
                )
            .CreateLogger();

        var builder = WebApplication.CreateBuilder();

        builder.Services.AddControllers();
        builder.Services.AddSingleton<Serilog.ILogger>(log);

        builder.Services.AddDbContext<ApplicationContext>(opt => {
            opt.UseNpgsql("Host=localhost;Port=5432;Database=usersdb;Username=postgres;Password=postgres")
               .EnableSensitiveDataLogging();
        });

        builder.Services.AddAutoMapper(cfg => {
            cfg.AddProfile<FieldProfile>();
            cfg.AddProfile<RuleProfile>();
            cfg.AddProfile<ProductProfile>();
            cfg.AddProfile<GuidelineProfile>();
        });

        builder.Services
            .AddKeyedScoped(typeof(IReadAllService<FieldDTO>), "readallFields", typeof(ReadAllFieldsService))
            .AddKeyedScoped(typeof(IReadService<FieldDTO>), "readField", typeof(ReadFieldService))
            .AddKeyedScoped(typeof(ICreateService<FieldDTO>), "createField", typeof(CreateField))
            .AddKeyedScoped(typeof(IUpdateService<FieldDTO>), "updateField", typeof(UpdateField));

        builder.Services
            .AddKeyedScoped(typeof(IReadAllService<ProductDTO>), "readallProducts", typeof(ReadAllProductsService))
            .AddKeyedScoped(typeof(IReadService<ProductDTO>), "readProduct", typeof(ProductReadService))
            .AddKeyedScoped(typeof(ICreateService<ProductDTO>), "createProduct", typeof(CreateProduct))
            .AddKeyedScoped(typeof(IUpdateService<ProductDTO>), "updateProduct", typeof(UpdateProduct));

        builder.Services
            .AddKeyedScoped(typeof(IReadAllService<GuidelineDTO>), "readallGuidelines", typeof(ReadAllGuidelinesService))
            .AddKeyedScoped(typeof(IReadService<GuidelineDTO>), "readGuideline", typeof(GuidelineReadService))
            .AddKeyedScoped(typeof(ICreateService<GuidelineDTO>), "createGuideline", typeof(CreateGuideline))
            .AddKeyedScoped(typeof(IUpdateService<GuidelineDTO>), "updateGuideline", typeof(UpdateGuideline));

        builder.Services
            .AddKeyedScoped(typeof(IReadAllService<RuleDTO>), "readallRules", typeof(ReadAllRulesService))
            .AddKeyedScoped(typeof(IReadService<RuleDTO>), "readRule", typeof(RuleReadService))
            .AddKeyedScoped(typeof(ICreateService<RuleDTO>), "createRule", typeof(CreateRule))
            .AddKeyedScoped(typeof(IUpdateService<RuleDTO>), "updateRule", typeof(UpdateRule));
        
        builder.Services
            .AddKeyedScoped(typeof(IRepository<RuleEntity>), "ruleRepository", typeof(RuleRepository))
            .AddKeyedScoped(typeof(IRepository<FieldEntity>), "fieldRepository", typeof(FieldRepository))
            .AddKeyedScoped(typeof(IRepository<GuidelineEntity>), "guidelineRepository", typeof(GuidelineRepository))
            .AddKeyedScoped(typeof(IRepository<ProductEntity>), "productRepository", typeof(ProductRepository));

        
        builder.Services.AddSwaggerGen();              

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.MapGet("/", () => "Hello World!");

        app.MapControllers();

        app.Run();
    }
}
