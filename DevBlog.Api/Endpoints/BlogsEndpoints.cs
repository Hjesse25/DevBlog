using DevBlog.Api.Dtos;

namespace DevBlog.Api.Endpoints;

public static class BlogsEndpoints
{
    const string GetBlogEndpointName = "GetBlog";

    private static readonly List<BlogDto> blogs = [
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

    public static void MapBlogEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/blogs");

        // GET /blogs
        group.MapGet("/", () => blogs);

        // GET /blogs/1
        group.MapGet("/{id}", (int id) =>
        {
            var blog = blogs.Find(blog => blog.Id == id);

            return blog is null ? Results.NotFound() : Results.Ok(blog);
        }).WithName(GetBlogEndpointName);

        // POST /blogs
        group.MapPost("/", (CreateBlogDto newBlog) =>
        {
            BlogDto blog = new(
            blogs.Count + 1,
            newBlog.Title,
            newBlog.Content,
            newBlog.Category,
            newBlog.Tags
            );

            blogs.Add(blog);

            return Results.CreatedAtRoute(GetBlogEndpointName, new { id = blog.Id }, blog);
        });

        // PUT /blogs/1
        group.MapPut("/{id}", (int id, UpdateBlogDto updatedBlog) =>
        {
            var index = blogs.FindIndex(blog => blog.Id == id);

            if (index == -1)
            {
                return Results.NotFound();
            }

            blogs[index] = new BlogDto(
                id,
                updatedBlog.Title,
                updatedBlog.Content,
                updatedBlog.Category,
                updatedBlog.Tags
            );

            return Results.NoContent();
        });

        // DELETE /blogs/1
        group.MapDelete("/{id}", (int id) =>
        {
            blogs.RemoveAll(blog => blog.Id == id);

            return Results.NoContent();
        });
    }
}
