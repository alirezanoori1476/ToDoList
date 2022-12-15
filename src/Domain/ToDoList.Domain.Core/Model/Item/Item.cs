using Framework.Domain;
using ToDoList.Domain.Core.Model.Item.Exception;

namespace ToDoList.Domain.Core.Model.Item
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

        private Item(string title, string description)
        {
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

        public static Item CreateOne(string name, string description)
        {
            return new Item(name, description);
        }

        #endregion
    }
}