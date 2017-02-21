using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineTouchInput : MonoBehaviour
{
    public LineTouchController player;
    public Material lineMaterial;

    Vector3 initTouchPos;
    List<Vector3> touchLineList = new List<Vector3>();
    List<List<Vector3>> lineList = new List<List<Vector3>>();
    LineRenderer lr;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        lr.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        lr.receiveShadows = false;
        lr.material = lineMaterial;
        lr.numPositions = 0;
    }

	// Update is called once per frame
	void Update () 
	{
#if UNITY_EDITOR
        if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Reset();

                initTouchPos = 
                                GetComponent<Camera>().ScreenToWorldPoint(
                                new Vector3(Input.mousePosition.x, 
                                Input.mousePosition.y, 
                                transform.position.y));

                lr.numPositions += 1;
                touchLineList.Add(initTouchPos);
            }

            if (Input.GetMouseButton(0))
            {
                if (!touchLineList.Contains(GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.y))) || touchLineList.Count == 0)
                {
                    touchLineList.Add(GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.y)));
                    lr.numPositions += 1;
                }

                /*Vector3 previousTouchPos = touchLineList[0];
                foreach (Vector3 tp in touchLineList)
                { 
                    Debug.DrawLine(previousTouchPos, tp);
                    previousTouchPos = tp;
                }*/

                lr.SetPositions(touchLineList.ToArray());
            }

            if (Input.GetMouseButtonUp(0))
            {
                
                if (!lineList.Contains(touchLineList))
                {
                    lineList.Add(touchLineList);
                }

                Debug.Log(touchLineList.Count);

                player.OnTouchUp(touchLineList);
                // player.StartCoroutine("OnTouchUp", touchLineList);
            }
        }
#endif

#if UNITY_ANDROID || UNITY_IOS

#endif
    }

    void Reset()
    {
        lr.numPositions = 0;

        touchLineList.Clear();
    }

    void Add(object obj)
    {
        /*Type type = obj.GetType();
        
        if (type == TypeCode.Int32)*/
    }
}
