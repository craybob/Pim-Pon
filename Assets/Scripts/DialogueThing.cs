using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueThing : MonoBehaviour
{
    public int chatWithWho;
    move player;
    dialogueSystem diaSysScript;
    public GameObject[] dialoguePanel;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<move>();
        diaSysScript = FindObjectOfType<dialogueSystem>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Cursor.visible = true;
            dialogueWindow();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Cursor.visible = false;
            dialoguePanel[chatWithWho].SetActive(false);
        }

    }
    void dialogueWindow()
    {
        player.enabled = false;
        dialoguePanel[chatWithWho].SetActive(true);
    }
}
