using Framework.Core.Exception;

namespace ToDoList.Domain.Core.Model.Item.Exception;

public class TagNotExistException : BusinessException
{
    public TagNotExistException() : base("Tag Not Exits")
    {
        
    }
}