using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using Mongo.Service.AboutListServices;
using Mongo.Service.AboutSection1Services;
using Mongo.Service.AboutSection2Services;
using Mongo.Service.FeatureServices;
using Mongo.Service.OrderServices;
using Mongo.Service.ProductServices;
using Mongo.Service.SocialMediaServices;
using Mongo.Service.SSSServices;
using Mongo.Service.StatisticServices;
using Mongo.Service.StoryVideoServices;
using Mongo.Service.SubscribeServices;
using Mongo.Service.TestimonialServices;
using Mongo.Settings;
using Mongo.Service.CategoryServices;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAboutListService, AboutListService>();
builder.Services.AddScoped<IAboutSection1Service, AboutSection1Service>();
builder.Services.AddScoped<IAboutSection2Service, AboutSection2Service>();
builder.Services.AddScoped<IFeatureService, FeatureService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ISocialMediaService, SocialMediaService>();
builder.Services.AddScoped<ISSSService, SSSService>();
builder.Services.AddScoped<IStoryVideoService, StoryVideoService>();
builder.Services.AddScoped<ISubscribeService, SubscribeService>();
builder.Services.AddScoped<ITestimonialService, TestimonialService>();
builder.Services.AddScoped<IStatisticService, StatisticService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});


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

var trCulture = new CultureInfo("tr-TR");
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("tr-TR"),
    SupportedCultures = new[] { trCulture },
    SupportedUICultures = new[] { trCulture }
});

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();