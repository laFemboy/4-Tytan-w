using UnityEngine;
using UnityEngine.SceneManagement;

public class ZmianaSceny : MonoBehaviour
{
    public string sceneToLoad;

    public float activationDistance = 5f;

    private Transform player; 

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= activationDistance && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
