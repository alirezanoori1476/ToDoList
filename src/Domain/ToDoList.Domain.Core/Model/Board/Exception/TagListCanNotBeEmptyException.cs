using Framework.Core.Exception;

namespace ToDoList.Domain.Core.Model.Board.Exception;

public class TagListCanNotBeEmptyException : BusinessException
{
    public TagListCanNotBeEmptyException() : base("Tag List Can Not Be Empty")
    {
        
    }
}