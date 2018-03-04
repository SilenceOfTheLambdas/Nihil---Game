using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

[RequireComponent(typeof(Rigidbody))]
public class FPS : MonoBehaviour
{
    private float m_MovX;
    private float m_MovY;
    private Vector3 m_moveHorizontal;
    private Vector3 m_movVertical;
    private Vector3 m_velocity;
    private Rigidbody m_Rigid;
    private float m_yRot;
    private float m_xRot;
    private Vector3 m_rotation;
    private Vector3 m_cameraRotation;  
    private bool m_cursorIsLocked = true;  
	[SerializeField] private static float speed = 5.0f;
	[SerializeField] private float m_lookSensitivity = 3.0f;
    [SerializeField] private bool m_IsWalking = true;
    
    [Header("The Values for Stamina system and walking.")]
    // Sets The Default walk speed (which it always reverts back to, and the chnaged walk speed.)
    public float m_WalkSpeed = speed;
    public float DefaultWalkSpeed = 5;
    // Run Speed and the set run speed; decided by user
    private float m_RunSpeed;
    [SerializeField] public float m_setRunSpeed;
   
    // User set run time (in secs)
    [Header("Set the amount of time the player can run for.")]
    [SerializeField] [Range(0, 10)]private float m_runTime;
    [SerializeField] [Range(0, 10)]public float m_setRunTime;
    
    // Stamina
	[Header("The Default Values for Stamina and Crouching")]
	[SerializeField]private float initailCharHeight;
	[SerializeField]private static float initialCharWalkSpeed = initialCharWalkSpeed = 3;
	[Header("The New Values for Crouching")]
	[SerializeField]private float CharCrouchHeight;

    [Header("The Camera the player looks through")]
    public Camera m_Camera;

    // Use this for initialization
    private void Start()
    {
        m_Rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void Update()
    {
		CharacterController controller = GetComponent<CharacterController>();
        m_MovX = Input.GetAxis("Horizontal");
        m_MovY = Input.GetAxis("Vertical");

        m_moveHorizontal = transform.right * m_MovX;
        m_movVertical = transform.forward * m_MovY;

        m_velocity = (m_moveHorizontal + m_movVertical).normalized * speed;

        //mouse movement 
        m_yRot = Input.GetAxisRaw("Mouse X");
        m_rotation = new Vector3(0, m_yRot, 0) * m_lookSensitivity;

        m_xRot = Input.GetAxisRaw("Mouse Y");
        m_cameraRotation = new Vector3(m_xRot, 0, 0) * m_lookSensitivity;

        //apply camera rotation

        //move the actual player here
        if (m_velocity != Vector3.zero)
        {
            m_Rigid.MovePosition(m_Rigid.position + m_velocity * Time.fixedDeltaTime);
        }

        if (m_rotation != Vector3.zero)
        {
            //rotate the camera of the player
            m_Rigid.MoveRotation(m_Rigid.rotation * Quaternion.Euler(m_rotation));
        }

        if (m_Camera != null)
        {
            //negate this value so it rotates like a FPS not like a plane
            m_Camera.transform.Rotate(-m_cameraRotation);
        }


		// Walking

        if (m_IsWalking == true) {

            m_WalkSpeed = m_WalkSpeed;
        }
        
        // Running System

		speed = Input.GetKey(KeyCode.LeftShift) ? m_RunSpeed : initialCharWalkSpeed;

        if (Input.GetKey(KeyCode.LeftShift)) {

            m_IsWalking = false;
            m_WalkSpeed = m_RunSpeed;
        }else {
            
            m_IsWalking = true;
        }

        InternalLockUpdate();
        
        //Stamina System

            if (m_IsWalking == false) {

                m_runTime -= Time.deltaTime;

            }if (m_runTime <= 0.02)
            {
                m_IsWalking = true;
                m_RunSpeed = DefaultWalkSpeed; 

            }if (m_RunSpeed == DefaultWalkSpeed)
            {
                m_runTime += Time.deltaTime;
            }
                if (m_runTime == m_setRunTime)
                {
                    m_RunSpeed = m_setRunSpeed;
                }
                if (m_runTime >= m_setRunTime)
                {
                    m_runTime = m_setRunTime;
            }

    }

    //controls the locking and unlocking of the mouse
    private void InternalLockUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            m_cursorIsLocked = false;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            m_cursorIsLocked = true;
        }

        if (m_cursorIsLocked)
        {
            UnlockCursor();
        }
        else if (!m_cursorIsLocked)
        {
            LockCursor();
        }
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}
