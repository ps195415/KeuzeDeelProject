using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;

    private float speed = 0.7f;
    private Vector2 velSpeed;

    private float defaultZoom = 5f;
    private float zoomSpeed = 1f;
    private float velZoom;

    private Vector2 startPos;
    private Transform roomT;

    public Camera _cam;

    public static CameraMovement Instance { get; set; }

    private void Awake()
    {
        Instance = this;
        startPos = transform.position;
    }

    void FixedUpdate()
    {
        if (player == null) return;
        //Movement
        float playerSpeed = PlayerMovements.Instance.GetRb().velocity.magnitude;
        Vector2 posOffset = PlayerMovements.Instance.GetRb().velocity / 1.75f;
        Vector2 myPos = new Vector2(player.transform.position.x, player.transform.position.y) + posOffset;

        transform.position = Vector2.SmoothDamp(transform.position, myPos, ref velSpeed, speed);

        if (playerSpeed > 11) playerSpeed = 11;
        //Zoom
        float desiredZoom = defaultZoom + (playerSpeed / 2); //+ height;
        Camera.main.orthographicSize =
            Mathf.SmoothDamp(Camera.main.orthographicSize, desiredZoom, ref velZoom, zoomSpeed);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }

    public void SetPlayer(Transform t)
    {
        player = t;
    }

    public void StartRound()
    {
        _cam.orthographicSize = 0.1f;
        transform.position = player.transform.position;
    }

    public void SetRoom(Transform pos)
    {
        roomT = pos;
    }

}
