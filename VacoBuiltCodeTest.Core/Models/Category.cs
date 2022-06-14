﻿namespace VacoBuiltCodeTest.Core.Entities
{
    public sealed class Category
    {
        public Category(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }
        public string Name { get; }
    }
}