using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour {
    public static BirdScript instance;

    [SerializeField] //Unity de kutucukların çıkmasını sağlıyo kod içinde
    private Rigidbody2D MyRigidBody = null;

    [SerializeField]
    private Animator Anim = null;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip flapClip, dieClip, pointClip;

    private float Speed = 3f;

    private float BounceSpeed = 4f;

    private bool didFlap;

    public bool isAlive;

    public int score;

    void Awake () {
        if (instance == null) {
            instance = this;
        }
        isAlive = true;
        setCameraX ();
    }

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void FixedUpdate () {
        if (isAlive) {
            Vector3 temp = transform.position;
            temp.x += Speed * Time.deltaTime; //Zıplarken ileri gitmesi için
            transform.position = temp;
            if (didFlap) {
                didFlap = false;
                MyRigidBody.velocity = new Vector2 (0, BounceSpeed); //Tıklayınca kuş yukarı zıplıyo
                audioSource.PlayOneShot (flapClip);
                Anim.SetTrigger ("FlappyFly"); //Mouse'a tıklama
            }
            if (MyRigidBody.velocity.y >= 0) { //Kuş düşürken aldığı eğim
                transform.rotation = Quaternion.Euler (0, 0, 0);
            } else {
                float angle = 0;
                angle = Mathf.Lerp (0, -90, MyRigidBody.velocity.y / 7);
                transform.rotation = Quaternion.Euler (0, 0, angle);
            }
        }
    }

    public float GetPositionX () {
        return transform.position.x;
    }

    void setCameraX () {
        CameraScript.setX = (Camera.main.transform.position.x -
            transform.position.x) - 1;

    }
    public void Uc () {
        didFlap = true;
    }

    void OnCollisionEnter2D (Collision2D Target) { //Olme
        if (Target.gameObject.tag == "Ground" || Target.gameObject.tag == "Pipe") {
            if (isAlive) {
                isAlive = false;
                Anim.SetTrigger ("BlueDie");
                audioSource.PlayOneShot (dieClip);
            }
        }
    }

    void OnTriggerEnter2D (Collider2D Target) { //Puan alma
        if (Target.gameObject.tag == "PipeHolder") {
            score++;
            GamePlayController.ornek.SetScore (score);
            audioSource.PlayOneShot (pointClip);
        }
    }
}