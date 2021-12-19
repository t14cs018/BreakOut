using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{

    // 速さの最小値を指定する変数
    public float minSpeed = 10f;
    // 速さの最小値を指定する変数
    public float maxSpeed = 30f;
    // ボールの初速度設定
    public float initSpeed;
    Rigidbody myRigidbody;
    // Transfomrコンポーネント保持用
    Transform myTransform;
    // スコア計算用
    private int score;
    // スコア描画用
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        initSpeed = minSpeed;
        // Rigidbodyにアクセスし変数に保持しておく
        myRigidbody = GetComponent<Rigidbody>();
        // 射出方向をランダムにする
        float phase = Random.Range(225f, 325f) * Mathf.PI * 2f / 360f;

        float speedX = initSpeed * Mathf.Cos(phase);
        float speedY = initSpeed * Mathf.Sin(phase);
        // 決まった方向から初速5でスタート
        myRigidbody.velocity = new Vector3(speedX, speedY, 0f);  // (x, y, z)の速度
        myTransform = transform;
        score = 0;

    }

    // Update is called once per frame
    void Update()
    {
        // 現在の速度を取得
        Vector3 velocity = myRigidbody.velocity;
        // 速さを計算
        float clampedSpeed = Mathf.Clamp(velocity.magnitude, minSpeed, maxSpeed);
        // 速度を変更
        myRigidbody.velocity = velocity.normalized * clampedSpeed;
        // print(myRigidbody.velocity);
        // print(minSpeed);
    }

    void OnCollisionEnter(Collision collision)
    {
        
        // プレイヤーオブジェクトを呼び出す（事前にObjectのプロパティからTagをつけておく必要がある）
        if (collision.gameObject.CompareTag("Player"))
        {
            print("Collision to player");
            changeBallSpeed(collision);
        }

        if (collision.gameObject.CompareTag("Block"))
        {
            print("Collision to Block");
            changeBallSpeed(collision);
            score += 100;
            scoreText.text = string.Format("Score:{0}", score);


        }
    }

    private void changeBallSpeed(Collision collision)
    {
            // プレイヤーの位置を取得
            Vector3 playerPos = collision.transform.position;
            // ボールの位置を取得
            Vector3 ballPos = myTransform.position;
            // プレイヤーから見たボールの方向を計算
            Vector3 direction = (ballPos - playerPos).normalized;
            // 現在の速さを取得
            float speed = myRigidbody.velocity.magnitude;
            // 速度を変更
            myRigidbody.velocity = direction * speed;

            // minSpeedを上げる（プレイヤーかブロックに衝突するたびに速度があがる）
            if (collision.gameObject.CompareTag("Player"))
                minSpeed *= 1.01f;
            else if(collision.gameObject.CompareTag("Block"))
                minSpeed *= 1.07f;

            return;
    }
}