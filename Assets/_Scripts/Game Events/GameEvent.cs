using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Event", fileName = "New Game Event")]
public class GameEvent : ScriptableObject
{
    HashSet<GameEventListener> _listeners = new HashSet<GameEventListener>();

    public void Invoke()
    {
        foreach (var globalEventListner in _listeners)
            globalEventListner.RaiseEvent();
    }

    public void Register(GameEventListener gameEventListener) => _listeners.Add(gameEventListener);

    public void Deregister(GameEventListener gameEventListener) => _listeners.Remove(gameEventListener);
}
