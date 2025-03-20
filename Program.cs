Network network = new Network(8);

network.Connect(1, 6);
network.Connect(1, 2);
network.Connect(6, 2);
network.Connect(2, 4);
network.Connect(5, 8);

Console.WriteLine("------------------------");
Console.WriteLine("Query tests:");
Console.WriteLine(network.Query(1, 4));
Console.WriteLine(network.Query(5, 7));
Console.WriteLine(network.Query(2, 6));
Console.WriteLine(network.Query(3, 7));

Console.WriteLine("------------------------");
Console.WriteLine("Level Connection Tests:");
Console.WriteLine(network.LevelConnection(1, 4));
Console.WriteLine(network.LevelConnection(1, 2));
Console.WriteLine(network.LevelConnection(3, 7));
Console.WriteLine(network.LevelConnection(5, 8));

Console.WriteLine("------------------------");
Console.WriteLine("Level Connection test adding one more connection");
network.Connect(4, 3);
network.Connect(3, 7);
network.Connect(6, 7);

Console.WriteLine(network.LevelConnection(1, 3));

Console.WriteLine("------------------------");
Console.WriteLine("Query test with disconnection of elements");
Console.WriteLine(network.Query(1, 4));
Console.WriteLine("Disconnecting...");
network.Diconnect(2, 4);

Console.WriteLine(network.Query(1, 4));
