using System.Collections;
using System.Timers;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerControl : MonoBehaviour
{
    public bool onDisappearingPlatform;
    public GameObject[] disappearingPlatforms1;
    public GameObject[] disappearingPlatforms2;
    public GameObject[] disappearingPlatforms3;

    public bool turnoff;
    public GameObject wall = null;
    public GameObject ground = null;
    public GameObject powerUp = null;

    public float moveSpeed;
    public float jumpHeight;
    public double bounceHeight;
    public double tempBounceHeight;
    public double trampolineHeight;
    private bool idle;

    public bool bounce;
    public bool sPress;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool grounded;

    public int direction; //right is 1, left is 2

    public bool dashBomb;
    public bool miniGun;

    public bool hasDoubleJump;
    public bool hasAirDash;
    public bool hasDashBomb;

    string loadscenetemp;
    string loadscene;

    private Animator anim;
    public GameObject saveManagerScript;

    // Use this for initialization
    void Start()
    {
        bounceHeight = jumpHeight * 1.3;
        trampolineHeight = bounceHeight * 2;
        tempBounceHeight = bounceHeight;
        direction = 1; //Start facing right as the default
        anim = GetComponent<Animator>();
        idle = true;

        if(ES3.FileExists("SaveData.es3"))
        {
            hasDoubleJump = ES3.Load<bool>("hasDoubleJump");
            hasAirDash = ES3.Load<bool>("hasAirDash");
            hasDashBomb = ES3.Load<bool>("hasDashBomb");
        }
        else
        {
            hasDoubleJump = false;
            hasAirDash = false;
            hasDashBomb = false;
        }

        if (hasDoubleJump) GetComponent<doubleJump>().enabled = true;
        if (hasAirDash) GetComponent<airDash>().enabled = true;
        if (hasDashBomb) GetComponent<DashBomb>().enabled = true;


        loadscenetemp = SceneManager.GetActiveScene().name;
        loadscene = "LocationData_" + loadscenetemp + ".es3";

        if(ES3.FileExists(loadscene))
        {
            transform.localPosition = ES3.Load<Vector3>("Location", loadscene);
        }
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround); //Ground MUST be in "Ground" Layer
    }

    // Update is called once per frame
    void Update()
    {
        if (turnoff && wall)
        {
            wall.SendMessage("destroyWall");
        }

        //BASIC MOVEMENT BEGIN

        if ((Input.GetKey(KeyCode.D) || Input.GetAxis("DPadHorizontal") > 0f) && !GetComponent<airDash>().airDashingCurrently)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            direction = 1;
            idle = false;
            
        }

        if ((Input.GetKey(KeyCode.A) || Input.GetAxis("DPadHorizontal") < 0f) && !GetComponent<airDash>().airDashingCurrently)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            direction = 2;
            idle = false;
            
        }

        if ((Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A)) && !GetComponent<airDash>().airDashingCurrently && !GetComponent<GroundDash>().dashingCurrently)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
            idle = true;
           
        }

        if(Input.GetAxis("DPadHorizontal") == 0f && !GetComponent<airDash>().airDashingCurrently && !GetComponent<GroundDash>().dashingCurrently && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
            idle = true;
            
        }

        if (Input.GetButtonDown("Jump") && grounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight); //Jump
        }

        if (Input.GetButtonDown("Bounce"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -30); //Barrels towards the ground to maintain bounce momentum
            
            if (!grounded) sPress = true;
        }

        if (Input.GetButtonDown("ResetPlatforms") && !onDisappearingPlatform && grounded)
        {
            
            disappearingPlatforms1 = GameObject.FindGameObjectsWithTag("DisappearingPlatform1");
            disappearingPlatforms2 = GameObject.FindGameObjectsWithTag("DisappearingPlatform2");
            disappearingPlatforms3 = GameObject.FindGameObjectsWithTag("DisappearingPlatform3");

            foreach (GameObject disappearingPlatform in disappearingPlatforms1)
            {
                disappearingPlatform.SendMessage("Reset");
            }
            foreach (GameObject disappearingPlatform in disappearingPlatforms2)
            {
                disappearingPlatform.SendMessage("Reset");
            }
            foreach (GameObject disappearingPlatform in disappearingPlatforms3)
            {
                disappearingPlatform.SendMessage("Reset");
            }
        }

        if (bounce)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, (float)bounceHeight);
            
            bounce = false;
            bounceHeight = tempBounceHeight;
        }

        //BASIC MOVEMENT END

        anim.SetBool("Grounded", grounded);
        anim.SetInteger("Direction", direction);
        anim.SetBool("Idle", idle);
        anim.SetBool("Bouncing", sPress);
        anim.SetBool("HasDashBomb", hasDashBomb);
        anim.SetBool("DashBomb", GetComponent<airDash>().airDashingCurrently);
        anim.SetBool("DoubleJumping", GetComponent<doubleJump>().djAnim);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if ((collision.CompareTag("Ground") || (collision.CompareTag("Trampoline")) || collision.CompareTag("DisappearingPlatform1") || collision.CompareTag("DisappearingPlatform2") || collision.CompareTag("DisappearingPlatform3") || collision.CompareTag("SaveSpot") || collision.CompareTag("RotatingPlatform")) && sPress)
        {
            bounce = true;
            sPress = false;
            
            if (collision.CompareTag("Trampoline"))
            {
                ground = collision.gameObject;
                ground.SendMessage("SetTrampolineTrue");
                tempBounceHeight = bounceHeight;
                bounceHeight = trampolineHeight;
            }
        }
        else if (collision.CompareTag("Trampoline"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, (float)bounceHeight);
        }

        else if (collision.CompareTag("SaveSpot"))
        {
            string sceneName = SceneManager.GetActiveScene().name;
            string location = "LocationData_" + sceneName + ".es3";

            Vector3 v = new Vector3(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);
            ES3.Save<Vector3>("Location", v, location);
            ES3.Save<string>("Scene", sceneName, "LocationData.es3");
            Debug.Log("Saved " + sceneName);
        }

        if (collision.CompareTag("DisappearingPlatform1") || collision.CompareTag("DisappearingPlatform2") || collision.CompareTag("DisappearingPlatform3"))
        {
            onDisappearingPlatform = true;
        }

        if (collision.CompareTag("DoubleJumpPowerUp") || collision.CompareTag("AirDashPowerUp") || collision.CompareTag("DashBombPowerUp") || collision.CompareTag("MiniGunPowerUp"))
        {
            powerUp = collision.gameObject;
            powerUp.SendMessage("PowerUpAttained");
            Debug.Log("Message sent: PowerUpAttained");
            powerUp = null;

            if (collision.CompareTag("DoubleJumpPowerUp"))
            {
                GetComponent<doubleJump>().enabled = true;
                hasDoubleJump = true;
                Save();
            }
            else if (collision.CompareTag("AirDashPowerUp"))
            {
                GetComponent<airDash>().enabled = true;
                hasAirDash = true;
                Save();
            }
            else if (collision.CompareTag("DashBombPowerUp"))
            {
                GetComponent<DashBomb>().enabled = true;
                hasDashBomb = true;
                Save();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Trampoline"))
        {
            ground = null;
        }

        if (collision.CompareTag("DisappearingPlatform1") || collision.CompareTag("DisappearingPlatform2") || collision.CompareTag("DisappearingPlatform3"))
        {
            collision.gameObject.SendMessage("Bounce");
            onDisappearingPlatform = false;
        }
    }

    public void Save()
    {
        ES3.Save<bool>("hasDoubleJump", hasDoubleJump);
        ES3.Save<bool>("hasAirDash", hasAirDash);
        ES3.Save<bool>("hasDashBomb", hasDashBomb);
    }
}
