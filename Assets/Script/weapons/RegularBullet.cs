using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularBullet : Bullet
{

    protected Rigidbody2D rb;

    public override BulletDataSO BulletData
    {

        get => base.BulletData;
        set
        {
            base.BulletData = value;
            rb = GetComponent<Rigidbody2D>();
            rb.drag = BulletData.Friction;
        }

    }

    private void FixedUpdate()
    {
        if(rb != null && BulletData != null)
        {
            rb.MovePosition(transform.position + BulletData.BulletSpeed * transform.right * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var hittable = collision.GetComponent<Ihittable>();
        hittable?.GetHit(bulletData.Damage, gameObject);

        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            HitObstacle();
        }else if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy")){
            HitEnemy();
        }

        Destroy(gameObject);
    }

    private void HitEnemy()
    {
        Debug.Log("hit enemy");
    }

    private void HitObstacle()
    {
        Debug.Log("Hitting obstacle");
    }
}
