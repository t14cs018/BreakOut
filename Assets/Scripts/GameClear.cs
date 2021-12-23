using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    Transform myTransform;
    public Text gameClearText;
    bool isGameClear = false;
    // Start is called before the first frame update
    void Start()
    {
        // Transformコンポーネントを保持しておく
        myTransform = transform;    
    }

    // Update is called once per frame
    void Update()
    {
        if (myTransform.childCount == 0)
        {
            gameClearText.text = "Game Clear!";
            Time.timeScale = 0f;
            isGameClear = true;
        }

        if (isGameClear && Input.GetButtonDown("Submit"))
        {
            // タイトル画面に遷移
            SceneManager.LoadScene("Title");
        }
    }
}
