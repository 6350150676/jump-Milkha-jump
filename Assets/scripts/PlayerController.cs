using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float GravityModifier =10.0f;
    private AudioSource PlayerAudio;
    public ParticleSystem explosionanime;
    public ParticleSystem DirtParticle;
    public AudioClip Jummp;
    public AudioClip buff;
    public float JumpForce;
    public bool IsOnGround = true;
    public bool GameOver = false;
    private Animator Playeranimator;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Playeranimator = GetComponent<Animator>();
        PlayerAudio = GetComponent<AudioSource>();
        Physics.gravity *= GravityModifier;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& IsOnGround && !GameOver)
        {
            playerRb.AddForce(Vector3.up * JumpForce , ForceMode.Impulse);
            IsOnGround = false;
            Playeranimator.SetTrigger("Jump_trig");
            DirtParticle.Stop();
            PlayerAudio.PlayOneShot(Jummp, 1.0f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsOnGround = true;
            DirtParticle.Play();
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            GameOver = true;
            Debug.Log("Game Over!!!");
            Playeranimator.SetBool("Death_b", true);
            Playeranimator.SetInteger("DeathType_int", 1);
            explosionanime.Play();
            DirtParticle.Stop();
            PlayerAudio.PlayOneShot(buff, 1.0f);
        }
    }
}
