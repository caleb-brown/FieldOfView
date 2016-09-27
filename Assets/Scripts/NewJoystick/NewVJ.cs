using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class NewVJ : MonoBehaviour {

    Vector3 inputVector;

    public virtual void OnDrag(PointerEventData ped)
    {
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
            if (touch.position.x > (Screen.width / 2) && touch.position.y > (Screen.height / 2)
                && touch.position.y < 0 && touch.position.x > 0 )
            {
                Debug.Log(touch.position);
            }
        }
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        inputVector = Vector3.zero;
    }
}
