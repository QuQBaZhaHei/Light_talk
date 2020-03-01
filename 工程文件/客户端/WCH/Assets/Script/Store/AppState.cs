using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WCH
{
    public class AppState : IPreservable<AppState>
    {
        public List<string> WechatId;

        //所有接收到的信息到这里保存
        public List<ArticleCover> article_cover_list = new List<ArticleCover>();

        //TODO临时的
        public List<OffcialAccount> offcial_account_list = new List<OffcialAccount>();

    }

}
