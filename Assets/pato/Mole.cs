using UnityEngine;

public class Mole : MonoBehaviour
{
    private MoleManager manager;

    private void Start()
    {
        manager = FindObjectOfType<MoleManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("ball"))
        {
            manager.MoleHit(gameObject);
        }
    }
}