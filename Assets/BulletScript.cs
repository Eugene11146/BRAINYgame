using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    IEnumerator TimeToDelete()
    {
        yield return new WaitForSeconds(7f);
        Destroy(gameObject);
    }

    private void Start()
    {
        StartCoroutine(TimeToDelete());
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(gameObject);
    }

}
