using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WCH
{
    public class Article
    {
        public string article_id = "";//文章标题 
        public string article_url = "";//文章地址
        public string article_imgs = "";//文章图片
        public string article_abstract = "";//文章摘要  
        public string gzh_headimage = "";// 文章来源公众号头像
        public string gzh_id = "";//微信id

    }

    public class ArticleCover
    {
        public string wechat_id;//微信id
        public string wechat_name;// 名称
        public string title;//文章标题
        public string articleAbstract;//文章摘要
        public string author; //作者
        public int time;//时间戳
        public string cover;//封面图
    }

}

