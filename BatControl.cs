using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatControl : MonoBehaviour
{
    public float flyUp;
    private bool IsAlive=true;
    private Rigidbody2D rb2d;
    private Animator animateBat;

    private AudioSource audioSource;
    public AudioClip flap;
    public AudioClip die;


    // Start is called before the first frame update
    void Start()
    {
        rb2d=GetComponent<Rigidbody2D>();   
        animateBat=GetComponent<Animator>();
        audioSource=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsAlive == true)
    	{
            if(Input.GetMouseButtonDown(0))
    		{
                rb2d.velocity=Vector2.zero;
    			rb2d.AddForce(new Vector2(0,flyUp));
                animateBat.SetTrigger("Flap");
                audioSource.PlayOneShot(flap, 1f);
            }
        }
        
    }
    void OnCollisionEnter2D(){
        rb2d.velocity=Vector2.zero;
    	IsAlive=false;
        animateBat.SetTrigger("Die");
        audioSource.PlayOneShot(die, 1f);
        GameControl.instance.BirdDied();
    }
}
