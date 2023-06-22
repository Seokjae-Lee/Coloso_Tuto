using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player_Script : MonoBehaviour
{
    public static Player_Script Instance { get; private set; }

    public void Awake()
    {
        Instance = this;
    }
    private void OnDestroy()
    {
        Instance = null;
    }

    public void Init_Game()
    {

    }

    public void Player_Dead()
    {
        Debug.Log("END");
    }






    public VariableJoystick variableJoystick;


    public float speed;
    private Rigidbody rb;
    public AudioSource item_sound;

    public bool isjump;

    public int score; 

    //public int left_item;

    public GameObject end_image;
    public GameObject over_image;
    public GameObject regame_point;

    public float time_limit;

    public TextMeshProUGUI score_text;
    public TextMeshProUGUI time_text;

    public Animator anim;









    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // left_item = 8;

        GameManager.Instance.Player_Dead();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isjump = true;
        }

        if(collision.gameObject.tag == "Regame")
        {
            Regame_On();
        }
    }

    public void Regame_On()
    {
        this.transform.position = regame_point.transform.position;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Item")
        {
            other.gameObject.SetActive(false);
            item_sound.Play();
            score += 10;
            //left_item--;
        }

        if (other.tag == "Jump_Item")
        {
            other.gameObject.SetActive(false);
            item_sound.Play();
            score += 20;
           // left_item--;
        }

        Debug.Log("My Score Is :" + score);
        //Debug.Log("Left Item is:" + left_item);

        if (score >= 100)
        {
            end_image.SetActive(true);
          
        }

        score_text.text = score + "/100";
    }

    //��������� ���� ����ϴ� ����ȣ��
    private void FixedUpdate()
    {
        /* 컴퓨터 이동 코드
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        rb.AddForce(movement * speed);

        if(Input.GetKey(KeyCode.Space) && isjump)
        {
            isjump = false;
            rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }


        //time call
        time_limit -= Time.deltaTime;
        time_text.text = "Left Time :" + Mathf.Round(time_limit);

        if (time_limit <= 0)
        {
            over_image.SetActive(true);
            time_limit = 0;
        }
        */

        

        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        transform.LookAt(transform.position + direction);
        //rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange); //구체 이동
        transform.position += direction * speed * Time.deltaTime;
        anim.SetBool("isRun", direction != Vector3.zero);

        FreezeRotation();
    }

    void FreezeRotation()
    {
        rb.angularVelocity = Vector3.zero;
    }

    public void jump_on()
    {
        if (isjump)
        {
            isjump = false;
            rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }
    }

}

