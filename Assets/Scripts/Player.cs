using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // プレイヤーの移動速度
    public float initVelocity = 10f;
    Rigidbody myRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        // Rigidbodyにアクセスし変数を保持
        myRigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // 左右のキー入力により速度を変更する
            myRigidbody.velocity = new Vector3(initVelocity, 0f, 0f);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidbody.velocity = new Vector3(initVelocity * -1, 0f, 0f);
        }
        else 
        {
            myRigidbody.velocity = new Vector3(0f, 0f, 0f);
        }
    }
}
