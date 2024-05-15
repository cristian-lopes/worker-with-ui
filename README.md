To create te Service:

	Publish to C:\inetpub\services\WindowsServiceApiDemo\App\netcoreapp3.1
	Run cmd as Administrator:

	sc create WorkerMultiServices binpath= C:\inetpub\services\WindowsServiceApiDemo\App\netcoreapp3.1\WindowsServiceApiDemo.exe start= auto DisplayName= "Worker Multi-Services"
	sc description WorkerMultiServices "This is a Windows Service Api Demo, done in dotnet core 3.1"

Additional options:

	sc start WorkerMultiServices
	sc stop WorkerMultiServices
	sc delete WorkerMultiServices

Or open services.msc find 'Worker Multi-Services' and start / stop from there

To test the service:

	Open a browser in http://localhost:5000/home
	Open a browser in http://localhost:5000/status

Refs: Loggin with HTML: https://code-maze.com/aspnetcore-webapi-return-html/
