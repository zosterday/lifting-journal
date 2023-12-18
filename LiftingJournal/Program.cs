using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LiftingJournal.Data;
using Auth0.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<LiftingJournalContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LiftingJournalContext") ?? throw new InvalidOperationException("Connection string 'LiftingJournalContext' not found.")));

//Add services to the container.
builder.Services
    .AddAuth0WebAppAuthentication(options => {
        options.Domain = builder.Configuration["Auth0:Domain"] ;
        options.ClientId = builder.Configuration["Auth0:ClientId"];
        options.Scope = "openid profile email";
    });

builder.Services.AddRazorPages(options =>
{
    //TODO: Add all pages that will be hidden until logged in
    //options.Conventions.AuthorizePage("/AddLiftEntry");
    options.Conventions.AuthorizePage("/Account/Logout");
    options.Conventions.AuthorizePage("/Account/Profile");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
