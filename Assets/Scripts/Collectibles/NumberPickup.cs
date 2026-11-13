using UnityEngine;
public class NumberPickup : MonoBehaviour
{
    [SerializeField] private int value = 1;
    public void SetValue(int amount) => value = amount;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        MathGameState.Collect(value);
        Destroy(gameObject);
    }
}
