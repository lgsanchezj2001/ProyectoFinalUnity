using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirEnemigo : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("entro");
            Destroy(transform.root.gameObject);
        }
    }
}
/*Codigo para destruir al enemigo*/
