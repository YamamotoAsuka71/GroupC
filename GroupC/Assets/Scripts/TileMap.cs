using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMap : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    [SerializeField] Tile Road;
    [SerializeField] Tile Wall;
    [SerializeField] Tile Goal;

    const int size = 6;
    public int Size = 6;
    const int width = 13;   //  マップの横幅
    const int height = 13;  //  マップの縦幅
    public int Width = 13;
    public int Height = 13;
    int[,] map = new int[height, width];    //  マップ上で壁か道かを判別するための二次配列
    const int wall = 1; //  壁だった場合の判別するための値
    const int road = 0; //  道だった場合の判別するための値
    public int positionX;   //  X座標
    public int positionY;   //  Y座標

    public int GoalPositionX;
    public int GoalPositionY;

    public int pointX;
    public int pointY;

    int[] PositionNum = { 2, 4, 6, 8, 10 }; //  偶数の座標

    public bool flg = false;    //  道が生成できるかどうかの判別フラグ

    public int Num = 500;   //  一本道のループ回数
    public int Num2 = 250;  //  分かれ道のループ回数

    bool[] direction = new bool[4]; //  方向の判別フラグを格納するための配列
    // Start is called before the first frame update
    void Start()
    {
        positionX = 2;  //  初期生成X座標
        positionY = 10; //  初期生成Y座標
        StartCoroutine(SetTile());
        StartCoroutine(CreateMap());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SetTile()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                tilemap.SetTile(new Vector3Int((x * size) - (width * size ) / 2, (y * size ) - (height * size ) / 2, 0), Wall);
                map[y, x] = wall;
                yield return new WaitForEndOfFrame();
            }
        }
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x += width - 1)
            {
                tilemap.SetTile(new Vector3Int((x * size ) - (width * size) / 2, (y * size ) - (height * size ) / 2, 1), Wall);
                map[y, x] = road;
            }
        }
        for (int y = 0; y < height; y++)
        {
            int x = 1;
            tilemap.SetTile(new Vector3Int((x * size) - (width * size) / 2, (y * size) - (height * size) / 2, 1), Wall);
            map[y, x] = road;
        }
        for (int y = 0; y < height; y++)
        {
            int x = 11;
            tilemap.SetTile(new Vector3Int((x * size) - (width * size) / 2, (y * size) - (height * size) / 2, 1), Wall);
            map[y, x] = road;
        }
        for (int y = 0; y < height; y += height - 1)
        {
            for (int x = 0; x < width; x++)
            {
                tilemap.SetTile(new Vector3Int((x * size) - (width * size) / 2, (y * size) - (height * size) / 2, 1), Wall);
                map[y, x] = road;
            }
        }
        for (int x = 0; x < width; x ++)
        {
            int y = 1;
            tilemap.SetTile(new Vector3Int((x * size) - (width * size) / 2, (y * size) - (height * size) / 2, 1), Wall);
            map[y, x] = road;
        }
        for (int x = 0; x < width; x ++)
        {
            int y = 11;
            tilemap.SetTile(new Vector3Int((x * size) - (width * size) / 2, (y * size) - (height * size) / 2, 1), Wall);
            map[y, x] = road;
        }
        tilemap.SetTile(new Vector3Int((positionX * size) - (width * size) / 2, (positionY * size) - (height * size) / 2, 0), Road);
        map[positionY, positionX] = road;
    }
    IEnumerator CreateMap()
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
                    if (map[positionY + 2, positionX] == wall)  //  最後に生成した道から上２マスが壁なら実行
                    {
                        map[positionY + 1, positionX] = road;   //  最後に生成した道から上１マスを道と設定
                        map[positionY + 2, positionX] = road;   //  最後に生成した道から上２マスを道と設定
                        tilemap.SetTile(new Vector3Int((positionX * size) - (width * size) / 2, ((positionY + 1) * size) - (height * size) / 2, 0), Road);
                        tilemap.SetTile(new Vector3Int((positionX * size) - (width * size) / 2, ((positionY + 2) * size) - (height * size) / 2, 0), Road);
                        yield return new WaitForEndOfFrame();
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
                    if (map[positionY - 2, positionX] == wall)  //  最後に生成した道から下２マスが壁なら実行
                    {
                        map[positionY - 1, positionX] = road;   //  最後に生成した道から下１マスを道と設定
                        map[positionY - 2, positionX] = road;   //  最後に生成した道から下２マスを道と設定
                        tilemap.SetTile(new Vector3Int((positionX * size) - (width * size) / 2, ((positionY - 1) * size) - (height * size) / 2, 0), Road);
                        tilemap.SetTile(new Vector3Int((positionX * size) - (width * size) / 2, ((positionY - 2) * size) - (height * size) / 2, 0), Road);
                        yield return new WaitForEndOfFrame();
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
                    if (map[positionY, positionX + 2] == wall)  //  最後に生成した道から右２マスが壁なら実行
                    {
                        map[positionY, positionX + 1] = road;  //  最後に生成した道から右１マスを道と設定
                        map[positionY, positionX + 2] = road;  //  最後に生成した道から右２マスを道と設定
                        tilemap.SetTile(new Vector3Int(((positionX + 1) * size) - (width * size) / 2, (positionY * size) - (height * size) / 2, 0), Road);
                        tilemap.SetTile(new Vector3Int(((positionX + 2) * size) - (width * size) / 2, (positionY * size) - (height * size) / 2, 0), Road);
                        yield return new WaitForEndOfFrame();
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
                    if (map[positionY, positionX - 2] == wall)  //  最後に生成した道から左２マスが壁なら実行
                    {
                        map[positionY, positionX - 1] = road;  //  最後に生成した道から左１マスを道と設定
                        map[positionY, positionX - 2] = road;  //  最後に生成した道から左２マスを道と設定
                        tilemap.SetTile(new Vector3Int(((positionX - 1) * size) - (width * size) / 2, (positionY * size) - (height * size) / 2, 0), Road);
                        tilemap.SetTile(new Vector3Int(((positionX - 2) * size) - (width * size) / 2, (positionY * size) - (height * size) / 2, 0), Road);
                        yield return new WaitForEndOfFrame();
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
    }
    /*IEnumerator SetTileplY()
    {
        tilemap.SetTile(new Vector3Int((positionX * size) - (width * size) / 2, ((positionY + 1) * size) - (height * size) / 2, 0), Road);
        tilemap.SetTile(new Vector3Int((positionX * size) - (width * size) / 2, ((positionY + 2) * size) - (height * size) / 2, 0), Road);
        yield return new WaitForEndOfFrame();
    }
    IEnumerator SetTilemiY()
    {
        tilemap.SetTile(new Vector3Int((positionX * size) - (width * size) / 2, ((positionY - 1) * size) - (height * size) / 2, 0), Road);
        tilemap.SetTile(new Vector3Int((positionX * size) - (width * size) / 2, ((positionY - 2) * size) - (height * size) / 2, 0), Road);
        yield return new WaitForEndOfFrame();
    }
    IEnumerator SetTileplX()
    {
        tilemap.SetTile(new Vector3Int(((positionX + 1) * size) - (width * size) / 2, (positionY * size) - (height * size) / 2, 0), Road);
        tilemap.SetTile(new Vector3Int(((positionX + 2) * size) - (width * size) / 2, (positionY * size) - (height * size) / 2, 0), Road);
        yield return new WaitForEndOfFrame();
    }
    IEnumerator SetTilemiX()
    {
        tilemap.SetTile(new Vector3Int(((positionX - 1) * size) - (width * size) / 2, (positionY * size) - (height * size) / 2, 0), Road);
        tilemap.SetTile(new Vector3Int(((positionX - 2) * size) - (width * size) / 2, (positionY * size) - (height * size) / 2, 0), Road);
        yield return new WaitForEndOfFrame();
    }*/
}
