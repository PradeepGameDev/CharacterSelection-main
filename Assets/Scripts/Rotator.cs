using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed;

    private float m_rotation;

    private void Update()
    {
        m_rotation += rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, m_rotation, 0);
    }
}