using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player_Script : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public AudioSource item_sound;

    public bool isjump;

    public int score;

    //public int left_item;

    public GameObject end_image;
    public GameObject over_image;

    public float time_limit;

    public TextMeshProUGUI score_text;
    public TextMeshProUGUI time_text;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       // left_item = 8;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isjump = true;
        }
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

        score_text.text = "Score :" + score + "/100";
    }

    //물리사용을 위해 사용하는 지속호출
    private void FixedUpdate()
    {
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
    }
}
