using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapgeneration : MonoBehaviour
{
    const int size = 5;
    const int width = 17;   //  マップの横幅
    const int height = 17;  //  マップの縦幅
    int[,] map = new int[width, height];    //  マップ上で壁か道かを判別するための二次配列
    const int wall = 1; //  壁だった場合の判別するための値
    const int road = 0; //  道だった場合の判別するための値
    public int positionX;   //  X座標
    public int positionY;   //  Y座標

    public int pointX;
    public int pointY;

    int[] PositionNum = { 2, 4, 6, 8, 10, 12, 14 }; //  偶数の座標

    public bool flg = false;    //  道が生成できるかどうかの判別フラグ

    public int Num = 500;   //  一本道のループ回数
    public int Num2 = 250;  //  分かれ道のループ回数

    bool[] direction = new bool[4]; //  方向の判別フラグを格納するための配列

    float timer = 0.0f;


    //public GameObject[,] WALL = new GameObject[width, height];  

    public GameObject Wall; //  壁となるマップチップを保存するための場所
    public GameObject Road; //  道となるマップチップを保存するための場所
    public GameObject Goal; //  ゴールとなるマップチップを保存するための場所
    public GameObject Player;
    public Transform PlayerPosition;
    public GameObject Enemy;
    public new GameObject camera;
    void Start()
    {
        camera = Camera.main.gameObject;
        PlayerPosition = Player.transform;
        //  マップのすべてを壁で生成させるためのループ
        for (int i = 0; i < width; i++) //  横幅(X座標)のループ
        {
            for (int n = 0; n < height; n++)    //  縦幅(Y座標)のループ
            {
                map[i, n] = wall;   //  生成した座標は壁と設定
                Instantiate(Wall, new Vector3((i * size) - (width * size) / 2, (n * size) - (height * size) / 2, 0.0f), Quaternion.identity);   //  壁を生成
                //  生成したクローンにわかりやすいように名前を番号でつけるためのプログラム
                if (n == height - 1)
                {
                    if (i <= width - 1)
                    {
                        Wall.name = "Wall" + "0" + "," + "0";
                    }
                    else
                    {
                        Wall.name = "Wall" + (i + 1).ToString() + "," + "0";
                    }
                }
                else
                {
                    Wall.name = "Wall" + i.ToString() + "," + (n + 1).ToString();
                }
            }
        }
        positionX = 2;  //  初期生成X座標
        positionY = 14; //  初期生成Y座標
        /*positionX = Random.Range(4, width - 4);
        if (positionX % 2 != 0)
        {
            while (positionX % 2 != 0)
            {
                positionX = Random.Range(4, width - 4);
            }
        }
        positionY = Random.Range(4, height - 4);
        if (positionY % 2 != 0)
        {
            while (positionY % 2 != 0)
            {
                positionY = Random.Range(4, width - 4);
            }
        }*/
        //  マップの端から二マスは壁になるように設定するためのループ
        for (int i = 0; i < width; i++)
        {
            map[i, 0] = road;
            map[i, height - 1] = road;
            map[i, 1] = road;
            map[i, height - 2] = road;
            map[0, i] = road;
            map[width - 1, i] = road;
            map[1, i] = road;
            map[width - 2, i] = road;
        }
        map[positionX, positionY] = road;   //  初期生成ポジションを道として設定
        GameObject wall1 = GameObject.Find("Wall" + positionX.ToString() + "," + positionY.ToString() + "(Clone)"); //  道を生成した座標と同じ場所にある壁を探す
        Destroy(wall1); //  探した壁を破壊
        Instantiate(Road, new Vector3((positionX * size) - (width * size) / 2, (positionY * size) - (height * size) / 2, 0.0f), Quaternion.identity);   //  道を生成
        pointX = positionX;
        pointY = positionY;
        PlayerPosition.transform.position = new Vector3((pointX * size) - (width * size) / 2, (pointY * size) - (height * size) / 2, 0.0f);
        camera.transform.position = new Vector3((pointX * size) - (width * size) / 2, (pointY * size) - (height * size) / 2, -10.0f);
        //Debug.Log(positionX + "," + positionY);
        CreateMap();    //  一本道を生成する関数
        Instantiate(Goal, new Vector3((positionX * size) - (width * size) / 2, (positionY * size) - (height * size) / 2, 0.0f), Quaternion.identity);   //  ゴールを生成
        CreateRoad();   //  分かれ道を生成する関数
    }
    void CreateMap()
    {
        Num = 500;  //  何度もループするのでこの関数が呼ばれるたびにループを数えるカウントをリセット
        while (true)    //  無限ループ
        {
            if (Num > 0)    //  カウントが0より大きければ実行
            {
                //Debug.Log(positionX + "," + positionY);
                int RandomNum = Random.Range(0, 4); //  方向を決めるためにランダムに方向を抽選
                direction[RandomNum] = true;    //  抽選した方向のフラグを立てる
                if (direction[0] == true)   //  0番目(上と仮定)のフラグが立っていたら実行
                {
                    if (map[positionX, positionY + 2] == wall)  //  最後に生成した道から上２マスが壁なら実行
                    {
                        map[positionX, positionY + 1] = road;   //  最後に生成した道から上１マスを道と設定
                        map[positionX, positionY + 2] = road;   //  最後に生成した道から上２マスを道と設定
                        GameObject wall2 = GameObject.Find("Wall" + positionX.ToString() + "," + (positionY + 1).ToString() + "(Clone)");  //  最後に生成した道から上１マスの壁を探す
                        GameObject wall3 = GameObject.Find("Wall" + positionX.ToString() + "," + (positionY + 2).ToString() + "(Clone)");  //  最後に生成した道から上２マスの壁を探す
                        Destroy(wall2);    //  最後に生成した道から上１マスの壁を破壊
                        Destroy(wall3);    //  最後に生成した道から上２マスの壁を破壊
                        Instantiate(Road, new Vector3((positionX * size) - (width * size) / 2, ((positionY + 1) * size) - (height * size) / 2, 0.0f), Quaternion.identity); //  最後に生成した道から上１マスに道を生成
                        Instantiate(Road, new Vector3((positionX * size) - (width * size) / 2, ((positionY + 2) * size) - (height * size) / 2, 0.0f), Quaternion.identity); //  最後に生成した道から上２マスに道を生成
                        positionY = positionY + 2;  //  最後に生成した道のY座標を更新
                        //  方向のフラグをすべて初期化
                        for (int i = 0; i < 4; i++)
                        {
                            direction[i] = false;
                        }
                    }
                    else if ((direction[0] == true) && (direction[1] == true) && (direction[2] == true) && direction[3] == true)    //  すべてのフラグが立っていたら実行
                    {
                        flg = true; //  道が生成できるかどうかを判別するフラグを立てる
                    }
                }
                else if (direction[1] == true)     //  1番目(下と仮定)のフラグが立っていたら実行
                {
                    if (map[positionX, positionY - 2] == wall)  //  最後に生成した道から下２マスが壁なら実行
                    {
                        map[positionX, positionY - 1] = road;   //  最後に生成した道から下１マスを道と設定
                        map[positionX, positionY - 2] = road;   //  最後に生成した道から下２マスを道と設定
                        GameObject wall2 = GameObject.Find("Wall" + positionX.ToString() + "," + (positionY - 1).ToString() + "(Clone)");  //  最後に生成した道から下１マスの壁を探す
                        GameObject wall3 = GameObject.Find("Wall" + positionX.ToString() + "," + (positionY - 2).ToString() + "(Clone)");  //  最後に生成した道から下２マスの壁を探す
                        Destroy(wall2);    //  最後に生成した道から下１マスの壁を破壊
                        Destroy(wall3);    //  最後に生成した道から下２マスの壁を破壊
                        Instantiate(Road, new Vector3((positionX * size) - (width * size) / 2, ((positionY - 1) * size) - (height * size) / 2, 0.0f), Quaternion.identity); //  最後に生成した道から下１マスに道を生成
                        Instantiate(Road, new Vector3((positionX * size) - (width * size) / 2, ((positionY - 2) * size) - (height * size) / 2, 0.0f), Quaternion.identity); //  最後に生成した道から下２マスに道を生成
                        positionY = positionY - 2;  //  最後に生成した道のY座標を更新
                        //  方向のフラグをすべて初期化
                        for (int i = 0; i < 4; i++)
                        {
                            direction[i] = false;
                        }
                    }
                    else if ((direction[0] == true) && (direction[1] == true) && (direction[2] == true) && direction[3] == true)   //  すべてのフラグが立っていたら実行
                    {

                        flg = true; //  道が生成できるかどうかを判別するフラグを立てる
                    }
                }
                else if (direction[2] == true)     //  2番目(右と仮定)のフラグが立っていたら実行
                {
                    if (map[positionX + 2, positionY] == wall)  //  最後に生成した道から右２マスが壁なら実行
                    {
                        map[positionX + 1, positionY] = road;  //  最後に生成した道から右１マスを道と設定
                        map[positionX + 2, positionY] = road;  //  最後に生成した道から右２マスを道と設定
                        GameObject wall2 = GameObject.Find("Wall" + (positionX + 1).ToString() + "," + positionY.ToString() + "(Clone)");  //  最後に生成した道から右１マスの壁を探す
                        GameObject wall3 = GameObject.Find("Wall" + (positionX + 2).ToString() + "," + positionY.ToString() + "(Clone)");  //  最後に生成した道から右２マスの壁を探す
                        Destroy(wall2);    //  最後に生成した道から右１マスの壁を破壊
                        Destroy(wall3);    //  最後に生成した道から右２マスの壁を破壊
                        Instantiate(Road, new Vector3(((positionX + 1) * size) - (width * size) / 2, (positionY * size) - (height * size) / 2, 0.0f), Quaternion.identity); //  最後に生成した道から右１マスに道を生成
                        Instantiate(Road, new Vector3(((positionX + 2) * size) - (width * size) / 2, (positionY * size) - (height * size) / 2, 0.0f), Quaternion.identity); //  最後に生成した道から右２マスに道を生成
                        positionX = positionX + 2;  //  最後に生成した道のX座標を更新
                        //  方向のフラグをすべて初期化
                        for (int i = 0; i < 4; i++)
                        {
                            direction[i] = false;
                        }
                    }
                    else if ((direction[0] == true) && (direction[1] == true) && (direction[2] == true) && direction[3] == true)   //  すべてのフラグが立っていたら実行
                    {
                        flg = true; //  道が生成できるかどうかを判別するフラグを立てる
                    }
                }
                else if (direction[3] == true)     //  3番目(左と仮定)のフラグが立っていたら実行
                {
                    if (map[positionX - 2, positionY] == wall)  //  最後に生成した道から左２マスが壁なら実行
                    {
                        map[positionX - 1, positionY] = road;  //  最後に生成した道から左１マスを道と設定
                        map[positionX - 2, positionY] = road;  //  最後に生成した道から左２マスを道と設定
                        GameObject wall2 = GameObject.Find("Wall" + (positionX - 1).ToString() + "," + positionY.ToString() + "(Clone)");  //  最後に生成した道から左１マスの壁を探す
                        GameObject wall3 = GameObject.Find("Wall" + (positionX - 2).ToString() + "," + positionY.ToString() + "(Clone)");  //  最後に生成した道から左２マスの壁を探す
                        Destroy(wall2);    //  最後に生成した道から左１マスの壁を破壊
                        Destroy(wall3);    //  最後に生成した道から左２マスの壁を破壊
                        Instantiate(Road, new Vector3(((positionX - 1) * size) - (width * size) / 2, (positionY * size) - (height * size) / 2, 0.0f), Quaternion.identity); //  最後に生成した道から左１マスに道を生成
                        Instantiate(Road, new Vector3(((positionX - 2) * size) - (width * size) / 2, (positionY * size) - (height * size) / 2, 0.0f), Quaternion.identity); //  最後に生成した道から左２マスに道を生成
                        positionX = positionX - 2;  //  最後に生成した道のX座標を更新
                        //  方向のフラグをすべて初期化
                        for (int i = 0; i < 4; i++)
                        {
                            direction[i] = false;
                        }
                    }
                    else if ((direction[0] == true) && (direction[1] == true) && (direction[2] == true) && direction[3] == true)   //  すべてのフラグが立っていたら実行
                    {
                        flg = true; //  道が生成できるかどうかを判別するフラグを立てる
                    }
                }
                //  何もできなかった時に方向のフラグをすべて初期化
                for (int i = 0; i < 4; i++)
                {
                    direction[i] = false;
                }
                if (flg == true) //  道が生成できるかどうかを判別するフラグが立っていたら実行
                {
                    Num = -1;   //  ループカウントを必ず-1に固定
                }
                Num--;  //  ループカウントを１減少させる

            }
            else　  //ループカウントが0よりちいさくなったら実行
            {
                flg = false;    //  道が生成できるかどうかを判別するフラグを初期化
                break;  //  無限ループを必ず抜ける
            }
        }
        //DebugDate();
    }
    /*void DebugDate()
    {
        for(int i=0;i<width;i++)
        {
            for (int n = 0; n < height; n++)
            {
                Debug.Log("map[" + i + "," + n + "]" + "=" + map[i, n]);
            }
        }
    }*/
    void CreateRoad()
    {
        while (true)    //  無限ループ
        {
            if (Num2 > 0)   //  ループを数えるカウントが0より大きい場合実行
            {
                int x = Random.Range(0, 7); //  偶数のマスをランダムに抽選
                int y = Random.Range(0, 7); //  偶数のマスをランダムに抽選
                if (map[PositionNum[x], PositionNum[y]] != road)    //  ランダムに抽選した座標が道ではなかった場合に実行
                {
                    while (map[PositionNum[x], PositionNum[y]] != road)    //  ランダムに抽選した座標が道ではなかった場合にループさせる
                    {
                        x = Random.Range(0, 7); //  もう一度偶数のマスをランダムに抽選
                        y = Random.Range(0, 7); //  もう一度偶数のマスをランダムに抽選
                    }
                }
                else　  //   ランダムに抽選した座標が道だった場合に実行
                {
                    positionX = PositionNum[x]; //  X座標に分岐させるX座標を代入
                    positionY = PositionNum[y]; //  Y座標に分岐させるY座標を代入
                }
                CreateMap();    //  一本道を生成させる関数を呼び出し分岐する道を生成
                Num2--; //  ロープカウントを１減少させる
            }
            else　   //  ループカウントが0より小さい場合に実行
            {
                break;  //  無限ループを必ず抜ける
            }
        }
    }
    void Update()
    {
        if ((timer < 60) && (timer > 30))
        {
            //Instantiate(Enemy, new Vector3((pointX * size) - (width * size) / 2, (pointY * size) - (height * size) / 2, 0.0f), Quaternion.identity);
            timer = 60;
        }
        else if (timer <= 30)
        {
            timer += Time.deltaTime;
        }
    }
}
