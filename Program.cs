var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSession(); //enabling session state

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseSession(); //middle-ware pipeline change - enabling session state


app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

