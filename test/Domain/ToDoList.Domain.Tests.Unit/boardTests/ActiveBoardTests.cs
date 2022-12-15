using FluentAssertions;
using ToDoList.Domain.Core.Model.Board;
using ToDoList.Domain.Tests.Unit.Utility;
using Xunit;

namespace ToDoList.Domain.Tests.Unit.boardTests;

public class ActiveBoardTests
{
    private readonly Board _board;

    public ActiveBoardTests()
    {
        _board = Board.CreateOne(BoardTestsConstants.BoardId, BoardTestsConstants.BoardTitle, BoardTestsConstants.BoardDescription);
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
}