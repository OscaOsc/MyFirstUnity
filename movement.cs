using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField]
    //[SerializeField]를 통해서 C# 스크립트 밖에서도 moveSpeed의 값을 조정할 수 있게 한다.
    private float moveSpeed;//플레이어의 이동속도

    // Vector3 moveTo; //플레이어가 일정한 속도로 움직이도록 하는 변수
    // /*Vector는 좌표를 나타내는 자료형이다. 
    // Vector2: 2차원상의 좌표를 나타내는 자료형이다. (x,y)
    // Vector3: 3차원상의 좌표를 나타내는 자료형이다. (x,y,z)*/
    Rigidbody2D rb; //게임 내에 물리법칙들을 적용할 수 있는 컴포넌트인 Rigidbody2D 컴포넌트를 자료형으로 하고맀다.
    Rigidbody2D rigid;
    // private Vector3 footPosition; //발의 위치
    // private bool isGround; //바닥 체크(바닥에 닿아있을 때는 true)
    [SerializeField]
    Animator animator ; //Animator라는 컴포넌트를 가져와서 변수 animator에 저장
    private Vector2 moveDirection;
    
    // Start is called before the first frame update
    private void Start()
    {
      rb = GetComponent<Rigidbody2D>();
      //Rigidbody2라는 컴포넌트를 가져와서 변수 rb에 담아 초기화한다.

      animator = GetComponent<Animator>();
      //Animator라는 컴포넌트를 가져와서 변수 animator에 담아 초기화한다.

      rigid = rb.GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
      //플레이어의 입력을 받는 변수
      // "Horizontal"은 Unity의 기본 입력 설정으로, 방향키 좌우나 A/D 키 입력을 받음
      float moveX = Input.GetAxisRaw("Horizontal");

      // 입력된 값에 따라 이동 방향을 설정
      // 수평 방향으로 이동하고, Y값은 0으로 고정
      moveDirection = new Vector2(moveX, 0).normalized;

      // Rigidbody2D에 속도를 적용하여 이동 구현
      // X축으로는 입력된 방향에 속도를 곱하여 적용하고, Y축 속도는 기존 속도를 유지
      rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);

      //애니메이션 코드

      //플레이어 이동
      if(Mathf.Abs(rigid.velocity.x) < 0.3) // Mathf.Abs는 절대값을 반환하는 함수입니다.
                                            //rigid.velocity.x의 절대값이 0.01보다 작을 때
      //or if(rigid.velocity.normalized.x < 0.3)
      //rb.velocity의 크기와 방향을 구분해  x축 방향 움직임 여부를 정확하게 판단하기 위해 .normalized를 쓴다.
      {
        animator.SetBool("isMove", false);
        /*만약 플레이어의 x축으로의 속도가 0이라면,
        애니메이터에서 설정한 자료형 bool의 isMove변수의 값은 false다.*/
      }
      else
      {
        animator.SetBool("isMove", true);
        /*만약 플레이어의 x축으로의 속도가 0이 아니라면,
        애니메이터에서 설정한 자료형 bool의 isMove변수의 값은 true다.*/
      }
      /*//rb.velocity의 크기와 방향을 구분해 
      x축 방향 움직임 여부를 정확하게 판단하기 위해 .normalized를 쓴다.
      rb.velocity는 Rigidbody 컴포넌트의 속도 벡터를 나타냅니다. 
      이 속도 벡터에는 크기(magnitude)와 방향(direction)이 모두 포함되어 있습니다.
      만약 단순히 rb.velocity.x == 0과 같이 비교하면, 속도의 크기가 0이 아니더라도 
      속도 벡터의 x 성분이 0이면 true가 반환될 수 있습니다. 
      이는 플레이어가 대각선 방향으로 움직이는 경우에도 발생할 수 있습니다.
      그래서 .normalized를 사용하여 속도 벡터의 방향 정보만을 사용하게 됩니다. 
      .normalized는 벡터의 방향 성분만을 추출하여 벡터의 크기를 1로 만듭니다. 
      이렇게 하면 속도의 크기와 상관없이 단순히 플레이어의 x축 방향 움직임 여부만을 확인할 수 있습니다.*/

    //   if(rb.velocity.y < 0)
    //   {
    //     Debug.DrawRay(rb.position, Vector3.down, new Color(0, 1, 0));

    //     RaycastHit2D rayHit = Physics2D.Raycast(rb.position, Vector3.down, 1, LayerMask.GetMask("Platform"));

    //     if(rayHit.collider != null)//만약 rayHit가 맞았다면
    //     {
    //       if(rayHit.distance < 0.5f)
    //       {
    //         animator.SetBool("isJumping", false);
    //       }
    //     }
    //   } //플레이어가 바닥에 닿았는지 확인해주는 코드
    }
}
// 씨발 나는 진짜로 그대로 따라 썼어. 왜 나만 버그냐고!!!!!!!!!!!!!!!!!!!