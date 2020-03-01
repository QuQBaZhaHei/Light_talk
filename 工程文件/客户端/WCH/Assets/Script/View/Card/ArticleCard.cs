using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace WCH
{
    public class ArticleCard : StatelessWidget
    { 
        ArticleCover m_ArticleCover;

        public ArticleCard(ArticleCover m_ArticleCover)
        {
            this.m_ArticleCover = m_ArticleCover;
             
 
        }

        private float? width;
        public override Widget build(BuildContext context)
        {
            if (width == null)
            {
                width = MediaQuery.of(context).size.width;

            }
            return 
                new Container( 
                   child: new Center(
                            child: new Card(
                                shape: new RoundedRectangleBorder(
                                    borderRadius: BorderRadius.all(5.0f)
                                ),
                                child: new Container( 
                                    child: new Column(
                                   
                                       children: new List<Widget> {
                                        
                                           new Padding(
                                               padding: EdgeInsets.only(8,8,8,8)
                                               ,child:
                                                    new Row(
                                                        children: new List<Widget>()
                                                        { 
                                                            new ClipOval(

                                                                child:Image.asset(
                                                                    m_ArticleCover.wechat_id??"products/backpack",
                                                                    fit: BoxFit.cover,
                                                                    width: 30,
                                                                    height: 30
                                                                ) 
                                                            )
                                                            ,
                                                            new Container(
                                                                padding: EdgeInsets.only(8,0,0,0)
                                                                ,child:new Text(m_ArticleCover.wechat_name??"这是名字")
                                                            )
                                                            //Image.memory()
                                                        }     
                                                    )
                                           
                                               )
                                            ,new InkWell(
                                                onTap:()=>{Debug.Log("H"); }
                                                ,child: 
                                                        Image.asset(
                                                            m_ArticleCover.cover??"products/backpack",
                                                            fit: BoxFit.cover,
                                                            width: width * 0.95f,
                                                            height: 150
                                                        ) 
                                                )

                                                ,new Container(
                                                alignment: Alignment.centerLeft
                                                ,padding: EdgeInsets.all(8),
                                                child:new Text(m_ArticleCover.title??"这是标题")

                                                )
                                                ,new Container(
                                                alignment: Alignment.centerLeft
                                                    ,padding: EdgeInsets.all(8),
                                                child:new Text(data: m_ArticleCover.articleAbstract??"这是简介"
                                                ,style:Theme.of(context).textTheme.body2.copyWith(color:Colors.black54))

                                                )
                                        }
                                    )
                                )
                        )
                    )
                );
        }
    }

}

