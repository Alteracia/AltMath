using System;
using UnityEngine;

public interface ITwoStateEvent<in T>
{
    void Clear();
    void InvokePrimary(T eventObject);
    void InvokeSecondary(T eventObject);
}

/// <summary>
/// Events of two state
/// </summary>
public abstract class TwoStateEvents<T> : ScriptableObject, ITwoStateEvent<T>
{
    [NonSerialized] public Action<T> OnPrimaryEvent;
    [NonSerialized] public Action<T> OnSecondaryEvent;
    
    public void Clear()
    {
        OnPrimaryEvent = null;
        OnSecondaryEvent = null;
    }

    public void InvokePrimary(T eventObject)
    {
        OnPrimaryEvent?.Invoke(eventObject);
    }

    public void InvokeSecondary(T eventObject)
    {
        OnSecondaryEvent?.Invoke(eventObject);
    }
}
