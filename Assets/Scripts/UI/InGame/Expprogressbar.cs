using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Expprogressbar : MonoBehaviour
{ 

    [SerializeField]
    private TMP_Text text_1;
    
    [SerializeField]
    private TMP_Text text_2;

    [SerializeField]
    private Image bar_fill;

    [SerializeField]
    private Image bar_outline;

    [SerializeField]
    private Image circle_1;

    [SerializeField]
    private Image circle_2;

    [SerializeField]
    private Color color;

    [SerializeField]
    private Color background_color;

    private int level = 0;
    private float currentAmount = 0; //expfornextlvl
    private float targetAmount = 50.0f;
    private float targetProgress;
    private float globalAmount;
    private Coroutine routine;
    private Coroutine routine_2;

    public GameObject Background_Powerup;

    //###
    public delegate void Event_Expprogressbar();
    public static event Event_Expprogressbar OnTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
        InitColor();
        level = 0;
        currentAmount = 0;
        bar_fill.fillAmount = currentAmount;
        //UpdateLevel(level);
        UpdateLevel_new(level);
    }


    void InitColor() {
        circle_1.color = color;
        circle_2.color = color;

        bar_fill.color = color;
        bar_outline.color = color;

        text_1.color = background_color;
        circle_2.color = color; //here we use a default color
    }

    /**
     * This updates the current progess 
     * The higher the duration the longer it takes to update the progress
     */
    public void UpdateProgress(float amount, float duration = 0.1f)
    {
        if (routine != null)
        {
            StopCoroutine(routine);
        }

        float target = currentAmount + amount;
        //Debug.Log("currentAmount " + currentAmount);
        //Debug.Log("amount " + amount);
        //Debug.Log("target " + target);
        routine = StartCoroutine(FillRoutine(target, duration));

    }

    private IEnumerator FillRoutine(float target, float duration)
    {
        float time = 0;
        float tempAmount = currentAmount; //current Amount of EXP
        float diff = target - tempAmount; //difference between target (not next level) and currentAmount
        currentAmount = target;

        while (time < duration)
        { //this is for fading
            time += Time.deltaTime;
            float percent = time / duration;
            bar_fill.fillAmount = tempAmount + diff * percent;
            yield return null; //progress was updated and IEnumerator ends
        }

        if (currentAmount >= 1)
        {
            LevelUp();
        }
    }


    private void UpdateLevel(int level)
    {
        this.level = level;
        //this.currentAmount = currentAmount + 0.5f; //Edited
        text_1.text = this.level.ToString();
        text_2.text = (this.level + 1).ToString();
    }



    private void LevelUp()
    {

        UpdateLevel(level + 1);
        UpdateProgress(-1f, 0.2f); //not sure why 0.2f, -1 doesnt change anything

    }

    private void LevelUp_new()
    {

        UpdateLevel_new(level + 1);//only for text

        UpdateProgress_new(-1f, 0.2f); //not sure why 0.2f, -1 doesnt change anything

    }

    public void UpdateProgress_new(float amount, float duration = 0.1f)
    {
        if (routine != null)
        {
            //StopCoroutine(routine);
        }
        if (routine_2 != null)
        {
            StopCoroutine(routine_2);
        }
        targetProgress = GetRatio(currentAmount) + GetRatio(amount); //next progress, e.g. if cA is 10, amount is 5, targetprogress is 15
        //Debug.Log("currentAmount " + GetRatio(currentAmount) + currentAmount);
        //Debug.Log("amount " + GetRatio(amount) + " " + amount);
        //Debug.Log("targetProgress " + targetProgress + " " + targetProgress);

        globalAmount = amount;

        if (targetProgress >= 1.0f)
        {
            //Debug.Log("Next level");

            //routine_2 = StartCoroutine(FillRoutine_new(targetProgress, duration));

            //routine = StartCoroutine(FillRoutine_new(targetProgress, duration));
            routine = StartCoroutine(FillRoutine_new(targetProgress, duration));

        } else
        {
            routine = StartCoroutine(FillRoutine_new(targetProgress, duration));
        }
        
        //Debug.Log("bar_fill.fillAmount " + bar_fill.fillAmount);
        //currentAmount = GetRatio(bar_fill.fillAmount);
    }

    private IEnumerator FillRoutine_new(float targetProgress, float duration)
    {
        float time = 0;
        float diff = targetProgress - GetRatio(currentAmount); //difference between targetProgress (not next level) and currentAmount
        //Debug.Log("bar_fill.diff " + diff);

        while (time < duration)
        { //this is for fading
            time += Time.deltaTime;
            float percent = time / duration;

            bar_fill.fillAmount = GetRatio(currentAmount) + diff * percent;
            yield return null; //progress was updated and IEnumerator ends
        }
        //Debug.Log("here bar_fill.fillAmount " + bar_fill.fillAmount);
        currentAmount = bar_fill.fillAmount * targetAmount; //assigns the currentAmount + the new added value

        if (bar_fill.fillAmount >= 1)
        {
            UpdateLevel_new(level + 1);
            currentAmount = 0.0f;
            bar_fill.fillAmount = 0.0f;
            //CALL MENU
            //Background_Powerup.SetActive(true);
           // Background_Powerup.GetComponent<PowerupUIController>().changePUUI();
            
            if (OnTarget != null)
            {
                Debug.Log("OnTarget");
                OnTarget();
            }
            StopCoroutine(routine);
            UpdateProgress_new(globalAmount, 0.3f);
        }

    }

    public float GetRatio(float input)
    {
        float currentFillAmountInRatio = input / targetAmount;
        return currentFillAmountInRatio;
    }

    //changes only the text
    private void UpdateLevel_new(int level)
    {
        this.level = level;
        //this.currentAmount = currentAmount + 0.5f; //Edited
        targetAmount = targetAmount + 10.0f;
        text_1.text = this.level.ToString();
        text_2.text = (this.level + 1).ToString();
    }
    //void GetCurrentFill()
    //{
    //    float fillAmount = (float)current / (float)targetAmount;
    //    return fillAmount;
    //}

}
