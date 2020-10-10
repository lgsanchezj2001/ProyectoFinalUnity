using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class DetectarObjetos : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 vector = new Vector3(transform.root.localScale.x * -1,
            transform.root.localScale.y,
            transform.root.localScale.z);
        transform.root.localScale = vector;
    }
}
