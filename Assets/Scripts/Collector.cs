using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private string ENEMY_TAG = "Enemy";
    private string PLAYER_TAG = "Player";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collisionTags = new[] {ENEMY_TAG, PLAYER_TAG};
        if (collisionTags.Contains(collision.tag))
        {
            Destroy(collision.gameObject);
        }
    }
}
