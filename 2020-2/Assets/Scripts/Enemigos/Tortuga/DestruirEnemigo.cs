﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirEnemigo : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(transform.root.gameObject);
        }
    }
}
/*Codigo para destruir al enemigo*/
