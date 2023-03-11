using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputer : MonoBehaviour {
    private static PlayerInputer _singleton;


    #region  ===== variable ==========
    [SerializeField] private bool _inputDown;
    public static bool inputDown {get {return _singleton._inputDown;}}

    [SerializeField] private Vector2 _inputPosition;
    public static Vector2 inputPosition {get {return _singleton._inputPosition;}}
    #endregion ========================================

    #region  ===== setting variable ==========
    [SerializeField] InputAction moveAction;
    #endregion ========================================

    private void Awake() {
        _singleton = null;
        _singleton = this;
    }

    private void Start() {
        moveAction.Enable();
        //Debug.Log("start");
    }

    private void Update() {
        GetInput();
        //Debug.Log("update");
    }

    private void GetInput() {
        _inputPosition = moveAction.ReadValue<Vector2>();
        _inputDown = inputPosition != Vector2.zero;
    }
}
