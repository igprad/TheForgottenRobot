using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
namespace UnitySampleAssets._2D
{

    public class PlatformerCharacter2D : MonoBehaviour
    {
        private UnitySampleAssets._2D.Platformer2DUserControl control;
        private int tempCounter=0;
        public LevelManager levelManager;

        public static bool mati = false;

        private bool facingRight = true; // For determining which way the player is currently facing.

        [SerializeField] private float maxSpeed = 10f; // The fastest the player can travel in the x axis.
        [SerializeField] private float jumpForce = 400f; // Amount of force added when the player jumps.	

        [Range(0, 1)] [SerializeField] private float crouchSpeed = .36f;
                                                     // Amount of maxSpeed applied to crouching movement. 1 = 100%

        [SerializeField] private bool airControl = false; // Whether or not a player can steer while jumping;
        [SerializeField] private LayerMask whatIsGround; // A mask determining what is ground to the character

        private Transform groundCheck; // A position marking where to check if the player is grounded.
        private float groundedRadius = .2f; // Radius of the overlap circle to determine if grounded
        private bool grounded = false; // Whether or not the player is grounded.
        private Transform ceilingCheck; // A position marking where to check for ceilings
        private float ceilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
        private Animator anim; // Reference to the player's animator component.

        public static int poin2=0;

        public AudioSource deathSound;
        public Text poin;
        public AudioSource beepCoin;
        private bool hasKunci;
        public AudioSource getKey;
        AudioSource BGM;
        public AudioSource hurtSFX;
        public AudioSource jumpsfx;

        public GameObject window;
        public Text windowText;

        public GameObject windowinfo;
        public Text isiWindowInfo;
        public Image gambarMap;

        public Sprite map1, map2, map3,map4,map5,map6,map7,map8,map9;

        public GameObject Kunci1;
        public AudioSource sfxPintu;


        private void Awake()
        {
            control = GetComponent<UnitySampleAssets._2D.Platformer2DUserControl>();
            levelManager = FindObjectOfType<LevelManager>();

            // Setting up references.
            groundCheck = transform.Find("GroundCheck");
            ceilingCheck = transform.Find("CeilingCheck");
            anim = GetComponent<Animator>();
            poin.text = "0";
            hasKunci = false;
            //hasKunci = true;
            Kunci1.SetActive(false);
            //BGM = GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>();
        }


        private void FixedUpdate()
        {
            // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
            grounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);
            anim.SetBool("Ground", grounded);

            // Set the vertical animation
            anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
            jumpForce = 1050;

            if (mati == true)
            {
                StartCoroutine(Pause());
                mati = false;
                
                if (CoreGame.nyawa > 0)
                {
                    deathSound.Play();
                }
            }

            poin.text = (int.Parse(poin.text) + poin2).ToString();
            poin2 = 0;
        }


