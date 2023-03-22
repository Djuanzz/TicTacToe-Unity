using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gaskeunn : MonoBehaviour
{
    public int turnSiapa;
    public Sprite[] spritesNya;
    public Button[] buttonNya; 
    public Sprite[] winnerText;
    public Image imageWin;
    public GameObject MengWin;
    public Button WinWess;
    private GameObject lineObject;
    public GameObject linePrefabs;
    private LineRenderer lineNya;

    void Start(){
        lineObject = Instantiate(linePrefabs) as GameObject;
        lineNya = lineObject.GetComponent<LineRenderer>();
        lineNya.enabled = false;
    }

    public void hitButton(int index)
    {
        buttonNya[index].image.sprite = spritesNya[turnSiapa];
        buttonNya[index].interactable = false;

        bool menang = CekMenang();
        bool draw = CekDraw();
        if (menang)
        {
            for (int i = 0; i < buttonNya.Length; i++)
            {
                buttonNya[i].transition = Selectable.Transition.None;
                buttonNya[i].interactable = false;
            }
            if(turnSiapa == 0){
                Debug.Log("X Menang!");
            } else{
                Debug.Log("O Menang!");
            }
            imageWin.sprite = winnerText[turnSiapa];
            MengWin.SetActive(true);
            Destroy(WinWess.gameObject);

            // WinWess.transition = Selectable.Transition.None;
            // WinWess.interactable = false;
            // GameObject prefabsWinnya = Instantiate(winPrefabs,Vector3.zero,transform.rotation) as GameObject;
            // prefabsWinnya.transform.SetParent(GameObject.FindGameObjectWithTag("GameBerlangsung").transform,false);
            return;
        }

        if(draw)
        {
            imageWin.sprite =  winnerText[2];
            MengWin.SetActive(true);
            Destroy(WinWess.gameObject);
            return;
        }

        turnSiapa = (turnSiapa == 0) ? 1 : 0;
    }
    
    private bool CekDraw(){
        bool draw = true;
        for (int i = 0; i < buttonNya.Length; i++)
        {
            if (buttonNya[i].interactable)
            {
                draw = false;
                break;
            }
        }
        return draw;
    }
    private bool CekMenang()
    {
        bool menang = KondisiWin(0, 1, 2) || KondisiWin(3, 4, 5) || KondisiWin(6, 7, 8) ||
                      KondisiWin(0, 3, 6) || KondisiWin(1, 4, 7) || KondisiWin(2, 5, 8) ||
                      KondisiWin(0, 4, 8) || KondisiWin(2, 4, 6);

        // if (menang)
        // {
        //     lineObject = Instantiate(linePrefabs) as GameObject;
        //     lineNya = lineObject.GetComponent<LineRenderer>();
        //     int[] winIndexes = GetWinIndexes();
        //     lineNya.SetPosition(0, buttonNya[winIndexes[0]].transform.position);
        //     lineNya.SetPosition(1, buttonNya[winIndexes[2]].transform.position);
        // }
        return menang;
    }
    private float a, b, c, d;

    private void DrawLine(int x, int y){
        switch(x){
            case 0:
                a = -1.5f;
                b = 1.5f;
                break;
            case 1:
                a = 0.0f;
                b = 1.5f;
                break;
            case 2:
                a = 1.5f;
                b = 1.5f;
                break;
            case 3:
                a = -1.5f;
                b = 0.0f;
                break;
            case 6:
                a = -1.5f;
                b = -1.5f;
                break;
        }
        
        switch(y){
            case 2:
                c = 1.5f;
                d = 1.5f;
                break;
            case 5:
                c = 1.5f;
                d = 0.0f;
                break;
            case 6:
                c = -1.5f;
                d = -1.5f;
                break;
            case 7:
                c = 0.0f;
                d = -1.5f;
                break;
            case 8:
                c = 1.5f;
                d = -1.5f;
                break;
        }

        lineNya.SetPosition(0, new Vector3(a,b,0));
        lineNya.SetPosition(1, new Vector3(c,d,0));
        // Color color =
        // lineNya.GetComponent<Image>.color = Color.red;
        lineNya.startColor = Color.red;
        lineNya.endColor = Color.red;
        // lineNya.SetPosition(1, buttonNya[x].transform.position);
        lineNya.enabled = true;
    }

    private bool KondisiWin(int index1, int index2, int index3)
    {
        bool sebaris = (buttonNya[index1].image.sprite == spritesNya[turnSiapa] &&
                        buttonNya[index2].image.sprite == spritesNya[turnSiapa] &&
                        buttonNya[index3].image.sprite == spritesNya[turnSiapa]);

        // if (sebaris)
        // {
        //     int[] winIndexes = new int[] { index1, index2, index3 };
        //     HighlightWinningButtons(winIndexes);
        // }

        if(sebaris) DrawLine(index1, index3);
        return sebaris;
    }

    private void HighlightWinningButtons(int[] indexes)
    {
        for (int i = 0; i < indexes.Length; i++)
        {
            buttonNya[indexes[i]].GetComponent<Image>().color = Color.green;
            // buttonNya[0].GetComponent<Image>().color = Color.green;

        }
    }

    private int[] GetWinIndexes()
    {
        if (KondisiWin(0, 1, 2)) return new int[] { 0, 1, 2 };
        if (KondisiWin(3, 4, 5)) return new int[] { 3, 4, 5 };
        if (KondisiWin(6, 7, 8)) return new int[] { 6, 7, 8 };
        if (KondisiWin(0, 3, 6)) return new int[] { 0, 3, 6 };
        if (KondisiWin(1, 4, 7)) return new int[] { 1, 4, 7 };
        if (KondisiWin(2, 5, 8)) return new int[] { 2, 5, 8 };
        if (KondisiWin(0, 4, 8)) return new int[] { 0, 4, 8 };
        if (KondisiWin(2, 4, 6)) return new int[] { 2, 4, 6 };
        return new int[0];
    }
}