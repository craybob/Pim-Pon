using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tpScript : MonoBehaviour
{
    public Transform tpPos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = tpPos.position;
        }
    }
}
