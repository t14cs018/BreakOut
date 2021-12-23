using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // 何かぶつかった時にオブジェクトをDestroyする
            Destroy(gameObject);
            
        }
    }
}
