using Csla.Configuration;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Elsa.RD.Dal;
using Elsa.RD.ElsaDrivenUI.ViewModels;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpContextAccessor();


builder.Services.AddCsla(o => o
  .AddAspNetCore()
  .AddServerSideBlazor());

builder.Services.AddTransient(typeof(IPersonEditDal), typeof(PersonEditDal));
builder.Services.AddTransient(typeof(ICompanyEditDal), typeof(CompanyEditDal));
builder.Services.AddTransient(typeof(WizardViewModel<>),typeof(WizardViewModel<>));

var app = builder.Build();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();