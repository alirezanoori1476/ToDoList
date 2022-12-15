using FluentAssertions;
using ToDoList.Domain.Core.Model.Board;
using ToDoList.Domain.Core.Model.Board.Exception;
using ToDoList.Domain.Tests.Unit.Utility;
using Xunit;

namespace ToDoList.Domain.Tests.Unit.ItemTests;

public class ToDoListItemTests
{
    private readonly Item _item;
    private readonly List<Tag> _tags;

    public ToDoListItemTests()
    {
        _item = Item.CreateOne(ItemTestsConstants.FirstItemId, ItemTestsConstants.ItemTitle, ItemTestsConstants.ItemDescription);

        _tags = new List<Tag>
        {
            Tag.CreateOne(TagTestsConstants.FirstTagId,TagTestsConstants.TagTitle),
            Tag.CreateOne(TagTestsConstants.SecondTagId,TagTestsConstants.TagTitle)
        };
    }

    [Fact]
    public void Item_created_properly()
    {
        _item.Id.Should().Be(ItemTestsConstants.FirstItemId);
        _item.Title.Should().Be(ItemTestsConstants.ItemTitle);
        _item.Description.Should().Be(ItemTestsConstants.ItemDescription);
    }

    [Fact]
    public void Add_tags_to_an_item()
    {
        _item.AddTags(_tags);

        _item.Tags.Should().BeEquivalentTo(_tags);
    }

    [Fact]
    public void AddTags_throw_exception_When_tag_list_is_empty()
    {
        var emptyTagList = new List<Tag>();

        var action = () => _item.AddTags(emptyTagList);

        action.Should().Throw<TagListCanNotBeEmptyException>();
    }

    [Fact]
    public void Remove_Tag_from_item()
    {
        _item.AddTags(_tags);
        _item.RemoveTag(TagTestsConstants.ExistTagId);

        _item.Tags.Should().NotBeEquivalentTo(_tags);
    }

    [Fact]
    public void RemoveTag_throw_exception_When_tag_not_exist()
    {
        _item.AddTags(_tags);

        var action = () => _item.RemoveTag(TagTestsConstants.NotExistedTagId);

        action.Should().Throw<TagNotExistException>();
    }
}