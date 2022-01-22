using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour {
    ///<summary>
    ///控制UI清單
    ///</summary>
    [Header("HP")]
    [SerializeField]
    private byte hp = 0;

    ///<summary>
    ///控制UI清單
    ///</summary>
    [Header("HP圖片 小排到大")]
    [SerializeField]
    private Sprite[] hpSprite = new Sprite[1];
    
    ///<summary>
    ///控制Image清單
    ///</summary>
    [Header("Image清單")]
    [SerializeField]
    private Image[] hpImage = new Image[1];

    private int  hpimage_length;
    private int  hpsprite_length;

    private void Start() {
        hpimage_length = hpImage.Length;
        hpsprite_length = hpSprite.Length;
    }

    private void Update() {
        SetHpImage();
    }

    private void SetHpImage() {

        //血量點數：用來計算分配給每個UI的血量
        int hp_count = hp;

        for(byte i = 0; i < hpimage_length; i++) {
            if(hp_count > 0) {
                if(hp_count < hpsprite_length) 
                    hpImage[i].sprite = hpSprite[hp_count];
                else 
                    hpImage[i].sprite = hpSprite[hpSprite.Length-1];
            }
            else 
                hpImage[i].sprite = hpSprite[0];

            hp_count -= hpsprite_length-1;
        }
    }
}