using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility {

    public static GameController gameController;
    public static Player player;
    public static StatManager statManager;
    public static LevelManager levelManager;
    public static UIManager uiManager;

    public static GameObject playerPrefab;

    public static bool signCanBeDestroyed = false;

    public static GameObject ui;

    public static float GetMouseAngle(Transform transform) {
        var direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = transform.position - direction;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        return angle + 180f;
    }

    public static void FaceMouse(Sprite[] sprites, SpriteRenderer spriteRenderer) {
        Vector3 rotation = new Vector3(0, 0, GetMouseAngle(player.transform));
        float quadrantAngle = 360f / 8f;
        rotation.x = Mathf.Round(rotation.x / quadrantAngle) * quadrantAngle;
        rotation.y = Mathf.Round(rotation.y / quadrantAngle) * quadrantAngle;
        rotation.z = Mathf.Round(rotation.z / quadrantAngle) * quadrantAngle;

        for (int i = 0; i < sprites.Length; i++) {
            int index = (int)(rotation.z / quadrantAngle);
            spriteRenderer.sprite = sprites[index];
        }
    }

    public static void RotateProjectile(Transform transform) {
        Vector3 rotation = new Vector3(0f, 0f, GetMouseAngle(transform));
        transform.eulerAngles = rotation;
    }

    public static void ChangeColor(Color color, SpriteRenderer renderer) {
        renderer.color = color;
    }
}