        public void Move(float move, bool crouch, bool jump)
        {


            // If crouching, check to see if the character can stand up
            if (!crouch && anim.GetBool("Crouch"))
            {
                // If the character has a ceiling preventing them from standing up, keep them crouching
                if (Physics2D.OverlapCircle(ceilingCheck.position, ceilingRadius, whatIsGround))
                    crouch = true;
            }

            // Set whether or not the character is crouching in the animator
            anim.SetBool("Crouch", crouch);

            //only control the player if grounded or airControl is turned on
            if (grounded || airControl)
            {
                // Reduce the speed if crouching by the crouchSpeed multiplier
                move = (crouch ? move*crouchSpeed : move);

                // The Speed animator parameter is set to the absolute value of the horizontal input.
                anim.SetFloat("Speed", Mathf.Abs(move));

                // Move the character
                GetComponent<Rigidbody2D>().velocity = new Vector2(move*maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

                // If the input is moving the player right and the player is facing left...
                if (move > 0 && !facingRight)
                    // ... flip the player.
                    Flip();
                    // Otherwise if the input is moving the player left and the player is facing right...
                else if (move < 0 && facingRight)
                    // ... flip the player.
                    Flip();
            }
            // If the player should jump...
            if (grounded && jump && anim.GetBool("Ground"))
            {
                // Add a vertical force to the player.
                grounded = false;
                anim.SetBool("Ground", false);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
                jumpsfx.Play();
            }
        }


        private void Flip()
        {
            // Switch the way the player is labelled as facing.
            facingRight = !facingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Spring")
            {
                jumpsfx.Play();
                jumpForce = 2500;
                Move(0f, false, true);
                jumpForce = 1050;
            }

            if (other.tag == "Spring2")
            {
                jumpsfx.Play();
                jumpForce = 3500;
                Move(0f, false, true);
                jumpForce = 1050;
            }

            if (other.tag == "Duri")
            {
                CoreGame.health -= 10;
                hurtSFX.Play();
                if (10 + CoreGame.health - 10 <= 0)
                {
                    mati = true;
                }
            }

            if (other.tag == "Koin")
            {
                poin.text = (int.Parse(poin.text) + 10).ToString();
                Destroy(other.gameObject);
                beepCoin.Play();
            }

            if (other.tag == "Kunci")
            {
                Kunci1.SetActive(true);
                hasKunci = true;
                Destroy(other.gameObject);
                //BGM.mute = false;
                getKey.Play();
                //BGM.PlayDelayed(1);
            }

            if (other.tag == "Pintu")
            {
                if (hasKunci == false)
                {

                }
                else if (hasKunci == true)
                {
                    //Application.LoadLevel("Select Level");
                    windowText.text = "\t\tSelamat, Kita lanjut ke lantai berikutnya";
                    window.GetComponent<Animator>().SetTrigger("Open");
                    sfxPintu.Play();
                    if (Application.loadedLevelName == "Level 1") { 
                        if(LevelProgress.level.Count==0)
                            LevelProgress.Save();
                    }
                    if (Application.loadedLevelName == "Level 2")
                    {
                        if (LevelProgress.level.Count == 1)
                            LevelProgress.Save();
                    }
                    if (Application.loadedLevelName == "Level 3") {
                        Application.LoadLevel("Credit");
                    }
                    BGM.Pause();
                }
            }

            if (other.tag == "Info1")
            {
                windowinfo.GetComponent<Animator>().SetTrigger("Open");
                gambarMap.sprite = map1;
                //isiWindowInfo = windowinfo.GetComponent<Text>();
                isiWindowInfo.text = "\t\tInformasi:\n\nIni adalah peta yang tersedia pada level ini."
                    +"\nAnda bisa menembak saat ini..\nHarap berhati-hati terhadap robot rusak yang ada . . .";
            }

            if (other.tag == "Info2")
            {
                windowinfo.GetComponent<Animator>().SetTrigger("Open");
                gambarMap.sprite = map2;
                //isiWindowInfo = windowinfo.GetComponent<Text>();
                isiWindowInfo.text = "\t\tInformasi:\n\nPercayalah dan yakinlah, apa yang didepan mata, belum tentu seperti yang anda pikirkan";
            }

            if (other.tag == "Info3")
            {
                windowinfo.GetComponent<Animator>().SetTrigger("Open");
                gambarMap.sprite = map3;
                //isiWindowInfo = windowinfo.GetComponent<Text>();
                isiWindowInfo.text = "\t\tInformasi:\n\nAnda harus mendapatkan kunci terlebih dahulu";
            }

            if (other.tag == "Info4")
            {
                
                windowinfo.GetComponent<Animator>().SetTrigger("Open");
                gambarMap.sprite = map4;
                //isiWindowInfo = windowinfo.GetComponent<Text>();
                isiWindowInfo.fontSize = 20;
                isiWindowInfo.text = "\t\tInformasi:\n\nTombol dipojok kiri bawah berguna untuk menggerakkan karakter\nTombol di pojok kanan bawah untuk melakukan aksi : \n- Tombol A = menembak (di level 1 belum ada fitur menembak)\n- Tombol B = melompat";

            }

            if (other.tag == "Info5")
            {
                windowinfo.GetComponent<Animator>().SetTrigger("Open");
                gambarMap.sprite = map5;
                isiWindowInfo.fontSize = 35;
                //isiWindowInfo = windowinfo.GetComponent<Text>();
                isiWindowInfo.text = "\t\tInformasi:\n\nIni adalah peta yang tersedia pada level ini. \nHarap ingat dengan baik-baik.";
            }

            if (other.tag == "Info6")
            {
                windowinfo.GetComponent<Animator>().SetTrigger("Open");
                gambarMap.sprite = map6;
                isiWindowInfo.fontSize = 35;
                //isiWindowInfo = windowinfo.GetComponent<Text>();
                isiWindowInfo.text = "\t\tInformasi:\n\nAnda harus mendapatkan kunci terlebih dahulu";
            }

            if (other.tag == "Info 7") {
                windowinfo.GetComponent<Animator>().SetTrigger("Open");
                gambarMap.sprite = map7;
                isiWindowInfo.text = "\t\tInformasi:\n\nIni adalah peta yang tersedia pada level ini. \nHarap ingat dengan baik-baik.\nHarap berhati-hati terhadap duri yang ada...";
            }

            if (other.tag == "Info 8")
            {
                windowinfo.GetComponent<Animator>().SetTrigger("Open");
                gambarMap.sprite = map8;
                isiWindowInfo.text = "\t\tInformasi:\n\nIni adalah peta yang tersedia pada level ini. \nPosisi Anda Berada di sini.\n";
            }


            if (other.tag == "Info 9")
            {
                windowinfo.GetComponent<Animator>().SetTrigger("Open");
                gambarMap.sprite = map9;
                isiWindowInfo.text = "\t\tInformasi:\n\nAnda harus mengambil kunci terlebih dahulu";
            }


            if (other.tag == "KillZone")
            {
                if (tempCounter == 0)
                {
                    mati = true;
                    
                    CoreGame.nyawa--;
                    tempCounter = 1;
                }
            }

        }



        public void exitWindowInfo()
        {
            windowinfo.GetComponent<Animator>().SetTrigger("Exit");
        }

        IEnumerator Pause()
        {
            

            control.enabled = false;
            anim.Play("Death");
            yield return new WaitForSeconds(1f);
            levelManager.RespawnPlayer();
            control.enabled = true;
            tempCounter = 0;
            anim.Play("Idle");
            mati = false;
        }

    }

    
}