using Core;

Console.WriteLine("CI-Server Starting...");

var server = new CIServer();

while(true)
{
    Console.WriteLine("Enter option:");
    var input = Console.ReadLine();
	var inputNumber = -1;

	int.TryParse(input, out inputNumber);

	switch(inputNumber)
	{
		case 1:
			EnterMarketPlace(); break;
		case 2:
			AddJob(); break;
		case 3:
			AddJobStep(); break;
		case 4:
			ExecuteJob(); break;


		case -1:
            Console.WriteLine("Good bye 👋");
			break;
		default:
            Console.WriteLine("Invalid input, Please try again 🤕");
			break;
	}
}

void ExecuteJob()
{
	throw new NotImplementedException();
}

void AddJobStep()
{
	throw new NotImplementedException();
}

void AddJob()
{
	throw new NotImplementedException();
}

void EnterMarketPlace()
{
	throw new NotImplementedException();
}