namespace DevBlog.Api.Dtos;

public record UpdateBlogDto(
    string Title,
    string Content,
    string Category,
    string[] Tags
);
