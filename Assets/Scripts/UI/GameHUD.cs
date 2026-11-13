using UnityEngine;
public class GameHUD : MonoBehaviour
{
    [SerializeField] private string instructions = "";
    private int score;
    private string result;
    private void OnEnable()
    {
        GameSignals.ScoreChanged += OnScore;
        GameSignals.GameFinished += OnFinished;
    }
    private void OnDisable()
    {
        GameSignals.ScoreChanged -= OnScore;
        GameSignals.GameFinished -= OnFinished;
    }
    public void Configure(string text) => instructions = text;
    private void OnScore(int value) => score = value;
    private void OnFinished(string value) => result = value;
    private void OnGUI()
    {
        GUI.Box(new Rect(12, 12, Mathf.Min(Screen.width - 24, 650), 84),
            instructions + "\nScore: " + score);
        if (string.IsNullOrEmpty(result)) return;
        GUI.Box(new Rect(Screen.width / 2f - 190, Screen.height / 2f - 60, 380, 120),
            result + "\nPress R to restart");
    }
}
