using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{

    // 速さの最小値を指定する変数
    public float minSpeed = 10f;
    // 速さの最大値を指定する変数
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
    public AudioClip blockImpact;
    public AudioClip wallImpact;
    // 計算用
    private float rad = Mathf.PI * 2f / 360f;

    // プレイヤーバーに瞬間的に複数衝突した時に速度が急激にあがらないように
    private int collisionTime = 0;


    // Start is called before the first frame update
    void Start()
    {
        // 初速度
        initSpeed = minSpeed;
        // Rigidbodyにアクセスし変数に保持しておく
        myRigidbody = GetComponent<Rigidbody>();
        // 射出方向をランダムにする
        float phase = Random.Range(225f, 325f) * Mathf.PI * 2f / 360f;

        float speedX = initSpeed * Mathf.Cos(phase);
        float speedY = initSpeed * Mathf.Sin(phase);
        // 決まった方向からスタート
        myRigidbody.velocity = new Vector3(speedX, speedY, 0f);  // (x, y, z)の速度
        myTransform = transform;
        score = 0;


    }

    // Update is called once per frame
    void Update()
    {
        // 最小速度が最大速度を超えないようにする
        if (minSpeed > maxSpeed)
        {
            minSpeed = maxSpeed;
        }
        // 現在の速度を取得
        Vector3 velocity = myRigidbody.velocity;
        // 速さを計算
        float clampedSpeed = Mathf.Clamp(velocity.magnitude, minSpeed, maxSpeed);
        // 速度を変更
        myRigidbody.velocity = velocity.normalized * clampedSpeed;

        collisionTime++;
    }

    void OnCollisionEnter(Collision collision)
    {
        // プレイヤーオブジェクトを呼び出す（事前にObjectのプロパティからTagをつけておく必要がある）
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<AudioSource>().PlayOneShot(wallImpact, 0.1f);
            print("Collision to player");
            changeBallAngle(collision);
        }

        // ブロックに当たった時の処理
        if (collision.gameObject.CompareTag("Block"))
        {
            GetComponent<AudioSource>().PlayOneShot(blockImpact, 1.0f);
            print("Collision to Block");
            changeBallAngle(collision);
            score += 100;
            scoreText.text = string.Format("Score:{0}", score);
        }

        // 壁に当たった時の処理
        if (collision.gameObject.CompareTag("Wall"))
        {
            GetComponent<AudioSource>().PlayOneShot(wallImpact, 0.1f);
            changeBallAngleForWall(collision);
        }
    }

    private void changeBallAngle(Collision collision)
    {
            // プレイヤーの位置を取得
            Vector3 playerPos = collision.transform.position;
            // ボールの位置を取得
            Vector3 ballPos = myTransform.position;
            // プレイヤーから見たボールの方向を計算
            Vector3 direction = (ballPos - playerPos).normalized;
            print(direction);

            // ボールがプレイヤーのバーに横から衝突した場合はボールの挙動を変更しない
            if (!(collision.gameObject.CompareTag("Player") && direction.y <= 0))
            {
                // 現在の速さを取得
                float speed = myRigidbody.velocity.magnitude;
                // 反射角度を変更
                myRigidbody.velocity = direction * speed;
            }

            // minSpeedを上げる（プレイヤーかブロックに衝突するたびに速度があがる）
            if (collision.gameObject.CompareTag("Player") && collisionTime > 1000){
                minSpeed *= 1.01f;
                collisionTime = 0;
            }
            else if(collision.gameObject.CompareTag("Block"))
                minSpeed *= 1.07f;

            return;
    }

    private void changeBallAngleForWall(Collision collision)
    {
            Vector3 direction = myRigidbody.velocity.normalized;

            // 壁にほぼ垂直にぶつかった場合は角度を少し変更する
            if ((direction.y < Mathf.Cos(80f * rad) && 0 < direction.y) || (direction.x > Mathf.Cos(100f * rad) && 0 > direction.x))
            {
                print("changeBallAngleForWall Enter");
                direction = Quaternion.Euler(0f, 0f, Random.Range(1f, 15f)) * direction;

                // 現在の速さを取得
                float speed = myRigidbody.velocity.magnitude;
                // 速度を変更
                myRigidbody.velocity = direction * speed;
            }

            if ((direction.x < Mathf.Cos(80f * rad) && 0 <= direction.x) || (direction.y <= 0 && direction.y > Mathf.Cos(100f * rad)))
            {
                print("changeBallAngleForWall Enter");
                direction = Quaternion.Euler(0f, 0f, Random.Range(-1f, -15f)) * direction;
                // 現在の速さを取得
                float speed = myRigidbody.velocity.magnitude;
                // 速度を変更
                myRigidbody.velocity = direction * speed;
            }

            print($"BallVec is {myRigidbody.velocity}");

            return;
    }


}