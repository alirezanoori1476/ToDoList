using Framework.Domain;
using System.Xml.Linq;
using ToDoList.Domain.Core.Model.Board.Exception;

namespace ToDoList.Domain.Core.Model.Board
{
    public class Item : Entity<long>
    {
        #region Properties

        public string Title { get; private set; }
        public string Description { get; private set; }
        public IReadOnlyCollection<Tag> Tags => _tags.AsReadOnly();
        private List<Tag> _tags { get; }

        #endregion

        #region Constructors

        private Item(long id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
            _tags = new List<Tag>();
        }

        #endregion

        #region Actions

        public void AddTags(List<Tag> tags)
        {
            if (tags.Count == 0)
                throw new TagListCanNotBeEmptyException();

            _tags.AddRange(tags);
        }

        public void RemoveTag(long tagId)
        {
            var tag = _tags.FirstOrDefault(a => a.Id == tagId);

            if (tag == null)
                throw new TagNotExistException();

            _tags.Remove(tag);
        }

        #endregion

        #region Factory

        public static Item CreateOne(long id, string name, string description)
        {
            return new Item(id, name, description);
        }

        #endregion
    }
}