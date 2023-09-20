using UnityEngine;

public class Asteroid : MonoBehaviour {
    public GameObject diVFXprefab;

    void Update () {

        transform.position += 2f * Time.deltaTime * Vector3.down;
        transform.Rotate (0, 0, 7f * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ebullet"))
        {
            // Instantiate the current enemy prefab at the chosen spawn point.
            Instantiate(diVFXprefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("PBullet"))
        {
            // Instantiate the current enemy prefab at the chosen spawn point.
            Instantiate(diVFXprefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
                
        }
    }
    
}
