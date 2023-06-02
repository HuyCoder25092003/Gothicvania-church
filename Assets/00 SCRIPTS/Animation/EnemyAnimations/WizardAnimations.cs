using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAnimations : MonoBehaviour
{
    public Animator anim;

    public Transform shooting;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Transform parent = transform.parent;
        shooting = parent.GetComponentInChildren<Transform>().GetChild(1);

    }

    public void DoFire()
    {
        GameObject bullet = ObjectPooling.Instant.GetObject(Resources.Load("Prefabs/Fire/Fire") as GameObject, shooting.position);
        bullet.transform.position = shooting.transform.position;
        bullet.SetActive(true);
        
    }
}
