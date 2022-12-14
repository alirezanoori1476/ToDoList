using FluentAssertions;
using ToDoList.Domain.Core.Model.Item;
using ToDoList.Domain.Core.Model.Item.Exception;
using ToDoList.Domain.Tests.Unit.Utility;
using Xunit;

namespace ToDoList.Domain.Tests.Unit;

public class ToDoListItemTests
{
    private readonly Item _item;
    private readonly List<Tag> _tags;

    public ToDoListItemTests()
    {
        _item = Item.CreateOne(ItemTestsConstants.ItemTitle, ItemTestsConstants.ItemDescription);

        _tags = new List<Tag>
        {
            Tag.CreateOne(ItemTestsConstants.FirstTagId,ItemTestsConstants.TagTitle),
            Tag.CreateOne(ItemTestsConstants.SecondTagId,ItemTestsConstants.TagTitle)
        };
    }

    [Fact(DisplayName = "یک آیتم به درستی ساخته شود")]
    public void Item_created_properly()
    {
        _item.Title.Should().Be(ItemTestsConstants.ItemTitle);
        _item.Description.Should().Be(ItemTestsConstants.ItemDescription);
    }

    [Fact(DisplayName = "یک لیستی از تگ ها به آیتم اضافه شود")]
    [Trait("Category", "Add Tags")]
    public void Add_tags_to_an_item()
    {
        _item.AddTags(_tags);

        _item.Tags.Should().BeEquivalentTo(_tags);
    }

    [Fact(DisplayName = "در زمان اضافه کردن تگ اگر لیست خالی باشد خطا داده می شود")]
    [Trait("Category", "Add Tags")]
    public void AddTags_throw_exception_When_tag_list_is_empty()
    {
        var tags = new List<Tag>();

        var action = () => _item.AddTags(tags);

        action.Should().Throw<TagListCanNotBeEmptyException>();
    }

    [Fact(DisplayName = "یک تگ از لیست تگ ها حذف می شود")]
    [Trait("Category", "Remove Tags")]
    public void Remove_Tag_from_item()
    {
        _item.AddTags(_tags);
        _item.RemoveTag(ItemTestsConstants.ExistTagId);

        _item.Tags.Should().NotBeEquivalentTo(_tags);
    }

    [Fact(DisplayName = "در هنگام حذف تگ اگر وجود نداشته باشد، خطا داده می شود")]
    [Trait("Category", "Remove Tags")]
    public void RemoveTag_throw_exception_When_tag_not_exist()
    {
        _item.AddTags(_tags);

        var action = () => _item.RemoveTag(ItemTestsConstants.NotExistedTagId);

        action.Should().Throw<TagNotExistException>();
    }
}