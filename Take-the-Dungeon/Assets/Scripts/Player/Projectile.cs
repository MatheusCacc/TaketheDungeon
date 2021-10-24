using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject arrow;
    public GameObject OtherProjectile;
    public Transform spawn_bullet;
    private Jogador_status sts;

    private void Start()
    {
        sts = FindObjectOfType<Jogador_status>();
    }

    void Update()
    {
        Fire();
    }
    public void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(arrow, spawn_bullet.position, transform.rotation);
        }
    }
}
