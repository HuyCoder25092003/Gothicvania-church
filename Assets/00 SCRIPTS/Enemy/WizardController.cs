using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardController : MonoBehaviour
{
    //[SerializeField] float speed;

    [SerializeField] GameObject _bullet;
    [SerializeField] float maxTimeShoot = 3;
    float countTime = 0;
    [SerializeField] GameObject shooting;
    WizardAnimations wizardAnimations;

    // Start is called before the first frame update
    void Start()
    {
        //rigi = GetComponent<Rigidbody2D>();
        wizardAnimations = GetComponentInChildren<WizardAnimations>();
    }
    void Update()
    {
        
        Fire();
    }
    //void FixedUpdate()
    //{
    //    Moving();
    //}
    //void Moving()
    //{
    //    rigi.velocity = transform.right * speed;
    //}
    //void Flip()
    //{
    //    Quaternion rotation = transform.rotation;
    //    if (rotation.y == 0)
    //        rotation.y = 180;
    //    else rotation.y = 0;
    //    transform.rotation = rotation;
    //}

    void Fire()
    {
        countTime-=Time.deltaTime;
        if (countTime > 0)
            return;
        wizardAnimations.anim.SetTrigger("Fire");
        countTime = maxTimeShoot;
    }
    
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.CompareTag("Wall"))
    //        Flip();
    //}



}
