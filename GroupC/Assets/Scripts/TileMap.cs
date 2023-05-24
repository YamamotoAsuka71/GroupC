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
    const int width = 13;   //  �}�b�v�̉���
    const int height = 13;  //  �}�b�v�̏c��
    public int Width = 13;
    public int Height = 13;
    int[,] map = new int[height, width];    //  �}�b�v��ŕǂ������𔻕ʂ��邽�߂̓񎟔z��
    const int wall = 1; //  �ǂ������ꍇ�̔��ʂ��邽�߂̒l
    const int road = 0; //  ���������ꍇ�̔��ʂ��邽�߂̒l
    public int positionX;   //  X���W
    public int positionY;   //  Y���W

    public int GoalPositionX;
    public int GoalPositionY;

    public int pointX;
    public int pointY;

    int[] PositionNum = { 2, 4, 6, 8, 10 }; //  �����̍��W

    public bool flg = false;    //  ���������ł��邩�ǂ����̔��ʃt���O

    public int Num = 500;   //  ��{���̃��[�v��
    public int Num2 = 250;  //  �����ꓹ�̃��[�v��

    bool[] direction = new bool[4]; //  �����̔��ʃt���O���i�[���邽�߂̔z��
    // Start is called before the first frame update
    void Start()
    {
        positionX = 2;  //  ��������X���W
        positionY = 10; //  ��������Y���W
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
        Num = 500;  //  ���x�����[�v����̂ł��̊֐����Ă΂�邽�тɃ��[�v�𐔂���J�E���g�����Z�b�g
        while (true)    //  �������[�v
        {
            if (Num > 0)    //  �J�E���g��0���傫����Ύ��s
            {
                //Debug.Log(positionX + "," + positionY);
                int RandomNum = Random.Range(0, 4); //  ���������߂邽�߂Ƀ����_���ɕ����𒊑I
                direction[RandomNum] = true;    //  ���I���������̃t���O�𗧂Ă�
                if (direction[0] == true)   //  0�Ԗ�(��Ɖ���)�̃t���O�������Ă�������s
                {
                    if (map[positionY + 2, positionX] == wall)  //  �Ō�ɐ��������������Q�}�X���ǂȂ���s
                    {
                        map[positionY + 1, positionX] = road;   //  �Ō�ɐ��������������P�}�X�𓹂Ɛݒ�
                        map[positionY + 2, positionX] = road;   //  �Ō�ɐ��������������Q�}�X�𓹂Ɛݒ�
                        tilemap.SetTile(new Vector3Int((positionX * size) - (width * size) / 2, ((positionY + 1) * size) - (height * size) / 2, 0), Road);
                        tilemap.SetTile(new Vector3Int((positionX * size) - (width * size) / 2, ((positionY + 2) * size) - (height * size) / 2, 0), Road);
                        yield return new WaitForEndOfFrame();
                        positionY = positionY + 2;  //  �Ō�ɐ�����������Y���W���X�V
                        //  �����̃t���O�����ׂď�����
                        for (int i = 0; i < 4; i++)
                        {
                            direction[i] = false;
                        }
                    }
                    else if ((direction[0] == true) && (direction[1] == true) && (direction[2] == true) && direction[3] == true)    //  ���ׂẴt���O�������Ă�������s
                    {
                        flg = true; //  ���������ł��邩�ǂ����𔻕ʂ���t���O�𗧂Ă�
                    }
                }
                else if (direction[1] == true)     //  1�Ԗ�(���Ɖ���)�̃t���O�������Ă�������s
                {
                    if (map[positionY - 2, positionX] == wall)  //  �Ō�ɐ������������牺�Q�}�X���ǂȂ���s
                    {
                        map[positionY - 1, positionX] = road;   //  �Ō�ɐ������������牺�P�}�X�𓹂Ɛݒ�
                        map[positionY - 2, positionX] = road;   //  �Ō�ɐ������������牺�Q�}�X�𓹂Ɛݒ�
                        tilemap.SetTile(new Vector3Int((positionX * size) - (width * size) / 2, ((positionY - 1) * size) - (height * size) / 2, 0), Road);
                        tilemap.SetTile(new Vector3Int((positionX * size) - (width * size) / 2, ((positionY - 2) * size) - (height * size) / 2, 0), Road);
                        yield return new WaitForEndOfFrame();
                        positionY = positionY - 2;  //  �Ō�ɐ�����������Y���W���X�V
                        //  �����̃t���O�����ׂď�����
                        for (int i = 0; i < 4; i++)
                        {
                            direction[i] = false;
                        }
                    }
                    else if ((direction[0] == true) && (direction[1] == true) && (direction[2] == true) && direction[3] == true)   //  ���ׂẴt���O�������Ă�������s
                    {

                        flg = true; //  ���������ł��邩�ǂ����𔻕ʂ���t���O�𗧂Ă�
                    }
                }
                else if (direction[2] == true)     //  2�Ԗ�(�E�Ɖ���)�̃t���O�������Ă�������s
                {
                    if (map[positionY, positionX + 2] == wall)  //  �Ō�ɐ�������������E�Q�}�X���ǂȂ���s
                    {
                        map[positionY, positionX + 1] = road;  //  �Ō�ɐ�������������E�P�}�X�𓹂Ɛݒ�
                        map[positionY, positionX + 2] = road;  //  �Ō�ɐ�������������E�Q�}�X�𓹂Ɛݒ�
                        tilemap.SetTile(new Vector3Int(((positionX + 1) * size) - (width * size) / 2, (positionY * size) - (height * size) / 2, 0), Road);
                        tilemap.SetTile(new Vector3Int(((positionX + 2) * size) - (width * size) / 2, (positionY * size) - (height * size) / 2, 0), Road);
                        yield return new WaitForEndOfFrame();
                        positionX = positionX + 2;  //  �Ō�ɐ�����������X���W���X�V
                        //  �����̃t���O�����ׂď�����
                        for (int i = 0; i < 4; i++)
                        {
                            direction[i] = false;
                        }
                    }
                    else if ((direction[0] == true) && (direction[1] == true) && (direction[2] == true) && direction[3] == true)   //  ���ׂẴt���O�������Ă�������s
                    {
                        flg = true; //  ���������ł��邩�ǂ����𔻕ʂ���t���O�𗧂Ă�
                    }
                }
                else if (direction[3] == true)     //  3�Ԗ�(���Ɖ���)�̃t���O�������Ă�������s
                {
                    if (map[positionY, positionX - 2] == wall)  //  �Ō�ɐ������������獶�Q�}�X���ǂȂ���s
                    {
                        map[positionY, positionX - 1] = road;  //  �Ō�ɐ������������獶�P�}�X�𓹂Ɛݒ�
                        map[positionY, positionX - 2] = road;  //  �Ō�ɐ������������獶�Q�}�X�𓹂Ɛݒ�
                        tilemap.SetTile(new Vector3Int(((positionX - 1) * size) - (width * size) / 2, (positionY * size) - (height * size) / 2, 0), Road);
                        tilemap.SetTile(new Vector3Int(((positionX - 2) * size) - (width * size) / 2, (positionY * size) - (height * size) / 2, 0), Road);
                        yield return new WaitForEndOfFrame();
                        positionX = positionX - 2;  //  �Ō�ɐ�����������X���W���X�V
                        //  �����̃t���O�����ׂď�����
                        for (int i = 0; i < 4; i++)
                        {
                            direction[i] = false;
                        }
                    }
                    else if ((direction[0] == true) && (direction[1] == true) && (direction[2] == true) && direction[3] == true)   //  ���ׂẴt���O�������Ă�������s
                    {
                        flg = true; //  ���������ł��邩�ǂ����𔻕ʂ���t���O�𗧂Ă�
                    }
                }
                //  �����ł��Ȃ��������ɕ����̃t���O�����ׂď�����
                for (int i = 0; i < 4; i++)
                {
                    direction[i] = false;
                }
                if (flg == true) //  ���������ł��邩�ǂ����𔻕ʂ���t���O�������Ă�������s
                {
                    Num = -1;   //  ���[�v�J�E���g��K��-1�ɌŒ�
                }
                Num--;  //  ���[�v�J�E���g���P����������

            }
            else�@  //���[�v�J�E���g��0��肿�������Ȃ�������s
            {
                flg = false;    //  ���������ł��邩�ǂ����𔻕ʂ���t���O��������
                break;  //  �������[�v��K��������
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
