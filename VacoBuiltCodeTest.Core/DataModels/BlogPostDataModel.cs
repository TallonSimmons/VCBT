namespace VacoBuiltCodeTest.Core.DataModels
{
    public sealed class BlogPostDataModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryDataModel Category { get; set; }
        public DateTimeOffset Timestamp { get; set; }
    }
}
