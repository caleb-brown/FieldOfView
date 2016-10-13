using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class PlaceJoysticks : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{

    public GameObject moveJoystick;
    public GameObject lookJoystick;

    List<Touch> touches = new List<Touch>();
    Vector3 inputVector;

    void Start()
    {
        
    }
    
    public virtual void OnDrag(PointerEventData ped)
    {
        
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        // moveJoystick.
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {

    }
}
