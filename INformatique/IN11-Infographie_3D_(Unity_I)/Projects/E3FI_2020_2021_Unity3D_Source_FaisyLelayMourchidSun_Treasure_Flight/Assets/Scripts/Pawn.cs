using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using SDD.Events;


public class Pawn : MonoBehaviour
{
    [Header("Motion Setup")]
    [Tooltip("unit: m.s-1")]
    [SerializeField] float m_TranslationSpeed;  // m/s

    // Physics
    Transform m_Transform;
    Rigidbody m_Rigidbody;
    Vector3 m_SpawnPosition;
    Quaternion m_SpawnOrientation;

    // Inputs
    InputSettings inputs;
    float hInput;

    private void Awake()
    {
        // Physics
        m_Transform = GetComponent<Transform>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_SpawnPosition = m_Transform.position;
        m_SpawnOrientation = m_Transform.rotation;

        // Inputs
        inputs = new InputSettings();

        inputs.Pawn.Move.performed += context => hInput = context.ReadValue<float>();
        inputs.Pawn.Move.canceled += context => hInput = 0;
        inputs.Pawn.Restart.performed += context => m_Transform.SetPositionAndRotation(m_SpawnPosition, m_SpawnOrientation);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 newVelocity = Vector3.right * m_TranslationSpeed * this.hInput;
        Vector3 correctingVelocity = -Vector3.ProjectOnPlane(m_Rigidbody.velocity, Vector3.up);
        Vector3 velocityChange = newVelocity + correctingVelocity;
        m_Rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);

        Vector3 angularVelocityChange = - m_Rigidbody.angularVelocity;
        m_Rigidbody.AddTorque(angularVelocityChange, ForceMode.VelocityChange);

        Vector3 keepRightTorque = Vector3.Cross(m_Transform.forward, Vector3.forward) * Vector3.Angle(m_Transform.forward, Vector3.forward) * Mathf.Deg2Rad * 2000;
        m_Rigidbody.AddTorque(keepRightTorque, ForceMode.Force);
    }

    private void OnEnable()
    {
        inputs.Enable();
    }

    private void OnDisable()
    {
        inputs.Disable();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            string sceneName = SceneManager.GetActiveScene().name;
            string nextSceneName="";
            if(sceneName == "Level_0_0")
            {
                nextSceneName = "Scenes/Level_0_1";
            }
            else if (sceneName == "Level_0_1")
            {
                nextSceneName = "Scenes/Level_0_2";
            }
            else if (sceneName == "Level_0_2")
            {
                nextSceneName = "Scenes/Level_1_0";
            }
            else if (sceneName == "Level_1_0")
            {
                nextSceneName = "Scenes/Level_2_0";
            }
            else
            {
                EventManager.Instance.Raise(new MainMenuButtonClickedEvent());
                
            }
            SceneManager.LoadScene(nextSceneName);
        }
    }
    
}
