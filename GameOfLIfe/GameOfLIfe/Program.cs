using Engine.Implementations;
using GameOfLIfe;

Console.WriteLine("Game of Life");

var squareSize = 20;
var game = new GameOfLife();
var random = new Random();
var god = new ClassicGod();
var shouldContinue = () => random.NextSingle() <= 0.8;

while (true)
{
    var land = new SquareLand(squareSize);
    var printer = new PrinterObserver(squareSize);

    Console.WriteLine("Starting...");
    game.Initialize(land, god, printer);

    Console.WriteLine("Started");
    game.Start(shouldContinue);

    Console.WriteLine("Finished");

    Console.ReadLine();
}



