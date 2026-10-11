using NebulaCloud.Data;
using NebulaCloud.Components;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddDbContext<NebulaCloudDbContext>();
builder.Services.AddMudServices();
builder.Services.AddRazorComponents()
.AddInteractiveServerComponents();

var app = builder.Build();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapControllers();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();