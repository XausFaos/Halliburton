using WebApplication6;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions { WebRootPath = "static" });
var app = builder.Build();

app.UseStaticFiles();
app.UseDefaultFiles();

app.Run(async (context) =>
{
    var response = context.Response;
    var requets = context.Request;

    var path = requets.Path;

    switch (path)
    {
        case "/transfer":
            var data = await requets.ReadFromJsonAsync<ResultResponce>();

            if (data != null)
            {
                SortMethod methodSort = (SortMethod)data.sort;
                string words = data.word;
                char separator = (char)data.separator;

                MyList list = new MyList(words, methodSort, separator);
                list.Sort();

                await response.WriteAsJsonAsync(new { result = list.ToString(separator) });
            }

            break;

        default:
            context.Response.ContentType = "text/html; charset=utf-8";
            await response.SendFileAsync("static/index.html");
            break;
    }
});

app.Run();

public record ResultResponce(int sort, string word, char separator);
