using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // アクセスが1回きりのため、フィールド変数を用意しなくても良い
        Text myText = GetComponent<Text>();
        // myTextにからの文字列を設定する
        myText.text = "";
    }
}
