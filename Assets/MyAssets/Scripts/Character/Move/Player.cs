using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player : Move {
    #region 變數宣告 ===============================================================================================================
    /// <summary>
    /// 是否正在輸入?
    /// </summary>
    [Header("是否正在輸入?")]
    [SerializeField]
    private bool input = false;

    

    #endregion =============================================================================================================== 變數宣告

    #region 函式 ===============================================================================================================
    /// <summary>
    /// 初始化函式
    /// </summary>
    public void Player_Initialize() {
        
    }

    /// <summary>
    /// 移動主架構
    /// </summary>
    override public void _Move() {
        _Input();
    }

    /// <summary>
    /// 輸入主架構
    /// </summary>
    private void _Input() {
        Debug.Log("輸入主架構");
    }

    #endregion =============================================================================================================== 函式
}