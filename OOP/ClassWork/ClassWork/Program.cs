Player player = new Player("Антонио Маргаретти", 9, "Нападающий", "Спортинг");

player.ShowInfo();

class Player
{
    private string _name;
    private int _gameNumber;
    private string _position;
    private string _footballTeam;
    
    public Player (string name, int gameNumber, string position, string footballTeam)
    {
        _name = name;
        _gameNumber = gameNumber;
        _position = position;
        _footballTeam = footballTeam;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Имя игрока: {_name},\nИгровой номер: {_gameNumber},\nПозиция: {_position},\nКоманда: {_footballTeam}.");
    }
}
