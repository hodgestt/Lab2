using Lab2.Pages.Login;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSession(); //enabling session state
//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options
//    { OptionsBuilderConfigurationExtensions.LoginPath = "/DBLogin"; });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();


app.UseRouting();

app.UseAuthorization();
//app.UseAuthentication();

app.UseSession(); //middle-ware pipeline change - enabling session state

app.MapRazorPages();

app.Run();

