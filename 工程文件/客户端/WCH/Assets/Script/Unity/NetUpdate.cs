

using Unity.UIWidgets.Redux;
using UnityEngine;

namespace WCH
{
    public class NetUpdate : MonoBehaviour 
    {

        public static bool flag = true;

        private void Awake()
        {

        }

        public static void init()
        {
            if (flag) {
                if (flag == true)
                {
                    flag = false;
                    Debug.Log("测试点一 ： 网络是否连接");
                    NetSvc.instance.Init(); //TODO 测试点一 ： 网络是否连接
                }
            }
        }

        public void Update()
        {
            if (NetSvc.instance.msgQueue.Count > 0)
            {
                //这里采用的是收集多线程的信息
                //在单线程中处理，所以没有接受后马上发送
                lock (NetSvc.lockstr)
                {
                    AppMsg appMsg = NetSvc.instance.msgQueue.Dequeue();
                    HandOut(appMsg);
                }
            }
        }

        public void OnDestroy()
        {
            NetSvc.instance.client.Close();
        }


        private void HandOut(AppMsg appMsg)
        {
            switch ((CMD)appMsg.cmd)
            {
                case CMD.HOTARTICLECOVERINFO:
                    //Common.store.dispatcher.dispatch(new HotListAction(appMsg.rspHotList.article_cover_list));
                    break;
                case CMD.SEARCHRESULT:
                    Debug.Log("收到");
                    Common.store.dispatcher.dispatch(new SearchReasultAction(appMsg.rspSearchList.article_cover_list, appMsg.rspSearchList.offcial_account_list));
 
                    return;
                     ;
                case CMD.ARTICLECONTENT:
                    break;
                case CMD.ARTICLECOVERANDOA:
                    break;
                default:
                    break;
            }
        }
    }

}


