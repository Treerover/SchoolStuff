using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float MaxLifeTime = 3.0f;
    public float Speed = 20.0f;

    public void Init(Vector3 position, Vector3 velocity)
    {
        transform.position = position;
        m_Velocity = velocity;
        m_TimeLeftTillDestroy = MaxLifeTime;
    }

	// Update is called once per frame
	void Update ()
    {
        transform.position += m_Velocity * Speed * Time.deltaTime;

        m_TimeLeftTillDestroy -= Time.deltaTime;

        if(m_TimeLeftTillDestroy <= 0.0f)
        {
            gameObject.SetActive(false);
        }
	}

    void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject != null)
        {
            this.gameObject.SetActive(false);
        }
    }

    float m_TimeLeftTillDestroy;
    Vector3 m_Velocity;
}
