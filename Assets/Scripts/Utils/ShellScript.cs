using UnityEngine;

public class ShellScript : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    public GameObject trail;
    public Rigidbody shellBody;
    public MeshRenderer shellMesh;
    public Collider shellCollider;

    public float maxVelocity = 10;
    public float shellLifeTime = 5;
    public float explosionRadius = 2;
    public float explosionForce = 1000;

    public AudioClip shootingClip;
    public AudioClip explosionClip;
    public AudioSource source;

    private CameraController m_camera;

    private bool m_IsExploded = false;

    private void Start() => shellBody.velocity = maxVelocity * transform.forward;

    private void Update() => transform.forward = shellBody.velocity;

    private void OnCollisionEnter(Collision collision) => Explode();

    public void SetShellProperties(Transform exitPoint, CameraController camera)
    {
        m_camera = camera;

        SetShootingAudio();
        SetShellActive(true);
        transform.SetPositionAndRotation(exitPoint.position, exitPoint.rotation);

        // just precaution, if the shell didnt hit anything
        // it'll still explode after lifetime
        m_IsExploded = false;
        Invoke(nameof(Explode), shellLifeTime);
    }

    private void SetShootingAudio()
    {
        source.clip = shootingClip;
        source.Play();
    }

    private void Explode()
    {
        if (m_IsExploded)
        {
            return;
        }

        m_IsExploded = true;

        SetShellActive(false);
        CheckInRadius();
        SetOffExplosion();
    }

    private void CheckInRadius()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider col in cols)
        {
            if (col.TryGetComponent(out TankView tank))
            {
                tank.GetRigidbody().AddExplosionForce(explosionForce, transform.position, explosionRadius);
                continue;
            }

            if (col.TryGetComponent(out TargetScript target))
            {
                target.ChangePosition();
            }
        }
    }

    private void SetShellActive(bool active)
    {
        shellMesh.enabled = active;
        shellCollider.enabled = active;
        trail.SetActive(active);
    }

    private void SetOffExplosion()
    {
        m_camera.CameraShake();

        explosionParticle.transform.SetPositionAndRotation(transform.position, Quaternion.Euler(-90, 0, 0));
        explosionParticle.Play();

        source.clip = explosionClip;
        source.Play();

        Destroy(gameObject, explosionParticle.main.duration);
    }
}