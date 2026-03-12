using Facebook.Core.FBCommon;

namespace Facebook.Core.FBRepos;

public class FB_MemoryRepo<T> where T : FB_Entity
{
    private readonly Dictionary<string, T> _items = new();

    public void Add(T item) //dictionaryd nemj baina
    {
        _items[item.Id] = item;
    }

    public T? GetById(string id) //null butsaaj bolzoshgui
    {
        return _items.TryGetValue(id, out var item) ? item : null; //oldvol item  oldohgui bol null
    }

    public List<T> GetAll() //buh entityg list bolgoj butsaana
    {
        return _items.Values.ToList();
    }

    public bool Delete(string id) //remove amjilttai bol true baihgui bol false
    {
        return _items.Remove(id);
    }

    public int Count => _items.Count; //repository dotor heden entity bgag haruulna 
}