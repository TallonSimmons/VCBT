namespace VacoBuiltCodeTest.Core.Entities
{
    public sealed class BlogPost
    {
        public BlogPost(Guid id, string title, string contents, Category category, DateTimeOffset timestamp)
        {
            Id = id;
            Title = title;
            Contents = contents;
            Category = category;
            Timestamp = timestamp;
        }

        public Guid Id { get; }
        public string Title { get; }
        public string Contents { get; }
        public Category Category { get; }
        public DateTimeOffset Timestamp { get; }
    }
}
