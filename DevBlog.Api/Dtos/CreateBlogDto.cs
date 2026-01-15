using System.ComponentModel.DataAnnotations;

namespace DevBlog.Api.Dtos;

public record CreateBlogDto(
    [Required][StringLength(50)] string Title,
    [Required] string Content,
    [Required][StringLength(20)] string Category,
    string[] Tags
);
