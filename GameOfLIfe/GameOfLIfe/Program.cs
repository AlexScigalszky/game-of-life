using Engine.Implementations;

Console.WriteLine(" ---- Game of Life ---- ");

var builder = new SquareRandomIterationsBuilder();
var director = new Director(builder);

while (true)
{
    Console.WriteLine("Starting...");
    var game = director.Make();
    
    Console.WriteLine("Started");
    game.Start();

    do
    {
        game.Next();
    }
    while (ender?.ShouldContinue() ?? false);


    Console.WriteLine("Finished");

    Console.ReadLine();
}



