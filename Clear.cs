using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Scene을 관리하는 모듈

public class Clear : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    //collider컴포넌트끼리 충돌했을때의 함수
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene("ClearScene");
            //만약 "Enemy"태그의 오브젝트에 닿았다면 "GameOverScene"Scene으로 이동한다.
        }
    }
}
