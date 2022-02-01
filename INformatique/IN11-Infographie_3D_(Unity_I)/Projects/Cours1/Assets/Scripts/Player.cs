using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Player : MonoBehaviour
{
    [Header("Motion Setup")]
    [Tooltip("Translation Speed in m.s-1")]
    [SerializeField] float m_TranslationSpeed; // m/s
    [Tooltip("Rotation Speed in °.s-1")]
    [SerializeField] float m_RotationSpeed; // °/s

    Transform m_Transform;
    Rigidbody m_Rigidbody;

    [Header("Ball Setup")]
    [SerializeField] GameObject m_BallPrefab;
    [SerializeField] Transform m_BallSpawnPosition;
    [SerializeField] float m_BallStartVelocity;
    [SerializeField] int m_BallLifeDuration;
    [SerializeField] float m_BallShootCoolDownDuration;

    float m_BallNextShootTime;

    private void Awake()
    {
        m_Transform = GetComponent<Transform>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        m_BallNextShootTime = Time.time;
    }

    // Update is called once per frame

    // Comportement cinématique -> les positions & orientations sont forcées par le script
        // Translate, Rotate
    void Update()
    {
        /**
        float vInput = Input.GetAxis("Vertical");
        float hInput = Input.GetAxis("Horizontal");

        // Debug.Log("vInput = " + vInput);

        // Translation
        //
        // en modifiant directement transform.position
        // Vector3 moveVect = vInput * m_Transform.forward * m_TranslationSpeed * Time.deltaTime;
        // transform.position += moveVect;
        //
        // Translation en utilisant la méthode transform.Translate()
        // Space.World
        // Vector3 moveVect = vInput * m_Transform.forward * m_TranslationSpeed * Time.deltaTime;
        // transform.Translate(moveVect, Space.World);
        //
        // Space.Self
        Vector3 moveVect = vInput * Vector3.forward * m_TranslationSpeed * Time.deltaTime;
        m_Transform.Translate(moveVect, Space.Self);

        // Rotation
        // En modifiant directement transform.rotation

        // En utilisant la méthode transform.Rotate()
        float deltaAngle = hInput * m_RotationSpeed * Time.deltaTime;
        // transform.Rotate(m_Transform.up, deltaAngle, Space.World);
        m_Transform.Rotate(Vector3.up, deltaAngle, Space.Self);
        */
    }

    // Comportement cinétique (physique) -> les positions & orientations de l'objet sont calculées par le moteur physique d'Unity
        // FixedUpdate(), rigidbody, fixedDeltaTime
    private void FixedUpdate()
    {
        float vInput = Input.GetAxis("Vertical");
        float hInput = Input.GetAxisRaw("Horizontal");

        // Translation & Rotation via les méthodes rigidbody.MovePosition() et rigidbody.MoveRotation()
        /*
        Vector3 moveVect = vInput * m_Transform.forward * m_TranslationSpeed * Time.fixedDeltaTime;
        Vector3 newPos = m_Rigidbody.position + moveVect;
        m_Rigidbody.MovePosition(newPos);

        Quaternion qUprightRot = Quaternion.FromToRotation(m_Transform.up, Vector3.up);

        Quaternion qUprightOrientation = qUprightRot * m_Rigidbody.rotation;
        Quaternion qSlerpedUprightOrientation = Quaternion.Slerp(m_Rigidbody.rotation, qUprightOrientation, Time.fixedDeltaTime * 50);

        Vector3 uprightUp = qSlerpedUprightOrientation * Vector3.up;
        float deltaAngle = hInput * m_RotationSpeed * Time.fixedDeltaTime;
        Quaternion qRot = Quaternion.AngleAxis(deltaAngle, uprightUp);

        Quaternion qNewOrientation = qRot * qSlerpedUprightOrientation;
        m_Rigidbody.MoveRotation(qNewOrientation);

        // Casser l'inertie
        m_Rigidbody.AddForce(-Vector3.ProjectOnPlane(m_Rigidbody.velocity, Vector3.up), ForceMode.VelocityChange);
        m_Rigidbody.AddTorque(-m_Rigidbody.angularVelocity, ForceMode.VelocityChange);
        */

        // Translation & Rotation via les méthodes rigidbody.AddForce() et rigidbody.AddTorque()
        Vector3 newVelocity = vInput * m_TranslationSpeed * m_Transform.forward;
        Vector3 velocityChange = newVelocity - Vector3.ProjectOnPlane(m_Rigidbody.velocity, Vector3.up);
        m_Rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);

        Vector3 newAngularVelocity = hInput * m_RotationSpeed * m_Transform.up;
        Vector3 angularVelocityChange = newAngularVelocity - m_Rigidbody.angularVelocity;
        m_Rigidbody.AddTorque(angularVelocityChange, ForceMode.VelocityChange);

        Vector3 uprightTorque = Vector3.Cross(m_Transform.up, Vector3.up) * Vector3.Angle(m_Transform.up, Vector3.up) * Mathf.Deg2Rad * 5000;
        m_Rigidbody.AddTorque(uprightTorque, ForceMode.Force);

        bool fire = Input.GetButton("Fire1");
        if (fire && Time.time > m_BallNextShootTime)
        {
            ShootBall();
            m_BallNextShootTime = Time.time + m_BallShootCoolDownDuration;
        }
    }

    void ShootBall()
    {
        GameObject newBallGO = Instantiate(m_BallPrefab,m_BallSpawnPosition.position, Quaternion.identity);
        Rigidbody rigidbody = newBallGO.GetComponent<Rigidbody>();
        rigidbody.velocity = m_BallSpawnPosition.forward * m_BallStartVelocity;
        Destroy(newBallGO, m_BallLifeDuration);
    }
}
