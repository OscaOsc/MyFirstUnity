using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour
{
    SpriteRenderer spriteRenderer; //스프라이트랜더 컴포넌트의 변수 선언

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //SpriteRenderer라는 컴포넌트를 가져와서 변수 spriteRenderer에 담아 초기화한다.
    }

    // Update is called once per frame
    void Update()
    {
        //방향전환 코드
        if(Input.GetButtonDown("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
            //만약 플레이어가 수평방향으로 이동하는 키를 누른다면 SpriteRenderer컴포넌트에서 X축으로 뒤집는 
            //변수인 spriteRenderer.flipX의 값은 Input.GetAxisRaw("Horizontwal")의 값과 -1에 같다.
            //spriteRenderer.flipX의 자료형은 bool이다.
            /*이 코드는 플레이어가 오른쪽으로 이동할 때 flipX를 true로 설정하여 
            캐릭터가 오른쪽을 바라보도록 합니다. 
            Input.GetAxisRaw("Horizontal")의 값이 -1일 때만 스프라이트가 반전됩니다.*/
        }
    }
}
