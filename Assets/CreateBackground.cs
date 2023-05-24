using UnityEngine;

public class CreateBackground : MonoBehaviour
{
    public GameObject BackgroundTilePrefab;
    //public GameObject[] BackgroundTilePrefabs;
    public GameObject BackgroundTileDead;
    public GameObject Player;

    bool myb = true;
    public double DelayAmount = 1.0;
    Vector3 oldPlayermovedV3;
    Vector3 diff;
    protected float Timer;
    private SpriteRenderer sr;
    private float RightMostBound;
    private int rightcount;
    public bool spawned = false;
    public bool ru = false;
    public bool rm = false;
    public bool rd = false;
    public bool lu = false;
    public bool lm = false;
    public bool ld = false;
    public bool um = false;
    public bool dm = false;
    private Player PlayerScript;


    // Start is called before the first frame update
    void Start()
    {
        rightcount = 1;
        RightMostBound = 20;
        oldPlayermovedV3 = Player.transform.position;
        sr = BackgroundTilePrefab.GetComponent<SpriteRenderer>();
        PlayerScript = Player.GetComponent<Player>();

        PlayerScript.BackgroundTilePrefabs = GameObject.FindGameObjectsWithTag("BackgroundTile");

    }

    // Update is called once per frame
    void Update()
    {

        if (Player.transform.position.x > RightMostBound)
        {

            //Debug.Log("Reached most right end");
            //Debug.Log(Player.transform.position);
            //Debug.Log(oldPlayermovedV3);

            //GameObject BackgroundTile2 = Instantiate(BackgroundTileDead, new Vector3(sr.bounds.size.x * rightcount + 1,1,0), this.transform.rotation);
            rightcount = rightcount + 1;
            RightMostBound = sr.bounds.size.x * rightcount - sr.bounds.size.x / 2 - sr.bounds.size.x / 4;

            //Debug.Log(BackgroundTile2.transform.position.x);
            //Debug.Log(sr.bounds.size.x +"Here");

        }
        if (Player.transform.position.y > oldPlayermovedV3.y + 20)
        {


            //GameObject BackgroundTile2 = Instantiate(BackgroundTileDead, oldPlayermovedV3 + new Vector3(0,sr.bounds.size.y,0), this.transform.rotation);
            oldPlayermovedV3 = Player.transform.position;

        }
        if (Player.transform.position.x < oldPlayermovedV3.x - 10)
        {


            //GameObject BackgroundTile2 = Instantiate(BackgroundTileDead, oldPlayermovedV3 - new Vector3(sr.bounds.size.x,0,0), this.transform.rotation);
            oldPlayermovedV3 = Player.transform.position;
        }
        if (Player.transform.position.y < oldPlayermovedV3.y - 10)
        {


            //GameObject BackgroundTile2 = Instantiate(BackgroundTileDead, oldPlayermovedV3 - new Vector3(0,sr.bounds.size.y,0), this.transform.rotation);
            oldPlayermovedV3 = Player.transform.position;
        }

        if (myb == true)
        {
            //BackgroundTile.transform.position = Player.transform.position;
            myb = false;
        }
        myb = false;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("BackgroundTile"))
        {
            //Debug.Log("found");
            //Destroy(this);
            //Destroy(col.gameObject);

        }
        else
        {

        }
        if (col.gameObject.name == "Player")
        {

            //Debug.Log("GO position" + this.transform.position);

            /**if (spawned == false) {
            BackgroundTilePrefabs = GameObject.FindGameObjectsWithTag("BackgroundTile");
                 foreach (GameObject BGObject in BackgroundTilePrefabs) {
            
                    if (BGObject.transform.position.x == this.transform.position.x + sr.bounds.size.x && BGObject.transform.position.y == this.transform.position.y && rm == false){              
                    } else {
                    if (rm == false) {
                    GameObject BackgroundTile1 = Instantiate(BackgroundTilePrefab, new Vector3(this.transform.position.x + sr.bounds.size.x,this.transform.position.y,0), this.transform.rotation);//right mid
                    }
                    rm = true;
                    }

                     if (BGObject.transform.position.x == this.transform.position.x && BGObject.transform.position.y == this.transform.position.y + sr.bounds.size.y && um == false){
                     } else {
                       if (um == false) {
                        GameObject BackgroundTile2 = Instantiate(BackgroundTilePrefab, new Vector3(this.transform.position.x,this.transform.position.y + sr.bounds.size.y,0), this.transform.rotation); //up mid 
                        }
                        um = true;              
                       }

                    if (BGObject.transform.position.x == this.transform.position.x && BGObject.transform.position.y == this.transform.position.y - sr.bounds.size.y && dm == false){
                       } else {
                       if (dm == false) {
                        //GameObject BackgroundTile3 = Instantiate(BackgroundTilePrefab, new Vector3(this.transform.position.x,this.transform.position.y - sr.bounds.size.y,0), this.transform.rotation);//down mid
                          }
                        dm = true;                      
                    }

                    if (BGObject.transform.position.x == this.transform.position.x + sr.bounds.size.x && BGObject.transform.position.y == this.transform.position.y + sr.bounds.size.y && ru == false){         
                    } else {
                       if (ru == false) {
                        //GameObject BackgroundTile4 = Instantiate(BackgroundTilePrefab, new Vector3(this.transform.position.x + sr.bounds.size.x,this.transform.position.y + sr.bounds.size.y,0), this.transform.rotation); //right top
                          }
                        ru = true;                      
                    }

                    if (BGObject.transform.position.x == this.transform.position.x + sr.bounds.size.x && BGObject.transform.position.y == this.transform.position.y - sr.bounds.size.y && rd == false){
                    } else {
                       if (rd == false) {
                       // GameObject BackgroundTile5 = Instantiate(BackgroundTilePrefab, new Vector3(this.transform.position.x + sr.bounds.size.x,this.transform.position.y - sr.bounds.size.y,0), this.transform.rotation);//right down
                          }
                        rd = true;                      
                    }

                    if (BGObject.transform.position.x == this.transform.position.x - sr.bounds.size.x && BGObject.transform.position.y == this.transform.position.y + sr.bounds.size.y && lu == false){ 
                    } else {
                       if (lu == false) {
                      // GameObject BackgroundTile6 = Instantiate(BackgroundTilePrefab, new Vector3(this.transform.position.x - sr.bounds.size.x,this.transform.position.y + sr.bounds.size.y,0), this.transform.rotation); //left top
                          }
                        lu = true;                      
                    }

                    if (BGObject.transform.position.x == this.transform.position.x - sr.bounds.size.x && BGObject.transform.position.y == this.transform.position.y && lm == false){      
                    } else {
                       if (lm == false) {
                      // GameObject BackgroundTile7 = Instantiate(BackgroundTilePrefab, new Vector3(this.transform.position.x - sr.bounds.size.x,this.transform.position.y,0), this.transform.rotation);//left mid
                       }
                        lm = true;                      
                    }

                    if (BGObject.transform.position.x == this.transform.position.x - sr.bounds.size.x && BGObject.transform.position.y == this.transform.position.y - sr.bounds.size.y && ld == false){
                    } else {
                       if (ld == false) {
                       // GameObject BackgroundTile9 = Instantiate(BackgroundTilePrefab, new Vector3(this.transform.position.x - sr.bounds.size.x,this.transform.position.y - sr.bounds.size.y,0), this.transform.rotation); //Left down
                        }
                        ld = true; 
                     }
                 }   
            }
            spawned = true;
            */
            if (spawned == false)
            {
                //PlayerScript.BackgroundTilePrefabs = GameObject.FindGameObjectsWithTag("BackgroundTile");
                foreach (GameObject BGObject in PlayerScript.BackgroundTilePrefabs)
                {

                    if (Mathf.Sqrt(BGObject.transform.position.x) == Mathf.Sqrt(this.transform.position.x + sr.bounds.size.x) && Mathf.Sqrt(BGObject.transform.position.y) == Mathf.Sqrt(this.transform.position.y))
                    {
                        rm = true;
                    }

                    if (Mathf.Sqrt(BGObject.transform.position.x) == Mathf.Sqrt(this.transform.position.x) && Mathf.Sqrt(BGObject.transform.position.y) == Mathf.Sqrt(this.transform.position.y + sr.bounds.size.y))
                    {
                        um = true;
                    }

                    if (Mathf.Sqrt(BGObject.transform.position.x) == Mathf.Sqrt(this.transform.position.x) && Mathf.Sqrt(BGObject.transform.position.y) == Mathf.Sqrt(this.transform.position.y - sr.bounds.size.y))
                    {
                        dm = true;
                    }

                    if (Mathf.Sqrt(BGObject.transform.position.x) == Mathf.Sqrt(this.transform.position.x + sr.bounds.size.x) && Mathf.Sqrt(BGObject.transform.position.y) == Mathf.Sqrt(this.transform.position.y + sr.bounds.size.y))
                    {
                        ru = true;
                    }

                    if (Mathf.Sqrt(BGObject.transform.position.x) == Mathf.Sqrt(this.transform.position.x + sr.bounds.size.x) && Mathf.Sqrt(BGObject.transform.position.y) == Mathf.Sqrt(this.transform.position.y - sr.bounds.size.y))
                    {
                        rd = true;
                    }

                    if (Mathf.Sqrt(BGObject.transform.position.x) == Mathf.Sqrt(this.transform.position.x - sr.bounds.size.x) && Mathf.Sqrt(BGObject.transform.position.y) == Mathf.Sqrt(this.transform.position.y + sr.bounds.size.y))
                    {
                        lu = true;
                    }

                    if (Mathf.Sqrt(BGObject.transform.position.x) == Mathf.Sqrt(this.transform.position.x - sr.bounds.size.x )&& Mathf.Sqrt(BGObject.transform.position.y) == Mathf.Sqrt(this.transform.position.y))
                    {
                        lm = true;
                    }

                    if (Mathf.Sqrt(BGObject.transform.position.x) == Mathf.Sqrt(this.transform.position.x - sr.bounds.size.x) && Mathf.Sqrt(BGObject.transform.position.y) == Mathf.Sqrt(this.transform.position.y - sr.bounds.size.y))
                    {
                        ld = true;
                    }
                }
            }
            spawned = true;
            if (ld == false)
            {
                GameObject BackgroundTile9 = Instantiate(BackgroundTilePrefab, new Vector3(this.transform.position.x - sr.bounds.size.x, this.transform.position.y - sr.bounds.size.y, 0), this.transform.rotation); //Left down
                ld = true;
                BackgroundTile9.name = "ld";
                BackgroundTile9.GetComponent<CreateBackground>().ru = true;
            }
            /**
             * xxx
             * 0xx
             * xxx
             */
            if (lm == false)
            {
                GameObject BackgroundTile7 = Instantiate(BackgroundTilePrefab, new Vector3(this.transform.position.x - sr.bounds.size.x, this.transform.position.y, 0), this.transform.rotation);//left mid
                lm = true;
                BackgroundTile7.name = "lm";
                BackgroundTile7.GetComponent<CreateBackground>().rm = true;

            }
            if (lu == false)
            {
                GameObject BackgroundTile6 = Instantiate(BackgroundTilePrefab, new Vector3(this.transform.position.x - sr.bounds.size.x, this.transform.position.y + sr.bounds.size.y, 0), this.transform.rotation); //left top
                lu = true;
                BackgroundTile6.name = "lu";
                BackgroundTile6.GetComponent<CreateBackground>().rd = true;
            }
            if (rm == false) //right mid 
            {
                GameObject BackgroundTile1 = Instantiate(BackgroundTilePrefab, new Vector3(this.transform.position.x + sr.bounds.size.x, this.transform.position.y, 0), this.transform.rotation);//right mid
                rm = true;
                BackgroundTile1.name = "rm";
                BackgroundTile1.GetComponent<CreateBackground>().lm = true;
            }
            if (um == false)
            {
                GameObject BackgroundTile2 = Instantiate(BackgroundTilePrefab, new Vector3(this.transform.position.x, this.transform.position.y + sr.bounds.size.y, 0), this.transform.rotation); //up mid 
                um = true;
                BackgroundTile2.name = "um";
                BackgroundTile2.GetComponent<CreateBackground>().dm = true;

            }
            if (dm == false)
            {
                GameObject BackgroundTile3 = Instantiate(BackgroundTilePrefab, new Vector3(this.transform.position.x, this.transform.position.y - sr.bounds.size.y, 0), this.transform.rotation);//down mid
                dm = true;
                BackgroundTile3.name = "dm";
                BackgroundTile3.GetComponent<CreateBackground>().um = true;
            }
            if (ru == false)
            {
                GameObject BackgroundTile4 = Instantiate(BackgroundTilePrefab, new Vector3(this.transform.position.x + sr.bounds.size.x, this.transform.position.y + sr.bounds.size.y, 0), this.transform.rotation); //right top
                ru = true;
                BackgroundTile4.name = "ru";
                BackgroundTile4.GetComponent<CreateBackground>().ld = true;
            }
            if (rd == false)
            {
                GameObject BackgroundTile5 = Instantiate(BackgroundTilePrefab, new Vector3(this.transform.position.x + sr.bounds.size.x, this.transform.position.y - sr.bounds.size.y, 0), this.transform.rotation);//right down
                rd = true;
                BackgroundTile5.name = "rd";
                BackgroundTile5.GetComponent<CreateBackground>().lu = true;
            }



        }

    }


    private void OnTriggerEnter2D(Collider2D col2)
    {
        if (col2.gameObject.CompareTag("BackgroundTile"))
        {
            //Destroy(this);

        }
    }


}
