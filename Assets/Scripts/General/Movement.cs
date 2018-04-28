using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour {
    /// <summary>
    ///     Moves an object in the direction of the translation.
    /// </summary>
    /// <param name="translation">A Vector2 giving the direction the object needs to move to</param>
    public virtual void Move(Vector2 translation, float movementSpeed) {
        Vector2 normalizedTranslation = translation.normalized;
        transform.position += (Vector3)normalizedTranslation * movementSpeed * Time.deltaTime;
    }

    /// <summary>
    ///     Moves an object in tthe direction of the x and y.
    /// </summary>
    /// <param name="x">The x value for the Vector2 in which the object needs to move</param>
    /// <param name="y">The y value for the Vector2 in which the object needs to move</param>
    public virtual void Move(float x, float y, float movementSpeed) {
        Vector2 normalizedTranslation = new Vector2(x, y).normalized;
        transform.position += (Vector3)normalizedTranslation * movementSpeed * Time.deltaTime;
    }
}
