using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{

	private Rigidbody2D rb;

	public Vector3 target = new Vector3(0, 0, 0);

        void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

        void Update()
    {
        transform.eulerAngles = new Vector3(0f, 0f, Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg - 90);
    }

    void FixedUpdate()
    {
        float vision = 5f;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, vision);
        for (int i = 0; i < colliders.Length; i++)
        {
        	if(colliders[i].gameObject == gameObject) continue;
        	Boid boid = colliders[i].gameObject.GetComponent<Boid>();
        	if(boid)
        	{
        		Vector3 pos = colliders[i].gameObject.transform.position;
        		float dist = Vector3.Distance(transform.position, pos);
        		pos -= transform.position;
        		dist = Mathf.Max(1f, dist);
        		if(dist < 3) target -= pos / dist * 100;
        		target += pos / dist;
        		target += boid.target * 10f;
        	}
        }

        target.Normalize();
        rb.velocity += new Vector2(target.x, target.y);
        rb.velocity *= 0.9f;
    }

}
