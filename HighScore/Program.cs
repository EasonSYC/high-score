namespace HighScore;

class Program
{
    
    static void Main(string[] args)
    {
        string[] PlayerName = new string[11];
        int[] PlayerScore = new int[11];

        ReadHighScores(PlayerName, PlayerScore);
        OutputHighScores(PlayerName, PlayerScore);

        string? userName = string.Empty;
        do
        {
            Console.WriteLine("Input a three-character user name:");
            userName = Console.ReadLine();
        } while (userName!.Length != 3);

        int userScore = -1;
        do
        {
            Console.WriteLine("Input a score between 1 and 100 000 inclusive:");
            userScore = int.Parse(Console.ReadLine()!);
        } while (userScore < 1 || userScore > 100000);

        Arrange(userName, userScore, PlayerName, PlayerScore);
        OutputHighScores(PlayerName, PlayerScore);

        WriteTopTen(PlayerName, PlayerScore);
    }

    static void Arrange(string userName, int userScore, string[] PlayerName, int[] PlayerScore)
    {
        for(int i = 10 - 1; i >= -1; --i)
        {
            if(i == -1 || PlayerScore[i] >= userScore)
            {
                PlayerScore[i + 1] = userScore;
                PlayerName[i + 1] = userName;
                break;
            }

            PlayerScore[i + 1] = PlayerScore[i];
            PlayerName[i + 1] = PlayerName[i];
        }
    }

    static void ReadHighScores(string[] PlayerName, int[] PlayerScore)
    {
        string[] fileLines = File.ReadAllLines("HighScore.txt");
        for(int i = 0; i < 20; ++i)
        {
            if (i % 2 == 0)
            {
                PlayerName[i / 2] = fileLines[i];
            }
            else
            {
                PlayerScore[i / 2] = int.Parse(fileLines[i]);
            }
        }
    }

    static void OutputHighScores(string[] PlayerName, int[] PlayerScore)
    {
        for (int i = 0; i < 10; ++i)
        {
            Console.WriteLine($"{PlayerName[i]} {PlayerScore[i]}");
        }
    }

    static void WriteTopTen(string[] PlayerName, int[] PlayerScore)
    {
        string[] fileLines = new string[20];
        for (int i = 0; i < 10; ++i)
        {
            fileLines[2 * i] = PlayerName[i];
            fileLines[2 * i + 1] = PlayerScore[i].ToString();
        }

        File.WriteAllLines("NewHighScore.txt", fileLines);
    }
}

