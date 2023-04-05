using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.U2D;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    float horizontalValue;
    Rigidbody2D rb;
    Vector3 m_Velocity = Vector3.zero;
    [SerializeField] private float m_MovementSmoothing = .05f;
    float speed = 40f;
    private float m_JumpForce = 800f;
    private bool jumping = false;
    public int JumpCount;
 
    /* definit chaque valeurs*/
    
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();         /* definit rigidbody en rb*/
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y == 0) /* definit la postition Y du joueur pour savoir si il est entrain de sauter, si la valeur est de 0 il est autorisé de sauter jusqu'a deux fois */

        {

            JumpCount = 0;


        }
        horizontalValue = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && jumping == false && JumpCount < 2) 
        {
            jumping = true;

        }
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 v_diff = (target - transform.position).normalized;
        float atan2 = Mathf.Atan2(v_diff.y, v_diff.x);
        
      

       

    }
   

    private void FixedUpdate()
    {
        Vector3 targetVelocity = new Vector2(horizontalValue * 10f * speed * Time.fixedDeltaTime, rb.velocity.y); /*definit la vitesse horizontale du player*/
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        if (jumping)
        {
            rb.AddForce(new Vector2(0f, m_JumpForce)); 
            JumpCount++;
            jumping = false; 
        }

    }


}
