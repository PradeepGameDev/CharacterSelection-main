using UnityEngine;

public class TankController
{
    private TankModel m_model;
    private TankView m_view;

    private Rigidbody m_rb;

    private Vector3 m_targetDirection;

    private CameraController m_cameraController;

    public TankController(TankModel tankModel, TankView tankView, CameraController cameraController)
    {
        m_model = tankModel;
        m_view = GameObject.Instantiate<TankView>(tankView);
        m_rb = m_view.GetRigidbody();
        m_cameraController = cameraController;

        m_model.SetController(this);
        m_view.SetController(this);

        m_view.SetMaterial(m_model.material);
        m_cameraController.SetPlayer(m_view.transform);
    }

    public TankModel GetTankModel() => m_model;

    public void Move(float movement, float movementSpeed)
    {
        m_rb.velocity = movement * movementSpeed * m_view.transform.forward;
    }

    public void Rotate(float rotation, float rotationSpeed)
    {
        m_targetDirection.y = rotation * rotationSpeed * Time.deltaTime;
        m_rb.MoveRotation(m_rb.rotation * Quaternion.Euler(m_targetDirection));
    }

    internal void Fire()
    {
        ShellScript newShell = GameObject.Instantiate<ShellScript>(m_model.shellPrefab);
        newShell.SetShellProperties(m_view.firePoint, m_cameraController);
        m_cameraController.CameraShake();
    }
}
