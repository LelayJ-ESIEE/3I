using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [Header("Motion Setup")]
    [Tooltip("unit: m.s-1")]
    [SerializeField] float m_TranslationSpeed;  // m/s
    [Tooltip("Rotation Speed in °.s-1")]
    [SerializeField] float m_RotationSpeed; // °/s

    // Physics
    Transform m_Transform;
    Vector3 m_SpawnPosition;
    Quaternion m_SpawnOrientation;

    // Inputs
    InputSettings inputs;
    float hInput;
    float vInput;
    float dInput;

    private void Awake()
    {
        // Physics
        m_Transform = GetComponent<Transform>();
        m_SpawnPosition = m_Transform.position;

        // Inputs
        inputs = new InputSettings();

        inputs.Level.RotationUD.performed += context => vInput = context.ReadValue<float>();
        inputs.Level.RotationUD.canceled += context => vInput = 0;
        inputs.Level.RotationLR.performed += context => hInput = context.ReadValue<float>();
        inputs.Level.RotationLR.canceled += context => hInput = 0;
        inputs.Level.Translation.performed += context => dInput = context.ReadValue<float>();
        inputs.Level.Translation.canceled += context => dInput = 0;
        inputs.Level.Restart.performed += context => m_Transform.SetPositionAndRotation(m_SpawnPosition, m_SpawnOrientation);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hAngle = hInput * m_RotationSpeed;
        hInput = 0;
        float vAngle = vInput * m_RotationSpeed;
        vInput = 0;
        Vector3 dVector = dInput * Vector3.forward * m_TranslationSpeed;
        dInput = 0;

        m_Transform.Rotate(Vector3.up, hAngle, Space.World);
        m_Transform.Rotate(Vector3.right, vAngle, Space.World);
        m_Transform.Translate(dVector, Space.World);
    }

    private void OnEnable()
    {
        inputs.Enable();
    }

    private void OnDisable()
    {
        inputs.Disable();
    }
}
