using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button btnA, btnB, btnC, btnD;
    private int currentUnlocked = 0; // 0 = A, 1 = B, etc.

    void Start()
    {
        UpdateButtons();
        btnA.onClick.AddListener(() => LoadLevel("LevelA"));
        btnB.onClick.AddListener(() => LoadLevel("LevelB"));
        btnC.onClick.AddListener(() => LoadLevel("LevelC"));
        btnD.onClick.AddListener(() => LoadLevel("LevelD"));
    }

    void UpdateButtons()
    {
        btnA.interactable = (currentUnlocked >= 0);
        btnB.interactable = (currentUnlocked >= 1);
        btnC.interactable = (currentUnlocked >= 2);
        btnD.interactable = (currentUnlocked >= 3);
    }

    public void UnlockNextLevel()
    {
        if (currentUnlocked < 3)
        {
            currentUnlocked++;
            UpdateButtons();
        }
    }

    void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
