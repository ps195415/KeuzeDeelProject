using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Actor
{
    public GameObject goldFx;
    public static PlayerMovement Instance { get; set; }
    private bool invincible;
    private int cooldown;
    private int pCooldown;

    public int soda, helmet, sneaker;

    public GameObject currentWeapon;
    public GameObject chest;

    private int gold;

    private Vector2 pushDir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        Instance = this;
    }

    public Rigidbody2D GetRb()
    {
        return rb;
    }

    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Aim(mousePos);

        if (pCooldown > 0)
            return;
        if (dashing)
            return;

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Move(new Vector2(x, y));

        //Shooting
        if (Input.GetMouseButton(0))
        {
            Fire();
        }
        
    }

    private void FixedUpdate()
    {
        if (dashCooldown > 0) dashCooldown--;

        if (invincible)
        {
            float a = Mathf.PingPong(Time.time * 10, 0.6f) + 0.3f;
            if (a > 0.7f)
                sr.color = dColor;
            else sr.color = Color.black;

            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, a / 1.3f);

            cooldown--;
            pCooldown--;

            if (cooldown < 1)
            {
                invincible = false;
            }

            if (pCooldown > 0)
            {
                rb.velocity = pushDir;
                return;
            }

            if (cooldown == 0) sr.color = dColor;
        }
        
    }


}
