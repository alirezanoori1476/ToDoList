using FluentAssertions;
using ToDoList.Domain.Core.Model.Board;
using ToDoList.Domain.Core.Model.Board.Exception;
using ToDoList.Domain.Tests.Unit.Utility;
using Xunit;

namespace ToDoList.Domain.Tests.Unit.boardTests;

public class ToDoListBoardsUnitTests
{
    private readonly Board _board;
    private readonly List<Item> _items;

    public ToDoListBoardsUnitTests()
    {
        _board = Board.CreateOne(BoardTestsConstants.BoardId, BoardTestsConstants.BoardTitle, BoardTestsConstants.BoardDescription);
        
        _items = new List<Item>
        {
            Item.CreateOne(ItemTestsConstants.FirstItemId,ItemTestsConstants.ItemTitle,ItemTestsConstants.ItemDescription),
            Item.CreateOne(ItemTestsConstants.SecondTagId,ItemTestsConstants.ItemTitle,ItemTestsConstants.ItemDescription)
        };
    }

    [Fact]
    public void Create_a_board_properly()
    {
        _board.Id.Should().Be(BoardTestsConstants.BoardId);
        _board.Title.Should().Be(BoardTestsConstants.BoardTitle);
        _board.Desciption.Should().Be(BoardTestsConstants.BoardDescription);
        _board.IsActive.Should().BeTrue();
    }

    [Fact]
    public void DeActive_a_board()
    {
        _board.DeActiveBoard();

        _board.IsActive.Should().BeFalse();
    }

    [Fact]
    public void Active_a_deactivated_board()
    {
        _board.DeActiveBoard();
        _board.ActiveBoard();

        _board.IsActive.Should().BeTrue();
    }

    [Fact]
    public void Add_some_items_to_board()
    {
        _board.AddItems(_items);

        _board.Items.Should().BeEquivalentTo(_items);
    }

    [Fact]
    public void When_itemList_is_empty_can_not_add_to_board()
    {
        var emptyItemList = new List<Item>();

        var action = () => _board.AddItems(emptyItemList);

        action.Should().Throw<ItemListAreEmptyException>();
    }

    [Fact]
    public void Remove_an_item_from_board_item_list()
    {
        _board.AddItems(_items);
        _board.RemoveItem(ItemTestsConstants.FirstItemId);

        _board.Items.Should().NotBeEquivalentTo(_items);
    }

    [Fact]
    public void When_item_not_exist_in_boardItemList_can_not_be_removed()
    {
        _board.AddItems(_items);

        var action = () => _board.RemoveItem(BoardTestsConstants.NotExistItemId);

        action.Should().Throw<ItemNotExistException>();
    }
}