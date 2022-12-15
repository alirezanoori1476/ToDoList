using Framework.Core.Exception;

namespace ToDoList.Domain.Core.Model.Board.Exception;

public class ItemListAreEmptyException : BusinessException
{
    public ItemListAreEmptyException() : base("Item List Can Not Be Empty")
    {

    }
}