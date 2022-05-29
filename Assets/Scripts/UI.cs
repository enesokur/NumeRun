using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI question;
    float temp = 0f;
    public GameObject[] hearts;
    int counter = 2;
    GameObject myCharacter;
    GameObject roadTwo;
    GameObject roadOne;
    public GameObject panel;
    bool calculateQuestion;
    int gameDifficulty = 1; // 0 = Normal, 1 = Hard 
    int gameMode = 0; // 0 = Mathematical Operations, Choosing Operator
    //int gameDifficulty;
    //int gamemode;
    public TextMeshProUGUI firstButton;
    public TextMeshProUGUI secondButton;
    public TextMeshProUGUI thirdButton;
    public TextMeshProUGUI fourthButton;
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
    bool clicked;
    void Start(){
        hearts = new GameObject[3];
        playerLife = 3;
        myCharacter = GameObject.Find("Character");
        roadTwo = GameObject.Find("Road 2");
        roadOne = GameObject.Find("Road 1");
        calculateQuestion = true;
        heartOne = GameObject.Find("heart1");
        heartTwo = GameObject.Find("heart2");
        heartThree = GameObject.Find("heart3");
        clicked = false;
    }

    void Update(){
        temp += 2 * Time.deltaTime;
        score.text = ((int)temp).ToString();
        if(myCharacter.transform.position.z - roadOne.transform.position.z >= 25 && calculateQuestion == false){
            calculateQuestion = true;
        }
        if(myCharacter.transform.position.z - roadTwo.transform.position.z >= 25 && calculateQuestion){
            Time.timeScale = 0f;
            CreateQuestion();
            panel.SetActive(true);
            calculateQuestion = false;
            detectAnswer = true;
            clicked = false;
        }
        if(detectAnswer && clicked == false){
            DetectTouch();
        }
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
                        firstButton.text = (answer).ToString();
                        secondButton.text = (answer + Random.Range(1,6)).ToString();
                        thirdButton.text = (answer + Random.Range(-1,-6)).ToString();
                        fourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 2){
                        secondButton.text = (answer).ToString();
                        firstButton.text = (answer + Random.Range(1,6)).ToString();
                        thirdButton.text = (answer + Random.Range(-1,-6)).ToString();
                    fourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 3){
                        thirdButton.text = (answer).ToString();
                        secondButton.text = (answer + Random.Range(-1,-6)).ToString();
                        firstButton.text = (answer + Random.Range(1,6)).ToString();
                        fourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 4){
                    fourthButton.text = (answer).ToString();
                    thirdButton.text = (answer + Random.Range(6,13)).ToString();
                    secondButton.text = (answer + Random.Range(-1,-6)).ToString();
                    firstButton.text = (answer + Random.Range(1,6)).ToString();
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
                        firstButton.text = (answer).ToString();
                        secondButton.text = (answer + Random.Range(1,6)).ToString();
                        thirdButton.text = (answer + Random.Range(-1,-6)).ToString();
                        fourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 2){
                        secondButton.text = (answer).ToString();
                        firstButton.text = (answer + Random.Range(1,6)).ToString();
                        thirdButton.text = (answer + Random.Range(-1,-6)).ToString();
                        fourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 3){
                        thirdButton.text = (answer).ToString();
                        secondButton.text = (answer + Random.Range(-1,-6)).ToString();
                        firstButton.text = (answer + Random.Range(1,6)).ToString();
                        fourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 4){
                        fourthButton.text = (answer).ToString();
                        thirdButton.text = (answer + Random.Range(6,13)).ToString();
                        secondButton.text = (answer + Random.Range(-1,-6)).ToString();
                        firstButton.text = (answer + Random.Range(1,6)).ToString();
                    }
                }
                else if(randomOperator == 3){
                    randomNumberOne = Random.Range(2,10);
                    randomNumberTwo = Random.Range(10,15);
                    question.text = randomNumberOne + " x " + randomNumberTwo + " = " + " ?";
                    answer = randomNumberOne * randomNumberTwo;
                    if(trueAnswer == 1){
                        firstButton.text = (answer).ToString();
                        secondButton.text = (answer + Random.Range(1,6)).ToString();
                        thirdButton.text = (answer + Random.Range(-1,-6)).ToString();
                        fourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 2){
                        secondButton.text = (answer).ToString();
                        firstButton.text = (answer + Random.Range(1,6)).ToString();
                        thirdButton.text = (answer + Random.Range(-1,-6)).ToString();
                        fourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 3){
                        thirdButton.text = (answer).ToString();
                        secondButton.text = (answer + Random.Range(-1,-6)).ToString();
                        firstButton.text = (answer + Random.Range(1,6)).ToString();
                        fourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 4){
                        fourthButton.text = (answer).ToString();
                        thirdButton.text = (answer + Random.Range(6,13)).ToString();
                        secondButton.text = (answer + Random.Range(-1,-6)).ToString();
                        firstButton.text = (answer + Random.Range(1,6)).ToString();
                    }
                }
                else if(randomOperator == 4){
                    randomNumberTwo = Random.Range(1,7);
                    randomNumberOne = Random.Range(1,7)*randomNumberTwo;
                    question.text = randomNumberOne + " / " + randomNumberTwo + " = " + " ?";
                    answer = randomNumberOne / randomNumberTwo;
                    if(trueAnswer == 1){
                        firstButton.text = (answer).ToString();
                        secondButton.text = (answer + Random.Range(1,6)).ToString();
                        thirdButton.text = (answer + Random.Range(-1,-6)).ToString();
                        fourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 2){
                        secondButton.text = (answer).ToString();
                        firstButton.text = (answer + Random.Range(1,6)).ToString();
                        thirdButton.text = (answer + Random.Range(-1,-6)).ToString();
                        fourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 3){
                        thirdButton.text = (answer).ToString();
                        secondButton.text = (answer + Random.Range(-1,-6)).ToString();
                        firstButton.text = (answer + Random.Range(1,6)).ToString();
                        fourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 4){
                        fourthButton.text = (answer).ToString();
                        thirdButton.text = (answer + Random.Range(6,13)).ToString();
                        secondButton.text = (answer + Random.Range(-1,-6)).ToString();
                        firstButton.text = (answer + Random.Range(1,6)).ToString();
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
                        firstButton.text = (answer).ToString();
                        secondButton.text = (answer + Random.Range(1,6)).ToString();
                        thirdButton.text = (answer + Random.Range(-1,-6)).ToString();
                        fourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 2){
                        secondButton.text = (answer).ToString();
                        firstButton.text = (answer + Random.Range(1,6)).ToString();
                        thirdButton.text = (answer + Random.Range(-1,-6)).ToString();
                        fourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 3){
                        thirdButton.text = (answer).ToString();
                        secondButton.text = (answer + Random.Range(-1,-6)).ToString();
                        firstButton.text = (answer + Random.Range(1,6)).ToString();
                        fourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 4){
                        fourthButton.text = (answer).ToString();
                        thirdButton.text = (answer + Random.Range(6,13)).ToString();
                        secondButton.text = (answer + Random.Range(-1,-6)).ToString();
                        firstButton.text = (answer + Random.Range(1,6)).ToString();
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
                        firstButton.text = (answer).ToString();
                        secondButton.text = (answer + Random.Range(1,6)).ToString();
                        thirdButton.text = (answer + Random.Range(-1,-6)).ToString();
                        fourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 2){
                        secondButton.text = (answer).ToString();
                        firstButton.text = (answer + Random.Range(1,6)).ToString();
                        thirdButton.text = (answer + Random.Range(-1,-6)).ToString();
                        fourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 3){
                        thirdButton.text = (answer).ToString();
                        secondButton.text = (answer + Random.Range(-1,-6)).ToString();
                        firstButton.text = (answer + Random.Range(1,6)).ToString();
                        fourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 4){
                        fourthButton.text = (answer).ToString();
                        thirdButton.text = (answer + Random.Range(6,13)).ToString();
                        secondButton.text = (answer + Random.Range(-1,-6)).ToString();
                        firstButton.text = (answer + Random.Range(1,6)).ToString();
                    }
                }
                else if(randomOperator == 3){
                    randomNumberOne = Random.Range(1,10);
                    randomNumberTwo = Random.Range(1,20);
                    question.text = randomNumberOne + " x " + randomNumberTwo + " = " + " ?";
                    answer = randomNumberOne * randomNumberTwo;
                    if(trueAnswer == 1){
                        firstButton.text = (answer).ToString();
                        secondButton.text = (answer + Random.Range(1,6)).ToString();
                        thirdButton.text = (answer + Random.Range(-1,-6)).ToString();
                        fourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 2){
                        secondButton.text = (answer).ToString();
                        firstButton.text = (answer + Random.Range(1,6)).ToString();
                        thirdButton.text = (answer + Random.Range(-1,-6)).ToString();
                        fourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 3){
                        thirdButton.text = (answer).ToString();
                        secondButton.text = (answer + Random.Range(-1,-6)).ToString();
                        firstButton.text = (answer + Random.Range(1,6)).ToString();
                        fourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 4){
                        fourthButton.text = (answer).ToString();
                        thirdButton.text = (answer + Random.Range(6,13)).ToString();
                        secondButton.text = (answer + Random.Range(-1,-6)).ToString();
                        firstButton.text = (answer + Random.Range(1,6)).ToString();
                    }
                }
                else if(randomOperator == 4){
                    randomNumberTwo = Random.Range(1,10);
                    randomNumberOne = Random.Range(1,10)*randomNumberTwo;
                    question.text = randomNumberOne + " / " + randomNumberTwo + " = " + " ?";
                    answer = randomNumberOne / randomNumberTwo;
                    if(trueAnswer == 1){
                        firstButton.text = (answer).ToString();
                        secondButton.text = (answer + Random.Range(1,6)).ToString();
                        thirdButton.text = (answer + Random.Range(-1,-6)).ToString();
                        fourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 2){
                        secondButton.text = (answer).ToString();
                        firstButton.text = (answer + Random.Range(1,6)).ToString();
                        thirdButton.text = (answer + Random.Range(-1,-6)).ToString();
                        fourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 3){
                        thirdButton.text = (answer).ToString();
                        secondButton.text = (answer + Random.Range(-1,-6)).ToString();
                        firstButton.text = (answer + Random.Range(1,6)).ToString();
                        fourthButton.text = (answer + Random.Range(6,13)).ToString();
                    }
                    else if(trueAnswer == 4){
                        fourthButton.text = (answer).ToString();
                        thirdButton.text = (answer + Random.Range(6,13)).ToString();
                        secondButton.text = (answer + Random.Range(-1,-6)).ToString();
                        firstButton.text = (answer + Random.Range(1,6)).ToString();
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
                        firstButton.text = operatorAnswer[0].ToString();
                        secondButton.text = operatorAnswer[1].ToString();
                        thirdButton.text = operatorAnswer[2].ToString();
                    }
                    else if(trueAnswer == 2){
                        firstButton.text = operatorAnswer[1].ToString();
                        secondButton.text = operatorAnswer[0].ToString();
                        thirdButton.text = operatorAnswer[2].ToString();
                    }
                    else if(trueAnswer == 3){
                        firstButton.text = operatorAnswer[2].ToString();
                        secondButton.text = operatorAnswer[1].ToString();
                        thirdButton.text = operatorAnswer[0].ToString();
                    }
                }
                else if(randomNumberOne < randomNumberTwo){
                     if(trueAnswer == 1){
                        firstButton.text = operatorAnswer[1].ToString();
                        secondButton.text = operatorAnswer[0].ToString();
                        thirdButton.text = operatorAnswer[2].ToString();
                    }
                    else if(trueAnswer == 2){
                        firstButton.text = operatorAnswer[2].ToString();
                        secondButton.text = operatorAnswer[1].ToString();
                        thirdButton.text = operatorAnswer[0].ToString();
                    }
                    else if(trueAnswer == 3){
                        firstButton.text = operatorAnswer[0].ToString();
                        secondButton.text = operatorAnswer[1].ToString();
                        thirdButton.text = operatorAnswer[2].ToString();
                    }
                }
                else if(randomNumberOne == randomNumberTwo){
                    if(trueAnswer == 1){
                        firstButton.text = operatorAnswer[2].ToString();
                        secondButton.text = operatorAnswer[0].ToString();
                        thirdButton.text = operatorAnswer[1].ToString();
                    }
                    else if(trueAnswer == 2){
                        firstButton.text = operatorAnswer[1].ToString();
                        secondButton.text = operatorAnswer[2].ToString();
                        thirdButton.text = operatorAnswer[0].ToString();
                    }
                    else if(trueAnswer == 3){
                        firstButton.text = operatorAnswer[0].ToString();
                        secondButton.text = operatorAnswer[1].ToString();
                        thirdButton.text = operatorAnswer[2].ToString();
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
    }

    void DetectTouch(){   
        clicked = false;
        if(Input.touchCount == 1){
                Touch touch = Input.GetTouch(0); // get the touch
            if(touch.phase == TouchPhase.Began){
                if(touch.position.x <= 350 && touch.position.x >= 100 && touch.position.y <= 1900 && touch.position.y >= 1650){
                    if(trueAnswer == 1){
                        print("Doğru cevap verdiniz, tebrikler.");
                        //detectAnswer = false;
                    }
                    else{
                        print("Cevap" + trueAnswer.ToString() + " . şık olmalıydı. Yanlış bildiniz.");
                        playerLife = playerLife -1;
                        print(playerLife.ToString() + " canınız kaldı.");
                    }
                    clicked = true;      
                }
                else if(touch.position.x <= 650 && touch.position.x >= 450 && touch.position.y <= 1900 && touch.position.y >= 1650){
                    print("İkinci şık tıklandı.");
                    if(trueAnswer == 2){
                        print("Doğru cevap verdiniz, tebrikler.");
                    }
                    else{
                        print("Cevap" + trueAnswer.ToString() + " . şık olmalıydı. Yanlış bildiniz.");
                        playerLife = playerLife -1;
                        print(playerLife.ToString() + " canınız kaldı.");
                    }
                clicked = true;    
                }
                else if(touch.position.x <= 990 && touch.position.x >= 740 && touch.position.y <= 1900 && touch.position.y >= 1650){
                    if(trueAnswer == 3){
                        print("Doğru cevap verdiniz, tebrikler.");
                    }
                    else{
                        print("Cevap" + trueAnswer.ToString() + " . şık olmalıydı. Yanlış bildiniz.");
                        playerLife = playerLife -1;
                        print(playerLife.ToString() + " canınız kaldı.");
                    }
                clicked = true;    
                }
                else if(touch.position.x <= 1300 && touch.position.x >= 1080 && touch.position.y <= 1900 && touch.position.y >= 1650){
                    if(trueAnswer == 4){
                        print("Doğru cevap verdiniz, tebrikler.");
                    }
                    else{
                        print("Cevap" + trueAnswer.ToString() + " . şık olmalıydı. Yanlış bildiniz.");
                        playerLife = playerLife -1;
                        print(playerLife.ToString() + " canınız kaldı.");
                    }
                clicked = true;         
                }
                else{
                    print("Tıklanan konum --> " + touch.position.y.ToString());
                }
            
                switch (playerLife){
                    case 0:
                        print("Canınız kalmamıştır, oyun sonlandı.");
                        heartOne.SetActive(false);
                         // Game over eklenecek.
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
            if(clicked == true){
                detectAnswer = false;
                Time.timeScale = 1f;
                panel.SetActive(false);  
            if(playerLife == 0){
                Time.timeScale= 0f;
            }
            }               
        }
    }
        
}
    // Soruyu yanlış bildiğinde counterı bir eksilt ve kalplerden birini sil.


