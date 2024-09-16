using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherControl : MonoBehaviour
{
    public Collider bola;
    public KeyCode input;

    public float maxTimeHold;
    public float maxForce;

    private bool isHold = false;

    public Color color;
    private Color originalColor;

    private void Start()
    {
        originalColor = GetComponent<Renderer>().material.color;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider == bola)
        {
            ReadInput(bola);
        }
    }

    private void ReadInput(Collider collider)
    {
        if (Input.GetKey(input) && !isHold)
        {
            StartCoroutine(StartHold(collider));
        }
    }

    private IEnumerator StartHold(Collider collider)
    {
        isHold = true;

        float force = 0.0f;
        float timeHold = 0.0f;

        GetComponent<Renderer>().material.color = color;

        while (Input.GetKey(input))
        {
            force = Mathf.Lerp(0, maxForce, timeHold/maxTimeHold);

            yield return new WaitForEndOfFrame();
            timeHold += Time.deltaTime;
        }
        
        GetComponent<Renderer>().material.color = originalColor;
        
        collider.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
        isHold = false;
    }
}
