using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rigi;
    [SerializeField] float speed;
    [SerializeField] float timeDestruct = 5;

    // Start is called before the first frame update
    void Start()
    {
        rigi = this.GetComponent<Rigidbody2D>();
        StartCoroutine(autoDestruc());
    }

    // Update is called once per frame
    void Update()
    {
        rigi.velocity = -this.transform.right * speed;
    }
    IEnumerator autoDestruc()
    {
        yield return new WaitForSeconds(timeDestruct);

        this.gameObject.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.gameObject.SetActive(false);

        if (collision.gameObject.GetComponent<WizardController>())
        {
            collision.gameObject.SetActive(false);
        }
    }
}
