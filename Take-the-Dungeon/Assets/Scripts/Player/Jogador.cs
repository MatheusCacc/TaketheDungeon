using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jogador : MonoBehaviour
{
    public float speed;
    public float runspeed;
    
    private float initialspeed;
    private Rigidbody2D rig;
    private Vector2 _direction;

    public Vector2 direction{
        get { return _direction;}
        set { _direction = value;}
    } 

    // Update is called once per frame

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        initialspeed = speed;
    }
    void Update()
    {
        OnImput();
        OnRun();
    }

    private void FixedUpdate()
    {
        OnMove();

    }

    #region Movimentação

    void OnImput() {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnMove() {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }

    void OnRun() {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            speed = runspeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            speed = initialspeed;
        }
    }
    #endregion
}
