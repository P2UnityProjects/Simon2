using System.Collections.Generic;
using UnityEngine;

public class S2_CameraManager : S2_Singleton<S2_CameraManager>, IManager<string, S2_CameraBehaviour>
{
    Dictionary<string, S2_CameraBehaviour> managedItems = new Dictionary<string, S2_CameraBehaviour>();

    public Dictionary<string, S2_CameraBehaviour> ManagedItem => managedItems;

    public void Add(S2_CameraBehaviour _item)
    {
        string _id = _item.ID.ToLower();
        if (Exist(_item) || string.IsNullOrEmpty(_id)) return;
        managedItems.Add(_id, _item);
        _item.name += " [Managed]";
    }
    public void Clear()
    {
        managedItems.Clear();
    }
    public bool Exist(string _id)
    {
        return managedItems.ContainsKey(_id.ToLower()) && !string.IsNullOrEmpty(_id);
    }
    public bool Exist(S2_CameraBehaviour _item)
    {
        return Exist(_item.ID);
    }
    public S2_CameraBehaviour Get(string _id)
    {
        if (!Exist(_id)) return null;
        return managedItems[_id.ToLower()];
    }
    public void Remove(string _id)
    {
        if (!Exist(_id)) return;
        managedItems.Remove(_id.ToLower());
    }
    public void Remove(S2_CameraBehaviour _item)
    {
        Remove(_item.ID);
    }
}