using Framework.Domain;

namespace ToDoList.Domain.Core.Model.Item;

public class Tag : Entity<long>
{
    public string Title { get; private set; }

    private Tag(long id, string title)
    {
        Id = id;
        Title = title;
    }

    public static Tag CreateOne(long tagId, string title)
    {
        return new Tag(tagId, title);
    }
}