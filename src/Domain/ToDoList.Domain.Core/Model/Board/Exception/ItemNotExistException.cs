using Framework.Core.Exception;

namespace ToDoList.Domain.Core.Model.Board.Exception;

public class ItemNotExistException : BusinessException
{
    public ItemNotExistException() : base("Item Not Exist")
    {
    }
}