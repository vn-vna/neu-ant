// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var client = new HttpClient()
{
  BaseAddress = new Uri("http://localhost:5192")
};

var task = client.GetAsync("/api/auth/sign-in?username=vnvna&password=kaorisuki");
task.Wait();
var res = task.Result;

Console
  .WriteLine(res.ToString());

