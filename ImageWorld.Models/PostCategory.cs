namespace ImageWorld.Models;

public class PostCategory
{
    public int PostId { get; set; }
    public Post Post { get; set; }
    public string CategoryId { get; set; }
    public Category Category  { get; set; }
}