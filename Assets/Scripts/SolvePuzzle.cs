using UnityEngine;

public class SolvePuzzle : MonoBehaviour
{
    public int totalPlaceholders = 3;
    public AudioSource successAudio;
    private int correctCount = 0;
    public void RegisterCorrectPlacement()
    {
        correctCount++;

        if (correctCount >= totalPlaceholders && successAudio != null)
        {
            successAudio.Play();
        }
    }
}
