using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;

    private float speed = 0.7f;
    private Vector2 velSpeed;

    private float defaultZoom = 5f;
    private float zoomSpeed = 1f;
    private float velZoom;

    private Vector2 startPos;

    public Camera _cam;

    public static CameraMovement Instance { get; set; }

    private void Awake()
    {
        Instance = this;
        startPos = transform.position;
    }

    void FixedUpdate()
    {
        if (target == null) return;
        //Movement
        float playerSpeed = PlayerMovements.Instance.GetRb().velocity.magnitude;
        Vector2 posOffset = PlayerMovements.Instance.GetRb().velocity / 1.75f;
        Vector2 targetPos = new Vector2(target.transform.position.x, target.transform.position.y) + posOffset;

        transform.position = Vector2.SmoothDamp(transform.position, targetPos, ref velSpeed, speed);

        if (playerSpeed > 11) playerSpeed = 11;
        //Zoom
        float desiredZoom = defaultZoom + (playerSpeed / 2); //+ height;
        Camera.main.orthographicSize =
            Mathf.SmoothDamp(Camera.main.orthographicSize, desiredZoom, ref velZoom, zoomSpeed);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }

}
