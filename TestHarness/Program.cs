using LoggerModule;

var databaseLogger = new DatabaseLogger();

var message = "Turtles are great, turtles are wonderful!";

databaseLogger.Log(message);

Console.WriteLine($"The turtles have sent a message to the Database!");