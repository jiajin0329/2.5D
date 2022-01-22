using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    
    public enum Move_Type{player}

    /// <summary>
    /// 移動方式
    /// </summary>
    public Move_Type move_type;

    
    private Move move;

    void Start() {
        if(move_type == Move_Type.player) {
            move = new Player();
        }
    }

    // Update is called once per frame
    void Update() {
        move._Move();
    }
}