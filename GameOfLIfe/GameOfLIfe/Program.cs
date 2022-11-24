using Engine.Implementations;

Console.WriteLine(" ---- Game of Life ---- ");

var squareSize = 20;
var game = new GameOfLife();

var god = new ClassicGod();
var ender = new RandomEnder();

while (true)
{
    var land = new SquareLand(squareSize);
    var printer = new PrinterObserver(squareSize);

    Console.WriteLine("Starting...");
    game.Initialize(land, god, printer, ender);

    Console.WriteLine("Started");
    game.Start();

    Console.WriteLine("Finished");

    Console.ReadLine();
}



