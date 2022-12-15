using Framework.Core.Exception;

namespace ToDoList.Domain.Core.Model.Board.Exception;

public class TagNotExistException : BusinessException
{
    public TagNotExistException() : base("Tag Not Exits")
    {
        
    }
}