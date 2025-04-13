using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private string oneStroke = "1 stroke";
    private string twoStroke = "2 stroke";
    private string threeStroke = "3 stroke";
    private string fourStroke = "4 stroke";
    private string fiveStroke = "5 stroke";
    private string sixStroke = "6 stroke(max)";
    private static GameManager instance;
    private int levelsBeat = 0;
    public static bool advancing = false;
    void Awake(){
    if(instance == null){
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    else{
        Destroy(gameObject);
        
    }
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == oneStroke || SceneManager.GetActiveScene().name == twoStroke || SceneManager.GetActiveScene().name == threeStroke){
            Cursor.visible = true;
        }
        else if(SceneManager.GetActiveScene().name == fourStroke || SceneManager.GetActiveScene().name == fiveStroke || SceneManager.GetActiveScene().name == sixStroke || SceneManager.GetActiveScene().name == "Win"){
            Cursor.visible = true;
        }
        else{
            Cursor.visible = false;
        }
        Restart();
        if(Ball.nextLevel == true){
            LevelWin(Aim.strokeCount);
            Ball.nextLevel = false;
            Aim.totalStrokeCount += Aim.strokeCount;
            Aim.strokeCount = 0;
            levelsBeat += 1;
        }
        if(advancing){
            advance(levelsBeat);
            advancing = false;
            Debug.Log(Aim.totalStrokeCount);
        }
    }
    public void Restart(){
        if(Input.GetButtonDown("Restart")){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Aim.strokeCount = 0;
        }
    }
    
    public void LevelWin(int strokeCount){
        if(SceneManager.GetActiveScene().name == "Level18"){
            SceneManager.LoadScene("Win");
        }
        else if(strokeCount == 1){
            SceneManager.LoadScene(oneStroke);
        }
        else if(strokeCount == 2){
            SceneManager.LoadScene(twoStroke);
        }
        else if(strokeCount == 3){
            SceneManager.LoadScene(threeStroke);
        }
        else if(strokeCount == 4){
            SceneManager.LoadScene(fourStroke);
        }
        else if(strokeCount == 5){
            SceneManager.LoadScene(fiveStroke);
        }
        else{
            SceneManager.LoadScene(sixStroke);
        }
    }
    private void advance(int levelsBeat){
        if(levelsBeat == 1){
            SceneManager.LoadScene("Level2");
        }
        else if(levelsBeat == 2){
            SceneManager.LoadScene("Level3");
        }
        else if(levelsBeat == 3){
            SceneManager.LoadScene("Level4");
        }
        else if(levelsBeat == 4){
            SceneManager.LoadScene("Level5");
        }
        else if(levelsBeat == 5){
            SceneManager.LoadScene("Level6");
        }
        else if(levelsBeat == 6){
            SceneManager.LoadScene("Level7");
        }
        else if(levelsBeat == 7){
            SceneManager.LoadScene("Level8");
        }
        else if(levelsBeat == 8){
            SceneManager.LoadScene("Level9");
        }
        else if(levelsBeat == 9){
            SceneManager.LoadScene("Level10");
        }
        else if(levelsBeat == 10){
            SceneManager.LoadScene("Level11");
        }
        else if(levelsBeat == 11){
            SceneManager.LoadScene("Level12");
        }
        else if(levelsBeat == 12){
            SceneManager.LoadScene("Level13");
        }
        else if(levelsBeat == 13){
            SceneManager.LoadScene("Level14");
        }
        else if(levelsBeat == 14){
            SceneManager.LoadScene("Level15");
        }
        else if(levelsBeat == 15){
            SceneManager.LoadScene("Level16");
        }
        else if(levelsBeat == 16){
            SceneManager.LoadScene("Level17");
        }
        else if(levelsBeat == 17){
            SceneManager.LoadScene("Level18");
        }
    }
    
    
}
