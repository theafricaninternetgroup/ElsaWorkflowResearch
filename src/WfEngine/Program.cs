using Elsa;
using Elsa.Options;
using Elsa.RD.ActivityLibrary.Activities;
using Csla.Configuration;
using Elsa.RD.WfEngine.Workflows;
using Elsa.RD.Dal;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddElsa(elsa =>
{
    elsa.AddConsoleActivities();
    elsa.AddActivity<AddPersonalDetails>();
    elsa.AddActivity<AddContactDetails>();
    elsa.AddWorkflow<CustomerOnBoardingWorkflow>();
});
builder.Services.AddNotificationHandlersFrom<CustomerOnBoardingWorkflow>();

builder.Services.AddElsaApiEndpoints();
builder.Services.AddRazorPages();
builder.Services.AddCsla();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app
    .UseStaticFiles()
    .UseRouting()
    .UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
        endpoints.MapFallbackToPage("/_Host");
    });

app.Run();
