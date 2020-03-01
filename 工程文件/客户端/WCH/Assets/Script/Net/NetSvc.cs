

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace WCH
{
     
    public class NetSvc 
    {
        private static NetSvc m_instance;
        public static NetSvc instance
        { 
            get
            {
                if (m_instance == null)
                    m_instance = new NetSvc();
                return m_instance;
            }
        }

        public Queue<AppMsg> msgQueue = new Queue<AppMsg>();
        public static readonly string lockstr = "LOCK"; 
        public Client client;
        public Thread rcvthread;
        public Thread sedthread;



        public void Init()
        { 
            client = new Client();
            rcvthread = new Thread(client.OnInit);
            rcvthread.Start();
        }
        public void Send(AppMsg msg)
        {
            sedthread = new Thread(client.SendMsg);
            sedthread.Start(msg);
             
        }


        public void AddMsg(AppMsg msg) { 

            //注意多线程从操作
            lock (lockstr)
            {
                msgQueue.Enqueue(msg);
            }
        }
         


    }

}

