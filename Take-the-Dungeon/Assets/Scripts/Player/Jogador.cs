using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jogador : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rig;
    private Vector2 direction;
    
    [Header("Status")]
    public int vida;
    public int energia;
    public int xp;

    // Update is called once per frame

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));//armazena o imput pressionado
    }

    private void FixedUpdate()
    {
        rig.MovePosition(rig.position + direction * speed * Time.fixedDeltaTime);//velocidade.
    }
}
