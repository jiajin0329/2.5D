using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour {
    static Vector2 movePosition;
    static public Vector2 Get_movePosition() {return movePosition;}
    [SerializeField] Vector2 show_movePosition;

    float nowSpeed;
    static float nowSpeedScale;
    static public float Get_nowSpeedScale() {return nowSpeedScale;}
    [SerializeField] float show_nowSpeedScale;

    static float moveAngle = 180f;
    static public float Get_moveAngle() {return moveAngle;}
    [SerializeField] float show_moveAngle;

    [SerializeField] float maxSpeed;
    [SerializeField] float addSpeed;
    [SerializeField] float drag;

    void Update() {
        Move();
        Drag();
        MaxSpeed();
        SetPosition();

        ShowVariable();
    }

    void Move() {
        if(PlayerInputer.Get_using())
        movePosition += PlayerInputer.Get_inputPosition() * (addSpeed+drag) * Time.deltaTime;
    }

    void Drag() {
        if(!PlayerInputer.Get_using()) {
            nowSpeed = Vector2.Distance(Vector2.zero, movePosition);
            float after_drag = nowSpeed - drag * Time.deltaTime;

            movePosition *= after_drag > 0 ? after_drag/nowSpeed : 0;
        }
    }

    void MaxSpeed() {
        if(PlayerInputer.Get_using()) {
            nowSpeed = Vector2.Distance(Vector2.zero, movePosition);
            if(nowSpeed > maxSpeed) movePosition *= maxSpeed/nowSpeed;
        }
    }

    void SetPosition() {
        nowSpeedScale = nowSpeed / maxSpeed;
        if(PlayerInputer.Get_using()) moveAngle = Mathf.Atan2(movePosition.x, movePosition.y) / (Mathf.PI/180f);
        transform.position += new Vector3(movePosition.x, 0, movePosition.y); 
    }

    void ShowVariable() {
        show_movePosition = movePosition;
        show_nowSpeedScale = nowSpeedScale;
        show_moveAngle = moveAngle;
    }
}
