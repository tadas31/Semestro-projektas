using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Player" || collision.gameObject.tag == "Damage_fatal") && gameObject.tag != "Bullet_harmless")
            Destroy(gameObject);
        else        
            gameObject.tag = "Bullet_harmless";       
    }
}
