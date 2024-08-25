using UnityEngine;
using UnityEngine.SceneManagement; // Scene을 관리하는 모듈

public class PlayerCollision : MonoBehaviour
{
    // 충돌할 오브젝트의 태그를 설정합니다.
    public Vector2 targetPosition;



    // 오브젝트가 충돌할 때 호출되는 메서드
    private void OnCollisionEnter2D(Collision2D collision)
    //collider컴포넌트끼리 충돌했을때의 함수
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            transform.position = new Vector2(0, 0);
            transform.position = targetPosition;

            SceneManager.LoadScene("GameOverScene");
            //만약 "Enemy"태그의 오브젝트에 닿았다면 "GameOverScene"Scene으로 이동한다.
        }
    } 
}




//DeathBlock
