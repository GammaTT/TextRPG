using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using EnumCollection;
using TextRPG;

namespace TextRPG
{
    internal class TextRPG
    {
        static void Main()
        {
            GameManager gameManager = new GameManager();

            gameManager.GameStart();
        }
    }

    class GameManager
    {
        Shop shop = new Shop();
        Shelter shelter = new Shelter();
        Dungeon dungeon = new Dungeon();

        //IOManager는 문장을 전달받아 출력을 위주로 하는 객체
        IOManager ioManager = new IOManager();
        GameCharacter playerCharacter = new GameCharacter();

        public void GameStart()
        {
            ioManager.OutputMessage(ioManager.GameStart);

            while (true)
            {
                ioManager.OutputMessage(ioManager.PlzInputName);
                ioManager.InputStringFunc();

                if (ioManager.OutputMessageWithNumber(ioManager.SaveOrCancel) == 1)
                {
                    break;
                }
            }

            playerCharacter.name = ioManager.InputString; // 이름 저장

            Console.Clear();
            ioManager.OutputMessage(ioManager.PlzInputJob);
            ioManager.OutputMessageWithNumber(ioManager.Jobs);
            playerCharacter.job = (Job)ioManager.inputNumber;
            playerCharacter.SetJob(); // 직업에 따른 보너스 스탯
            Game();
        }

        public void Game()
        {
            int ActivityResult = 0;

            while (ActivityResult != 6)
            {
                ActivityResult = Activity();
            }
            //Activity();
        }

        public int Activity()
        {
            int select = 0;

            //1~6번 고르면
            switch (ioManager.OutputMessageWithNumber(ioManager.Activity, true))
            {
                //캐릭터 상태(스탯)보기
                case 1:
                    ioManager.OutputMessage(playerCharacter.GetCharacterInfo(), true);
                    if (ioManager.OutputMessageWithNumber(ioManager.InputOneForExit, false) == 1)
                    {
                        return 0;
                    }
                    break;

                //인벤토리 장착관리
                case 2:
                    ioManager.OutputMessage(playerCharacter.GetInventoryInfoIntro(), true);
                    ioManager.OutputMessageWithNumberNoSelect(playerCharacter.GetInventoryInfo(), false);
                    if (ioManager.OutputMessageWithNumber(ioManager.EquipOrExit, false) == 2)
                    {
                        return 0;
                    }

                    while (true)
                    {
                        ioManager.OutputMessage(playerCharacter.GetInventoryInfoIntroForEquip(), true);
                        select = ioManager.OutputMessageWithNumberZeroExit(playerCharacter.GetInventoryInfo(), false);

                        if (select == 0)
                        {
                            break;
                        }
                        playerCharacter.EquipItem(select);
                    }

                    break;

                //상점
                case 3:
                    // select 3은 나가기
                    while (select != 3)
                    {
                        ioManager.OutputMessage(shop.GetShopItemsIntro(playerCharacter.gold), true);
                        ioManager.OutputMessage(shop.GetShopItemList(), false);
                        select = ioManager.OutputMessageWithNumber(ioManager.BuyOrExit);
                        //아이템 구매
                        if (select == 1)
                        {
                            ioManager.OutputMessage(shop.GetShopItemsIntroForBuy(playerCharacter.gold), true);
                            int buySelect = ioManager.OutputMessageWithNumber(shop.GetShopItemList(), false);
                            if (shop.BuyItem(playerCharacter, buySelect) == true)
                            {
                                ioManager.BuyComplete();
                            }
                            else
                            {
                                ioManager.BuyFail();
                            }
                        }
                        //아이템 판매
                        else if (select == 2)
                        {
                            if (playerCharacter.itemList.Count == 0)
                            {
                                ioManager.SellFail();

                                break;
                            }
                            ioManager.OutputMessage(shop.GetShopItemsIntroForSell(playerCharacter.gold), true);
                            int SellSelect = ioManager.OutputMessageWithNumber(playerCharacter.GetInventoryInfoForSell(), false);
                            shop.SellItem(playerCharacter, SellSelect);
                        }
                    }

                    break;

                //던전 입장
                case 4:

                    while (select != 4)
                    {
                        select = ioManager.OutputMessageWithNumber(ioManager.DungeonSelect, true);

                        if (select == 4)
                        {
                            break;
                        }

                        if (dungeon.InDungeon(playerCharacter, select) == true)
                        {
                            //플레이어 사망
                            if (playerCharacter.currentHP <= dungeon.damage)
                            {
                                ioManager.OutputMessage(playerCharacter.PlayerDie(), true);

                                return 6;
                            }

                            ioManager.OutputMessage(dungeon.DungeonClear(playerCharacter), true);

                            ioManager.OutputMessageWithNumber(ioManager.InputOneForExit, false);

                            //던전 클리어시
                            if (playerCharacter.DungeonClear() == true)
                            {
                                ioManager.OutputMessage(playerCharacter.LevelUp(), true);

                                ioManager.OutputMessageWithNumber(ioManager.InputOneForExit, false);
                            }
                        }
                        else
                        {
                            ioManager.OutputMessage(dungeon.DungeonFail(playerCharacter), true);

                            ioManager.OutputMessageWithNumber(ioManager.InputOneForExit, false);

                        }
                    }

                    break;

                //휴식하기
                case 5:
                    ioManager.OutputMessage(shelter.GetShelterIntro(playerCharacter.gold), true);
                    select = ioManager.OutputMessageWithNumber(ioManager.RestOrExit);

                    if (select == 1)
                    {
                        shelter.Rest(playerCharacter);
                    }

                    break;

                case 6:
                    return 6;
            }
            return 0;
        }

    }
}
