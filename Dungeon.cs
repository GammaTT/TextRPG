using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TextRPG;

namespace TextRPG
{
    class Difficulty
    {
        public int difficultyLevel;
        public int armorRecommended;
        public int clearRewardGold;

        public Difficulty (int difficultyLevel, int armorRecommended, int clearRewardGold)
        {
            this.difficultyLevel = difficultyLevel;
            this.armorRecommended = armorRecommended;
            this.clearRewardGold = clearRewardGold;
        }
    }
    class Dungeon
    {
        public int damage = 0;
        public int bonusGold = 0;
        Random rand = new Random();
        public Difficulty currentDifficulty;
        public Difficulty[] dungone = new Difficulty[3];
        
        public Dungeon()
        {
            dungone[0] = new Difficulty(1, 5, 1000);   // Easy
            dungone[1] = new Difficulty(2, 11, 1700); // Normal
            dungone[2] = new Difficulty(3, 17, 2500);  // Hard
        }

        public bool InDungeon(GameCharacter player, int select)
        {
            currentDifficulty = dungone[select - 1];

            if (player.armor < currentDifficulty.armorRecommended)
            {
                int temp = rand.Next(1, 11);

                if (temp < 5)
                {
                    return false;
                }
            }

            int defaultDamage = rand.Next(20, 36);
            int armorCalc = player.armor - currentDifficulty.armorRecommended;
            defaultDamage -= armorCalc;
            damage = Math.Max(defaultDamage, 0);

            bonusGold = (int)(currentDifficulty.clearRewardGold * player.attackDamage * 2 * 0.01f);

            return true;
        }

        public string[] DungeonFail(GameCharacter player)
        {
            List<String> failText = new List<string>();

            failText.Add("던전 실패");

            switch (currentDifficulty.difficultyLevel)
            {
                case 1:
                    failText.Add("쉬운 던전을 클리어 실패 하였습니다.");
                    break;

                case 2:
                    failText.Add("일반 던전을 클리어 실패 하였습니다.");
                    break;

                case 3:
                    failText.Add("어려운 던전을 클리어 실패 하였습니다.");
                    break;
            }

            failText.Add("[탐험 결과]");
            failText.Add($"체력 {player.currentHP} -> {(int)player.currentHP / 2}");

            player.currentHP = (int)(player.currentHP / 2);

            return failText.ToArray();
        }

        public string[] DungeonClear(GameCharacter player)
        {
            List<String> clearText = new List<string>();

            clearText.Add("던전 클리어");
            clearText.Add("축하합니다!!");

            switch(currentDifficulty.difficultyLevel)
            {
                case 1:
                    clearText.Add("쉬운 던전을 클리어 하였습니다.");
                    break;

                case 2:
                    clearText.Add("일반 던전을 클리어 하였습니다.");
                    break;

                case 3:
                    clearText.Add("어려운 던전을 클리어 하였습니다.");
                    break;
            }

            /*int resultHP = player.currentHP - damage;
            int resultGold = player.gold + currentDifficulty.clearRewardGold + bonusGold*/;

            clearText.Add("[탐험 결과]");
            clearText.Add($"체력 {player.currentHP} -> {player.currentHP - damage}");
            clearText.Add($"Gold {player.gold} G -> {player.gold + currentDifficulty.clearRewardGold + bonusGold} G");

            player.currentHP -= damage;
            player.gold += currentDifficulty.clearRewardGold;
            player.gold += bonusGold;

            return clearText.ToArray();
        }
    }
}
