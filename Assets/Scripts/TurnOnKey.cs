using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnKey : MonoBehaviour
{
    public GameObject effects;
    public SpriteRenderer tvColor;
    public GameObject portal;
    // Start is called before the first frame update

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            tvColor.color = Color.white;
            portal.SetActive(true);
            effects.SetActive(true);
            Destroy(gameObject);
        }
    }
}
