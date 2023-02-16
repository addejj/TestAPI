using Microsoft.Azure.Cosmos;

using CosmosClient client = new(
    accountEndpoint: Environment.GetEnvironmentVariable("https://testapicosmosdb.documents.azure.com:443/")!,
    authKeyOrResourceToken: Environment.GetEnvironmentVariable("vJ5ozcVGENm5aGAabiaqU2XvnOkb49RQdR8znZBDvHCuEFnW5ypeYh7bcHi2Sn7VoL4zGq25jqHgACDb7kfpOg==")!
);

Database database = client.GetDatabase(id: "cosmicworks");

Console.WriteLine($"New database:\t{database.Id}");

Container container = await database.CreateContainerIfNotExistsAsync(
    id: "products",
    partitionKeyPath: "/categoryId",
    throughput: 400
);

Console.WriteLine($"New container:\t{container.Id}");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
