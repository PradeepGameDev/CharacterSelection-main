using UnityEngine;

[System.Serializable]
public class TankModel
{
    public float movementSpeed;
    public float rotationSpeed;

    public TankType type;

    public Material material;
    public ShellScript shellPrefab;

    private TankController m_controller;

    public TankModel(float _movementSpeed, float _rotationSpeed, TankType _type, Material _material, ShellScript _shell)
    {
        movementSpeed = _movementSpeed;
        rotationSpeed = _rotationSpeed;
        type = _type;
        material = _material;
        shellPrefab = _shell;
    }

    public void SetController(TankController tankController) => m_controller = tankController;
}
