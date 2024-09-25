using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG;

namespace TextRPG
{
    class Shelter
    {
        int restPrice = 500;
        public string[] GetShelterIntro(int playerGold)
        {
            string[] restIntro =
            { 
                "휴식하기",
                $"{restPrice} G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : {playerGold} G"
            };

            return restIntro;
        }

        public void Rest(GameCharacter player)
        {
            if (player.gold < restPrice)
            {
                Console.WriteLine("\nGold가 부족합니다");
                Console.ReadLine();
                return;
            }

            player.currentHP = player.maxHP;
            Console.WriteLine("\n휴식을 완료했습니다.");
            Console.ReadLine();
            return;
        }
    }
}
