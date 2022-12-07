using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public CollectableType type;
    public Sprite icon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        esploratore player = collision.GetComponent<esploratore>();
        if (player)
        {
            player.inventario.Add(this);
            Destroy(this.gameObject);
        }
    }
}
 public enum CollectableType
 {
      NONE, CHIAVE
 }
