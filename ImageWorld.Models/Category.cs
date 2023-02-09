namespace ImageWorld.Models;

public class Category : BaseModel<string>
{
    private IList<PostCategory> Posts { get; set; }
}