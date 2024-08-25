using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Scene을 관리하는 모듈

public class Replay : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 좌클릭 감지
        {
            // 마우스 위치를 월드 좌표로 변환
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // 해당 위치에서 Raycast 발사
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            // Raycast가 오브젝트와 충돌했는지 확인
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Replay"))
                {
                    SceneManager.LoadScene("PlayScene"); // PlayScene으로 전환
                }
            }
            //SceneManager.LoadScene("PlayScene");
        }
    }
    
}
