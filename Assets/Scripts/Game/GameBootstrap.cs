using UnityEngine;
public class GameBootstrap : MonoBehaviour
{
    [SerializeField] private Color skyColor = new Color(0.12f, 0.18f, 0.3f);
    private Sprite squareSprite;
    private void Start()
    {
        var texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, Color.white);
        texture.Apply();
        squareSprite = Sprite.Create(texture, new Rect(0, 0, 1, 1), new Vector2(0.5f, 0.5f), 1f);
        var camera = new GameObject("Main Camera").AddComponent<Camera>();
        camera.orthographic = true;
        camera.orthographicSize = 6.5f;
        camera.transform.position = new Vector3(0, 1, -10);
        camera.backgroundColor = skyColor;
        Block("Ground Left", new Vector2(-6.5f, -4.6f), new Vector2(7, 1), Color.gray, false);
        Block("Ground Middle", new Vector2(0, -4.6f), new Vector2(4, 1), Color.gray, false);
        Block("Ground Right", new Vector2(6.5f, -4.6f), new Vector2(7, 1), Color.gray, false);
        Block("Platform 1", new Vector2(-4, -1.8f), new Vector2(3, 0.5f), Color.gray, false);
        Block("Platform 2", new Vector2(0, 0.2f), new Vector2(3, 0.5f), Color.gray, false);
        Block("Platform 3", new Vector2(4, 1.8f), new Vector2(3, 0.5f), Color.gray, false);
        var player = Block("Player", new Vector2(-8, -3.4f), new Vector2(0.8f, 0.8f), Color.cyan, false);
        player.tag = "Player";
        var rb = player.AddComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        player.AddComponent<PlatformPlayer>();
        Number(new Vector2(-4, -0.9f), 2);
        Number(new Vector2(0, 1.1f), 3);
        Number(new Vector2(4, 2.7f), 5);
        var goal = Block("Goal Portal", new Vector2(8.5f, -3.4f), new Vector2(1, 1.5f), Color.green, true);
        goal.AddComponent<GoalPortal>();
        var hazard = Block("Hazard", new Vector2(0, -7f), new Vector2(30, 0.5f), Color.red, false);
        hazard.tag = "Respawn";
        gameObject.AddComponent<MathGameState>();
        gameObject.AddComponent<GameHUD>().Configure("MATH KINGDOM — A/D or arrows move, Space/Up jumps; collect 2+3+5=10 and reach green portal; R restart");
    }
    private GameObject Block(string name, Vector2 position, Vector2 size, Color color, bool trigger)
    {
        var obj = new GameObject(name);
        obj.transform.position = position;
        obj.transform.localScale = new Vector3(size.x, size.y, 1);
        var sprite = obj.AddComponent<SpriteRenderer>();
        sprite.sprite = squareSprite;
        sprite.color = color;
        var collider = obj.AddComponent<BoxCollider2D>();
        collider.isTrigger = trigger;
        return obj;
    }
    private void Number(Vector2 position, int value)
    {
        var obj = Block("Number " + value, position, Vector2.one * 0.7f, Color.yellow, true);
        obj.AddComponent<NumberPickup>().SetValue(value);
        var label = new GameObject("Number Label");
        label.transform.SetParent(obj.transform);
        label.transform.localPosition = new Vector3(0, 0, -0.1f);
        label.transform.localScale = new Vector3(1.2f, 1.2f, 1);
        var text = label.AddComponent<TextMesh>();
        text.text = value.ToString();
        text.fontSize = 36;
        text.characterSize = 0.13f;
        text.anchor = TextAnchor.MiddleCenter;
        text.color = Color.black;
    }
}
