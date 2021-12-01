using System.Collections.Generic;

public interface IManager<TID, TItem> where TItem : IManagedItem<TID>
{
    Dictionary<TID, TItem> ManagedItem { get; }

    void Add(TItem _item);
    void Clear();
    bool Exist(TID _id);
    bool Exist(TItem _item);
    TItem Get(TID _id);
    void Remove(TID _id);
    void Remove(TItem _item);
}