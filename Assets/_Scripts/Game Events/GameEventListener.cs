using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [Tooltip("Event to be called")]
    [SerializeField] protected GameEvent _gameEvent;
    [Tooltip("Action to be performed")]
    [SerializeField] protected UnityEvent _unityEvent;

    void Awake() => _gameEvent.Register(this);

    void OnDestroy() => _gameEvent.Deregister(this);

    public virtual void RaiseEvent() => _unityEvent.Invoke();
}
