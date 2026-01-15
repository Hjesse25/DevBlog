namespace DevBlog.Api.Dtos;

public record BlogDto(
    int Id,
    string Title,
    string Content,
    string Category,
    string[] Tags
);
