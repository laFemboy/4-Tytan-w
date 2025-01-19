using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform target; // Mo¿e to byæ cel, który przeciwnik œciga (np. gracz)

    void Update()
    {
        if (target != null)
        {
            // Ruch przeciwnika w stronê celu
            Vector3 direction = (target.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
        }
    }
}
