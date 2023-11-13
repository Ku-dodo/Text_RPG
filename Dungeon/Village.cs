
// UI를 그리는 class
//마을 기능 클래스
public class Village
{
    Player Player;
    DrawUnicodeUI DrawUI = new DrawUnicodeUI();
    Dungeon Dungeon;

    public Village(Player player)
    {
        Player = player;
        Dungeon = new Dungeon(Player);
    }

    //마을 기능을 루프 시키는 함수
    public void VillageLoop()
    {
        while (true)
        {

            Console.SetCursorPosition(5, 22);
            Console.Write("마을에서는 아래의 행동을 할 수 있습니다. 어떤 행동을 하시겠습니까? [ ]");
            Console.SetCursorPosition(5, 24);
            Console.Write("1. 상태 보기");
            Console.SetCursorPosition(5, 25);
            Console.Write("2. 인벤토리");
            Console.SetCursorPosition(5, 26);
            Console.Write("3. 휴식하기");
            Console.SetCursorPosition(5, 27);
            Console.Write("4. 던전 입장");
            Console.SetCursorPosition(73, 22);
            ConsoleKeyInfo inputKey = Console.ReadKey();
            Thread.Sleep(500);
            DrawUI.ClearChatUI();
            if (inputKey.Key == ConsoleKey.D1)
            {
                ViewPlayerStatus();
            }
            else if (inputKey.Key == ConsoleKey.D2)
            {
                ViewInventory();
            }
            else if (inputKey.Key == ConsoleKey.D3)
            {
                Rest();
            }
            else if (inputKey.Key == ConsoleKey.D4)
            {
                Player.EquipmentStat();
                DungeonDifficulty();
            }
            else
            {
                Console.SetCursorPosition(5, 22);
                Console.Write("잘못된 입력 입니다.");
                Thread.Sleep(500);
                DrawUI.ClearChatUI();
            }
        }
    }
    // 플레이어 상태 보기
    void ViewPlayerStatus()
    {
    exceptionKey:
        Player.EquipmentStat();
        Console.SetCursorPosition(5, 22);
        Console.Write("이름 \t: {0} ({1})", Player.Name, Player.Job);
        Console.SetCursorPosition(5, 23);
        Console.Write("체력 \t: {0}", Player.HP);
        Console.SetCursorPosition(5, 24);
        Console.Write("공격력 \t: {0} (+{1})", Player.ResultAtk, Player.equipAtk);
        Console.SetCursorPosition(5, 25);
        Console.Write("방어력 \t: {0} (+{1})", Player.ResultDef, Player.equipDef);
        Console.SetCursorPosition(5, 26);
        Console.Write("소지 골드 \t: {0} Gold", Player.Gold);
        Console.SetCursorPosition(5, 27);
        Console.Write("뒤로 가기(R)\t   [ ]");
        Console.SetCursorPosition(28, 27);
        ConsoleKeyInfo inputKey = Console.ReadKey();
        Thread.Sleep(500);
        DrawUI.ClearChatUI();

        if (inputKey.Key == ConsoleKey.R)
        {
            VillageLoop();
        }
        else
        {
            Console.SetCursorPosition(5, 22);
            Console.Write("잘못된 입력 입니다.");
            Thread.Sleep(500);
            DrawUI.ClearChatUI();
            goto exceptionKey;
        }
    }

    //플레이어 인벤토리 메서드
    void ViewInventory()
    {
    exceptionKey:
        Console.SetCursorPosition(5, 22);
        Console.Write("보유 중인 아이템을 관리할 수 있습니다. 장착 관리 [Q] 나가기 [R] [ ]");
        Console.SetCursorPosition(5, 23);

        for (int i = 0; i < Player.itemlist.Count(); i++)
        {
            string equipSym = "";

            if (Player.itemlist[i].equipState == true)
            {
                equipSym = "[E]";
            }
            else if (Player.itemlist[i].equipState == false)
            {
                equipSym = "";
            }
            Console.SetCursorPosition(5, 24 + i);
            Console.Write("{0} {1}\t 공격력 : {2}\t 방어력 : {3}", equipSym, Player.itemlist[i].Name, Player.itemlist[i].Atk, Player.itemlist[i].Def);
        }

        // 입력값 분기 처리
        Console.SetCursorPosition(70, 22);
        ConsoleKeyInfo inputKey = Console.ReadKey();
        Thread.Sleep(500);
        DrawUI.ClearChatUI();
        if (inputKey.Key == ConsoleKey.Q)
        {
            ViewEquip();
        }
        else if (inputKey.Key == ConsoleKey.R)
        {
            //해당 함수는 종료됨
        }
        else
        {
            Console.SetCursorPosition(5, 22);
            Console.Write("잘못된 입력 입니다.");
            Thread.Sleep(500);
            DrawUI.ClearChatUI();
            goto exceptionKey;
        }

    }


