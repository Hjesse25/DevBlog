using DevBlog.Api.Dtos;

const string GetBlogEndpointName = "GetBlog";

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

app.MapGet("/blogs/{id}", (int id) => blogs.Find(blog => blog.Id == id))
    .WithName(GetBlogEndpointName);

app.MapPost("/blogs", (CreateBlogDto newBlog) =>
{
   BlogDto blog = new (
        blogs.Count + 1,
        newBlog.Title,
        newBlog.Content,
        newBlog.Category,
        newBlog.Tags
   );

   blogs.Add(blog);

   return Results.CreatedAtRoute(GetBlogEndpointName, new { id = blog.Id}, blog); 
});

app.Run();
