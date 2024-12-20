// See https://aka.ms/new-console-template for more information
using Grpc.Net.Client;
using UserManagementGRPCClient;

Console.WriteLine("Hello, World!");


using var channel = GrpcChannel.ForAddress("https://localhost:7179");
var client =  new ManageUser.ManageUserClient(channel);
//var reply = await client.CreateUserAsync(new CreateUserRequest
//{
//    Name = "Mojtaba",
//    Family = "Hosseini",
//    Birthday = "1993-06-09",
//    NationalCode = "106850446969"
//});

//Console.WriteLine(reply.Id);

User user = null;

try
{
    user = await client.GetUserAsync(new UserId { Id = 1 });
}
catch (Exception ex)
{

	throw;
}


Console.WriteLine($"{user.Name} {user.Family}");
