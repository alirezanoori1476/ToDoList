namespace ToDoList.Domain.Core.Model.Item.Exception;

public class TagNotExistException : System.Exception
{
    public TagNotExistException() : base("Tag Not Exits")
    {
        
    }
}