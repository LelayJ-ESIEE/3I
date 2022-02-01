using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IColorize
{
    [Header("Motion Setup")]
    [Tooltip("unit: m.s-1")]
    [SerializeField] float m_TranslationSpeed;  // m/s
    [Tooltip("unit: °.s-1")]
    [SerializeField] float m_RotationSpeed; // °/s

    Transform m_Transform;
    Rigidbody m_Rigidbody;

    [Header("Ball Setup")]
    [SerializeField] GameObject m_BallPrefab;
    [SerializeField] float m_BallStartVelocity;
    [SerializeField] Transform m_BallSpawnPosition;
    [SerializeField] float m_BallLifeDuration;
    [SerializeField] float m_BallCoolDownDuration;
    float m_BallNextShotTime;

    private void Awake()
    {
        m_Transform = GetComponent<Transform>(); // idem que .transform
        m_Rigidbody  = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        m_BallNextShotTime = Time.time;
    }

    // 2 types de comportement
    // comportement cinématique -> Update()  ... vous forcez les position/orientation de l'objet via votre script
   
    // Update is called once per frame
    void Update()
    {
      /*  float vInput = Input.GetAxis("Vertical");   //entre -1 et 1
        float hInput = Input.GetAxis("Horizontal");   //entre -1 et 1

        //Translation
        //Vector3 moveVect = vInput*m_Transform.forward * m_TranslationSpeed * Time.deltaTime;
        Vector3 moveVect = vInput * Vector3.forward * m_TranslationSpeed * Time.deltaTime;
        //m_Transform.position += moveVect;

        //m_Transform.Translate(moveVect, Space.World);
        m_Transform.Translate(moveVect, Space.Self);

        //Rotation
        //m_Transform.rotation
        float angle = hInput*m_RotationSpeed * Time.deltaTime;
        //m_Transform.Rotate(m_Transform.up, angle, Space.World);
        m_Transform.Rotate(Vector3.up, angle, Space.Self);*/
    }

    // comportement cinétique (physique) -> FixedUpdate() ... les position/rotation de l'objet sont calculées par le moteur physique
    // rigidbody , Time.fixedDeltaTime
    private void FixedUpdate()
    {
        if (!GameManager.Instance.IsPlaying) return;

        float vInput = Input.GetAxis("Vertical");   //entre -1 et 1
        float hInput = Input.GetAxisRaw("Horizontal");   //entre -1 et 1

        bool fire1 = Input.GetButton("Fire1");

        #region  MovePostion & MoveRotation
        /*        //Translation
                Vector3 moveVect = vInput*m_Transform.forward * m_TranslationSpeed * Time.fixedDeltaTime;
                Vector3 newPos = m_Rigidbody.position + moveVect;
                m_Rigidbody.MovePosition(newPos);

                //Rotation
                float angle = hInput * m_RotationSpeed * Time.fixedDeltaTime;
                Quaternion qRot = Quaternion.AngleAxis(angle, m_Transform.up);
                Quaternion qUprightRot = Quaternion.FromToRotation(m_Transform.up, Vector3.up);

                Quaternion qSlightUprightOrientation = 
                    Quaternion.Slerp(m_Rigidbody.rotation, qUprightRot * m_Rigidbody.rotation, Time.fixedDeltaTime * 4);

                Quaternion newOrientation = qRot * qSlightUprightOrientation;
                m_Rigidbody.MoveRotation(newOrientation);
        */
        #endregion

        // AddForce & AddTorque
        Vector3 newVelocity = m_Transform.forward * m_TranslationSpeed*vInput;
        Vector3 velocityChange = newVelocity - m_Rigidbody.velocity;
        m_Rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);

        Vector3 newAngularVelocity = m_Transform.up * m_RotationSpeed * Mathf.Deg2Rad*hInput;
        Vector3 angularVelocityChange = newAngularVelocity- m_Rigidbody.angularVelocity;
        m_Rigidbody.AddTorque(angularVelocityChange, ForceMode.VelocityChange);

        Vector3 uprightTorque = 
            Vector3.Cross(m_Transform.up, Vector3.up) * Vector3.Angle(m_Transform.up, Vector3.up) * Mathf.Deg2Rad * 2000;
        m_Rigidbody.AddTorque(uprightTorque, ForceMode.Force);

        // Ball throwing
        if (fire1 && m_BallNextShotTime < Time.time)
        {
            ThrowBall();
            m_BallNextShotTime = Time.time + m_BallCoolDownDuration;
        }

        //Debug
        //Debug.DrawLine(m_Transform.position + Vector3.up, m_Transform.position + Vector3.up + m_Rigidbody.velocity,Color.red);

        //if (Time.time > 3) Debug.Break();

    }

    void ThrowBall()
    {
        GameObject newBallGO = Instantiate(m_BallPrefab);
        newBallGO.transform.position = m_BallSpawnPosition.position;
        newBallGO.GetComponent<Rigidbody>().velocity = m_BallSpawnPosition.forward * m_BallStartVelocity;

        Destroy(newBallGO, m_BallLifeDuration);
        //cool down duration
    }

    public void Colorize()
    {
        MyTools.ChangeColorRandom(gameObject);
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawLine(m_Transform.position + Vector3.up, m_Transform.position + Vector3.up + m_Rigidbody.velocity);

    //}
}
