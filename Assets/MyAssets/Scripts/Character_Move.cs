using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Move : MonoBehaviour {
    #region 變數宣告 ===============================================================================================================

    /// <summary>
    /// 是否有移動量
    /// </summary>
    [Header("是否有移動量")]
    private bool move = false;
    /// <summary>
    /// 是否有移動量
    /// </summary>
    public bool _move {
        get { return move; }
    }

    /// <summary>
    /// 自己的Transform
    /// </summary>
    protected Transform tf;
    /// <summary>
    /// 自己的Transform
    /// </summary>
    public Transform _tf {
        get { return tf; }
    }

    /// <summary>
    /// 自己Rigidbody
    /// </summary>
    protected Rigidbody rb;

    /// <summary>
    /// 移動量
    /// </summary>
    [Header("移動量")]
    [SerializeField]
    protected Vector2 move_pos;
    /// <summary>
    /// 移動量
    /// </summary>
    public Vector2 _move_pos {
        get { return move_pos; }
    }

    /// <summary>
    /// 實際移動量
    /// </summary>
    protected Vector2 move_pos_sum;

    /// <summary>
    /// 速度
    /// </summary>
    [Header("速度")]
    [SerializeField]
    private float speed = 3f;

    #endregion =============================================================================================================== 變數宣告

    #region 函式 ===============================================================================================================

    protected void Move() {
        if(move_pos != Vector2.zero) {
            move = true;
            
            move_pos_sum = move_pos * speed;
            //設定移動量
            rb.velocity = new Vector3(move_pos_sum.x, rb.velocity.y, move_pos_sum.y);
        }
        else {
            move = false;
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
    }

    #endregion =============================================================================================================== 函式
}