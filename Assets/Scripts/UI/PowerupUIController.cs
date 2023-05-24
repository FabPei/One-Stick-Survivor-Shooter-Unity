using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class PowerupUIController : MonoBehaviour
{


    public GameObject First_Powerup;
    public GameObject Second_Powerup;
    public GameObject Third_Powerup;

    public GameObject Powerups;


    GameObject OnePText;
    GameObject OnePImage;
    GameObject TwoPText;
    GameObject TwoPImage;
    GameObject ThirdPText;
    GameObject ThirdImage;
    // Start is called before the first frame update
    void OnEnable()
    {

    Transform TOnePText = First_Powerup.transform.Find("First_Powerup_Text");
    Transform TOnePImage = First_Powerup.transform.Find("First_Powerup_Image");
    Transform TTwoPText = Second_Powerup.transform.Find("Second_Powerup_Text");
    Transform TTwoPImage = Second_Powerup.transform.Find("Second_Powerup_Image");
    Transform TThirdPText = Third_Powerup.transform.Find("Third_Powerup_Text");
    Transform TThirdImage = Third_Powerup.transform.Find("Third_Powerup_Image");

    OnePText = TOnePText.gameObject;
    //Debug.Log(TOnePText.gameObject);

    OnePImage = TOnePImage.gameObject;
    TwoPText = TTwoPText.gameObject;
    TwoPImage = TTwoPImage.gameObject;
    ThirdPText = TThirdPText.gameObject;
    ThirdImage = TThirdImage.gameObject;
    Time.timeScale = 0;

    }
    void OnDisable()
    {
        Time.timeScale = 1;
    }

        public void changePUUI()
    {
        List<Powerup> powerupList = Powerups.GetComponent<Powerups>().GetThreeRandom(new List<Powerup>());

        changePUDesc(OnePText, powerupList[0]);
        changePUImage(OnePImage, powerupList[0]);

        changePUDesc(TwoPText, powerupList[1]);
        changePUImage(TwoPImage, powerupList[1]);

        changePUDesc(ThirdPText, powerupList[2]);
        changePUImage(ThirdImage, powerupList[2]);
        //Debug.Log(Powerups.GetComponent<Powerups>().GetThreeRandom()[0]);


    }
    public void changePUImage (GameObject obj, Powerup objPU)
    {
        
        obj.GetComponent<Image>().sprite = objPU.GetDisplaySprite();
    }
    public void changePUDesc(GameObject obj, Powerup objPU)
    {

        obj.GetComponent<TextMeshProUGUI>().text = objPU.GetDisplayDescription();
    }

}
