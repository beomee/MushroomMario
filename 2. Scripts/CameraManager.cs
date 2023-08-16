using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public Transform player;

    public float cameraSpeed;

    // ī�޶� ���� ������ ��ġ�� ũ�� 
    public Vector2 areaCenter, areaSize;

    // ī�޶��� ����/���� ���� ���� 
    float heightHalf, widthHalf;

    float distX;
    float distY;


    // Start is called before the first frame update
    void Start()
    {
        // ī�޶��� ���� ���� ����  ������Ʈ ��������
        heightHalf = Camera.main.orthographicSize;

        // ī�޶��� ���� ���� ���� ���ϱ� 

        widthHalf = heightHalf * Screen.width / Screen.height;

        // ���� 
        distX = areaSize.x * 0.5f - widthHalf;

        // ����
        distY = areaSize.y * 0.5f - heightHalf;

    }

    void LateUpdate()
    {


        Vector3 target = new Vector3(player.position.x, player.position.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, target, cameraSpeed * Time.deltaTime);

        // x ��ġ ���� (�ִ�, �ּ�)
        float clampX = Mathf.Clamp(transform.position.x, areaCenter.x - distX, areaCenter.x + distX);

        float clampY = Mathf.Clamp(transform.position.y, areaCenter.y - distY, areaCenter.y + distY);


        // ī�޶� ���� ����
        transform.position = new Vector3(clampX, clampY, -10);

    }

    private void OnDrawGizmos()
    {
        // ����� ���� ������
        Gizmos.color = Color.red;

        // ī�޶� ���� ���� �׸���
        Gizmos.DrawWireCube(areaCenter, areaSize);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
