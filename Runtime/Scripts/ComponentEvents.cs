using System;
using UnityEngine;

public interface IComponentEvents<T> where T : Component
{
    Action<T> OnEvent  { get; set; }
    void Clear();
    void GetComponent(GameObject go);
    void AddComponent(GameObject go);
}

public abstract class ComponentEvents<T> : ScriptableObject, IComponentEvents<T> where T : Component
{
    [NonSerialized] private Action<T> _onEvent;
    public Action<T> OnEvent
    {
        get => _onEvent;
        set => _onEvent = value;
    }
    
    public void Clear()
    {
        _onEvent?.Invoke(null);
        _onEvent = null;
    }

    public void GetComponent(GameObject go)
    {
        var comp = go.GetComponent<T>();
        _onEvent?.Invoke(comp);
    }

    public void AddComponent(GameObject go)
    {
        var comp = go.AddComponent<T>();
        _onEvent?.Invoke(comp);
    }
}
