using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text gameOverText;
    // ゲームオーバーか判定するメンバ変数
    bool isGameOver = false;
    
    void Update()
    {
        if (isGameOver && Input.GetButtonDown("Submit"))
        {
            // Playシーンをロードし直す
            SceneManager.LoadScene("Play");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Game Overを表示
        gameOverText.text = "Game Over";
        // 当たったゲームオブジェクトを削除する
        Destroy(collision.gameObject);  
        // GameOverフラグをたてる
        isGameOver = true;
    }
}
