
using System.Collections.Generic;
using UnityEngine;


namespace WCH
{  
    public class AppMsg {

        public int cmd; //请求类型

        public ReqHotList reqHotList = new ReqHotList();
        public RspHotList rspHotList = new RspHotList();
        public ReqSearchList reqSearchList = new ReqSearchList();
        public RspSearchList rspSearchList = new RspSearchList();
        public ReqArticleContent reqArticleContent = new ReqArticleContent();
        public RspArticleContent rspArticleContent = new RspArticleContent();
        public ReqOAInfo reqOAInfo = new ReqOAInfo();
        public RspOAInfo rspOAInfo = new RspOAInfo();

        public RcvQRCode rcvQRCode = new RcvQRCode();
        public BackQRCode backQRCode = new BackQRCode();
    }

    #region 请求数据
    public class ReqHotList {
        public List<string> wechat_id_list = new List<string>();//发送关注名单
    }
    public class RspHotList {
        public List<ArticleCover> article_cover_list = new List<ArticleCover>(); //返回文章封面信息列表
    }
    public class ReqSearchList {
        public string input_text="";//搜索文字
    }
    public class RspSearchList {
        public List<ArticleCover> article_cover_list = new List<ArticleCover>(); //返回文章封面信息列表
        public List<OffcialAccount> offcial_account_list = new List<OffcialAccount>(); //返回公众号封面信息列表
    }
    public class ReqArticleContent {
        public string title="";//文章标题 
        public string author=""; //作者
    }
    public class RspArticleContent {
        public Article article = new Article();
    }
    public class ReqOAInfo
    {
        public string wechat_id="";//微信ID
    }
    public class RspOAInfo
    {
        public OffcialAccount offcialAccount = new OffcialAccount(); 
    }
    public class RcvQRCode
    {
        public string qrcode = "";
    }
    public class BackQRCode
    {
        public string qrcodestring="";
    }

    #endregion


    public enum CMD
    {
        HOTARTICLECOVERINFO = 0,//获取热门文章列表
        SEARCHRESULT = 1,//搜索结果
        ARTICLECONTENT = 2,//文章内容
        ARTICLECOVERANDOA = 3,//主页获取 
        ORCODE = 4,//二维码
    }




}

