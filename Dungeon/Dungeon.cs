
// UI를 그리는 class
//던전 기능 관련 클래스
public class Dungeon
{
    DrawUnicodeUI drawUI = new DrawUnicodeUI();
    Player Player;

    public Dungeon(Player player)
    {
        Player = player;
    }
    public void EasyMode()
    {
        int recommendDef = 5;
        int DefaultGold = 1000;
        // 권장 방어력 미만 > 권장 방어력 미만
        if (Player.ResultDef < recommendDef)
        {
            int ClearRate = new Random().Next(1, 11);
            // 성공
            if (ClearRate <= 4)
            {

                int decreaseHP = new Random().Next(20, 35);
                int bonusGold = new Random().Next(1, 3);
                Console.SetCursorPosition(5, 22);
                Console.Write("쉬운 던전을 클리어 하였습니다.");
                Console.SetCursorPosition(5, 23);
                Console.Write("[탐험 결과]");
                Console.SetCursorPosition(5, 24);
                Console.Write("체력\t {0} -> {1}", Player.HP, Player.HP - (decreaseHP + recommendDef - Player.ResultDef));
                Player.HP = Player.HP - (decreaseHP + recommendDef - Player.ResultDef);
                Console.SetCursorPosition(5, 25);
                Console.Write("Gold\t {0} -> {1}", Player.Gold, Player.Gold + DefaultGold + (DefaultGold * Player.Atk * bonusGold / 100));
                Player.Gold = Player.Gold + DefaultGold + (DefaultGold * Player.Atk * bonusGold / 100);

                Console.SetCursorPosition(5, 27);
                Console.Write("아무 키나 눌러 돌아가기 [ ]");
                Console.SetCursorPosition(30, 27);
                ConsoleKeyInfo inputKey = Console.ReadKey();
                Thread.Sleep(500);
                drawUI.ClearChatUI();

            }
            // 권장 방어력 미만 > 실패
            else
            {

                Console.SetCursorPosition(5, 22);
                Console.Write("던전 공략에 실패했습니다.");
                Console.SetCursorPosition(5, 23);
                Console.Write("체력이 절반으로 감소합니다.");
                Console.SetCursorPosition(5, 24);
                Console.Write("체력 {0} -> {1}", Player.HP, Player.HP / 2);
                Player.HP /= 2;

                Console.SetCursorPosition(5, 27);
                Console.Write("아무 키나 눌러 돌아가기 [ ]");
                Console.SetCursorPosition(30, 27);
                ConsoleKeyInfo inputKey = Console.ReadKey();
                Thread.Sleep(500);
                drawUI.ClearChatUI();

            }

        }
        //권장 방어력 이상
        else if (Player.ResultDef >= recommendDef)
        {
            int decreaseHP = new Random().Next(20, 35);
            int bonusGold = new Random().Next(1, 3);
            Console.SetCursorPosition(5, 22);
            Console.Write("쉬운 던전을 클리어 하였습니다.");
            Console.SetCursorPosition(5, 23);
            Console.Write("[탐험 결과]");
            Console.SetCursorPosition(5, 24);
            Console.Write("체력\t {0} -> {1}", Player.HP, Player.HP - (decreaseHP + recommendDef - Player.ResultDef));
            Player.HP = Player.HP - (decreaseHP + recommendDef - Player.ResultDef);
            Console.SetCursorPosition(5, 25);
            Console.Write("Gold\t {0} -> {1}", Player.Gold, Player.Gold + DefaultGold + (DefaultGold * Player.Atk * bonusGold / 100));
            Player.Gold = Player.Gold + DefaultGold + (DefaultGold * Player.Atk * bonusGold / 100);

            Console.SetCursorPosition(5, 27);
            Console.Write("아무 키나 눌러 돌아가기 [ ]");
            Console.SetCursorPosition(30, 27);
            ConsoleKeyInfo inputKey = Console.ReadKey();
            Thread.Sleep(500);
            drawUI.ClearChatUI();
        }

    }

