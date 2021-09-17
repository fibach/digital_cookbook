using CosmosDbAdapter;
using rest.Server;
using rest.Shared.Ports;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var config = new AppConfiguration();
builder.Services.AddSingleton(config);

builder.Configuration.Bind(config);
builder.Services.AddCosmosDbRepository(config.CosmosDbOptions ?? throw new ArgumentException($"no {nameof(config.CosmosDbOptions)} configured"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

await SetupDatabaseAsync(app);

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();

async Task SetupDatabaseAsync(WebApplication app)
{
    var databaseInstaller = app.Services.GetService<IDatabaseInstaller>();
    if (databaseInstaller == null)
        return;
    await databaseInstaller.InstallDatabaseAsync();
    await databaseInstaller.SetupDatabaseTablseAsync();
}