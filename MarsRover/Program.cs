// See https://aka.ms/new-console-template for more information
using MarsRover;

Console.WriteLine("Hello, welcome to the mars rover interface, where you can move the rover around mars!");
Console.WriteLine("First you will write the initial position of the machine, where we only accept positive numbers and the four usual direction(N,E,S,W) that will be where the little guy will be looking to!");
Console.WriteLine("So... lets start!");
Console.WriteLine("Write the initial position:");
Console.WriteLine("X position:");
var x = Console.ReadLine();
Console.WriteLine("Y position:");
var y = Console.ReadLine();
Console.WriteLine("Direction:");
var direction = Console.ReadLine();
Console.WriteLine("Now for the movements, we only accept the letters F(Go forward), B(Go backwards), L(turn 90 degrees left), R(turn 90 degress right) and we ask to write all the movements together.");
Console.WriteLine("Please write down the movements");
var movements = Console.ReadLine();
var message = x + " " + y + " " + direction + "///" + movements;
try
{
    var messageHandler = new MovementMessageHandler();
    var finalPosition = messageHandler.HandleMessage(message.ToUpper());
    Console.WriteLine("Congratulations, the final position of your mars rover is:" + finalPosition);
}catch(Exception ex) { Console.WriteLine(ex.Message); }