using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D theRB;

    public float moveSpeed;
    public float jumpForce;

    public Transform groundPoint;
    private bool isOnGround;
    public LayerMask whatIsGround;

    public Animator anim;

    public BulletController shotToFire;

    public Transform shotPoint;

    private bool canDoubleJump;

    public float dashSpeed, dashTime;

    private float dashCounter;

    public SpriteRenderer theSR, afterImage;
    public float afterImageLifetime, timeBetweenAfterImages;
    private float afterImageCounter;
    public Color afterImageColor;

    public float waitAfterDashing;
    private float dashRechargeCounter;

    public GameObject standing;
    public GameObject ball;
    public float waitToBall;
    private float ballCounter;
    public Animator ballAnim;

    public Transform bombPoint;
    public GameObject bomb;

    private PlayerAbilityTracker abilities;
    public bool canMove;

    public bool canShoot;


    // Start is called before the first frame update
    void Start()
    {
        abilities = GetComponent<PlayerAbilityTracker>();
        canMove = true;
        canShoot = true;
    }
    // Update is called once per frame
    void Update()
    {

        if (canMove)
        {
            dashRechargeCounter -= Time.deltaTime;
        }
        else
        {
            if (Input.GetButtonDown("Fire2") && standing.activeSelf && abilities.canDash)
            {
                dashCounter = dashTime;

                // ShowAfterImage();
            }
        }


        if (dashCounter >= 0)
        {
            dashCounter -= Time.deltaTime;
            theRB.velocity = new Vector2(dashSpeed * transform.localScale.x, theRB.velocity.y);

            afterImageCounter -= Time.deltaTime;
            if (afterImageCounter <= 0)
            {
                // ShowAfterImage();
            }

            dashRechargeCounter = waitAfterDashing;

        }
        else
        {
            //move sideways
            theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, theRB.velocity.y);

            //flip player
            if (theRB.velocity.x < 0)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else if (theRB.velocity.x > 0)
            {
                transform.localScale = Vector3.one;
            }
        }

        //check if player is on ground
        isOnGround = Physics2D.OverlapCircle(groundPoint.position, 0.2f, whatIsGround);

        if (Input.GetButtonDown("Jump") && (isOnGround || (canDoubleJump && abilities.canDoubleJump)))
        {
            if (isOnGround)
            {
                canDoubleJump = true;
                if (dashRechargeCounter > 0)
                {
                    dashRechargeCounter -= Time.deltaTime;
                }
                else
                {
                    if (Input.GetButtonDown("Fire2") && standing.activeSelf)
                    {
                        dashCounter = dashTime;

                        // ShowAfterImage();
                    }
                }


                //shooting
                if (Input.GetButtonDown("Fire1"))
                {
                    if (standing.activeSelf)
                    {

                        Instantiate(shotToFire, shotPoint.position, shotPoint.rotation).moveDir = new Vector2(transform.localScale.x, 0f);
                        anim.SetTrigger("shotFired"); //play animation
                    }
                    else if (ball.activeSelf && abilities.canDropBomb)
                    {
                        Instantiate(bomb, bombPoint.position, bombPoint.rotation);
                    }

                }


                //ball mode
                if (!ball.activeSelf)
                {
                    if (Input.GetAxisRaw("Vertical") < -.9f && abilities.canBecomeBall)
                        if (dashCounter >= 0)
                        {
                            dashCounter -= Time.deltaTime;
                            theRB.velocity = new Vector2(dashSpeed * transform.localScale.x, theRB.velocity.y);

                            afterImageCounter -= Time.deltaTime;
                            if (afterImageCounter <= 0)
                            {
                                // ShowAfterImage();
                            }

                            dashRechargeCounter = waitAfterDashing;

                        }
                        else
                        {
                            //move sideways
                            theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, theRB.velocity.y);

                            //flip player
                            if (theRB.velocity.x < 0)
                            {
                                transform.localScale = new Vector3(-1f, 1f, 1f);
                            }
                            else if (theRB.velocity.x > 0)
                            {
                                transform.localScale = Vector3.one;
                            }
                        }

                    //check if player is on ground
                    isOnGround = Physics2D.OverlapCircle(groundPoint.position, 0.2f, whatIsGround);

                    if (Input.GetButtonDown("Jump") && (isOnGround || canDoubleJump))
                    {
                        if (isOnGround)
                        {
                            canDoubleJump = true;
                        }
                        else
                        {
                            canDoubleJump = false;
                            anim.SetTrigger("doubleJump");
                        }

                        theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                    }

                    //shooting
                    if (canShoot)
                    {


                        if (Input.GetButtonDown("Fire1"))
                        {
                            Instantiate(shotToFire, shotPoint.position, shotPoint.rotation).moveDir = new Vector2(transform.localScale.x, 0f);

                            anim.SetTrigger("shotFired"); //play animation
                        }

                    }

                    //ball mode
                    if (!ball.activeSelf)
                    {
                        if (Input.GetAxisRaw("Vertical") < -.9f)
                        {
                            ballCounter -= Time.deltaTime;
                            if (ballCounter <= 0)
                            {
                                ball.SetActive(true);
                                standing.SetActive(false);
                            }
                        }
                        else
                        {
                            ballCounter = waitToBall;
                        }
                    }
                    else
                    {
                        if (Input.GetAxisRaw("Vertical") > +.9f)
                        {
                            ballCounter -= Time.deltaTime;
                            if (ballCounter <= 0)
                            {
                                ball.SetActive(false);
                                standing.SetActive(true);
                            }
                        }
                        else
                        {
                            ballCounter = waitToBall;
                        }
                    }
                }
                else
                {
                    theRB.velocity = Vector2.zero;
                }

                if (standing.activeSelf)
                {
                    anim.SetBool("isOnGround", isOnGround);
                    anim.SetFloat("speed", Mathf.Abs(theRB.velocity.x));
                }

                if (ball.activeSelf)
                {
                    ballAnim.SetFloat("speed", Mathf.Abs(theRB.velocity.x));
                }
            }

            // public void ShowAfterImage()
            //     {
            //         SpriteRenderer image = Instantiate(afterImage, transform.position, transform.rotation);
            //         image.sprite = theSR.sprite;
            //         image.transform.localScale = transform.localScale;
            //         image.color = afterImageColor;

            //         Destroy(image.gameObject, afterImageLifetime);

            //         afterImageCounter = timeBetweenAfterImages;

            //     }
        }
    }
}
