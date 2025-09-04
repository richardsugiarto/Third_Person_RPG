using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Animator player_move_animation;

    [SerializeField]
    private Transform player_transform;

    private Vector3 move_Direction;

    private Camera TP_camera;

    [Range (1,20)]
    public float player_rotation_speed;

    public float damp = 3f;

    // Start is called before the first frame update
    void Start()
    {
        player_move_animation = GetComponent<Animator>();
        TP_camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    { 
        PlayerMove();
    }

    void PlayerMove()
    {
        move_Direction = new Vector3(Input.GetAxis(Axis.HORIZONTAL), 0f, Input.GetAxis(Axis.VERTICAL));

        player_move_animation.SetFloat("speed", Vector3.ClampMagnitude(move_Direction,1).magnitude,damp,Time.deltaTime*10);
        print(Vector3.ClampMagnitude(move_Direction, 1).magnitude);
        Vector3 rotationOffset = TP_camera.transform.TransformDirection(move_Direction);
        rotationOffset.y = 0f;
        player_transform.forward = Vector3.Slerp(player_transform.forward, rotationOffset, Time.deltaTime* player_rotation_speed);
    }
}
