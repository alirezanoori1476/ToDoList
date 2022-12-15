using Framework.Core.Exception;

namespace ToDoList.Domain.Core.Model.Item.Exception;

public class TagListCanNotBeEmptyException : BusinessException
{
    public TagListCanNotBeEmptyException() : base("Tag List Can Not Be Empty")
    {
        
    }
}