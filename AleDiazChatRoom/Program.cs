using AleDiazChatRoom.Data;
using AleDiazChatRoom.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Threading;
using System.Globalization;
using AleDiazChatRoom.Constant;
using Microsoft.EntityFrameworkCore;
using AleDiazChatRoom.ChatObjects;
using AleDiazChatRoom.DAL;
using Microsoft.Extensions.Configuration;
using System;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<ChatHubService>();
builder.Services.AddSingleton<IBotService,ChatHubService>();
builder.Services.AddDbContextFactory<ApplicationDbContext>((DbContextOptionsBuilder options) => options.UseSqlServer("Source=(localdb)\\MSSQLLocalDB;Database=ChatRoomProject;Initial Catalog=AuthorDb;Trusted_Connection=True;MultipleActiveResultSets=true"));
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

app.UseEndpoints(endpoints =>
{
    endpoints.MapBlazorHub();
    endpoints.MapFallbackToPage("/_Host");
    endpoints.MapHub<ChatHubService>(ChatRoomConstants.HubUrl);
});


app.Run();