    public void NormalMode()
    {
        int recommendDef = 11;
        int DefaultGold = 1500;
        //권장 방어력 미만
        if (Player.ResultDef < recommendDef)
        {
            int ClearRate = new Random().Next(1, 11);
            //권장 방어력 미만 > 성공
            if (ClearRate <= 4)
            {
                int decreaseHP = new Random().Next(20, 35);
                int bonusGold = new Random().Next(1, 3);
                Console.SetCursorPosition(5, 22);
                Console.Write("보통 던전을 클리어 하였습니다.");
                Console.SetCursorPosition(5, 23);
                Console.Write("[탐험 결과]");
                Console.SetCursorPosition(5, 24);
                Console.Write("체력\t {0} -> {1}", Player.HP, Player.HP - (decreaseHP + recommendDef - Player.ResultDef));
                Player.HP = Player.HP - (decreaseHP + recommendDef - Player.ResultDef);
                Console.SetCursorPosition(5, 25);
                Console.Write("Gold\t {0} -> {1}", Player.Gold, Player.Gold + DefaultGold + (DefaultGold * Player.Atk * bonusGold / 100));
                Player.Gold = Player.Gold + DefaultGold + (DefaultGold * Player.Atk * bonusGold / 100);

                Console.SetCursorPosition(5, 27);
                Console.Write("아무 키나 눌러 돌아가기 [ ]");
                Console.SetCursorPosition(30, 27);
                ConsoleKeyInfo inputKey = Console.ReadKey();
                Thread.Sleep(500);
                drawUI.ClearChatUI();

            }
            //권장 방어력 미만 > 실패
            else
            {
                Console.SetCursorPosition(5, 22);
                Console.Write("던전 공략에 실패했습니다.");
                Console.SetCursorPosition(5, 23);
                Console.Write("체력이 절반으로 감소합니다.");
                Console.SetCursorPosition(5, 24);
                Console.Write("체력 {0} -> {1}", Player.HP, Player.HP / 2);
                Player.HP /= 2;

                Console.SetCursorPosition(5, 27);
                Console.Write("아무 키나 눌러 돌아가기 [ ]");
                Console.SetCursorPosition(30, 27);
                ConsoleKeyInfo inputKey = Console.ReadKey();
                Thread.Sleep(500);
                drawUI.ClearChatUI();
            }
        }
        //권장 방어력 이상
        else if (Player.ResultDef >= recommendDef)
        {
            int decreaseHP = new Random().Next(20, 35);
            int bonusGold = new Random().Next(1, 3);
            Console.SetCursorPosition(5, 22);
            Console.Write("보통 던전을 클리어 하였습니다.");
            Console.SetCursorPosition(5, 23);
            Console.Write("[탐험 결과]");
            Console.SetCursorPosition(5, 24);
            Console.Write("체력\t {0} -> {1}", Player.HP, Player.HP - (decreaseHP + recommendDef - Player.ResultDef));
            Player.HP = Player.HP - (decreaseHP + recommendDef - Player.ResultDef);
            Console.SetCursorPosition(5, 25);
            Console.Write("Gold\t {0} -> {1}", Player.Gold, Player.Gold + DefaultGold + (DefaultGold * Player.Atk * bonusGold / 100));
            Player.Gold = Player.Gold + DefaultGold + (DefaultGold * Player.Atk * bonusGold / 100);

            Console.SetCursorPosition(5, 27);
            Console.Write("아무 키나 눌러 돌아가기 [ ]");
            Console.SetCursorPosition(30, 27);
            ConsoleKeyInfo inputKey = Console.ReadKey();
            Thread.Sleep(500);
            drawUI.ClearChatUI();
        }
    }


    public void HardMode()
    {
        int recommendDef = 17;
        int DefaultGold = 2500;
        //권장 방어력 미만
        if (Player.ResultDef < recommendDef)
        {
            int ClearRate = new Random().Next(1, 11);
            // 권장 방어력 이상 > 성공
            if (ClearRate <= 4)
            {
                int decreaseHP = new Random().Next(20, 35);
                int bonusGold = new Random().Next(1, 3);
                Console.SetCursorPosition(5, 22);
                Console.Write("어려운 던전을 클리어 하였습니다.");
                Console.SetCursorPosition(5, 23);
                Console.Write("[탐험 결과]");
                Console.SetCursorPosition(5, 24);
                Console.Write("체력\t {0} -> {1}", Player.HP, Player.HP - (decreaseHP + recommendDef - Player.ResultDef));
                Player.HP = Player.HP - (decreaseHP + recommendDef - Player.ResultDef);
                Console.SetCursorPosition(5, 25);
                Console.Write("Gold\t {0} -> {1}", Player.Gold, Player.Gold + DefaultGold + (DefaultGold * Player.Atk * bonusGold / 100));
                Player.Gold = Player.Gold + DefaultGold + (DefaultGold * Player.Atk * bonusGold / 100);

                Console.SetCursorPosition(5, 27);
                Console.Write("아무 키나 눌러 돌아가기 [ ]");
                Console.SetCursorPosition(30, 27);
                ConsoleKeyInfo inputKey = Console.ReadKey();
                Thread.Sleep(500);
                drawUI.ClearChatUI();

            }
            // 권장 방어력 미만 > 실패
            else
            {
                Console.SetCursorPosition(5, 22);
                Console.Write("던전 공략에 실패했습니다.");
                Console.SetCursorPosition(5, 23);
                Console.Write("체력이 절반으로 감소합니다.");
                Console.SetCursorPosition(5, 24);
                Console.Write("체력 {0} -> {1}", Player.HP, Player.HP / 2);
                Player.HP /= 2;

                Console.SetCursorPosition(5, 27);
                Console.Write("아무 키나 눌러 돌아가기 [ ]");
                Console.SetCursorPosition(30, 27);
                ConsoleKeyInfo inputKey = Console.ReadKey();
                Thread.Sleep(500);
                drawUI.ClearChatUI();
            }
        }
        //권장 방어력 이상
        else if (Player.ResultDef >= recommendDef)
        {
            int decreaseHP = new Random().Next(20, 35);
            int bonusGold = new Random().Next(1, 3);
            Console.SetCursorPosition(5, 22);
            Console.Write("어려운 던전을 클리어 하였습니다.");
            Console.SetCursorPosition(5, 23);
            Console.Write("[탐험 결과]");
            Console.SetCursorPosition(5, 24);
            Console.Write("체력\t {0} -> {1}", Player.HP, Player.HP - (decreaseHP + recommendDef - Player.ResultDef));
            Player.HP = Player.HP - (decreaseHP + recommendDef - Player.ResultDef);
            Console.SetCursorPosition(5, 25);
            Console.Write("Gold\t {0} -> {1}", Player.Gold, Player.Gold + DefaultGold + (DefaultGold * Player.Atk * bonusGold / 100));
            Player.Gold = Player.Gold + DefaultGold + (DefaultGold * Player.Atk * bonusGold / 100);

            Console.SetCursorPosition(5, 27);
            Console.Write("아무 키나 눌러 돌아가기 [ ]");
            Console.SetCursorPosition(30, 27);
            ConsoleKeyInfo inputKey = Console.ReadKey();
            Thread.Sleep(500);
            drawUI.ClearChatUI();
        }
    }
}