    //플레이어 장비템 관리 메서드
    void ViewEquip()
    {
    exceptionKey:
        Player.EquipmentStat();
        Console.SetCursorPosition(5, 22);
        Console.Write("장착 여부를 전환할 아이템의 숫자를 입력해주세요. 뒤로가기 (R) [ ]");
        Console.SetCursorPosition(5, 23);
        for (int i = 0; i < Player.itemlist.Count(); i++)
        {
            string equipSym = "";
            if (Player.itemlist[i].equipState == true)
            {
                equipSym = "[E]";
            }
            else if (Player.itemlist[i].equipState == false)
            {
                equipSym = "";
            }
            Console.SetCursorPosition(5, 24 + i);
            Console.Write("{0}. {1} {2}\t 공격력 : {3}\t 방어력 : {4}", i + 1, equipSym, Player.itemlist[i].Name, Player.itemlist[i].Atk, Player.itemlist[i].Def);
        }

        // 입력값 분기 처리
        Console.SetCursorPosition(68, 22);
        ConsoleKeyInfo inputKey = Console.ReadKey();
        DrawUI.ClearChatUI();
        if (inputKey.Key == ConsoleKey.D1)
        {
            if (Player.itemlist[0].equipState == true)
            {
                Item item = new Item(Player.itemlist[0].Name, Player.itemlist[0].Atk, Player.itemlist[0].Def, false);
                Player.itemlist.Remove(Player.itemlist[0]);
                Player.itemlist.Insert(0, item);
            }
            else if (Player.itemlist[0].equipState == false)
            {
                Item item = new Item(Player.itemlist[0].Name, Player.itemlist[0].Atk, Player.itemlist[0].Def, true);
                Player.itemlist.Remove(Player.itemlist[0]);
                Player.itemlist.Insert(0, item);
            }
            goto exceptionKey;
        }
        else if (inputKey.Key == ConsoleKey.D2)
        {
            if (Player.itemlist[1].equipState == true)
            {
                Item item = new Item(Player.itemlist[1].Name, Player.itemlist[1].Atk, Player.itemlist[1].Def, false);
                Player.itemlist.Remove(Player.itemlist[1]);
                Player.itemlist.Add(item);
            }
            else if (Player.itemlist[1].equipState == false)
            {
                Item item = new Item(Player.itemlist[1].Name, Player.itemlist[1].Atk, Player.itemlist[1].Def, true);
                Player.itemlist.Remove(Player.itemlist[1]);
                Player.itemlist.Add(item);
            }
            goto exceptionKey;
        }
        else if (inputKey.Key == ConsoleKey.R)
        {
            ViewInventory();
        }
        else
        {
            Console.SetCursorPosition(5, 22);
            Console.Write("잘못된 입력 입니다.");
            Thread.Sleep(500);
            DrawUI.ClearChatUI();
            goto exceptionKey;
        }

    }

    //휴식 메서드
    void Rest()
    {
        if (Player.Gold >= 500)
        {
            Console.SetCursorPosition(5, 22);
            Console.Write("체력이 회복되었습니다.");
            Console.SetCursorPosition(5, 23);
            Console.Write("체력 {0} -> {1}", Player.HP, 100);
            Player.HP = 100;
            Player.Gold -= 500;

            Console.SetCursorPosition(5, 27);
            Console.Write("아무 키나 눌러 돌아가기 [ ]");
            Console.SetCursorPosition(30, 27);
            ConsoleKeyInfo inputKey = Console.ReadKey();
            Thread.Sleep(500);
            DrawUI.ClearChatUI();
        }
        else
        {
            Console.SetCursorPosition(5, 22);
            Console.Write("골드가 부족합니다.");

            Console.SetCursorPosition(5, 27);
            Console.Write("아무 키나 눌러 돌아가기 [ ]");
            Console.SetCursorPosition(30, 27);
            ConsoleKeyInfo inputKey = Console.ReadKey();
            Thread.Sleep(500);
            DrawUI.ClearChatUI();
        }
    }

    //던전 난이도 선택 메서드
    void DungeonDifficulty()
    {
    exceptionKey:
        Console.SetCursorPosition(5, 22);
        Console.Write("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다. 뒤로가기 (R) [ ]");
        Console.SetCursorPosition(5, 23);
        Console.Write("1. 쉬운 던전\t 방어력 5 이상 권장");
        Console.SetCursorPosition(5, 24);
        Console.Write("2. 일반 던전\t 방어력 11 이상 권장");
        Console.SetCursorPosition(5, 25);
        Console.Write("3. 어려운 던전\t 방어력 17 이상 권장");
        Console.SetCursorPosition(71, 22);

        // 입력값 분기 처리
        ConsoleKeyInfo inputKey = Console.ReadKey();
        Thread.Sleep(500);
        DrawUI.ClearChatUI();

        if (inputKey.Key == ConsoleKey.D1)
        {
            Dungeon.EasyMode();

        }
        else if (inputKey.Key == ConsoleKey.D2)
        {
            Dungeon.NormalMode();
        }
        else if (inputKey.Key == ConsoleKey.D3)
        {
            Dungeon.HardMode();
        }
        else
        {
            Console.SetCursorPosition(5, 22);
            Console.Write("잘못된 입력입니다.");
            Thread.Sleep(500);
            DrawUI.ClearChatUI();
            DrawUI.ClearChatUI();
            DrawUI.ClearChatUI();
            goto exceptionKey;
        }
    }


}

