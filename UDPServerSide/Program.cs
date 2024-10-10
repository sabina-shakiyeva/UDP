using System.Net;
using System.Net.Sockets;
using System.Text;

Console.WriteLine("server");

var server = new UdpClient(27001);
var remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);

while (true)
{
    var bytes = server.Receive(ref remoteEndPoint);
   
    //Console.WriteLine($"{remoteEndPoint}: {str}");
    int count = 0;
    var str = Encoding.UTF8.GetString(bytes);
    //string destinationPath = $@"C:\Users\Shaki_bf42\source\repos\UDPClientSide\UDPServerSide\Photos\image_{++count}.jpg";
    //var directory = Directory.CreateDirectory($@"C:\Users\Shaki_bf42\source\repos\UDPClientSide\UDPServerSide\{remoteEndPoint.Address.ToString}\image_{++count}.jpg");
  //  var destination = $@"C:\Users\Shaki_bf42\source\repos\UDPClientSide\UDPServerSide\{remoteEndPoint.Address}\image_{++count}.jpg";

    var destination = $@"C:\Users\Shaki_bf42\source\repos\UDPClientSide\UDPServerSide\{remoteEndPoint.Address}\image_{++count}.jpg";

   
    var directoryPath = Path.GetDirectoryName(destination);
    Directory.CreateDirectory(directoryPath); 

    //destination = $@"{destination}\{remoteEndPoint.Address}\image_{++count}.jpg";


    using (var fs=new FileStream(destination, FileMode.Append, FileAccess.Write))
    {
        
        fs.Write(bytes, 0, bytes.Length);
    }
    
}