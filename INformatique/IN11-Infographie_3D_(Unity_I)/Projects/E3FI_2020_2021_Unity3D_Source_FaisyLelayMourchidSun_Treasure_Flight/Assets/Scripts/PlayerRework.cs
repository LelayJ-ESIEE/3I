using SDD.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerRework : MonoBehaviour
{
    // 
    [Header("Motion Setup")]
    [Tooltip("Translation Speed in m.s-1")]
    [SerializeField] float m_TranslationSpeed;
    [Tooltip("Rotation Left/Right Speed in �.s-1")]
    [SerializeField] float m_RotationLRSpeed;
    [Tooltip("Rotation Up/Down Speed in �.s-1")]
    [SerializeField] float m_RotationUDSpeed;
    [Tooltip("Strafe Left/Right Speed in �.s-1")]
    [SerializeField] float m_StrafeLRSpeed;
    [Tooltip("Coef resistance de l'air contraire aux moteurs (test)")]
    [SerializeField] float m_drag;
    [Tooltip("Coef lift")]
    [SerializeField] float m_lift;
    [Tooltip("Plane mass (*9.8 to get Weight)")]
    [SerializeField] float m_mass;

    [Header("Player Settings")]
    [SerializeField] float m_MinSpeedCrash;
    [Tooltip("HP loosed in hp.s-1")]
    [SerializeField] float m_HpLoosedOnCollision;
    [SerializeField] float m_Maxhealth;
    float m_Health;

    //[SerializeField] GameObject m_Capsule;
    bool gameIsRunning = true;

    // Inputs
    InputSettings controls;
    bool stopEngine;
    bool accelerate;
    float rotationLR;
    float rotationUD;
    float strafeLR;
    
    float AngleFromUp;

    Transform m_Transform;
    Rigidbody m_Rigidbody;

    float m_previousSpeed;
    Vector3 m_previousPos;
    Vector3 m_velocity;

    private void Awake()
    {
        m_Health = m_Maxhealth;

        m_Transform = GetComponent<Transform>();
        m_Rigidbody = GetComponent<Rigidbody>();

        controls = new InputSettings();

        controls.Player.RotationLR.performed += context => rotationLR = context.ReadValue<float>();
        controls.Player.RotationUD.performed += context => rotationUD = context.ReadValue<float>();
        controls.Player.StrafeLR.performed += context => strafeLR = context.ReadValue<float>();
        controls.Player.RotationLR.canceled += context => rotationLR = 0;
        controls.Player.RotationUD.canceled += context => rotationUD = 0;
        controls.Player.StrafeLR.canceled += context => strafeLR = 0;
        controls.Player.Pause.started += context => EventManager.Instance.Raise(new PlayerPressPauseEvent());


        // Bouton couper moteurs
        controls.Player.StopEngine.started += context => ToggleEngine();
        controls.Player.StopEngine.canceled += context => ToggleEngine(true);

        // Bouton accelerer
        controls.Player.Accelerate.started += context => ToggleAcceleration();
        controls.Player.Accelerate.canceled += context => ToggleAcceleration(true);

        // Bouton reset
        controls.Player.Restart.started += context =>
        {
            EventManager.Instance.Raise(new PlayerResetEvent() { playerTransform = m_Transform, playerRigidbody = m_Rigidbody });
        };

        m_Rigidbody.useGravity = false;

        EventManager.Instance.AddListener<PlayerCrashEvent>(Crash);
        EventManager.Instance.AddListener<GamePauseEvent>(GamePause);
        EventManager.Instance.AddListener<GameResumeEvent>(GameResume);
    }

    // Start is called before the first frame update
    void Start()
    {
        m_previousPos = m_Transform.position;
    }

    private void OnEnable()
    {
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }

    private void OnDestroy()
    {
        EventManager.Instance.RemoveListener<PlayerCrashEvent>(Crash);
        EventManager.Instance.RemoveListener<GamePauseEvent>(GamePause);
        EventManager.Instance.RemoveListener<GameResumeEvent>(GameResume);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(m_previousSpeed > m_MinSpeedCrash)
        {
            m_Health = 0;
            Debug.Log("Crash !");
        }
        EventManager.Instance.Raise(new PlayerCollisonEvent() { playerTransform = m_Transform, playerRigidbody = m_Rigidbody, hpLeft = m_Health });
    }

    private void OnCollisionStay(Collision collision)
    {
        m_Health -= m_HpLoosedOnCollision * Time.deltaTime;
        EventManager.Instance.Raise(new PlayerCollisonEvent() { playerTransform = m_Transform, playerRigidbody = m_Rigidbody, hpLeft = m_Health });
        Debug.Log("HP: " + m_Health);
    }

    // Comportement cin�matique -> Les positions sont forc�es par le code
    // Update(), transform, deltaTime
    // Update is called once per frame
    void Update()
    {
        if (gameIsRunning)
        {
            //setColorCapsule();
            m_previousSpeed = m_Rigidbody.velocity.magnitude;
            // Vitesse calcul�e
            m_velocity = (m_Transform.position - m_previousPos) / Time.deltaTime;
            m_previousPos = m_Transform.position;
            Debug.DrawLine(m_Transform.position + Vector3.up, m_Transform.position + Vector3.up + m_velocity, Color.red);
        }
    }

    // Comportement cin�tique (Physique) ->
    // FixedUpdate(), rigidBody, fixedDeltaTime
    private void FixedUpdate()
    {
        if (gameIsRunning)
        {
            AngleFromUp = -(Vector3.Angle(m_Transform.forward, Vector3.up) - 90) / 90;

            /**
             * https://gamedev.stackexchange.com/questions/186777/simplified-aerodynamics-for-3d-airplane
             * p  the air density
             * S the equivalent surface of your plane (more wing surface -> more drag and lift)
             * V the plane airspeed (speed relative to the air: a plane at 100 kts with a front wind of 20 kts has an airspeed of 120 kts)
             * Cx the drag coefficient depending on the plane geometry and the angle of incidence
             * 
             * Drag = In your simplified model: A.V2 with A a well-tuned constant and V the airspeed of your plane.
             * Lift = In your simplified model : A.V2 with A a well-tuned constant and V the airspeed of your plane.
             */
            float forwardSpeed = Vector3.Project(m_Rigidbody.velocity, m_Transform.forward).magnitude; //m_Rigidbody.velocity.magnitude;
            Vector3 drag = -m_Rigidbody.velocity.normalized * (forwardSpeed * forwardSpeed) * m_drag;
            m_Rigidbody.AddForce(drag, ForceMode.Acceleration);

            float isGoingForward = Mathf.Abs(Vector3.Angle(m_Rigidbody.velocity, m_Transform.forward)) < Mathf.Abs(Vector3.Angle(m_Rigidbody.velocity, -m_Transform.forward)) ? 1 : -1;
            float speedTransferCoef = 1;
            if (isGoingForward == -1f && AngleFromUp > 0) speedTransferCoef = AngleFromUp;
            m_Rigidbody.AddForce(-m_Rigidbody.velocity.normalized * forwardSpeed * m_lift * speedTransferCoef, ForceMode.Acceleration);
            m_Rigidbody.AddForce(isGoingForward * m_Transform.forward * forwardSpeed * m_lift * speedTransferCoef, ForceMode.Acceleration); //Transf�re la vitesse en avant si on avance et en arri�re si on recule


            Vector3 weight = Vector3.down * 9.8f * m_mass;
            m_Rigidbody.AddForce(weight, ForceMode.Acceleration);

            #region debug
            /*Debug.Log("######################");
            if (AngleFromUp > 0) Debug.Log("Orientation: Pointe vers le haut");
            else Debug.Log("Orientation: Pointe vers le bas");
            if (m_Rigidbody.velocity.y > 0) Debug.Log("Gravit�: Monte");
            else Debug.Log("Gravit�: Descends");
            Debug.Log("######################");*/
            #endregion

            //### Translation ###
            if (!stopEngine)
            {
                Vector3 thrust = m_TranslationSpeed * m_Transform.forward * (accelerate ? 2 : 1);
                m_Rigidbody.AddForce(thrust, ForceMode.Acceleration);
            }

            //### Rotations ###
            Vector3 addAngularVelocity;

            // Rotation Haut et Bas
            addAngularVelocity = rotationUD * m_Transform.right * m_RotationUDSpeed;
            m_Rigidbody.AddTorque(addAngularVelocity, ForceMode.Acceleration);

            // Rotation Gauche et Droite
            addAngularVelocity = -rotationLR * m_Transform.forward * m_RotationLRSpeed;
            m_Rigidbody.AddTorque(addAngularVelocity, ForceMode.Acceleration);

            // Strafe Gauche et Droite
            addAngularVelocity = strafeLR * m_Transform.up * m_StrafeLRSpeed;
            m_Rigidbody.AddTorque(addAngularVelocity, ForceMode.Acceleration);

            EventManager.Instance.Raise(new PlayerMoveEvent() { velocity = m_Rigidbody.velocity });
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (m_Transform)
        {
            Gizmos.DrawLine(m_Transform.position + Vector3.up, m_Transform.position + Vector3.up + m_velocity);
        }
    }

    /*void setColorCapsule()
    {
        if (stopEngine)
        {
            m_Capsule.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
        }
        else if (accelerate)
        {
            m_Capsule.GetComponentInChildren<MeshRenderer>().material.color = Color.green;
        }
        else
        {
            m_Capsule.GetComponentInChildren<MeshRenderer>().material.color = Color.white;
        }
    }*/

    void ToggleEngine(bool activate = false)
    {
        if (stopEngine && activate)
        {
            stopEngine = false;
            
        }
        else
        {
            stopEngine = true;
        }
    }

    void ToggleAcceleration(bool activate = false)
    {
        if (accelerate && activate)
        {
            accelerate = false;
        }
        else
        {
            accelerate = true;
        }
    }

    void Crash(PlayerCrashEvent e)
    {
        m_Health = m_Maxhealth;
    }

    void GameResume(GameResumeEvent e)
    {
        gameIsRunning = true;
    }

    void GamePause(GamePauseEvent e)
    {
        gameIsRunning = false;
    }
}
