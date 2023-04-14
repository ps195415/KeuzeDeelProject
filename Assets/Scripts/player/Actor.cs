using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public float speed = 5;
    protected Rigidbody2D rb;
    public GameObject killFx, bullet, coin;


    protected int dashCooldown;

    protected bool dashing;
    protected Vector2 dashDir;
    protected float dashSpeed = 15f;
    protected int dashDuration = 35;
    protected int dashC;

    protected bool readyToFire = true;

    protected SpriteRenderer sr;
    protected Color dColor;

    [SerializeField]
    protected int health = 5;

    public ParticleSystem ps;
    private ParticleSystem.EmissionModule em;

    protected virtual void Init() { }


    protected void Aim(Vector3 target)
    {
        Vector2 dir = transform.position - target;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
    }

    protected void Move(Vector2 dir)
    {
        float pen = 1;
        if ((dir.x > 0.5f || dir.x < -0.5f) && (dir.y > 0.5f || dir.y < -0.5f))
        {
            pen = 1.35f;
        }

        rb.velocity = dir.normalized * GetSpeed() * pen;
    }

    protected virtual float GetSpeed()
    {
        return speed;
    }

    protected void Fire()
    {

    }

}
