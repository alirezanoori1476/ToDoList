using FluentAssertions;
using ToDoList.Domain.Core.Model.Board;
using ToDoList.Domain.Core.Model.Board.Exception;
using ToDoList.Domain.Tests.Unit.Utility;
using Xunit;

namespace ToDoList.Domain.Tests.Unit.boardTests;

public class BoardTagTests
{
    private readonly Board _board;
    private readonly Tag _tag;

    public BoardTagTests()
    {
        _board = Board.CreateOne(BoardTestsConstants.BoardId, BoardTestsConstants.BoardTitle, BoardTestsConstants.BoardDescription);
        _tag = Tag.CreateOne(TagTestsConstants.FirstTagId, TagTestsConstants.TagTitle);
    }

    [Fact]
    public void Add_tag_to_a_board()
    {
        _board.AddTag(_tag);

        _board.Tags.Should().Contain(_tag);
    }

    [Fact]
    public void Remove_tag_to_a_board()
    {
        _board.AddTag(_tag);

        _board.RemoveTag(TagTestsConstants.FirstTagId);

        _board.Tags.Should().BeEmpty();
    }

    [Fact]
    public void When_a_tag_not_exist_in_list_can_not_be_removed()
    {
        _board.AddTag(_tag);

        var action = () => _board.RemoveTag(TagTestsConstants.NotExistedTagId);

        action.Should().Throw<TagNotExistException>();
    }
}