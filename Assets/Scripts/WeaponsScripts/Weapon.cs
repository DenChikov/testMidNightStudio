using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float damage = 0.2f;
    [SerializeField] private float fireRate = 0.1f;
    [SerializeField] private float nextTimeFire;
    private ParticleSystem shootEffect;
    private Camera playerCamer;

    private void Start()
    {
        shootEffect = GetComponentInChildren<ParticleSystem>();
        playerCamer = GameObject.Find("playerCamera").GetComponent<Camera>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shootEffect.Play();
            Shoot();
        }
    }
    private void Shoot()
    {
        if (Time.time >= nextTimeFire)
        {
            nextTimeFire = Time.time + fireRate;
            Ray ray = playerCamer.ViewportPointToRay(new Vector3(3f, 3f, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider != null && hit.collider.CompareTag("Enemy"))
                {
                    hit.collider.GetComponent<EnemysGetDamage>().TakeDamage(damage);
                }
            }
        }

    }

}
