using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Jeœli u¿ywasz TextMeshPro

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance; // Singleton, aby ³atwo wywo³ywaæ dialogi
    public GameObject dialogPanel; // Panel dialogowy
    public TMP_Text dialogText; // Tekst dialogowy (u¿yj TextMeshPro)
    public float typingSpeed = 0.02f; // Prêdkoœæ pisania tekstu

    private Queue<string> dialogLines; // Kolejka przechowuj¹ca linie dialogowe
    private bool isTyping = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        dialogLines = new Queue<string>();
        dialogPanel.SetActive(false); 
    }

    public void StartDialog(List<string> lines)
    {
        dialogLines.Clear();
        foreach (string line in lines)
        {
            dialogLines.Enqueue(line);
        }

        dialogPanel.SetActive(true);
        DisplayNextLine();
    }

    public void DisplayNextLine()
    {
        if (isTyping) return; 

        if (dialogLines.Count == 0)
        {
            EndDialog();
            return;
        }

        string nextLine = dialogLines.Dequeue();
        StartCoroutine(TypeLine(nextLine));
    }

    IEnumerator TypeLine(string line)
    {
        isTyping = true;
        dialogText.text = "";
        foreach (char c in line.ToCharArray())
        {
            dialogText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }

    public void EndDialog()
    {
        dialogPanel.SetActive(false); // Ukryj panel
    }
}
