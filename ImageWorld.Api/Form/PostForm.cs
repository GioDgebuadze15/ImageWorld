namespace ImageWorld.Api.Form;

public class PostForm
{
    public string? Title { get; set; }
    public string ImageName { get; set; }
    public string? Content { get; set; }
    public IEnumerable<string> Categories { get; set; }
}