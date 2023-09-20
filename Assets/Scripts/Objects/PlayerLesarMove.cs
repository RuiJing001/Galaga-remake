using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerLesarMove : MonoBehaviour
{
    public float LesarSpeed;
    public bool isenemylesar=false;
    private void Update()
    {
        MoveBullet();

        // Check if the bullet is off-screen and destroy it
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        if (viewPos.y > 1.1f || viewPos.y < -0.1f) // Adjust the values as needed
        {
            Destroy(gameObject);
        }
    }

    private void MoveBullet()
    {
        if (isenemylesar)
        {
            transform.Translate(Vector2.down * LesarSpeed * Time.deltaTime);

        }
        else
        {
            transform.Translate(Vector2.up * LesarSpeed * Time.deltaTime);

        }
    }
}
