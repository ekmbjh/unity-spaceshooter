using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    // 컴포넌트를 캐시 처리할 변수.
    private Transform tr;

    // Animation 컴포넌트를 저장할 변수
    private Animation anim;

    // 이동 속도 변수 (public으로 선언되어 인스펙터 뷰에 노출됨).
    public float moveSpeed = 10.0f;

    // 회전 속도 변수.
    public float turnSpeed = 80.0f;
    void Start()
    {
        // 컴포넌트를 추출해 변수에 대입.
        tr = GetComponent<Transform>();
        anim = GetComponent<Animation>();

        anim.Play("Idle");
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // -1.0f ~ 0.0f ~ +1.0f
        float v = Input.GetAxis("Vertical"); // -1.0f ~ 0.0f ~ +1.0f
        float r = Input.GetAxis("Mouse X");

        // Debug.Log("h=" + h);
        // Debug.Log("v=" + v);

        // Transform 컴포넌트의 position 속성값을 변경.
        // transform.position += new Vector3(0, 0, 1);

        // 정규화 벡터를 사용한 코드.
        //transform.position += Vector3.forward * 1;

        // 전후좌우 이동 방향 벡터 계산.
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);

        // Translate 함수를 사용한 이동 로직.
        tr.Translate(moveDir.normalized * moveSpeed * Time.deltaTime);

        // Vector3.up 축을 기준으로 turnSpeed만큼의 속도로 회전.
        tr.Rotate(Vector3.up * turnSpeed * Time.deltaTime * r);

        PlayerAnim(h, v);
    }

    void PlayerAnim(float h, float v)
    {
        // 키보드 입력값을 기준으로 동작할 애니메이션 수행

        if (v >= 0.1f)
        {
            anim.CrossFade("RunF", 0.25f); // 전진 애니메이션 실행
        }
        else if (v <= -0.1f)
        {
            anim.CrossFade("RunB", 0.25f); // 후진 애니메이션 실행
        }
        else if (h >= 0.1f)
        {
            anim.CrossFade("RunR", 0.25f); // 오른쪽 이동 애니메이션 실행
        }
        else if (h <= -0.1f)
        {
            anim.CrossFade("RunL", 0.25f); // 왼쪽 이동 애니메이션 실행
        }
        else
        {
            anim.CrossFade("Idle", 0.25f); // 정지 시 Idle 애니메이션 실행.
        }
    }
}
