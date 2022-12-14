namespace ToDoList.Domain.Core.Model.Item.Exception;

public class TagListCanNotBeEmptyException : System.Exception
{
    public TagListCanNotBeEmptyException() : base("Tag List Can Not Be Empty")
    {
        
    }
}