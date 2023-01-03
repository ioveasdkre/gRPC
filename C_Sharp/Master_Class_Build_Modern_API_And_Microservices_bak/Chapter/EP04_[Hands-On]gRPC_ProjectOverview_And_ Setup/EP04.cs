using System.IO;
using System;
using Grpc.Core;
using System.Threading.Tasks;

namespace Chapter.EP04_Hands_On_gRPC_ProjectOverview_And_Setup
{
    public class EP04
    {
        const int prot = 50051;
        const string target = "127.0.0.1:50051";

        #region _17_GreetServerBoilerPlateCode [ Server端-問候服務器樣板代碼 ]
        /// <summary>
        /// Server端-問候服務器樣板代碼
        /// </summary>
        public void _17_GreetServerBoilerPlateCode()
        {
            Server server = null;

            try
            {
                server = new Server()
                {
                    Ports =
                    {
                        new ServerPort("localhost", prot, ServerCredentials.Insecure) // (主機, prot, 身分驗證.無權限)
                    }
                };

                server.Start(); // 啟動服務器
                Console.WriteLine($"The server is listening on the prot: {prot}");
                Console.ReadKey();
            }
            catch (IOException e) // 使用流、文件和目錄訪問資訊時引發的異常的基類
            {
                Console.WriteLine($"The server failed to start: {e.Message}");
                throw;
            }
            finally
            {
                if (server != null)
                    server.ShutdownAsync().Wait(); // 關閉伺服器. 如要在另一台計算機上渲染 兩者之間可能會存在一些延遲 這是它非同步運行的原因
            }
        }
        #endregion

        #region _18_GreetClientBoilerplateCode [ Client端-問候客戶端樣板代碼 ]
        /// <summary>
        /// Client端-問候客戶端樣板代碼
        /// </summary>
        public void _18_GreetClientBoilerplateCode()
        {
            Channel channel = new Channel(target, ChannelCredentials.Insecure); // (http, 身分驗證.無權限)

            channel.ConnectAsync().ContinueWith((task) =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                    Console.WriteLine("The client connected successfully");
            });

            var client = new Dummy.DummyService.DummyServiceClient(channel);
        }
        #endregion
    }
}
