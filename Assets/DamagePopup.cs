using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DamagePopup : MonoBehaviour
{
    private TextMeshPro tmp;
    //public float disappearSpeed;
    public float moveYSpeed = 20f;
    public float disappearTimer = 1f;
    public float disappearSpeed = 3.0f;
    public Color textColor;
    // Start is called before the first frame update
    void Awake()
    {
        tmp = this.GetComponent<TextMeshPro>();
    }

    public void Setup(float damageAmount)
    {
        tmp.SetText(damageAmount.ToString());
        textColor = tmp.color;
        //tmp.SetText(damageAmount.ToString());
        //this.GetComponent<TextMeshProUGUI>().sortingOrder = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(0.0f, moveYSpeed, this.transform.position.z) * Time.deltaTime;
        disappearTimer -= Time.deltaTime;

        if (disappearTimer < 0) {
            textColor.a -= disappearSpeed * Time.deltaTime;
            tmp.color = textColor;
            if (textColor.a < 0)
            {
                //Debug.Log("Destroy");
                Destroy(gameObject);
                
               
            }
        }
    }
}
