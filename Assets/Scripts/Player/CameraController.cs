using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;  // ����, �� ������� ����� ��������� ������ (��� ��������)
    public float smoothing = 5f;  // �������� ����������� �������� ������

    private Vector3 offset;  // �������� ������ ������������ ���������

    void Start()
    {
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        Vector3 targetCamPos = new(target.position.x, target.position.y, target.position.z + offset.z);
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
