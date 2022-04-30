using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuScript : MonoBehaviour
{
    public Sprite[] comixPage;
    int page;
    public Image comix;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void startComix(GameObject comixPanel)
    {
        comixPanel.SetActive(true);
    }

    public void nextButton()
    {
        if (page > comixPage.Length)
        {
            startScene(1);
        }
        page++;
        comix.sprite = comixPage[page];
    }
}
