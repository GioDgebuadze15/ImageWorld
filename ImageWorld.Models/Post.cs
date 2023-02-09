namespace ImageWorld.Models;

public class Post: BaseModel<int>  
{
    public string ImageName { get; set; }
    public string? Content { get; set; }
    public IList<PostCategory> PostCategories { get; set; }
}