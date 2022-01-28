using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    private enum Move_Type{player}

    // 移動方式
    [Header("移動方式")]
    [SerializeField]
    private Move_Type move_type;

    // 這個物件的GameObject
    [Header("這個物件的GameObject")]
    [SerializeField]
    private GameObject go;

    // 使用的移動程式
    private Move move;

    //初始化
    void Start() {

        if(move_type == Move_Type.player)move = go.AddComponent<Player>();
    }
    
    void Update() {
        move._Move();
    }
}