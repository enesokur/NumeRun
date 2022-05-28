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
    public GameObject panel;
    bool calculateQuestion;
    public TextMeshProUGUI firstButton;
    public TextMeshProUGUI secondButton;
    public TextMeshProUGUI thirdButton;
    public TextMeshProUGUI fourthButton;

    int randomNumberOne;
    int randomNumberTwo;
    int randomOperator;
    void Start(){
        hearts = new GameObject[3];
        myCharacter = GameObject.Find("Character");
        roadTwo = GameObject.Find("Road 2");
        calculateQuestion = true;
    }

    void Update(){
        temp += 2*Time.deltaTime;
        score.text = ((int)temp).ToString();
        if(myCharacter.transform.position.z - roadTwo.transform.position.z >= 25 && calculateQuestion ){
            Time.timeScale = 0f;
            CreateQuestion();
            panel.SetActive(true);
            calculateQuestion = false;
        }
    }

    void CreateQuestion(){
        int answer;
        question.text = "";
        randomOperator = Random.Range(1,5);
        if(randomOperator == 1){
            randomNumberOne = Random.Range(10,50);
            randomNumberTwo = Random.Range(10,50);
            question.text = randomNumberOne + " + " + randomNumberTwo + " = " + " ?";
            answer = randomNumberOne + randomNumberTwo;
            int trueAnswer = Random.Range(1,5);
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
            int trueAnswer = Random.Range(1,5);
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
            int trueAnswer = Random.Range(1,5);
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
            int trueAnswer = Random.Range(1,5);
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
    // Soruyu yanlış bildiğinde counterı bir eksilt ve kalplerden birini sil.
}
