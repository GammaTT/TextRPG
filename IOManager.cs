using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG;

namespace TextRPG
{
    class IOManager
    {
        public int inputNumber;
        string inputString = "";
        public string InputString
        {
            get { return inputString; }
            set { inputString = value; }
        }

        public readonly string[] GameStart = {"스파르타 마을에 오신 여러분 환영합니다.",
            "이곳에서 던전으로 들어가기전 활동을 할 수 있습니다."};
        public string[] PlzInputName = { "원하시는 이름을 입력해주세요.\n" };
        public string[] PlzInputJob = { "원하시는  직업을 선택해주세요." };

        public string[] InputOneForExit = { "나가기" };
        public string[] InputZeroForExit = { "\n0. 나가기" };
        public string[] Jobs = { "전사", "도적" };
        public string[] SaveOrCancel = { "저장", "취소" };
        public string[] Activity = { "상태 보기", "인벤토리", "상점" ,"던전입장", "휴식하기", "종료하기"};
        public string[] BuyOrExit = { "아이템 구매", "아이템 판매", "나가기" };
        public string[] EquipOrExit = { "아이템 장착", "나가기" };
        public string[] RestOrExit = { "휴식하기", "나가기" };
        public string[] DungeonSelect = {
            "쉬운 던전\t | 방어력 5 이상 권장",
            "일반 던전\t | 방어력 11 이상 권장",
            "어려운 던전\t | 방어력 17 이상 권장",
            "나가기"
        };

        //메세지 출력
        public void OutputMessage(string[] message, bool Clear = false)
        {
            if (Clear)
            {
                Console.Clear();
            }
            else
            {
                //Console.WriteLine();
            }

            foreach (var item in message)
            {
                Console.WriteLine(item);
            }
        }

        //메세지 넘버링 달고 출력 and 선택
        public int OutputMessageWithNumber(string[] message, bool Clear = false)
        {
            int selectNumber = -1;

            if (Clear)
            {
                Console.Clear();
            }
            else
            {
                Console.WriteLine();
            }

            while (true)
            {
                for (int i = 0; i < message.Length; i++)
                {
                    string printmessage = string.Format("{0}. {1}", i + 1, message[i]);
                    Console.WriteLine(printmessage);
                }

                //Console.WriteLine(InputZeroForExit[0]);

                Console.WriteLine("\n원하는 행동을 입력해주세요 : \n");

                try
                {
                    selectNumber = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    //Console.Write(ex.ToString());
                    Console.WriteLine("잘못된 입력입니다\n");
                }

                if (!(0 < selectNumber && selectNumber <= message.Length))
                {
                    selectNumber = -1;
                    Console.WriteLine("\n잘못된 숫자 입력입니다\n");
                }
                else
                {
                    break;
                }
            }

            inputNumber = selectNumber;
            return selectNumber;
        }

        public void OutputMessageWithNumberNoSelect(string[] message, bool Clear = false)
        {
            if (Clear)
            {
                Console.Clear();
            }
            else
            {
                Console.WriteLine();
            }

            for (int i = 0; i < message.Length; i++)
            {
                string printmessage = string.Format("{0}. {1}", i + 1, message[i]);
                Console.WriteLine(printmessage);
            }
        }

        public int OutputMessageWithNumberZeroExit(string[] message, bool Clear = false)
        {
            int selectNumber = -1;

            if (Clear)
            {
                Console.Clear();
            }
            else
            {
                Console.WriteLine();
            }

            while (true)
            {
                for (int i = 0; i < message.Length; i++)
                {
                    string printmessage = string.Format("{0}. {1}", i + 1, message[i]);
                    Console.WriteLine(printmessage);
                }

                Console.WriteLine(InputZeroForExit[0]);

                Console.WriteLine("\n원하는 행동을 입력해주세요 : \n");

                try
                {
                    selectNumber = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    //Console.Write(ex.ToString());
                    Console.WriteLine("잘못된 입력입니다\n");
                }

                if (selectNumber == 0)
                {
                    return selectNumber;
                }

                if (!(0 < selectNumber && selectNumber <= message.Length))
                {
                    selectNumber = -1;
                    Console.WriteLine("\n잘못된 숫자 입력입니다\n");
                }
                else
                {
                    break;
                }
            }

            inputNumber = selectNumber;
            return selectNumber;
        }

        public void BuyComplete()
        {
            Console.WriteLine("구매완료");
            Console.ReadLine();
        }
        public void BuyFail()
        {
            Console.WriteLine("구매실패");
            Console.ReadLine();
        }
    }
}
