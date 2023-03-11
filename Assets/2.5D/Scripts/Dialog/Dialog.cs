using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour {
    [SerializeField] float duration = 0.5f;
    [SerializeField] string targetText;
    [SerializeField] string nowText;

    void Update() {
        if(Input.GetKeyDown(KeyCode.F)) {
            StartCoroutine(Taking());
        }
    }

    IEnumerator Taking() {
        MakingSpace();
        for(int i = 0; i < targetText.Length; i++) { //用for迴圈逐一讀取

            nowText = nowText.Insert(i, targetText[i] + ""); //插入字串

            nowText = nowText.Remove(nowText.Length-1); //移除字尾空白

            yield return new WaitForSeconds(duration);
        }
    }

    void MakingSpace() {
        nowText = ""; //清空字串
        for(int i = 0; i < targetText.Length; i++) {
            nowText += "白";
        }
    }
}
