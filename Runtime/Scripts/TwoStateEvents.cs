using System;
using UnityEngine;

public interface ITwoStateEvent<T>
{
    Action<T> OnPrimaryEvent  { get; set; }
    Action<T> OnSecondaryEvent { get; set; }
    void Clear();
}

/// <summary>
/// Events of two state
/// </summary>
public abstract class TwoStateEvents<T> : ScriptableObject, ITwoStateEvent<T>
{
    [NonSerialized] private Action<T> _onPrimaryEvent;
    public Action<T> OnPrimaryEvent
    {
        get => _onPrimaryEvent;
        set => _onPrimaryEvent = value;
    }

    [NonSerialized] private Action<T> _onSecondaryEvent;
    public Action<T> OnSecondaryEvent
    {
        get => _onSecondaryEvent;
        set => _onSecondaryEvent = value;
    }

    public void Clear()
    {
        _onPrimaryEvent = null;
        _onSecondaryEvent = null;
    }
}
