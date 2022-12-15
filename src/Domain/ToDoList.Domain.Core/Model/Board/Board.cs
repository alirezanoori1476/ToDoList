using Framework.Domain;
using ToDoList.Domain.Core.Model.Board.Exception;

namespace ToDoList.Domain.Core.Model.Board;

public class Board : Entity<long>
{
    #region Properties

    public string Title { get; private set; }
    public string Desciption { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreateDate { get; set; }
    public IReadOnlyCollection<Item> Items => _items.AsReadOnly();
    private List<Item> _items { get; }

    #endregion

    #region Constructors

    private Board(long id, string title, string desciption)
    {
        Id = id;
        Title = title;
        Desciption = desciption;
        IsActive = true;
        CreateDate = DateTime.Now;
        _items = new List<Item>();
    }

    #endregion

    #region Actions



    #endregion

    #region Factories

    public static Board CreateOne(long id, string title, string description)
    {
        return new Board(id, title, description);
    }

    #endregion

    public void DeActiveBoard()
    {
        IsActive = false;
    }

    public void ActiveBoard()
    {
        IsActive = true;
    }

    public void AddItems(List<Item> items)
    {
        if (items.Count == 0)
            throw new ItemListAreEmptyException();

        _items.AddRange(items);
    }

    public void RemoveItem(long itemId)
    {
        var item = _items.FirstOrDefault(a => a.Id == itemId);

        if (item == null)
            throw new ItemNotExistException();

        _items.Remove(item);
    }
}