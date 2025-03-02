using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    public TankView tankView;

    [System.Serializable]
    public class Tank
    {
        public float movementSpeed;
        public float rotationSpeed;

        public TankType type;

        public Material material;
        public ShellScript shellPrefab;
    }

    public CameraController cameraController;

    public Tank[] tankList;

    public void CreateTank(TankType type)
    {
        if(tankList == null || tankList.Length <= 0)
        {
            Debug.LogError("Tank list is empty!");
            return;
        }

        int index = (int)type;
        TankModel model = new(
                tankList[index].movementSpeed, 
                tankList[index].rotationSpeed, 
                tankList[index].type, 
                tankList[index].material, 
                tankList[index].shellPrefab
            );

        TankController tankController = new(model, tankView, cameraController);
    }
}
