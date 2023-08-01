using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InputBuffer : MonoBehaviour
{
    public float bufferTime = 0.5f; // Buffer time in seconds
    public Button targetButton; // The UI button to be clicked

    private bool isBuffering = false;

    // UnityEvent to invoke when the buffer time has passed
    public UnityEvent onClickBuffered;

    private void Start()
    {
        // Add the button click listener
        targetButton.onClick.AddListener(ButtonClickHandler);
    }

    private void ButtonClickHandler()
    {
        if (isBuffering)
        {
            // If buffering is already in progress, cancel the previous buffer
            StopCoroutine("BufferCoroutine");
            isBuffering = false;
        }

        // Start the buffer coroutine
        StartCoroutine("BufferCoroutine");
    }

    private IEnumerator BufferCoroutine()
    {
        isBuffering = true;
        yield return new WaitForSeconds(bufferTime);

        // Invoke the buffered click event
        onClickBuffered.Invoke();

        isBuffering = false;
    }
}