using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.Redux;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace WCH
{
    public class HotListPage : StatefulWidget
    {
        public override State createState()
        {
            return new HotListPageState();
        }
    }

    public class HotListPageState : State<HotListPage> {

        public override void initState()
        {
            base.initState();
            Debug.Log("initsate开始了");


        }

        public override Widget build(BuildContext context)
        {
            //Debug.Log("build开始");


            return new ListView(

                children: new List<Widget>() { 
                    new ArticleCard(new ArticleCover(){
                        wechat_id = "test1"
                        ,wechat_name = "暴走漫画"
                        ,title = "\"网警\"人肉女孩求交往事件反转！"
                        ,articleAbstract = "任谁都想不到，一场微博求助，居然会有如此反转"
                        ,cover = "baozou-1"
                    })
                    ,new ArticleCard(new ArticleCover(){
                        wechat_id = "Unity-1"
                        ,wechat_name = "Unity官方平台"
                        ,title = "使用Unity AR Foundation "
                        ,articleAbstract = "本文将分享麻省理工学院的教程-使用Unity AR Foundation在增强现实中查看模型。"
                        ,cover = "Unity-2"
                        
                    })
                    //,new ArticleCard(null) 
                });
            
                
           


            //return new StoreConnector<AppState,List<ArticleCover>>(
            //    converter:state => state.article_cover_list
            //    , builder: (buildContext,model,dispatcher) => {

            //        return
            //            ListView.builder(

            //            itemCount: model.Count
            //            , itemBuilder: (mcontext, index) =>
            //             {
            //                 return new ArticleCard(model[index]); 
            //            }
            //            );
            //    } 
            //); 

        }
    }

}

