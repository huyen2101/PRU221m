using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLight : MonoBehaviour
{
    private Transform target;
    public GameObject Circle;
    public GameObject CircleUp;
    public float speed = 0.0001f;
    public float dame = 0.1f;
    public bool isBurn = false;
    public float bonusDamage = 0f;
    public int burnStacks = 3;
    public void Seek(Transform _target)
    {
        target = _target;

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            Debug.Log("===== targer info:" + target);
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        Path e = target.GetComponent<Path>();
        Debug.Log("Path: " + e);
        Debug.Log("Dame: " + dame);
        Debug.Log("Health: " + e.health);

        e.health -= dame;

        //bonusDamage = dame / 5f;
        if (e.health <= 0)
        {
            e.HealthBar.fillAmount = 0;
        }
        else
        {
            e.HealthBar.fillAmount = e.health;
        }
        Debug.Log("we hit");
        Destroy(gameObject);
        e.moveSpeed = 1.5f;

        /*      GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
              Destroy(effectIns, 5f);

              if (explosionRadius > 0f)
              {
                  Explode();
              }
              else
              {
                  Damage(target);
              }

              Destroy(gameObject);*/
    }
}
