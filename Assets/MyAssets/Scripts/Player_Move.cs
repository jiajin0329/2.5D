using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : Character_Move {
    #region 變數宣告 ===============================================================================================================
    /// <summary>
    /// 踩到地板上
    /// </summary>
    [Header("踩到地板上")]
    [SerializeField]
    private bool on_ground;
    /// <summary>
    /// 踩到地板數
    /// </summary>
    public bool _on_ground {
        get { return on_ground; }
    }

    /// <summary>
    /// 是否輸入中
    /// </summary>
    [Header("是否輸入中")]
    [SerializeField]
    private bool input = false;

    /// <summary>
    /// 鍵盤輸入量
    /// </summary>
    [Header("鍵盤輸入量")]
    [SerializeField]
    private Vector2 input_pos;
    /// <summary>
    /// 輸入角度
    /// </summary>
    public Vector2 _input_pos {
        get { return input_pos; }
    }

    /// <summary>
    /// 輸入角度
    /// </summary>
    [Header("輸入角度")]
    [SerializeField]
    private float input_angle;
    /// <summary>
    /// 輸入角度
    /// </summary>
    public float _input_angle {
        get { return input_angle; }
    }

    /// <summary>
    /// 是否可以移動
    /// </summary>
    [Header("是否可以移動")]
    public bool can_move = true;

    /// <summary>
    /// 是否走路中
    /// </summary>
    [Header("是否走路中")]
    [SerializeField]
    private bool walk = false;

    /// <summary>
    /// 幾禎到最高速
    /// </summary>
    [Header("幾禎到最高速")]
    [SerializeField]
    private byte speed_to_max = 12;

    /// <summary>
    /// 加速度
    /// </summary>
    private float addspeed;

    /// <summary>
    /// 加速完的速度
    /// </summary>
    private float speed_add;

    /// <summary>
    /// 幾禎到最高速
    /// </summary>
    [Header("幾禎到停止")]
    [SerializeField]
    private byte speed_to_zero = 12;

    /// <summary>
    /// 阻力
    /// </summary>
    private float drag;

    /// <summary>
    /// 儲存計算減速玩速度
    /// </summary>
    private float speed_sum;
    /// <summary>
    /// 儲存計算減速玩速度
    /// </summary>
    public float _speed_sum {
        get { return speed_sum; }
    }

    private float speed_max = 1f;

    /// <summary>
    /// 是否按到跳躍
    /// </summary>
    [Header("是否按到跳躍")]
    [SerializeField]
    private bool jump = false;
    /// <summary>
    /// 是否按到跳躍
    /// </summary>
    public bool _jump {
        get { return jump; }
    }

    /// <summary>
    /// 是否可以滯空
    /// </summary>
    [Header("是否可以滯空")]
    public bool stay_air = false;

    /// <summary>
    /// 跳躍力道
    /// </summary>
    [Header("跳躍力道")]
    [SerializeField]
    private byte jump_pow = 5;
    
    /// <summary>
    /// Camera
    /// </summary>
    [Header("Camera")]
    [SerializeField]
    private Transform cam;

    /// <summary>
    /// 自己的CapsuleCollider
    /// </summary>
    private CapsuleCollider capsule_collider;

    private bool is_hit;
    private Vector3 spherecast_pos;
    private float spherecast_radius;
    private RaycastHit hit;
    private float spherecast_dis;

    #endregion =============================================================================================================== 變數宣告
    
    #region 函式 ===============================================================================================================
    private void Start() {
        tf = transform;
        rb = rb = GetComponent<Rigidbody>();

        drag = 60f/speed_to_zero * 0.017f;
        addspeed = drag + 60f/speed_to_max * 0.017f;

        capsule_collider = GetComponent<CapsuleCollider>();

        spherecast_radius = capsule_collider.radius * 0.9f;
        spherecast_dis = capsule_collider.radius*1.1f;
    }

    private void FixedUpdate() {
        Inputer();
        InputPos2MovePos();
        Move();
    }

    private void Inputer() {
        input_pos = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if(input_pos != Vector2.zero) {
            input = true;

            //計算輸入角度
            input_angle = Mathf.Atan2(input_pos.x, input_pos.y);
        }
        else {
            input = false;
        }
    }

    private void InputPos2MovePos() {

        if(input) {
            //計算移動座標
            move_pos += addspeed * new Vector2(Mathf.Sin(input_angle), Mathf.Cos(input_angle));
        }

        //計算加速完速度
        speed_add = Vector2.Distance(move_pos, Vector2.zero);
        //計算減速完的速度
        speed_sum = speed_add - drag;

        //如果
        if(speed_sum > speed_max)
        speed_sum *= speed_max/speed_sum;
        else if(speed_sum < 0)
        speed_sum = 0f;

        move_pos *= speed_sum > 0f ? speed_sum/speed_add : 0f;
    }
    #endregion =============================================================================================================== 函式
}
