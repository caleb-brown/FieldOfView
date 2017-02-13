using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTouchInput : MonoBehaviour
{
    public BasicTouchController player;

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
        {
            Vector3 pos = GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Mathf.Abs(GetComponent<Camera>().transform.position.z)));

            if (Input.GetMouseButton(0))
            {
                player.OnTouch(pos);
                // Debug.DrawRay(transform.position, pos);
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