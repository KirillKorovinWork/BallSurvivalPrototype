using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehavior : MonoBehaviour
{
    private Transform target;
    private float speed = 15.0f;
    private bool homing;

    private float rocketStrength = 15.0f;
    private float aliveTimer = 5.0f;

    void Update()
    {
        if(homing && target != null)
        {
            Vector3 moveDitection = (target.transform.position - transform.position).normalized;
            transform.position += moveDitection * speed * Time.deltaTime;
            transform.LookAt(target);
        }
    }

    private void OnCollisionEnter(Collision col) 
    {
        if(target != null)
        {
            if(col.gameObject.CompareTag(target.tag))
            {
                Rigidbody targetRigidbody = col.gameObject.GetComponent<Rigidbody>();
                Vector3 away = col.contacts[0].normal;
                targetRigidbody.AddForce(away * rocketStrength, ForceMode.Impulse);
                Destroy(gameObject);
            }
        }   
    }

    public void Fire(Transform newTarget)
    {
        target = newTarget;
        homing = true;
        Destroy(gameObject, aliveTimer);
    }
}
