using ChatApp.DataAccessLayer.Data;
using ChatApp.DataAccessLayer.Interface;
using ChatApp.DataAccessLayer.Repositories;
using ChatApp.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();
builder.Services.AddTransient<IUser,UserRepository>();
builder.Services.AddSingleton(app => new AppDbContext(
        builder.Configuration.GetConnectionString("MongoDB")!,
        builder.Configuration.GetConnectionString("Database")!
    ));
builder.Services.AddTransient<ISMSSender,SMSSenderService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");
app.MapHub<SendMessage>("/chatHub");
app.Run();
