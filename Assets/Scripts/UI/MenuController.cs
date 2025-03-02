using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameManager gameManager;
    public TankSpawner tankSpwaner;

    public GameObject startPanel;
    public GameObject endPanel;
    public GameObject scorePanel;
    public TextMeshProUGUI score;
    public TextMeshProUGUI finalScore;
    public TextMeshProUGUI timer;

    public Transform menuTank;

    private TankType m_selectedType;

    private void Start()
    {
        m_selectedType = TankType.GreenTank;

        startPanel.SetActive(true);
        endPanel.SetActive(false);
        scorePanel.SetActive(false);
    }

    public void SetTankType(int selected)
    {
        m_selectedType = (TankType)selected;
        SetTankColor();
    }

    private void SetTankColor()
    {
        Material tankMaterial = tankSpwaner.tankList[(int)m_selectedType].material;
        Transform tankBody = menuTank.GetChild(0);
        foreach (Transform part in tankBody)
        {
            part.GetComponent<MeshRenderer>().material = tankMaterial;
        }
    }

    public void StartGame()
    {
        tankSpwaner.CreateTank(m_selectedType);
        menuTank.gameObject.SetActive(false);
        startPanel.SetActive(false);
        scorePanel.SetActive(true);

        gameManager.StartGame();
    }

    public void EndGame(int score)
    {
        endPanel.SetActive(true);
        scorePanel.SetActive(false);
        finalScore.text = "Target Destroyed : " + score;
    }

    public void UpdateScore(int value)
    {
        score.text = "Target Destroyed : " + value;
    }

    public void UpdateTimer(float value)
    {
       timer.text = "Time Left: " + (int)value;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}