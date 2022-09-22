using System.Collections;
using UnityEngine;

public class RespawnCollect : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Respawn")) return;
        
        StartCoroutine(RespawnSprite(col));

    }

    private IEnumerator RespawnSprite(Collider2D col)
    {
        col.gameObject.SetActive(false);
        yield return new WaitForSeconds(4f);
        col.gameObject.SetActive(true);
    }
}
