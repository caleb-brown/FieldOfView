using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTouchInput : MonoBehaviour
{
    public BasicTouchController player;

    Vector3 touchPos;

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
        {
            // I don't need the vector from the camera to the touch position
            // I need the vector from the touch position to where it has been moved to            

            if (Input.GetMouseButtonDown(0))
            {
                touchPos = GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Mathf.Abs(GetComponent<Camera>().transform.position.y)));
            }

            if (Input.GetMouseButton(0))
            {
                Vector3 mousePosInWorldSpace = GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Mathf.Abs(GetComponent<Camera>().transform.position.y)));
                Vector3 movePos = mousePosInWorldSpace - touchPos;

                player.OnTouch(movePos);
                Debug.DrawLine(touchPos, mousePosInWorldSpace);
                // Debug.DrawRay(transform.position, movePos, Color.magenta);
                // Debug.DrawRay(touchPos, mousePosInWorldSpace, Color.blue);
                // Debug.DrawRay(transform.position, touchPos);
                // Debug.Log((touchPos + movePos).magnitude);
            }
            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("TouchPhase.Ended");
                player.OnTouchUp();
            }
        }
#endif

#if UNITY_ANDROID || UNITY_IOS
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                Vector3 pos = GetComponent<Camera>().ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Mathf.Abs(GetComponent<Camera>().transform.position.z)));

                if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                {
                    player.OnTouch(pos);
                }
                if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    Debug.Log("TouchPhase.Ended");
                    player.OnTouchUp();
                }
            }
        }
#endif
    }
}