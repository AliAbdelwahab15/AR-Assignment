using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameWorker : MonoBehaviour
{
    public AudioSource successAudio;
    public GameObject winCanvas;
    public Button restartButton;
    private int totalPlaceholders;
    private int correctCount = 0;
    private bool hasWon = false;

    private void Start()
    {
        if (winCanvas != null)
        {
            winCanvas.SetActive(false);
        }

        CubeHolder[] placeholders = FindObjectsOfType<CubeHolder>();
        totalPlaceholders = placeholders.Length;

        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartScene);
        }
    }

    public void RegisterCorrectPlacement()
    {
        if (hasWon)
            return;

        correctCount++;
        if (correctCount >= totalPlaceholders)
        {
            TriggerWin();
        }
    }

    private void TriggerWin()
    {
        hasWon = true;

        AudioSource[] allSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource src in allSources)
        {
            if (src != successAudio)
                src.Stop();
        }

        if (successAudio != null)
        {
            successAudio.Play();
        }

        if (winCanvas != null)
        {
            winCanvas.SetActive(true);
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene("ARAssignment");
    }
}
