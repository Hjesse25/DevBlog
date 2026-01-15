namespace DevBlog.Api.Dtos;

public record CreateBlogDto(
    string Title,
    string Content,
    string Category,
    string[] Tags
);
