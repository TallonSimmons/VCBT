namespace VacoBuiltCodeTest.Core.DataModels
{
    public sealed class BlogPostDataModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public int CategoryId { get; set; }
        public CategoryDataModel Category { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
