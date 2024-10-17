var builder = WebApplication.CreateBuilder(args);

// ������ ������ �� ����������.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// ������ ������� ��������� �����, ���� �������.
app.UseStaticFiles();

// ������ UseRouting �� UseEndpoints
app.UseRouting();

// ������������ �����������, ���� �
app.UseAuthorization();

// ������ �������� �� ������� DownloadFile ��� ����������� �������
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
