using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WCH
{
    public class AppAction  
    {
        //所有网路操作，接收后由Action处理
         
    }

    public class HotListAction {

        public List<ArticleCover> article_cover_list;

        public HotListAction(List<ArticleCover> article_cover_list)
        {
            this.article_cover_list = article_cover_list;
        }
    }


    public class SearchReasultAction {
        public List<ArticleCover> article_cover_list; //返回文章封面信息列表
        public List<OffcialAccount> offcial_account_list; //返回公众号封面信息列表

        public SearchReasultAction(List<ArticleCover> article_cover_list, List<OffcialAccount> offcial_account_list)
        {
            this.article_cover_list = article_cover_list;
            this.offcial_account_list = offcial_account_list;
        }
    }

    public class ArticleContentAction {

        public Article article;

        public ArticleContentAction(Article article)
        {
            this.article = article;
        }
    }

    public class ArticleCoverAndOA {
        public OffcialAccount offcial_account;
        public List<Article> article;

        public ArticleCoverAndOA(OffcialAccount offcial_account, List<Article> article)
        {
            this.offcial_account = offcial_account;
            this.article = article;
        }
    }


    public class QRCodeAction {
        public byte[] qrcode;

        public QRCodeAction(byte[] qrcode)
        {
            this.qrcode = qrcode;
        }
    }


}
