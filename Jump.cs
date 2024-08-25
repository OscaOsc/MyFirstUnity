using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField]
    private float jumpPower;
    //private을 붙임으로써 다른 클래스에서 함부로 movespeed변수를 접근하거나 수정하거나 할 수 없게 한다.
    private float currentJumpCount;
    private float maxJumpCount = 2;
    Animator animator ;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //스페이스바로 점프하게 하는 코드
        if (Input.GetButtonDown("Jump") && currentJumpCount > 0)
        {
            rb.velocity = Vector2.up * jumpPower;
            //rb.velocity: Rigidbody2D안에 있는 속도. velocity는 속도
            //Vector2.up * 3 = (0,3)

            currentJumpCount--;
            //현재 가능한 점프 횟수가 1회 줄어듬

            //플레이어 점프
            animator.SetBool("isJumping", true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
      if (collision.gameObject.CompareTag("Ground"))
      {
        currentJumpCount = maxJumpCount;
        animator.SetBool("isJumping", false); // 바닥에 닿았을 때 점프 상태 해제
      }
    } 
}
