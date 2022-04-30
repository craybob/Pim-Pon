using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailScripts : MonoBehaviour
{
    public GameObject mail;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            mail.SetActive(true);
        }
    }

    public void closeButton()
    {
        mail.SetActive(false);
    }
}
