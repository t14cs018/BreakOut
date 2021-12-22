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
            // Playシーンをアンロードし、タイトル画面をロードする
            // SceneManager.UnloadSceneAsync("Play");
            SceneManager.LoadScene("Title");
            isGameOver = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // タイトル画面に戻る
            // SceneManager.UnloadSceneAsync("Play");
            SceneManager.LoadScene("Title");
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
