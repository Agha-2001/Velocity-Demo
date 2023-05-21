using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class CameraInputManager : MonoBehaviour
{   
    int _leftFingerID;      // The id of the first finger being tracked.
    float _halfScreenWidth; // Half of the screen width.
    Vector2 _lookInput;     // The movement of finger on screen
    float _cameraPitch;

    [SerializeField] CameraScriptableObject cam;     

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        // The id=-1 means finger is not being tracked.
        _leftFingerID=-1;

        // Calculate Once.
        _halfScreenWidth= Screen.width/2;
    }

    // Update is called once per frame
    void Update()
    {
        // Handles the touch input and identify left finger ID.
        GetTouchInput();

        // Only runs when the left finger is on screen.
        if(_leftFingerID!=-1)
            LookAround();
    }

    void LookAround()
    {
        // Vertical rotation.
        _cameraPitch= Mathf.Clamp(_cameraPitch - _lookInput.y,-90f,90f);
        Camera.main.transform.localRotation=Quaternion.Euler(_cameraPitch,0,0);

        // Horizontal rotation.
        transform.Rotate(transform.up,_lookInput.x);
    }

    void GetTouchInput()
    {
        // Iterate through all detected touches.
        for(int i=0;i<Input.touchCount;i++){
            
            Touch inputTouch=Input.GetTouch(i);

            // Check each touches phase.
            switch(inputTouch.phase){
                case TouchPhase.Began:
                    if(inputTouch.position.x < _halfScreenWidth && _leftFingerID == -1)
                        _leftFingerID=inputTouch.fingerId;
                break;

                // Both cases yield the same result.
                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    if(inputTouch.fingerId==_leftFingerID)
                        _leftFingerID=-1;
                break;

                case TouchPhase.Moved:
                    //Input for looking around
                    if(inputTouch.fingerId==_leftFingerID)
                        _lookInput = inputTouch.deltaPosition * cam.CameraSensitivity * Time.deltaTime;
                break;

                case TouchPhase.Stationary:
                    //Set look input to zero if finger is stationary
                    if(inputTouch.fingerId==_leftFingerID)
                        _lookInput= Vector2.zero;
                break;
            }
        }
    }
}
