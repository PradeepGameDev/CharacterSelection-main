using UnityEngine;

public class TankView : MonoBehaviour
{
    [Header("General")]
    public Transform firePoint;
    public Rigidbody rb;
    public Renderer[] renderers;

    [Header("Audio")]
    public AudioClip driving;
    public AudioClip idle;
    public AudioSource source;

    private TankController m_controller;

    private float m_movementInput;
    private float m_rotationInput;

    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }

        var camera = Camera.main;
        if (camera != null)
        {
            camera.transform.SetParent(transform);
            camera.transform.position = new Vector3(0, 3, -3.5f);
        }

        if (source == null)
        {
            source = GetComponent<AudioSource>();
        }
    }

    private void Update()
    {
        GetInput();
        HandleFire();
        Movement();
        PlayMovementAudio();
    }

    private void GetInput()
    {
        m_movementInput = Input.GetAxis(VERTICAL);
        m_rotationInput = Input.GetAxis(HORIZONTAL);
    }

    private void Movement()
    {
        if (m_movementInput != 0)
        {
            m_controller.Move(m_movementInput, m_controller.GetTankModel().movementSpeed);
        }

        if (m_rotationInput!= 0)
        {
            m_controller.Rotate(m_rotationInput, m_controller.GetTankModel().rotationSpeed);
        }
    }

    private void PlayMovementAudio()
    {
        if (rb.velocity != Vector3.zero && source.clip != driving)
        {
            source.clip = driving;
            source.Play();
        }
        else if (rb.velocity == Vector3.zero && source.clip != idle)
        {
            source.clip = idle;
            source.Play();
        }
    }

    private void HandleFire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_controller.Fire();
        }
    }

    public void SetController(TankController tankController) => m_controller = tankController;

    public Rigidbody GetRigidbody() => rb;

    public void SetMaterial(Material material)
    {
        for(int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material = material;
        }
    }
}
