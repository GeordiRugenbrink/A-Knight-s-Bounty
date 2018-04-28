using UnityEngine;

public class Player : Character {

    [SerializeField]
    private Sprite[] sprites = new Sprite[8];
    private SpriteRenderer spriteRenderer;



    private void Awake() {
        Utility.player = this;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        GetAngleMouse();
        FaceMouse();
    }

    private float GetAngleMouse() {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        return angle + 180f;
    }

    private void FaceMouse() {
        Vector3 rotation = new Vector3(0, 0, GetAngleMouse());
        float quadrantAngle = 360f / 8f;
        rotation.x = Mathf.Round(rotation.x / quadrantAngle) * quadrantAngle;
        rotation.y = Mathf.Round(rotation.y / quadrantAngle) * quadrantAngle;
        rotation.z = Mathf.Round(rotation.z / quadrantAngle) * quadrantAngle;

        for (int i = 0; i < sprites.Length; i++) {
            int index = Mathf.FloorToInt(rotation.z / quadrantAngle);
            spriteRenderer.sprite = sprites[index];
        }
    }
}