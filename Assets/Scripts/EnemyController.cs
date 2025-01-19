using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform target; // Mo�e to by� cel, kt�ry przeciwnik �ciga (np. gracz)

    void Update()
    {
        if (target != null)
        {
            // Ruch przeciwnika w stron� celu
            Vector3 direction = (target.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
        }
    }
}
