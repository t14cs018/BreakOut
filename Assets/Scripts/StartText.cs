using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartText : MonoBehaviour
{
    Transform myTransform;
    public Text gameStartText;

    // Start is called before the first frame update
    void Start()
    {
        // Transformコンポーネントを保持しておく
        myTransform = transform;  
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            // Playシーンをロード
            SceneManager.LoadScene("Play");
            Time.timeScale = 1f;
        }
    }
}
