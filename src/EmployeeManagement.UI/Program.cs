using EmployeeManagement.UI.Extensions;
using EmployeeManagement.UI.Services.Employees;
using System.Text.Json;
using EmployeeManagement.UI.Services.Departments;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.RegisterUIServices(builder.Configuration);
builder.Services.RegisterDepartmentService(builder.Configuration);

//builder.Services.AddScoped<EmployeeApiService>();
builder.Services.AddSingleton(new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseDeveloperExceptionPage();
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
