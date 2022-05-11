using UnityEngine;
using System.Collections;

/// MouseLook rotates the transform based on the mouse delta.
/// Minimum and Maximum values can be used to constrain the possible rotation

/// To make an FPS style character:
/// - Create a capsule.
/// - Add the MouseLook script to the capsule.
///   -> Set the mouse look to use LookX. (You want to only turn character but not tilt it)
/// - Add FPSInputController script to the capsule
///   -> A CharacterMotor and a CharacterController component will be automatically added.

/// - Create a camera. Make the camera a child of the capsule. Reset it's transform.
/// - Add a MouseLook script to the camera.
///   -> Set the mouse look to use LookY. (You want the camera to tilt up and down like a head. The character already turns.)
[AddComponentMenu("Camera-Control/Mouse Look")]

public class new_hikoHD_first_cam : MonoBehaviour {


	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 1.0F;
	public float sensitivityY = 1.0F;

	public float minimumX = -90F;
	public float maximumX = 90F;

	public float minimumY = -60F;
	public float maximumY = 60F;

	float rotationY = 0F;


	public bool lockCursor = true;
	private bool m_cursorIsLocked = true;


    private GameObject parent_hikoHD;

    public bool _shootmode;

    private float smo_Y,smo_X;

    public Transform iphone_target;

    Quaternion saq;

    Vector3 sap;

    GameObject f_camtoiphone;

//	private bool cam_active = false;
	void Start ()
	{
        //if(!networkView.isMine)
        //enabled = false;

        // Make the rigid body not change rotation
        //if (rigidbody)
        //rigidbody.freezeRotation = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        parent_hikoHD = GameObject.Find("hiko_HD");

        //_shootmode = parent_hikoHD.GetComponent<new_hikoHD_ctrl>().shootmode;
        _shootmode = false;
        smo_Y = 0.0f;
        smo_X = 0.0f;

        f_camtoiphone = GameObject.Find("FIRST_CAM_iphone");
       // SetCursorLock(true);
        Invoke("set_cursor_show", 2.0f);

        Invoke("set_cursor_hide",2.1f);
	}

    void set_cursor_show()
    {

        SetCursorLock(false);
    }
    void set_cursor_hide(){
        
        SetCursorLock(true);
    }

	void Update ()
	{
        //_shootmode = parent_hikoHD.GetComponent<new_hikoHD_ctrl>().shootmode;


        f_camtoiphone.transform.LookAt(iphone_target);

        if (axes == RotationAxes.MouseXAndY)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        else if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        }
        else
        {

            /*
            sap = iphone_target.position - this.transform.position;

            saq = Quaternion.LookRotation(iphone_target.position - this.transform.position);

            Vector3 saq_angle = saq.eulerAngles;

            print(saq_angle);
            */
            float speed = 100.0f;
            float step = speed * Time.deltaTime;

            //print(f_camtoiphone.transform.localEulerAngles.y);

            if (!_shootmode)
            {
                
                float m_y = Input.GetAxis("Mouse Y");
                
                if(m_y < 0.05 && m_y > -0.05){
                    m_y = 0.0f;
                }
                //print(m_y);
                rotationY += m_y * sensitivityY;
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
                smo_Y += (rotationY - smo_Y) / 1.0f;//
                //transform.localEulerAngles = new Vector3(-smo_Y, 0, 0);

                this.transform.localRotation = Quaternion.RotateTowards(this.transform.localRotation, Quaternion.Euler(-smo_Y, 0, 0), step);

            }
            else{

                /*
                float m_y = Input.GetAxis("Mouse Y");

                if (m_y < 0.05 && m_y > -0.05)
                {
                    m_y = 0.0f;
                }
                //print(m_y);
                rotationY += m_y * sensitivityY;
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
                smo_Y += (rotationY - smo_Y) / 1.0f;//
                //transform.localEulerAngles = new Vector3(-smo_Y, 0, 0);

                this.transform.localRotation = Quaternion.RotateTowards(this.transform.localRotation, Quaternion.Euler(-smo_Y, 0, 0), step);
                */
                //shoot_mode_camera

                //print("mode");
                smo_Y += ((-f_camtoiphone.transform.localEulerAngles.x+10.0f) - smo_Y) / 10.0f;
                this.transform.localRotation = Quaternion.RotateTowards(this.transform.localRotation, f_camtoiphone.transform.localRotation, step);

            }



			//transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
		}
		UpdateCursorLock();

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
	}




	public void SetCursorLock(bool value)
	{
		lockCursor = value;
		if(!lockCursor)
		{//we force unlock the cursor if the user disable the cursor locking helper
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
        }else{
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
	}

	public void UpdateCursorLock()
	{
		//if the user set "lockCursor" we check & properly lock the cursos
		if (lockCursor)
			InternalLockUpdate();
	}

	private void InternalLockUpdate()
	{
        if(Input.GetKeyUp(KeyCode.Tab))
		{
			m_cursorIsLocked = false;
		}
		else if(Input.GetMouseButtonUp(0))
		{
			m_cursorIsLocked = true;
		}

		if (m_cursorIsLocked)
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
		else if (!m_cursorIsLocked)
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
	}
}
