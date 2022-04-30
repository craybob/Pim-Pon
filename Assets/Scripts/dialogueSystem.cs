using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialogueSystem : MonoBehaviour
{
    public TextMeshProUGUI TextDisplay;
    public string[] sentences;
    public int index;
    public float typingSpeed;
    move player;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Type());
        player = FindObjectOfType<move>();
    }

    // Update is called once per frame

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            TextDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        if (index < sentences.Length - 1)
        {
            index++;
            TextDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            TextDisplay.text = "";
            player.enabled = true;
        }
    }
}
