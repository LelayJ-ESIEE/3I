using UnityEngine;
using System.Collections;

public class FlyingCamera : MonoBehaviour
{
    #region Attributes

 
    // Camera component
    protected Camera m_Camera = null;

    // Character
    [SerializeField]
    private GameObject m_Character = null;

    // Offset
    [SerializeField]
    private Vector3 m_CharacterOffset = new Vector3(0, 1, -4);

    // Lerp factor
    [SerializeField]
    private float m_LerpFactor = 4;


    #endregion


    // Camera component accessors
    public Camera CameraComponent
    {
        get { return m_Camera; }
    }



    // Use this for initialization
    protected void Start()
    {
        // Get camera component
        m_Camera = GetComponent<Camera>();

    }

    
   
    // Called at fixed time
    void FixedUpdate()
    {
        //  Camera follow character. Written in fixed update to avoid camera lerp break
        if (m_Character != null)
        {
            // Calculate local offset depending on dodge action
            Vector3 localOffset = m_Character.transform.right * m_CharacterOffset.x + m_Character.transform.up * m_CharacterOffset.y + m_Character.transform.forward * m_CharacterOffset.z;

            
            // Update position based on offset
            Vector3 desiredPosition = m_Character.transform.position + localOffset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.fixedDeltaTime * m_LerpFactor);

            // Follow character rotation depending on dodge action
            
                transform.rotation = Quaternion.Lerp(transform.rotation, m_Character.transform.rotation, Time.fixedDeltaTime * m_LerpFactor);
            
        }
    }
}
