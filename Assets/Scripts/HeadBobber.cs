using UnityEngine;

public class HeadBobber : MonoBehaviour
{
    public AudioSource footstep1;
    public AudioSource footstep2;
    public float walkingBobbingSpeed = 14f;
    public float bobbingAmount = 0.05f;
    public PlayerMovement controller;
    private float sinCount;
    private bool hasRunChanged = false;
    float defaultPosY = 0;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        defaultPosY = transform.localPosition.y;

        footstep1.GetComponent<AudioSource>();
        footstep2.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.moveSpeed == 2)
        {
            walkingBobbingSpeed = 14f;
            bobbingAmount = 0.05f;
        }
        else if (controller.moveSpeed == 4)
        {
            walkingBobbingSpeed = 28f;
            bobbingAmount = 0.1f;
        }
        
        if (Mathf.Abs(controller.horizontalInput) > 0.1f || Mathf.Abs(controller.verticleInput) > 0.1f)
        {
            //Player is moving
            timer += Time.deltaTime * walkingBobbingSpeed;
            sinCount = Mathf.Sin(timer);
            transform.localPosition = new Vector3(transform.localPosition.x, defaultPosY + Mathf.Sin(timer) * bobbingAmount, transform.localPosition.z);
        }
        else
        {
            //Idle
            timer = 0;
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, defaultPosY, Time.deltaTime * walkingBobbingSpeed), transform.localPosition.z);
        }

        if (sinCount > 0.9) footstep1.Play();
        //else if (sinCount < -0.9) footstep2.Play();
    }
}

