
using Newtonsoft.Json;
using System;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
 
namespace WCH
{
    public class Client
    {
        private Socket clientSocket;
        private DealMessage dmsg = new DealMessage();

        public Client() 
        {
        }

        public void OnInit()
        {
            clientSocket = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
            try
            {
                clientSocket.Connect(NetInfo.IP, NetInfo.PORT);
                StartHead();
            }
            catch (Exception e)
            {
                Debug.LogWarning("无法连接到服务器端，请检查你的网络！！！" + e);//TODO 客户端提示
            }
        }
        public void Close() {
            clientSocket.Close();
        }
        private void StartHead()
        {
            if (clientSocket == null || clientSocket.Connected == false)
            {
                return;//TODO 客户端提示
            }
            clientSocket.BeginReceive(dmsg.head, dmsg.headIndex,dmsg.headRemain, SocketFlags.None, ReceiveHeadCallback, null);
        }
        private void StartBody()
        {
            if (clientSocket == null || clientSocket.Connected == false)
            {
                return;//TODO 客户端提示
            }
            clientSocket.BeginReceive(dmsg.body, dmsg.bodyIndex, dmsg.bodyRemain, SocketFlags.None, ReceiveBodyCallback, null);
        }
        private void ReceiveHeadCallback(IAsyncResult ar)
        {
            try
            {
                int count = clientSocket.EndReceive(ar);
                if(count > 0)
                {
                    dmsg.headIndex += count;
                    if (dmsg.headIndex < dmsg.headLen)
                    {
                        StartHead();
                    }
                    else
                    {
                        dmsg.InitBody();
                        StartBody();
                    }

                }
                else
                {
                    //TODO 关闭Socket
                }

            }
            catch (Exception e)
            {
                //TODO 关闭Socket
                Debug.Log(e);//TODO 客户端提示
            }


        }

        private void ReceiveBodyCallback(IAsyncResult ar)
        {
            try
            {
                int count = clientSocket.EndReceive(ar);
                if (count > 0)
                {
                    dmsg.bodyIndex += count;
                    if (dmsg.bodyIndex < dmsg.bodyLen)
                    {
                        StartBody();
                    }
                    else
                    {
                        //处理 dmsg.body

                        string str = Encoding.UTF8.GetString(dmsg.body);
                        Debug.Log("-->" + str);
                        
                        AppMsg msg = JsonConvert.DeserializeObject<AppMsg>(str);

                        //TODO 接收完毕提醒
                        NetSvc.instance.AddMsg(msg);

                        dmsg.ResetData();

                        StartHead();
                    }
                }
                else
                {
                    //TODO 关闭Socket
                }

            }
            catch (Exception e)
            {
                //TODO 关闭Socket
                Debug.Log(e);//TODO 客户端提示
            }


        }


        public void SendMsg(System.Object msg)
        {
            if (clientSocket == null || clientSocket.Connected == false)
            {
                Debug.LogWarning("网络未连接！");
                return; 
            }


            string msgString = JsonConvert.SerializeObject(msg);
            Debug.Log(msgString);
            byte[] bytes = DealMessage.PackLenInfo(Encoding.UTF8.GetBytes(msgString));
            clientSocket.Send(bytes);
        }

    }

}

