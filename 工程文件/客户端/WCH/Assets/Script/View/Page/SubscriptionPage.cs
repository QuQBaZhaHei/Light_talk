using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace WCH
{
    public class SubscriptionPage : StatefulWidget
    {
        public override State createState()
        {
            return new SubscriptionPageState();
        }
    }

    public class SubscriptionPageState : State<SubscriptionPage> {

        public override Widget build(BuildContext context)
        {
            return new ListView(

                children: new List<Widget>() {

                    new OACard(new OffcialAccount(){
                        headimage = "test1"
                        ,wechat_name = "暴走漫画"
                        ,introduction = "小孩子不要暴漫！"
                        ,post_perm = "13"
                    })
                    ,new OACard(new OffcialAccount(){
                        headimage = "Unity-1"
                        ,wechat_name ="Unity官方平台"
                        ,introduction = "Unity官方开发平台，分享最前沿的技术文章和开发经验，精彩的Unity活动和社区相关信息。"
                        ,post_perm = "15"
                    }) 

                } 
            );
        }
    }

}
