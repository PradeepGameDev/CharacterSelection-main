using UnityEngine;

public class TankSelection : MonoBehaviour
{
    public TankSpawner tankSpawner;

    // Start is called before the first frame update
    void Start()
    {
        if (tankSpawner == null)
        {
            tankSpawner = FindObjectOfType<TankSpawner>(true);
        }
    }

    private void HideUI() => gameObject.SetActive(false);

    public void OnGreenTankClick()
    {
        tankSpawner.CreateTank(TankType.GreenTank);
        HideUI();
    }

    public void OnBlueTankClick()
    {
        tankSpawner.CreateTank(TankType.BlueTank);
        HideUI();
    }

    public void OnRedTankClick()
    {
        tankSpawner.CreateTank(TankType.RedTank);
        HideUI();
    }
}
