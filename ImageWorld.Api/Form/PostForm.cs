namespace ImageWorld.Api.Form;

public class PostForm
{
    public string ImageName { get; set; }
    public string? Content { get; set; }
    public IEnumerable<string> Categories { get; set; }
}