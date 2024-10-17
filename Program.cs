var builder = WebApplication.CreateBuilder(args);

// Додаємо служби до контейнера.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Додаємо обробку статичних файлів, якщо потрібно.
app.UseStaticFiles();

// Виклик UseRouting до UseEndpoints
app.UseRouting();

// Використання авторизації, якщо є
app.UseAuthorization();

// Додаємо редирект на сторінку DownloadFile при завантаженні додатку
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/File/DownloadFile");
        return;
    }
    await next();
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=File}/{action=DownloadFile}/{id?}");
});

app.Run();
