using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject panel;

    void Start()
    {
        panel.SetActive(false);
    }

    public void Wroc()
    {
        panel.SetActive(false);
    }

    public void Sterowanie()
    {
        panel.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Hangar");
    }
}