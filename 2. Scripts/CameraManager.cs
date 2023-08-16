using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public Transform player;

    public float cameraSpeed;

    // 카메라 제한 영역의 위치와 크기 
    public Vector2 areaCenter, areaSize;

    // 카메라의 세로/가로 절반 길이 
    float heightHalf, widthHalf;

    float distX;
    float distY;


    // Start is called before the first frame update
    void Start()
    {
        // 카메라의 세로 절반 길이  컴포넌트 가져오기
        heightHalf = Camera.main.orthographicSize;

        // 카메라의 가로 절반 길이 구하기 

        widthHalf = heightHalf * Screen.width / Screen.height;

        // 가로 
        distX = areaSize.x * 0.5f - widthHalf;

        // 세로
        distY = areaSize.y * 0.5f - heightHalf;

    }

    void LateUpdate()
    {


        Vector3 target = new Vector3(player.position.x, player.position.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, target, cameraSpeed * Time.deltaTime);

        // x 위치 제한 (최대, 최소)
        float clampX = Mathf.Clamp(transform.position.x, areaCenter.x - distX, areaCenter.x + distX);

        float clampY = Mathf.Clamp(transform.position.y, areaCenter.y - distY, areaCenter.y + distY);


        // 카메라에 제한 적용
        transform.position = new Vector3(clampX, clampY, -10);

    }

    private void OnDrawGizmos()
    {
        // 기즈모 색상 빨간색
        Gizmos.color = Color.red;

        // 카메라 제한 영역 그리기
        Gizmos.DrawWireCube(areaCenter, areaSize);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
