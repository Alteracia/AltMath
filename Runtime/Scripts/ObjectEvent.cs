using System;
using UnityEngine;

public interface IObjectEvent<T>
{
    Action<T> OnEvent  { get; set; }
    void Clear();
}

public abstract class ObjectEvent<T> : ScriptableObject, IObjectEvent<T>
{
    [NonSerialized] private Action<T> _onEvent;
    public Action<T> OnEvent
    {
        get => _onEvent;
        set => _onEvent = value;
    }

    public void Clear()
    {
        _onEvent = null;
    }
}
