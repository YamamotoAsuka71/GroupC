using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapgeneration : MonoBehaviour
{
    const int size = 5;
    const int width = 17;   //  �}�b�v�̉���
    const int height = 17;  //  �}�b�v�̏c��
    int[,] map = new int[width, height];    //  �}�b�v��ŕǂ������𔻕ʂ��邽�߂̓񎟔z��
    const int wall = 1; //  �ǂ������ꍇ�̔��ʂ��邽�߂̒l
    const int road = 0; //  ���������ꍇ�̔��ʂ��邽�߂̒l
    public int positionX;   //  X���W
    public int positionY;   //  Y���W

    public int pointX;
    public int pointY;

    int[] PositionNum = { 2, 4, 6, 8, 10, 12, 14 }; //  �����̍��W

    public bool flg = false;    //  ���������ł��邩�ǂ����̔��ʃt���O

    public int Num = 500;   //  ��{���̃��[�v��
    public int Num2 = 250;  //  �����ꓹ�̃��[�v��

    bool[] direction = new bool[4]; //  �����̔��ʃt���O���i�[���邽�߂̔z��

    float timer = 0.0f;


    //public GameObject[,] WALL = new GameObject[width, height];  

    public GameObject Wall; //  �ǂƂȂ�}�b�v�`�b�v��ۑ����邽�߂̏ꏊ
    public GameObject Road; //  ���ƂȂ�}�b�v�`�b�v��ۑ����邽�߂̏ꏊ
    public GameObject Goal; //  �S�[���ƂȂ�}�b�v�`�b�v��ۑ����邽�߂̏ꏊ
    public GameObject Player;
    public Transform PlayerPosition;
    public GameObject Enemy;
    public new GameObject camera;
    void Start()
    {
        camera = Camera.main.gameObject;
        PlayerPosition = Player.transform;
        //  �}�b�v�̂��ׂĂ�ǂŐ��������邽�߂̃��[�v
        for (int i = 0; i < width; i++) //  ����(X���W)�̃��[�v
        {
            for (int n = 0; n < height; n++)    //  �c��(Y���W)�̃��[�v
            {
                map[i, n] = wall;   //  �����������W�͕ǂƐݒ�
                Instantiate(Wall, new Vector3((i * size) - (width * size) / 2, (n * size) - (height * size) / 2, 0.0f), Quaternion.identity);   //  �ǂ𐶐�
                //  ���������N���[���ɂ킩��₷���悤�ɖ��O��ԍ��ł��邽�߂̃v���O����
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
        positionX = 2;  //  ��������X���W
        positionY = 14; //  ��������Y���W
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
        //  �}�b�v�̒[�����}�X�͕ǂɂȂ�悤�ɐݒ肷�邽�߂̃��[�v
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
        map[positionX, positionY] = road;   //  ���������|�W�V�����𓹂Ƃ��Đݒ�
        GameObject wall1 = GameObject.Find("Wall" + positionX.ToString() + "," + positionY.ToString() + "(Clone)"); //  ���𐶐��������W�Ɠ����ꏊ�ɂ���ǂ�T��
        Destroy(wall1); //  �T�����ǂ�j��
        Instantiate(Road, new Vector3((positionX * size) - (width * size) / 2, (positionY * size) - (height * size) / 2, 0.0f), Quaternion.identity);   //  ���𐶐�
        pointX = positionX;
        pointY = positionY;
        PlayerPosition.transform.position = new Vector3((pointX * size) - (width * size) / 2, (pointY * size) - (height * size) / 2, 0.0f);
        camera.transform.position = new Vector3((pointX * size) - (width * size) / 2, (pointY * size) - (height * size) / 2, -10.0f);
        //Debug.Log(positionX + "," + positionY);
        CreateMap();    //  ��{���𐶐�����֐�
        Instantiate(Goal, new Vector3((positionX * size) - (width * size) / 2, (positionY * size) - (height * size) / 2, 0.0f), Quaternion.identity);   //  �S�[���𐶐�
        CreateRoad();   //  �����ꓹ�𐶐�����֐�
    }
    void CreateMap()
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
                    if (map[positionX, positionY + 2] == wall)  //  �Ō�ɐ��������������Q�}�X���ǂȂ���s
                    {
                        map[positionX, positionY + 1] = road;   //  �Ō�ɐ��������������P�}�X�𓹂Ɛݒ�
                        map[positionX, positionY + 2] = road;   //  �Ō�ɐ��������������Q�}�X�𓹂Ɛݒ�
                        GameObject wall2 = GameObject.Find("Wall" + positionX.ToString() + "," + (positionY + 1).ToString() + "(Clone)");  //  �Ō�ɐ��������������P�}�X�̕ǂ�T��
                        GameObject wall3 = GameObject.Find("Wall" + positionX.ToString() + "," + (positionY + 2).ToString() + "(Clone)");  //  �Ō�ɐ��������������Q�}�X�̕ǂ�T��
                        Destroy(wall2);    //  �Ō�ɐ��������������P�}�X�̕ǂ�j��
                        Destroy(wall3);    //  �Ō�ɐ��������������Q�}�X�̕ǂ�j��
                        Instantiate(Road, new Vector3((positionX * size) - (width * size) / 2, ((positionY + 1) * size) - (height * size) / 2, 0.0f), Quaternion.identity); //  �Ō�ɐ��������������P�}�X�ɓ��𐶐�
                        Instantiate(Road, new Vector3((positionX * size) - (width * size) / 2, ((positionY + 2) * size) - (height * size) / 2, 0.0f), Quaternion.identity); //  �Ō�ɐ��������������Q�}�X�ɓ��𐶐�
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
                    if (map[positionX, positionY - 2] == wall)  //  �Ō�ɐ������������牺�Q�}�X���ǂȂ���s
                    {
                        map[positionX, positionY - 1] = road;   //  �Ō�ɐ������������牺�P�}�X�𓹂Ɛݒ�
                        map[positionX, positionY - 2] = road;   //  �Ō�ɐ������������牺�Q�}�X�𓹂Ɛݒ�
                        GameObject wall2 = GameObject.Find("Wall" + positionX.ToString() + "," + (positionY - 1).ToString() + "(Clone)");  //  �Ō�ɐ������������牺�P�}�X�̕ǂ�T��
                        GameObject wall3 = GameObject.Find("Wall" + positionX.ToString() + "," + (positionY - 2).ToString() + "(Clone)");  //  �Ō�ɐ������������牺�Q�}�X�̕ǂ�T��
                        Destroy(wall2);    //  �Ō�ɐ������������牺�P�}�X�̕ǂ�j��
                        Destroy(wall3);    //  �Ō�ɐ������������牺�Q�}�X�̕ǂ�j��
                        Instantiate(Road, new Vector3((positionX * size) - (width * size) / 2, ((positionY - 1) * size) - (height * size) / 2, 0.0f), Quaternion.identity); //  �Ō�ɐ������������牺�P�}�X�ɓ��𐶐�
                        Instantiate(Road, new Vector3((positionX * size) - (width * size) / 2, ((positionY - 2) * size) - (height * size) / 2, 0.0f), Quaternion.identity); //  �Ō�ɐ������������牺�Q�}�X�ɓ��𐶐�
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
                    if (map[positionX + 2, positionY] == wall)  //  �Ō�ɐ�������������E�Q�}�X���ǂȂ���s
                    {
                        map[positionX + 1, positionY] = road;  //  �Ō�ɐ�������������E�P�}�X�𓹂Ɛݒ�
                        map[positionX + 2, positionY] = road;  //  �Ō�ɐ�������������E�Q�}�X�𓹂Ɛݒ�
                        GameObject wall2 = GameObject.Find("Wall" + (positionX + 1).ToString() + "," + positionY.ToString() + "(Clone)");  //  �Ō�ɐ�������������E�P�}�X�̕ǂ�T��
                        GameObject wall3 = GameObject.Find("Wall" + (positionX + 2).ToString() + "," + positionY.ToString() + "(Clone)");  //  �Ō�ɐ�������������E�Q�}�X�̕ǂ�T��
                        Destroy(wall2);    //  �Ō�ɐ�������������E�P�}�X�̕ǂ�j��
                        Destroy(wall3);    //  �Ō�ɐ�������������E�Q�}�X�̕ǂ�j��
                        Instantiate(Road, new Vector3(((positionX + 1) * size) - (width * size) / 2, (positionY * size) - (height * size) / 2, 0.0f), Quaternion.identity); //  �Ō�ɐ�������������E�P�}�X�ɓ��𐶐�
                        Instantiate(Road, new Vector3(((positionX + 2) * size) - (width * size) / 2, (positionY * size) - (height * size) / 2, 0.0f), Quaternion.identity); //  �Ō�ɐ�������������E�Q�}�X�ɓ��𐶐�
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
                    if (map[positionX - 2, positionY] == wall)  //  �Ō�ɐ������������獶�Q�}�X���ǂȂ���s
                    {
                        map[positionX - 1, positionY] = road;  //  �Ō�ɐ������������獶�P�}�X�𓹂Ɛݒ�
                        map[positionX - 2, positionY] = road;  //  �Ō�ɐ������������獶�Q�}�X�𓹂Ɛݒ�
                        GameObject wall2 = GameObject.Find("Wall" + (positionX - 1).ToString() + "," + positionY.ToString() + "(Clone)");  //  �Ō�ɐ������������獶�P�}�X�̕ǂ�T��
                        GameObject wall3 = GameObject.Find("Wall" + (positionX - 2).ToString() + "," + positionY.ToString() + "(Clone)");  //  �Ō�ɐ������������獶�Q�}�X�̕ǂ�T��
                        Destroy(wall2);    //  �Ō�ɐ������������獶�P�}�X�̕ǂ�j��
                        Destroy(wall3);    //  �Ō�ɐ������������獶�Q�}�X�̕ǂ�j��
                        Instantiate(Road, new Vector3(((positionX - 1) * size) - (width * size) / 2, (positionY * size) - (height * size) / 2, 0.0f), Quaternion.identity); //  �Ō�ɐ������������獶�P�}�X�ɓ��𐶐�
                        Instantiate(Road, new Vector3(((positionX - 2) * size) - (width * size) / 2, (positionY * size) - (height * size) / 2, 0.0f), Quaternion.identity); //  �Ō�ɐ������������獶�Q�}�X�ɓ��𐶐�
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
        while (true)    //  �������[�v
        {
            if (Num2 > 0)   //  ���[�v�𐔂���J�E���g��0���傫���ꍇ���s
            {
                int x = Random.Range(0, 7); //  �����̃}�X�������_���ɒ��I
                int y = Random.Range(0, 7); //  �����̃}�X�������_���ɒ��I
                if (map[PositionNum[x], PositionNum[y]] != road)    //  �����_���ɒ��I�������W�����ł͂Ȃ������ꍇ�Ɏ��s
                {
                    while (map[PositionNum[x], PositionNum[y]] != road)    //  �����_���ɒ��I�������W�����ł͂Ȃ������ꍇ�Ƀ��[�v������
                    {
                        x = Random.Range(0, 7); //  ������x�����̃}�X�������_���ɒ��I
                        y = Random.Range(0, 7); //  ������x�����̃}�X�������_���ɒ��I
                    }
                }
                else�@  //   �����_���ɒ��I�������W�����������ꍇ�Ɏ��s
                {
                    positionX = PositionNum[x]; //  X���W�ɕ��򂳂���X���W����
                    positionY = PositionNum[y]; //  Y���W�ɕ��򂳂���Y���W����
                }
                CreateMap();    //  ��{���𐶐�������֐����Ăяo�����򂷂铹�𐶐�
                Num2--; //  ���[�v�J�E���g���P����������
            }
            else�@   //  ���[�v�J�E���g��0��菬�����ꍇ�Ɏ��s
            {
                break;  //  �������[�v��K��������
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
