using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI question;
    GameObject myCharacter;
    GameObject roadTwo;
    GameObject roadOne;
    public GameObject arithmathicPanel;
    public GameObject comparisonPanel;
    public GameObject timerPanel;
    bool calculateQuestion;
    int gameDifficulty = 1; // 0 = Normal, 1 = Hard 
    public int gameMode = 0; // 0 = Mathematical Operations, Choosing Operator
    //int gameDifficulty;
    //int gamemode;
    public TextMeshProUGUI afirstButton;
    public TextMeshProUGUI asecondButton;
    public TextMeshProUGUI athirdButton;
    public TextMeshProUGUI afourthButton;
    public TextMeshProUGUI cfirstButton;
    public TextMeshProUGUI csecondButton;
    public TextMeshProUGUI cthirdButton;
    public Slider timeSlider;
    public GameObject heartOne;
    public GameObject heartTwo;
    public GameObject heartThree;
    public Vector3 touchPosition;
    int randomNumberOne;
    int randomNumberTwo;
    int randomOperator;
    int trueAnswer;
    int playerLife;
    bool detectAnswer;

    public float defaultWaitTime = 10f;
    public float remainingTime;

    void Start(){
        playerLife = 3;
        myCharacter = GameObject.Find("Character");
        roadTwo = GameObject.Find("Road 2");
        roadOne = GameObject.Find("Road 1");
        calculateQuestion = true;
        heartOne = GameObject.Find("heart1");
        heartTwo = GameObject.Find("heart2");
        heartThree = GameObject.Find("heart3");
    }

    void Update(){
        scoreText.text = ((int)GameManager.I.score).ToString();
        if(myCharacter.transform.position.z - roadOne.transform.position.z >= 25 && calculateQuestion == false){
            calculateQuestion = true;
        }
        if(myCharacter.transform.position.z - roadTwo.transform.position.z >= 25 && calculateQuestion){
            AskQuestion();
        }
    }

    #region Question
    private void AskQuestion()
    {
        if (detectAnswer) return;

        GameManager.I.StopGame();
        CreateQuestion();
        if(gameMode == 0)
            arithmathicPanel.SetActive(true);
        else if(gameMode == 1)
            comparisonPanel.SetActive(true);

        question.gameObject.SetActive(true);
        timerPanel.SetActive(true);
        calculateQuestion = false;
        detectAnswer = true;
    }

    void CreateQuestion(){
        int answer;
        question.text = "";
        randomOperator = Random.Range(1,5);
        trueAnswer = Random.Range(1,5);
        string[] operatorAnswer = new string[]{">","<","="};
        if (gameMode == 0){
            if(gameDifficulty == 0){
                if(randomOperator == 1){
                    randomNumberOne = Random.Range(10,50);
                    randomNumberTwo = Random.Range(10,50);
                    question.text = randomNumberOne + " + " + randomNumberTwo + " = " + " ?";
                    answer = randomNumberOne + randomNumberTwo;

                    if(trueAnswer == 1){
                        afirstButton.text = (answer).ToString();
                        asecondButton.text = (answer + Random.Range(1,6)).ToString();
                        athirdButton.text = (answer + Random.Range(-1,-6)).ToString();
                        afourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 2){
                        asecondButton.text = (answer).ToString();
                        afirstButton.text = (answer + Random.Range(1,6)).ToString();
                        athirdButton.text = (answer + Random.Range(-1,-6)).ToString();
                    afourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 3){
                        athirdButton.text = (answer).ToString();
                        asecondButton.text = (answer + Random.Range(-1,-6)).ToString();
                        afirstButton.text = (answer + Random.Range(1,6)).ToString();
                        afourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 4){
                    afourthButton.text = (answer).ToString();
                    athirdButton.text = (answer + Random.Range(6,13)).ToString();
                    asecondButton.text = (answer + Random.Range(-1,-6)).ToString();
                    afirstButton.text = (answer + Random.Range(1,6)).ToString();
                    }
                }
                else if(randomOperator == 2){
                    randomNumberOne = Random.Range(10,50);
                    randomNumberTwo = Random.Range(10,50);
                    if (randomNumberOne >= randomNumberTwo){
                        question.text = randomNumberOne + " - " + randomNumberTwo + " = " + " ?";
                        answer = randomNumberOne - randomNumberTwo;
                    }
                    else{
                        question.text = randomNumberTwo + " - " + randomNumberOne + " = " + " ?";
                        answer = randomNumberTwo - randomNumberOne;
                    }
                    if(trueAnswer == 1){
                        afirstButton.text = (answer).ToString();
                        asecondButton.text = (answer + Random.Range(1,6)).ToString();
                        athirdButton.text = (answer + Random.Range(-1,-6)).ToString();
                        afourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 2){
                        asecondButton.text = (answer).ToString();
                        afirstButton.text = (answer + Random.Range(1,6)).ToString();
                        athirdButton.text = (answer + Random.Range(-1,-6)).ToString();
                        afourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 3){
                        athirdButton.text = (answer).ToString();
                        asecondButton.text = (answer + Random.Range(-1,-6)).ToString();
                        afirstButton.text = (answer + Random.Range(1,6)).ToString();
                        afourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 4){
                        afourthButton.text = (answer).ToString();
                        athirdButton.text = (answer + Random.Range(6,13)).ToString();
                        asecondButton.text = (answer + Random.Range(-1,-6)).ToString();
                        afirstButton.text = (answer + Random.Range(1,6)).ToString();
                    }
                }
                else if(randomOperator == 3){
                    randomNumberOne = Random.Range(2,10);
                    randomNumberTwo = Random.Range(10,15);
                    question.text = randomNumberOne + " x " + randomNumberTwo + " = " + " ?";
                    answer = randomNumberOne * randomNumberTwo;
                    if(trueAnswer == 1){
                        afirstButton.text = (answer).ToString();
                        asecondButton.text = (answer + Random.Range(1,6)).ToString();
                        athirdButton.text = (answer + Random.Range(-1,-6)).ToString();
                        afourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 2){
                        asecondButton.text = (answer).ToString();
                        afirstButton.text = (answer + Random.Range(1,6)).ToString();
                        athirdButton.text = (answer + Random.Range(-1,-6)).ToString();
                        afourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 3){
                        athirdButton.text = (answer).ToString();
                        asecondButton.text = (answer + Random.Range(-1,-6)).ToString();
                        afirstButton.text = (answer + Random.Range(1,6)).ToString();
                        afourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 4){
                        afourthButton.text = (answer).ToString();
                        athirdButton.text = (answer + Random.Range(6,13)).ToString();
                        asecondButton.text = (answer + Random.Range(-1,-6)).ToString();
                        afirstButton.text = (answer + Random.Range(1,6)).ToString();
                    }
                }
                else if(randomOperator == 4){
                    randomNumberTwo = Random.Range(1,7);
                    randomNumberOne = Random.Range(1,7)*randomNumberTwo;
                    question.text = randomNumberOne + " / " + randomNumberTwo + " = " + " ?";
                    answer = randomNumberOne / randomNumberTwo;
                    if(trueAnswer == 1){
                        afirstButton.text = (answer).ToString();
                        asecondButton.text = (answer + Random.Range(1,6)).ToString();
                        athirdButton.text = (answer + Random.Range(-1,-6)).ToString();
                        afourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 2){
                        asecondButton.text = (answer).ToString();
                        afirstButton.text = (answer + Random.Range(1,6)).ToString();
                        athirdButton.text = (answer + Random.Range(-1,-6)).ToString();
                        afourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 3){
                        athirdButton.text = (answer).ToString();
                        asecondButton.text = (answer + Random.Range(-1,-6)).ToString();
                        afirstButton.text = (answer + Random.Range(1,6)).ToString();
                        afourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 4){
                        afourthButton.text = (answer).ToString();
                        athirdButton.text = (answer + Random.Range(6,13)).ToString();
                        asecondButton.text = (answer + Random.Range(-1,-6)).ToString();
                        afirstButton.text = (answer + Random.Range(1,6)).ToString();
                    }
                }
            }
            else if(gameDifficulty ==1){
                if(randomOperator == 1){
                    randomNumberOne = Random.Range(30,200);
                    randomNumberTwo = Random.Range(30,99);
                    question.text = randomNumberOne + " + " + randomNumberTwo + " = " + " ?";
                    answer = randomNumberOne + randomNumberTwo;
                    if(trueAnswer == 1){
                        afirstButton.text = (answer).ToString();
                        asecondButton.text = (answer + Random.Range(1,6)).ToString();
                        athirdButton.text = (answer + Random.Range(-1,-6)).ToString();
                        afourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 2){
                        asecondButton.text = (answer).ToString();
                        afirstButton.text = (answer + Random.Range(1,6)).ToString();
                        athirdButton.text = (answer + Random.Range(-1,-6)).ToString();
                        afourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 3){
                        athirdButton.text = (answer).ToString();
                        asecondButton.text = (answer + Random.Range(-1,-6)).ToString();
                        afirstButton.text = (answer + Random.Range(1,6)).ToString();
                        afourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 4){
                        afourthButton.text = (answer).ToString();
                        athirdButton.text = (answer + Random.Range(6,13)).ToString();
                        asecondButton.text = (answer + Random.Range(-1,-6)).ToString();
                        afirstButton.text = (answer + Random.Range(1,6)).ToString();
                    }
                }
                else if(randomOperator == 2){
                    randomNumberOne = Random.Range(30,200);
                    randomNumberTwo = Random.Range(30,99);
                    if (randomNumberOne >= randomNumberTwo){
                        question.text = randomNumberOne + " - " + randomNumberTwo + " = " + " ?";
                        answer = randomNumberOne - randomNumberTwo;
                    }
                    else{
                        question.text = randomNumberTwo + " - " + randomNumberOne + " = " + " ?";
                        answer = randomNumberTwo - randomNumberOne;
                    }
                    if(trueAnswer == 1){
                        afirstButton.text = (answer).ToString();
                        asecondButton.text = (answer + Random.Range(1,6)).ToString();
                        athirdButton.text = (answer + Random.Range(-1,-6)).ToString();
                        afourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 2){
                        asecondButton.text = (answer).ToString();
                        afirstButton.text = (answer + Random.Range(1,6)).ToString();
                        athirdButton.text = (answer + Random.Range(-1,-6)).ToString();
                        afourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 3){
                        athirdButton.text = (answer).ToString();
                        asecondButton.text = (answer + Random.Range(-1,-6)).ToString();
                        afirstButton.text = (answer + Random.Range(1,6)).ToString();
                        afourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 4){
                        afourthButton.text = (answer).ToString();
                        athirdButton.text = (answer + Random.Range(6,13)).ToString();
                        asecondButton.text = (answer + Random.Range(-1,-6)).ToString();
                        afirstButton.text = (answer + Random.Range(1,6)).ToString();
                    }
                }
                else if(randomOperator == 3){
                    randomNumberOne = Random.Range(1,10);
                    randomNumberTwo = Random.Range(1,20);
                    question.text = randomNumberOne + " x " + randomNumberTwo + " = " + " ?";
                    answer = randomNumberOne * randomNumberTwo;
                    if(trueAnswer == 1){
                        afirstButton.text = (answer).ToString();
                        asecondButton.text = (answer + Random.Range(1,6)).ToString();
                        athirdButton.text = (answer + Random.Range(-1,-6)).ToString();
                        afourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 2){
                        asecondButton.text = (answer).ToString();
                        afirstButton.text = (answer + Random.Range(1,6)).ToString();
                        athirdButton.text = (answer + Random.Range(-1,-6)).ToString();
                        afourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 3){
                        athirdButton.text = (answer).ToString();
                        asecondButton.text = (answer + Random.Range(-1,-6)).ToString();
                        afirstButton.text = (answer + Random.Range(1,6)).ToString();
                        afourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 4){
                        afourthButton.text = (answer).ToString();
                        athirdButton.text = (answer + Random.Range(6,13)).ToString();
                        asecondButton.text = (answer + Random.Range(-1,-6)).ToString();
                        afirstButton.text = (answer + Random.Range(1,6)).ToString();
                    }
                }
                else if(randomOperator == 4){
                    randomNumberTwo = Random.Range(1,10);
                    randomNumberOne = Random.Range(1,10)*randomNumberTwo;
                    question.text = randomNumberOne + " / " + randomNumberTwo + " = " + " ?";
                    answer = randomNumberOne / randomNumberTwo;
                    if(trueAnswer == 1){
                        afirstButton.text = (answer).ToString();
                        asecondButton.text = (answer + Random.Range(1,6)).ToString();
                        athirdButton.text = (answer + Random.Range(-1,-6)).ToString();
                        afourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 2){
                        asecondButton.text = (answer).ToString();
                        afirstButton.text = (answer + Random.Range(1,6)).ToString();
                        athirdButton.text = (answer + Random.Range(-1,-6)).ToString();
                        afourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 3){
                        athirdButton.text = (answer).ToString();
                        asecondButton.text = (answer + Random.Range(-1,-6)).ToString();
                        afirstButton.text = (answer + Random.Range(1,6)).ToString();
                        afourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 4){
                        afourthButton.text = (answer).ToString();
                        athirdButton.text = (answer + Random.Range(6,13)).ToString();
                        asecondButton.text = (answer + Random.Range(-1,-6)).ToString();
                        afirstButton.text = (answer + Random.Range(1,6)).ToString();
                    }
                }
            }   
        }
        else if (gameMode == 1){
            trueAnswer = Random.Range(1,4);
            if(gameDifficulty == 0){
                randomNumberOne = Random.Range(10,200);
                randomNumberTwo = Random.Range(10,200);
            }
            else if(gameDifficulty == 1){
                randomNumberOne = Random.Range(-100,100);
                randomNumberTwo = Random.Range(-100,100);
            }
                question.text = randomNumberOne + "  ?  " + randomNumberTwo;
                if(randomNumberOne > randomNumberTwo){
                    if(trueAnswer == 1){
                        cfirstButton.text = operatorAnswer[0].ToString();
                        csecondButton.text = operatorAnswer[1].ToString();
                        cthirdButton.text = operatorAnswer[2].ToString();
                    }
                    else if(trueAnswer == 2){
                        cfirstButton.text = operatorAnswer[1].ToString();
                        csecondButton.text = operatorAnswer[0].ToString();
                        cthirdButton.text = operatorAnswer[2].ToString();
                    }
                    else if(trueAnswer == 3){
                        cfirstButton.text = operatorAnswer[2].ToString();
                        csecondButton.text = operatorAnswer[1].ToString();
                        cthirdButton.text = operatorAnswer[0].ToString();
                    }
                }
                else if(randomNumberOne < randomNumberTwo){
                     if(trueAnswer == 1){
                        cfirstButton.text = operatorAnswer[1].ToString();
                        csecondButton.text = operatorAnswer[0].ToString();
                        cthirdButton.text = operatorAnswer[2].ToString();
                    }
                    else if(trueAnswer == 2){
                        cfirstButton.text = operatorAnswer[2].ToString();
                        csecondButton.text = operatorAnswer[1].ToString();
                        cthirdButton.text = operatorAnswer[0].ToString();
                    }
                    else if(trueAnswer == 3){
                        cfirstButton.text = operatorAnswer[0].ToString();
                        csecondButton.text = operatorAnswer[1].ToString();
                        cthirdButton.text = operatorAnswer[2].ToString();
                    }
                }
                else if(randomNumberOne == randomNumberTwo){
                    if(trueAnswer == 1){
                        cfirstButton.text = operatorAnswer[2].ToString();
                        csecondButton.text = operatorAnswer[0].ToString();
                        cthirdButton.text = operatorAnswer[1].ToString();
                    }
                    else if(trueAnswer == 2){
                        cfirstButton.text = operatorAnswer[1].ToString();
                        csecondButton.text = operatorAnswer[2].ToString();
                        cthirdButton.text = operatorAnswer[0].ToString();
                    }
                    else if(trueAnswer == 3){
                        cfirstButton.text = operatorAnswer[0].ToString();
                        csecondButton.text = operatorAnswer[1].ToString();
                        cthirdButton.text = operatorAnswer[2].ToString();
                    }
                }
        }
        if (gameMode == 0){
            switch (trueAnswer){
            case 1:
                print ("True Answer is first option.");
                break;
            case 2:
                print ("True Answer is second option.");
                break;
            case 3:
                print ("True Answer is third option.");
                break;
            case 4:
                print ("True Answer is fourth option.");
                break;
            default:
                print ("An error has occured.");
                break;
            }      
        }
        if (gameMode == 1){
            switch (trueAnswer){
            case 1:
                print ("True Answer is first option.");
                break;
            case 2:
                print ("True Answer is second option.");
                break;
            case 3:
                print ("True Answer is third option.");
                break;
            default:
                print ("An error has occured.");
                break;
            }      
        }
        StartCoroutine(Timer(defaultWaitTime));
    }

    void CloseQuestion()
    {
        detectAnswer = false;
        arithmathicPanel.SetActive(false);
        comparisonPanel.SetActive(false);
        question.gameObject.SetActive(false);
        timerPanel.SetActive(false);
        GameManager.I.StartGame();
    }

    public void Answer(int answer)
    {
        if (trueAnswer != answer)
        {
            playerLife -= 1;

            switch (playerLife)
            {
                case 0:
                    print("Canınız kalmamıştır, oyun sonlandı.");
                    heartOne.SetActive(false);
                    GameManager.I.Fail();
                    break;
                case 1:
                    heartTwo.SetActive(false);
                    break;
                case 2:
                    heartThree.SetActive(false);
                    break;
                default:
                    break;
            }
        }
        CloseQuestion();
    }

    private IEnumerator Timer(float waitTime){
        Debug.Log(Time.timeScale);
        remainingTime = waitTime;
        while(remainingTime > 0){
            remainingTime -= Time.deltaTime;
            timeSlider.normalizedValue = Mathf.Clamp01(remainingTime / waitTime);
            //Debug.Log(remainingTime);
            yield return new WaitForEndOfFrame();
        }
        if(detectAnswer)
            Answer(-1);
        yield return null;
    }
    #endregion

    #region Menu
    public GameObject mainMenu;
    public GameObject retryMenu;

    public TextMeshProUGUI gameModeText;
    public void EnableMainMenu(bool isEnable)
    {
        mainMenu.SetActive(isEnable);
    }

    public void EnableRetryMenu(bool isEnable)
    {
        retryMenu.SetActive(isEnable);
    }

    public void ToggleGameMode()
    {
        gameMode = (gameMode + 1) % 2;
        if(gameMode == 0)
        {
            gameModeText.text = "Arithmetic Mode";
        }
        if (gameMode == 1)
        {
            gameModeText.text = "Comparison Mode";
        }
    }

    #endregion
}
// Soruyu yanlış bildiğinde counterı bir eksilt ve kalplerden birini sil.


