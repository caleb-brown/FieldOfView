using UnityEngine;
using System.Collections;

#if UNITY_ANDROID || UNITY_IOS
    
using UnityStandardAssets.CrossPlatformInput;
    
#endif


public class Controller : MonoBehaviour {

	public float moveSpeed = 6;

    Camera viewCamera;

/*#if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_WEBGL*/
	
    Rigidbody rigidBody;
	Vector3 velocity;
    
/*#endif

#if UNITY_ANDROID || UNITY_IOS

    Rigidbody myBody;
	Vector3 moveVec;

#endif*/
    // Use this for initialization
    void Start () {
//#if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_WEBGL
		
        rigidBody = GetComponent<Rigidbody> ();

/*#endif

#if UNITY_ANDROID || UNITY_IOS
      
        myBody = GetComponent<Rigidbody>();
        
#endif*/
        viewCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update ()
    {
#if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_WEBGL
        
        if (Input.GetKey("escape"))
            Application.Quit();

		Vector3 mPos = viewCamera.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y));
		transform.LookAt(mPos + Vector3.up * transform.position.y);
		velocity = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical")).normalized * moveSpeed;
        
#endif

#if UNITY_ANDROID || UNITY_IOS

		/*moveVec = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"), 0) * moveSpeed;
		Debug.Log(moveVec);
		myBody.AddForce(moveVec);*/

        Vector3 mPos = viewCamera.ScreenToWorldPoint(new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"), viewCamera.transform.position.y));
        transform.LookAt(mPos + Vector3.up * transform.position.y);
        velocity = new Vector3(CrossPlatformInputManager.GetAxisRaw("Horizontal"), 0, CrossPlatformInputManager.GetAxisRaw("Vertical")).normalized * moveSpeed;

#endif

    }

	void FixedUpdate()
	{
//#if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_WEBGL

		rigidBody.MovePosition (rigidBody.position + velocity * Time.fixedDeltaTime);

/*#endif

#if UNTIY_ANDROID || UNITY_IOS

		myBody.MovePosition (myBody.ImagePosition + moveVec * Time.fixedDeltaTime);

#endif*/

    }
}
