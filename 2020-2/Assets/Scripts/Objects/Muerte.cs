﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muerte : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.name == "Mario"){
            Destroy(collider.gameObject);
            
        }
    }
}
