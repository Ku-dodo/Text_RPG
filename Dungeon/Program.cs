class Program
{
    static void Main(string[] args)
    {
        Console.Title = "RPG Game";
        Console.CursorVisible = false;
        Player player = new Player("chad", "전사", 100, 10, 5, 1500);
        DrawUnicodeUI drawUI = new DrawUnicodeUI();

        Village village = new Village(player);

        //구역 그리기
        drawUI.DrawOutLine();
        drawUI.DrawChatLineUI();

        //게임 루프
        village.VillageLoop();

    }
}

// UI를 그리는 class
class DrawUnicodeUI
{
    //외곽선을 그리는 함수
    public void DrawOutLine()
    {
        for (int i = 0; i <= 118; i++)
        {
            Console.SetCursorPosition(i, 0);
            Console.Write('─');
            Console.SetCursorPosition(i, 29);
            Console.Write('─');
        }
        for (int i = 0; i <= 29; i++)
        {
            Console.SetCursorPosition(0, i);
            Console.Write('│');
            Console.SetCursorPosition(118, i);
            Console.Write('│');
        }
        Console.SetCursorPosition(0, 0);
        Console.Write('┌');
        Console.SetCursorPosition(118, 0);
        Console.Write('┐');
        Console.SetCursorPosition(118, 29);
        Console.Write('┘');
        Console.SetCursorPosition(0, 29);
        Console.Write('└');
    }

    //하단 UI를 나눠주는 함수
    public void DrawChatLineUI()
    {
        for (int i = 0; i <= 118; i++)
        {
            Console.SetCursorPosition(i, 20);
            Console.Write("─");
        }
        Console.SetCursorPosition(0, 20);
        Console.Write("├");
        Console.SetCursorPosition(118, 20);
        Console.Write("┤");

    }
    //하단 UI 텍스트를 지워주는 함수
    public void ClearChatUI()
    {
        for (int i = 1; i <= 117; i++)
        {
            for (int j = 21; j <= 28; j++)
            {
                Console.SetCursorPosition(i, j);
                Console.Write(" ");
            }
        }
    }
}

//item 구조체


