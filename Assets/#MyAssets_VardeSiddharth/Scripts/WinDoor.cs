using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinDoor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(gameObject.layer == 8)
            {
                GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().world1Win();
                collision.gameObject.SetActive(false);
            }
            else
            {
                GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().world2Win();
                collision.gameObject.SetActive(false);
            }
        }
    }
}
