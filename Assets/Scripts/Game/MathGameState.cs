using UnityEngine;
using UnityEngine.InputSystem;
public class MathGameState : MonoBehaviour
{
    [SerializeField] private int targetSum = 10;
    [SerializeField] private float timeLimit = 90f;
    private static MathGameState instance;
    private int sum;
    private float timeLeft;
    private bool finished;
    public static bool Finished => instance == null || instance.finished;
    private void Awake() { instance = this; timeLeft = timeLimit; }
    private void Start() => GameSignals.Score(sum);
    private void Update()
    {
        if (Keyboard.current != null && Keyboard.current.rKey.wasPressedThisFrame)
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        if (finished) return;
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0) End("Game Over — time expired");
    }
    public static void Collect(int value)
    {
        if (Finished) return;
        instance.sum += value;
        GameSignals.Score(instance.sum);
    }
    public static void TryWin()
    {
        if (Finished) return;
        if (instance.sum == instance.targetSum) instance.End("Correct sum! You win!");
        else instance.End("Wrong sum! Game Over");
    }
    public static void Lose() { if (!Finished) instance.End("Game Over — fell into danger"); }
    private void End(string message) { finished = true; GameSignals.Finish(message); }
    private void OnDestroy() { if (instance == this) instance = null; }
}
