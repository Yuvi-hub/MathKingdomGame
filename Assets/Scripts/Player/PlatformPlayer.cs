using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody2D))]
public class PlatformPlayer : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float jumpImpulse = 9f;
    private Rigidbody2D body;
    private bool grounded;
    private float horizontal;
    private void Awake() => body = GetComponent<Rigidbody2D>();
    private void Update()
    {
        if (Keyboard.current == null || MathGameState.Finished) { horizontal = 0; return; }
        var k = Keyboard.current;
        horizontal = (k.dKey.isPressed || k.rightArrowKey.isPressed ? 1 : 0) -
            (k.aKey.isPressed || k.leftArrowKey.isPressed ? 1 : 0);
        if (grounded && (k.spaceKey.wasPressedThisFrame || k.upArrowKey.wasPressedThisFrame))
        {
            body.AddForce(Vector2.up * jumpImpulse, ForceMode2D.Impulse);
            grounded = false;
        }
    }
    private void FixedUpdate() => body.linearVelocity = new Vector2(horizontal * moveSpeed, body.linearVelocity.y);
    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (var contact in collision.contacts)
            if (contact.normal.y > 0.45f) grounded = true;
        if (collision.gameObject.CompareTag("Respawn")) MathGameState.Lose();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        foreach (var contact in collision.contacts)
            if (contact.normal.y > 0.45f) grounded = true;
    }
    private void OnCollisionExit2D(Collision2D collision) => grounded = false;
}
