using DevBlog.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

List<BlogDto> blogs = [
    new (
        1,
        "My First Blog Post",
        "This is the content of my first blog post.",
        "Technology",
        ["Tech", "Programming"]
    ),
    new (
        2,
        "My Second Blog Post",
        "This is the content of my second blog post.",
        "Cooking",
        ["Thai", "Noodles"]
    ),
    new (
        3,
        "My Third Blog Post",
        "This is the content of my third blog post.",
        "Lifestyle",
        ["Fitness", "Health"]
    )  
];

app.MapGet("/blogs", () => blogs);

app.Run();
