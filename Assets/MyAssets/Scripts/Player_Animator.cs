using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animator : MonoBehaviour {
    #region 變數宣告 ===============================================================================================================
    
    /// <summary>
    /// 方向索引值 上0 下1 左2 右3
    /// </summary>
    [Header("方向索引值")]
    [SerializeField]
    private byte dir_index = 1;

    /// <summary>
    /// Animator
    /// </summary>
    [Header("Animator")]
    [SerializeField]
    private Player_Move pm;

    /// <summary>
    /// Animator
    /// </summary>
    private Animator am;
    
    /// <summary>
    /// SpriteRenderer
    /// </summary>
    private SpriteRenderer sp;

    #endregion =============================================================================================================== 變數宣告

    #region 函式 ===============================================================================================================
    
    private void Start() {
        am = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate() {

        if(pm._input_pos.y > 0) 
        dir_index = 0;
        else if(pm._input_pos.y < 0)
        dir_index = 1;
        else if(pm._input_pos.x < 0)
        dir_index = 2;
        else if(pm._input_pos.x > 0)
        dir_index = 3;

        sp.flipX = dir_index == 2;

        if(pm._move){
            am.speed = pm._speed_sum;

            if(dir_index == 0)
            am.Play("walk_back");
            else if(dir_index == 1)
            am.Play("walk_front");
            else if(dir_index > 1)
            am.Play("walk_side");
        }
        else {
            am.speed = 1f;

            if(dir_index == 0)
            am.Play("idel_back");
            else if(dir_index == 1)
            am.Play("idel_front");
            else if(dir_index > 1)
            am.Play("idel_side");
        }
    }

    #endregion =============================================================================================================== 函式
}
