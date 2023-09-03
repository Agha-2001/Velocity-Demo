using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListenerWithDelay : GameEventListener
{
    [Tooltip("Delay before action")]
    [SerializeField] float _delay;
    [Tooltip("Action to be performed")]
    [SerializeField] UnityEvent _delayedUnityEvent;

    void Awake() => _gameEvent.Register(this);

    void OnDestroy() => _gameEvent.Deregister(this);

    public override void RaiseEvent()
    {
        _unityEvent.Invoke();
        StartCoroutine(RunDelayedEvent());
    }

    private IEnumerator RunDelayedEvent()
    {
        yield return new WaitForSeconds(_delay);
        _delayedUnityEvent.Invoke();
    }
}
