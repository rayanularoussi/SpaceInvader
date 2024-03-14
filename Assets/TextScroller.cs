using UnityEngine;

public class TextScroller : MonoBehaviour
{
    public float scrollSpeed = 20f;

    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 localVectorUp = transform.TransformDirection(Vector3.up);
        pos += localVectorUp * scrollSpeed * Time.deltaTime;
        transform.position = pos;
    }
}
