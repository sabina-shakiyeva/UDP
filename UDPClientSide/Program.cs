using System.Net;
using System.Net.Sockets;
using System.Text;

Console.WriteLine("Client Side");

var client = new UdpClient();
var endPoint = new IPEndPoint(IPAddress.Loopback, 27001);

while (true)
{
    //var msg = Console.ReadLine();
    //var bytes = Encoding.UTF8.GetBytes(msg);
    //client.Send(bytes, bytes.Length, endPoint);
    Console.WriteLine("File Path-ni daxil edin:");
    string FilePath=Console.ReadLine();

    using(var readFs =new FileStream(FilePath, FileMode.Open, FileAccess.Read))
    {
        int len = 0;
        var buffer = new byte[1024];
        while((len = readFs.Read(buffer, 0, buffer.Length)) > 0)
        {
            client.Send(buffer,len,endPoint);
        }
    }
    Console.WriteLine("photo sended");
    client.Close();

}