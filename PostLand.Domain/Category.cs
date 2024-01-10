namespace PostLand.Domain
{
    // generate class named Category has Id ,Name and Blogs
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Post> Blogs { get; set; }
    }
}
