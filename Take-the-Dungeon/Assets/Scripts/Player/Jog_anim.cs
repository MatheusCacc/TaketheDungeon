using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jog_anim : MonoBehaviour
{
    private Jogador player;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Jogador>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (player.direction.sqrMagnitude) {
            case 0:
                anim.SetInteger("transition", 0);
                break;
            case 1:
                if (player.direction.y > 0) {
                    anim.SetInteger("transition", 1);
                } else if (player.direction.y < 0) {
                    anim.SetInteger("transition", 4);
                }
                if (player.direction.x < 0) {
                    anim.SetInteger("transition", 2);
                } else if (player.direction.x > 0) {
                    anim.SetInteger("transition", 3);
                }
                break;
        }
    }
}
