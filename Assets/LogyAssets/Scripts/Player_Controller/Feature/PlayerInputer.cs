using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputer : MonoBehaviour {
    #region  ===== variable ==========
    static bool _using;
    static public bool Get_using() {return _using;}
    [SerializeField] bool show_using;

    static bool attack;
    static public bool Get_attack() {return attack;}
    [SerializeField] bool show_attack;

    static Vector2 inputPosition;
    static public Vector2 Get_inputPosition() {return inputPosition;}
    [SerializeField] Vector2 show_inputPosition;
    #endregion ========================================

    #region  ===== setting variable ==========
    [SerializeField] InputAction moveAction;
    #endregion ========================================

    void Start() {
        moveAction.Enable();
        //Debug.Log("start");
    }

    void Update() {
        GetInput();
        ShowVariable();
        //Debug.Log("update");
    }

    void GetInput() {
        inputPosition = moveAction.ReadValue<Vector2>();
        _using = inputPosition != Vector2.zero;
    }

    void ShowVariable() {
        show_using = _using;
        show_inputPosition = inputPosition;
    }
}
