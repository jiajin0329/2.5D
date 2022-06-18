using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimator : MonoBehaviour {
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    void Update() {
        _PlayAnimator();
    }

    void _PlayAnimator() {
        if(PlayerMove.Get_movePosition() != Vector2.zero) {
            Move();
        }
        else {
            Idle();
        }
    }

    void Move () {
        animator.speed = PlayerMove.Get_nowSpeedScale();
        if(PlayerMove.Get_moveAngle() > 45f && PlayerMove.Get_moveAngle() < 135f) {
            spriteRenderer.flipX = false;
            animator.Play("walk_side");
        }
        else if(PlayerMove.Get_moveAngle() < -45f && PlayerMove.Get_moveAngle() > -135f) {
            spriteRenderer.flipX = true;
            animator.Play("walk_side");
        }
        else if(PlayerMove.Get_moveAngle() < 45f && PlayerMove.Get_moveAngle() > -45f) {
            animator.Play("walk_back");
        }
        else if(PlayerMove.Get_moveAngle() > 135f || PlayerMove.Get_moveAngle() < -135f) {
            animator.Play("walk_front");
        }
    }

    void Idle() {
        animator.speed = 1f;
        if(PlayerMove.Get_moveAngle() > 45f && PlayerMove.Get_moveAngle() < 135f) {
            spriteRenderer.flipX = false;
            animator.Play("idle_side");
        }
        else if(PlayerMove.Get_moveAngle() < -45f && PlayerMove.Get_moveAngle() > -135f) {
            spriteRenderer.flipX = true;
            animator.Play("idle_side");
        }
        else if(PlayerMove.Get_moveAngle() < 45f && PlayerMove.Get_moveAngle() > -45f) {
            animator.Play("idle_back");
        }
        else if(PlayerMove.Get_moveAngle() > 135f || PlayerMove.Get_moveAngle() < -135f) {
            animator.Play("idle_front");
        }
    }

    void Attack() {
        animator.speed = 1f;
        if(PlayerMove.Get_moveAngle() > 45f && PlayerMove.Get_moveAngle() < 135f) {
            spriteRenderer.flipX = false;
            animator.Play("attack_weapon_side");
        }
        else if(PlayerMove.Get_moveAngle() < -45f && PlayerMove.Get_moveAngle() > -135f) {
            spriteRenderer.flipX = true;
            animator.Play("attack_weapon_side");
        }
        else if(PlayerMove.Get_moveAngle() < 45f && PlayerMove.Get_moveAngle() > -45f) {
            animator.Play("attack_weapon_front");
        }
        else if(PlayerMove.Get_moveAngle() > 135f || PlayerMove.Get_moveAngle() < -135f) {
            animator.Play("attack_weapon_back");
        }
    }
}
