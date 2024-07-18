namespace Day7_Project
{
    internal class Program
    {

        //블럭 번호
        public enum BlockNum
        {
            O,
            I = 1,
            T = 3,
            Z = 7,
            S = 9,
            J = 11,
            L = 15,
            end = 19

        }

        public struct Block
        {
            public int[,] b;



        }

        //행 열
        const int row = 30;
        const int column = 15;



        //블럭 입력용
        static char[,] pixel = new char[row, column];
        //블럭 충돌 구분용
        static int[,] pixelNum = new int[row, column];
        //블럭 초기화
        static Block[] block = new Block[19];

        //현재 블럭 번호
        static int currentBlockNum = 1;
        //블럭 번호 배열
        static int[] blockNumArr = new int[] { (int)BlockNum.O, (int)BlockNum.I, (int)BlockNum.T, (int)BlockNum.Z, (int)BlockNum.S, (int)BlockNum.J, (int)BlockNum.L, (int)BlockNum.end };
        //랜덤 블럭 번호
        static int randomBlockNum = 1;



        //시간 변수
        //그리기 시간
        static int renderTick = 0;
        //낙하 시간
        static int dropTick = 0;

        //낙하 속도
        static int dropSpeed = 1000;

        //블럭 포지션
        static int blockPositionX = 5, blockPositionY = 0;

        //false 되면 게임 종료
        static bool gameover = true;

        //점수
        static int score = 0;

        #region 블럭 세팅
        static void SetBlock()
        {
            //시작좌표 1,1

            //사각블럭
            block[0].b = new int[4, 4];
            block[0].b[0, 0] = 0; block[0].b[0, 1] = 0; block[0].b[0, 2] = 0; block[0].b[0, 3] = 0;
            block[0].b[1, 0] = 0; block[0].b[1, 1] = 1; block[0].b[1, 2] = 1; block[0].b[1, 3] = 0;
            block[0].b[2, 0] = 0; block[0].b[2, 1] = 1; block[0].b[2, 2] = 1; block[0].b[2, 3] = 0;
            block[0].b[3, 0] = 0; block[0].b[3, 1] = 0; block[0].b[3, 2] = 0; block[0].b[3, 3] = 0;


            //작대기블럭1
            block[1].b = new int[4, 4];
            block[1].b[0, 0] = 0; block[1].b[0, 1] = 0; block[1].b[0, 2] = 0; block[1].b[0, 3] = 0;
            block[1].b[1, 0] = 1; block[1].b[1, 1] = 1; block[1].b[1, 2] = 1; block[1].b[1, 3] = 1;
            block[1].b[2, 0] = 0; block[1].b[2, 1] = 0; block[1].b[2, 2] = 0; block[1].b[2, 3] = 0;
            block[1].b[3, 0] = 0; block[1].b[3, 1] = 0; block[1].b[3, 2] = 0; block[1].b[3, 3] = 0;


            //작대기블럭2
            block[2].b = new int[4, 4];
            block[2].b[0, 0] = 0; block[2].b[0, 1] = 1; block[2].b[0, 2] = 0; block[2].b[0, 3] = 0;
            block[2].b[1, 0] = 0; block[2].b[1, 1] = 1; block[2].b[1, 2] = 0; block[2].b[1, 3] = 0;
            block[2].b[2, 0] = 0; block[2].b[2, 1] = 1; block[2].b[2, 2] = 0; block[2].b[2, 3] = 0;
            block[2].b[3, 0] = 0; block[2].b[3, 1] = 1; block[2].b[3, 2] = 0; block[2].b[3, 3] = 0;


            //T블럭1

            block[3].b = new int[4, 4];
            block[3].b[0, 0] = 0; block[3].b[0, 1] = 0; block[3].b[0, 2] = 0; block[3].b[0, 3] = 0;
            block[3].b[1, 0] = 1; block[3].b[1, 1] = 1; block[3].b[1, 2] = 1; block[3].b[1, 3] = 0;
            block[3].b[2, 0] = 0; block[3].b[2, 1] = 1; block[3].b[2, 2] = 0; block[3].b[2, 3] = 0;
            block[3].b[3, 0] = 0; block[3].b[3, 1] = 0; block[3].b[3, 2] = 0; block[3].b[3, 3] = 0;

            //T블럭2

            block[4].b = new int[4, 4];
            block[4].b[0, 0] = 0; block[4].b[0, 1] = 1; block[4].b[0, 2] = 0; block[4].b[0, 3] = 0;
            block[4].b[1, 0] = 0; block[4].b[1, 1] = 1; block[4].b[1, 2] = 1; block[4].b[1, 3] = 0;
            block[4].b[2, 0] = 0; block[4].b[2, 1] = 1; block[4].b[2, 2] = 0; block[4].b[2, 3] = 0;
            block[4].b[3, 0] = 0; block[4].b[3, 1] = 0; block[4].b[3, 2] = 0; block[4].b[3, 3] = 0;


            //T블럭3

            block[5].b = new int[4, 4];
            block[5].b[0, 0] = 0; block[5].b[0, 1] = 1; block[5].b[0, 2] = 0; block[5].b[0, 3] = 0;
            block[5].b[1, 0] = 1; block[5].b[1, 1] = 1; block[5].b[1, 2] = 1; block[5].b[1, 3] = 0;
            block[5].b[2, 0] = 0; block[5].b[2, 1] = 0; block[5].b[2, 2] = 0; block[5].b[2, 3] = 0;
            block[5].b[3, 0] = 0; block[5].b[3, 1] = 0; block[5].b[3, 2] = 0; block[5].b[3, 3] = 0;


            //T블럭4

            block[6].b = new int[4, 4];
            block[6].b[0, 0] = 0; block[6].b[0, 1] = 1; block[6].b[0, 2] = 0; block[6].b[0, 3] = 0;
            block[6].b[1, 0] = 1; block[6].b[1, 1] = 1; block[6].b[1, 2] = 0; block[6].b[1, 3] = 0;
            block[6].b[2, 0] = 0; block[6].b[2, 1] = 1; block[6].b[2, 2] = 0; block[6].b[2, 3] = 0;
            block[6].b[3, 0] = 0; block[6].b[3, 1] = 0; block[6].b[3, 2] = 0; block[6].b[3, 3] = 0;



            //Z블럭1

            block[7].b = new int[4, 4];
            block[7].b[0, 0] = 0; block[7].b[0, 1] = 0; block[7].b[0, 2] = 0; block[7].b[0, 3] = 0;
            block[7].b[1, 0] = 1; block[7].b[1, 1] = 1; block[7].b[1, 2] = 0; block[7].b[1, 3] = 0;
            block[7].b[2, 0] = 0; block[7].b[2, 1] = 1; block[7].b[2, 2] = 1; block[7].b[2, 3] = 0;
            block[7].b[3, 0] = 0; block[7].b[3, 1] = 0; block[7].b[3, 2] = 0; block[7].b[3, 3] = 0;



            //Z블럭2

            block[8].b = new int[4, 4];
            block[8].b[0, 0] = 0; block[8].b[0, 1] = 1; block[8].b[0, 2] = 0; block[8].b[0, 3] = 0;
            block[8].b[1, 0] = 1; block[8].b[1, 1] = 1; block[8].b[1, 2] = 0; block[8].b[1, 3] = 0;
            block[8].b[2, 0] = 1; block[8].b[2, 1] = 0; block[8].b[2, 2] = 0; block[8].b[2, 3] = 0;
            block[8].b[3, 0] = 0; block[8].b[3, 1] = 0; block[8].b[3, 2] = 0; block[8].b[3, 3] = 0;


            //S블럭1

            block[9].b = new int[4, 4];
            block[9].b[0, 0] = 0; block[9].b[0, 1] = 0; block[9].b[0, 2] = 0; block[9].b[0, 3] = 0;
            block[9].b[1, 0] = 0; block[9].b[1, 1] = 1; block[9].b[1, 2] = 1; block[9].b[1, 3] = 0;
            block[9].b[2, 0] = 1; block[9].b[2, 1] = 1; block[9].b[2, 2] = 0; block[9].b[2, 3] = 0;
            block[9].b[3, 0] = 0; block[9].b[3, 1] = 0; block[9].b[3, 2] = 0; block[9].b[3, 3] = 0;


            //S블럭2

            block[10].b = new int[4, 4];
            block[10].b[0, 0] = 1; block[10].b[0, 1] = 0; block[10].b[0, 2] = 0; block[10].b[0, 3] = 0;
            block[10].b[1, 0] = 1; block[10].b[1, 1] = 1; block[10].b[1, 2] = 0; block[10].b[1, 3] = 0;
            block[10].b[2, 0] = 0; block[10].b[2, 1] = 1; block[10].b[2, 2] = 0; block[10].b[2, 3] = 0;
            block[10].b[3, 0] = 0; block[10].b[3, 1] = 0; block[10].b[3, 2] = 0; block[10].b[3, 3] = 0;



            //J블럭1

            block[11].b = new int[4, 4];
            block[11].b[0, 0] = 0; block[11].b[0, 1] = 0; block[11].b[0, 2] = 0; block[11].b[0, 3] = 0;
            block[11].b[1, 0] = 1; block[11].b[1, 1] = 1; block[11].b[1, 2] = 1; block[11].b[1, 3] = 0;
            block[11].b[2, 0] = 0; block[11].b[2, 1] = 0; block[11].b[2, 2] = 1; block[11].b[2, 3] = 0;
            block[11].b[3, 0] = 0; block[11].b[3, 1] = 0; block[11].b[3, 2] = 0; block[11].b[3, 3] = 0;



            //J블럭2

            block[12].b = new int[4, 4];
            block[12].b[0, 0] = 0; block[12].b[0, 1] = 1; block[12].b[0, 2] = 1; block[12].b[0, 3] = 0;
            block[12].b[1, 0] = 0; block[12].b[1, 1] = 1; block[12].b[1, 2] = 0; block[12].b[1, 3] = 0;
            block[12].b[2, 0] = 0; block[12].b[2, 1] = 1; block[12].b[2, 2] = 0; block[12].b[2, 3] = 0;
            block[12].b[3, 0] = 0; block[12].b[3, 1] = 0; block[12].b[3, 2] = 0; block[12].b[3, 3] = 0;



            //J블럭3

            block[13].b = new int[4, 4];
            block[13].b[0, 0] = 1; block[13].b[0, 1] = 0; block[13].b[0, 2] = 0; block[13].b[0, 3] = 0;
            block[13].b[1, 0] = 1; block[13].b[1, 1] = 1; block[13].b[1, 2] = 1; block[13].b[1, 3] = 0;
            block[13].b[2, 0] = 0; block[13].b[2, 1] = 0; block[13].b[2, 2] = 0; block[13].b[2, 3] = 0;
            block[13].b[3, 0] = 0; block[13].b[3, 1] = 0; block[13].b[3, 2] = 0; block[13].b[3, 3] = 0;


            //J블럭4

            block[14].b = new int[4, 4];
            block[14].b[0, 0] = 0; block[14].b[0, 1] = 1; block[14].b[0, 2] = 0; block[14].b[0, 3] = 0;
            block[14].b[1, 0] = 0; block[14].b[1, 1] = 1; block[14].b[1, 2] = 0; block[14].b[1, 3] = 0;
            block[14].b[2, 0] = 1; block[14].b[2, 1] = 1; block[14].b[2, 2] = 0; block[14].b[2, 3] = 0;
            block[14].b[3, 0] = 0; block[14].b[3, 1] = 0; block[14].b[3, 2] = 0; block[14].b[3, 3] = 0;



            //L블럭1

            block[15].b = new int[4, 4];
            block[15].b[0, 0] = 0; block[15].b[0, 1] = 0; block[15].b[0, 2] = 0; block[15].b[0, 3] = 0;
            block[15].b[1, 0] = 1; block[15].b[1, 1] = 1; block[15].b[1, 2] = 1; block[15].b[1, 3] = 0;
            block[15].b[2, 0] = 1; block[15].b[2, 1] = 0; block[15].b[2, 2] = 0; block[15].b[2, 3] = 0;
            block[15].b[3, 0] = 0; block[15].b[3, 1] = 0; block[15].b[3, 2] = 0; block[15].b[3, 3] = 0;



            //L블럭2

            block[16].b = new int[4, 4];
            block[16].b[0, 0] = 0; block[16].b[0, 1] = 1; block[16].b[0, 2] = 0; block[16].b[0, 3] = 0;
            block[16].b[1, 0] = 0; block[16].b[1, 1] = 1; block[16].b[1, 2] = 0; block[16].b[1, 3] = 0;
            block[16].b[2, 0] = 0; block[16].b[2, 1] = 1; block[16].b[2, 2] = 1; block[16].b[2, 3] = 0;
            block[16].b[3, 0] = 0; block[16].b[3, 1] = 0; block[16].b[3, 2] = 0; block[16].b[3, 3] = 0;



            //L블럭3

            block[17].b = new int[4, 4];
            block[17].b[0, 0] = 0; block[17].b[0, 1] = 0; block[17].b[0, 2] = 1; block[17].b[0, 3] = 0;
            block[17].b[1, 0] = 1; block[17].b[1, 1] = 1; block[17].b[1, 2] = 1; block[17].b[1, 3] = 0;
            block[17].b[2, 0] = 0; block[17].b[2, 1] = 0; block[17].b[2, 2] = 0; block[17].b[2, 3] = 0;
            block[17].b[3, 0] = 0; block[17].b[3, 1] = 0; block[17].b[3, 2] = 0; block[17].b[3, 3] = 0;



            //L블럭4

            block[18].b = new int[4, 4];
            block[18].b[0, 0] = 1; block[18].b[0, 1] = 1; block[18].b[0, 2] = 0; block[18].b[0, 3] = 0;
            block[18].b[1, 0] = 0; block[18].b[1, 1] = 1; block[18].b[1, 2] = 0; block[18].b[1, 3] = 0;
            block[18].b[2, 0] = 0; block[18].b[2, 1] = 1; block[18].b[2, 2] = 0; block[18].b[2, 3] = 0;
            block[18].b[3, 0] = 0; block[18].b[3, 1] = 0; block[18].b[3, 2] = 0; block[18].b[3, 3] = 0;


        }

        #endregion

        //키 입력 버퍼 지우기
        static void ClearBuffer()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(false);
            }
        }

        public static void Render()
        {

            //커서 지우기
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);

            Draw();
        }

        static public void Draw()
        {
            FrameInput(true);

            BlockDrawing();

            FrameInput(false);

            FrameDrawing();


        }

        //블럭 그리기, 블럭 충돌 체크

        static void BlockDrawing()
        {
            if (!gameover)
            {
                return;
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {


                    //배경 블럭일때
                    if (pixelNum[i + blockPositionY, j + blockPositionX] == 2)
                    {

                        //바닥에 닿을때 충돌 
                        if (block[currentBlockNum].b[i, j] == 1)
                        {
                            BlockCollider();
                        }


                    }
                    else if (pixelNum[i + blockPositionY, j + blockPositionX] == 3)
                    {
                        //블럭에 닿을때 충돌 
                        if (block[currentBlockNum].b[i, j] == 1)
                        {
                            BlockCollider();
                        }
                    }
                    else
                    {

                        pixelNum[i + blockPositionY, j + blockPositionX] = block[currentBlockNum].b[i, j];




                    }







                }
            }



        }


        //flag 최초 실행 여부
        //틀 입력
        static void FrameInput(bool flag)
        {


            for (int i = 0; i < row - 2; i++)
            {
                for (int j = 0; j < column - 2; j++)
                {
                    if (flag)
                    {
                        pixel[i, j] = '■';
                    }

                    //게임오버일시
                    if (pixelNum[i, j] == 4)
                    {
                        continue;
                    }


                    //윗줄
                    //if (i == 0 && j >= 0 && j <= column - 2)
                    //  {
                    // pixelNum[i, j] = 2;
                    // }
                    //밑 줄
                    if (i == row - 3 && j >= 0 && j <= column - 2)
                    {
                        pixelNum[i, j] = 2;
                    }
                    //왼쪽 줄
                    else if (j == 0)
                    {
                        pixelNum[i, j] = 2;
                    }

                    //오른쪽 줄
                    else if (j == column - 3)
                    {
                        pixelNum[i, j] = 2;
                    }
                    else
                    {
                        if (flag)
                        {
                            if (pixelNum[i, j] != 3)
                                pixelNum[i, j] = 0;
                        }
                    }


                }
            }
        }

        //틀 그리기
        static void FrameDrawing()
        {
            for (int i = 0; i < row - 2; i++)
            {
                for (int j = 0; j < column - 2; j++)
                {

                    if (pixelNum[i, j] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;

                    }
                    else if (pixelNum[i, j] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else if (pixelNum[i, j] == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                    }
                    else if (pixelNum[i, j] == 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }


                    Console.Write(pixel[i, j]);
                    Console.ResetColor();


                }

                Console.WriteLine();
            }

            //점수 표시
            Console.Write("Score : " + score);
            Console.WriteLine();
            Console.Write("회전 A    낙하 SpaceBar ");
        }


        //회전 체크
        static bool CheckRotate(int bNum)
        {
            if (currentBlockNum + 1 >= bNum)
            {
                return true;
            }

            return false;

        }

        //회전 충돌 체크
        static bool CheckRotateColider()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (currentBlockNum < 18)
                    {
                        if (pixelNum[i + blockPositionY, j + blockPositionX] == 2 && block[currentBlockNum + 1].b[i, j] == 1)
                        {
                            return false;


                        }
                        else if (pixelNum[i + blockPositionY, j + blockPositionX] == 3 && block[currentBlockNum + 1].b[i, j] == 1)
                        {
                            return false;

                        }
                    }
                    else if (currentBlockNum == 18)
                    {
                        if (pixelNum[i + blockPositionY, j + blockPositionX] == 2 && block[(int)BlockNum.L].b[i, j] == 1)
                        {
                            return false;


                        }
                        else if (pixelNum[i + blockPositionY, j + blockPositionX] == 3 && block[(int)BlockNum.L].b[i, j] == 1)
                        {
                            return false;

                        }
                    }

                }
            }

            return true;

        }

        //블록 회전
        static void BlockRotate()
        {

            switch ((BlockNum)blockNumArr[randomBlockNum])
            {
                case BlockNum.O:

                    return;

                case BlockNum.I:

                    if (CheckRotate((int)BlockNum.T))
                    {

                        if (!CheckRotateColider())
                            return;
                        currentBlockNum = (int)BlockNum.I;

                    }
                    else
                    {
                        if (!CheckRotateColider())
                            return;
                        break;
                    }

                    return;

                case BlockNum.T:
                    if (CheckRotate((int)BlockNum.Z))
                    {
                        if (!CheckRotateColider())
                            return;
                        currentBlockNum = (int)BlockNum.T;
                    }
                    else
                    {
                        if (!CheckRotateColider())
                            return;
                        break;
                    }

                    return;

                case BlockNum.Z:
                    if (CheckRotate((int)BlockNum.S))
                    {
                        if (!CheckRotateColider())
                            return;
                        currentBlockNum = (int)BlockNum.Z;
                    }
                    else
                    {
                        if (!CheckRotateColider())
                            return;
                        break;
                    }

                    return;

                case BlockNum.S:
                    if (CheckRotate((int)BlockNum.J))
                    {
                        if (!CheckRotateColider())
                            return;
                        currentBlockNum = (int)BlockNum.S;
                    }
                    else
                    {
                        if (!CheckRotateColider())
                            return;
                        break;
                    }

                    return;

                case BlockNum.J:
                    if (CheckRotate((int)BlockNum.L))
                    {
                        if (!CheckRotateColider())
                            return;
                        currentBlockNum = (int)BlockNum.J;
                    }
                    else
                    {
                        if (!CheckRotateColider())
                            return;
                        break;
                    }

                    return;

                case BlockNum.L:
                    if (CheckRotate((int)BlockNum.end))
                    {
                        if (!CheckRotateColider())
                            return;
                        currentBlockNum = (int)BlockNum.L;
                    }
                    else
                    {
                        if (!CheckRotateColider())
                            return;
                        break;
                    }

                    return;

                case BlockNum.end:
                    NewBlock();

                    return;

            }

            currentBlockNum++;
        }


        //키 입력
        static void InputKey()
        {
            //매끄러운 키 입력 구현
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo consoleKey = Console.ReadKey(true);

                switch (consoleKey.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (LeftRightCheck(0))
                            blockPositionX--;
                        break;
                    case ConsoleKey.RightArrow:
                        if (LeftRightCheck(1))
                            blockPositionX++;

                        break;

                    case ConsoleKey.A:
                        BlockRotate();

                        break;
                    case ConsoleKey.Spacebar:
                        dropSpeed = 10;

                        break;
                }
            }
        }


        //블럭 드랍
        static void DropBlock()
        {
            int currentTick = System.Environment.TickCount;

            //떨어지는 속도 제한
            if (currentTick - dropTick < dropSpeed)
            {
                return;
            }

            //떨어지는 블럭

            blockPositionY++;


            dropTick = currentTick;


        }


        //블럭 충돌시
        static void BlockCollider()
        {

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {

                    if (block[currentBlockNum].b[i, j] == 1)
                    {
                        pixelNum[i + blockPositionY - 1, j + blockPositionX] = 3;

                    }

                }
            }
            //라인 완성 체크
            LineCheck();


            //새 블럭 생성
            NewBlock();

            //블럭 좌표, 낙하 속도 초기화 
            blockPositionX = 5;
            blockPositionY = 0;
            dropSpeed = 1000;

        }

        //좌우 충돌 체크

        static bool LeftRightCheck(int leftRight)
        {

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (leftRight == 0)
                    {

                        if (j != 0)
                        {
                            if (currentBlockNum == 0 || currentBlockNum == 2 || currentBlockNum == 4 || currentBlockNum == 12 || currentBlockNum == 16)
                            {
                                if (pixelNum[i + blockPositionY, j + blockPositionX - 1] == 2 && block[currentBlockNum].b[i, j] == 1)
                                {

                                    return false;

                                }
                                else if (pixelNum[i + blockPositionY, j + blockPositionX - 1] == 3 && block[currentBlockNum].b[i, j] == 1)
                                {

                                    return false;

                                }
                            }


                        }
                        else if (j == 0)
                        {
                            if (currentBlockNum == 1 || currentBlockNum == 3 || currentBlockNum == 5
                                || currentBlockNum == 6 || currentBlockNum == 7
                                || currentBlockNum == 8 || currentBlockNum == 9
                                || currentBlockNum == 10 || currentBlockNum == 11
                                || currentBlockNum == 13 || currentBlockNum == 14
                                || currentBlockNum == 15
                                || currentBlockNum == 17 || currentBlockNum == 18
                                )
                            {
                                if (pixelNum[i + blockPositionY, j + blockPositionX - 1] == 2 && block[currentBlockNum].b[i, j] == 1)
                                {

                                    return false;
                                }
                                else if (pixelNum[i + blockPositionY, j + blockPositionX - 1] == 3 && block[currentBlockNum].b[i, j] == 1)
                                {

                                    return false;

                                }
                            }
                        }
                    }
                    else if (leftRight == 1)
                    {
                        if (pixelNum[i + blockPositionY, j + blockPositionX + 1] == 2 && block[currentBlockNum].b[i, j] == 1)
                        {
                            return false;

                        }
                        else if (pixelNum[i + blockPositionY, j + blockPositionX + 1] == 3 && block[currentBlockNum].b[i, j] == 1)
                        {
                            return false;

                        }
                    }
                }
            }

            return true;
        }


        //줄 완성 체크
        static void LineCheck()
        {
            int lineCount;

            for (int i = 0; i < row - 2; i++)
            {
                lineCount = 0;
                for (int j = 0; j < column - 2; j++)
                {

                    if (pixelNum[i, j] == 3)
                    {
                        lineCount++;
                    }

                    if (lineCount == column - 4)
                    {

                        LineClear(i);
                        lineCount = 0;
                        //줄 지우면 점수 증가
                        score += 50;
                        LineCheck();
                    }

                }



            }



        }

        //줄 지우기
        static void LineClear(int line)
        {

            for (int i = line; i > 1; i--)
            {
                for (int j = 1; j < column - 3; j++)
                {
                    if (pixelNum[i - 1, j] != 1 && pixelNum[i - 1, j] != 2)
                    {
                        pixelNum[i, j] = pixelNum[i - 1, j];
                    }
                    else
                    {
                        pixelNum[i, j] = 0;
                    }

                }
            }


        }

        static void Update()
        {
            DropBlock();
            GameOverCheck();

        }


        //새 블럭 랜덤 생성
        static void NewBlock()
        {
            Random rand = new Random();
            randomBlockNum = rand.Next(0, blockNumArr.Length - 1);

            currentBlockNum = blockNumArr[randomBlockNum];
        }

        //게임오버 체크
        static void GameOverCheck()
        {
            for (int i = 0; i < column; i++)
            {
                if (pixelNum[0, i] == 3)
                {
                    GameOver();
                }
            }
        }

        //게임오버
        static void GameOver()
        {



            for (int i = 0; i < row - 2; i++)
            {
                for (int j = 0; j < column - 2; j++)
                {
                    if ((pixelNum[i, j] == 3))
                    {
                        pixelNum[i, j] = 4;

                    }
                }


            }
            gameover = false;

        }

        //시작 씬
        static void GameStartScene()
        {

            Console.ForegroundColor = ConsoleColor.DarkYellow;

            string str = @"
 ■■■■■  ■■■■  ■■■■■  ■■■    ■■■    ■■■  
     ■      ■            ■      ■    ■    ■    ■        
     ■      ■■■        ■      ■■■      ■      ■■    
     ■      ■            ■      ■    ■    ■          ■  
     ■      ■■■■      ■      ■    ■  ■■■  ■■■   ";
            Console.WriteLine(str);
            Console.WriteLine("\n\n");
            Console.ResetColor();

            Console.WriteLine("                    press any key to start");


            Console.CursorVisible = false;

            Console.ReadKey();


            Console.Clear();

        }
        //종료 씬
        static void GameOverScene()
        {
            ClearBuffer();
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkRed;

            string str = @"
  ■■■    ■■    ■      ■  ■■■■        ■■    ■      ■  ■■■■  ■■■    
■        ■    ■  ■■  ■■  ■            ■    ■  ■      ■  ■        ■    ■  
■  ■■  ■■■■  ■  ■  ■  ■■■        ■    ■  ■      ■  ■■■    ■■■    
■    ■  ■    ■  ■      ■  ■            ■    ■    ■  ■    ■        ■    ■  
  ■■■  ■    ■  ■      ■  ■■■■        ■■        ■      ■■■■  ■    ■ ";
            Console.WriteLine(str);
            Console.ResetColor();

            Console.WriteLine($"\n                                       점수 {score}");
            
            Console.ReadKey(true);
        }

        static void Start()
        {
            GameStartScene();
            SetBlock();
            NewBlock();
        }

        static void Main(string[] args)
        {
            Start();

            //커서 끄기
            Console.CursorVisible = false;

            while (gameover)
            {
                Update();
                Render();
                InputKey();



                //현재 틱
                int currentTick = System.Environment.TickCount;


                //1000만큼의 시간이 지나지 않았으면 컨티뉴
                if (currentTick - renderTick < 100)
                    continue;



                //현재 틱을 저장
                renderTick = currentTick;


                ClearBuffer();


            }

           
            //잠시 기다렸다가
            Thread.Sleep(2000);
            //게임오버 씬 출력
            GameOverScene();


        }
    }
}

