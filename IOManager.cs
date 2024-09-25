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


        public string[] InputZeroForExit = { "나가기" };
        public string[] Jobs = { "전사", "도적" };
        public string[] SaveOrCancel = { "저장", "취소" };
        public string[] Activity = { "상태 보기", "인벤토리", "상점" };
        public string[] BuyOrExit = { "아이템 구매", "나가기" };

        //메세지 출력
        public void OutputMessage(string[] message, bool Clear = false)
        {
            if (Clear)
            {
                Console.Clear();
            }
            else
            {
                Console.WriteLine();
            }

            foreach (var item in message)
            {
                Console.WriteLine(item);
            }
        }

        //메세지 넘버링 달고 출력
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
    }
}
