

using System.Collections.Generic;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.rendering;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace WCH
{
    public class OAPanel: StatelessWidget
    {
        public OffcialAccount m_offcialAccount;

        public OAPanel(OffcialAccount offcialAccount)
        {
            this.m_offcialAccount = offcialAccount;
        }

        private float? width;
        List<Widget> OAList(BuildContext context)
        {
            List<Widget> list = new List<Widget>() {
                 new Container(
                   child: new Center(
                            child: new Card(
                                shape: new RoundedRectangleBorder(
                                    borderRadius: BorderRadius.all(5.0f)
                                ),
                                elevation:0,
                                child: new Container(
                                    width: width
                                    ,child: new Column( 
                                        children: new List<Widget>()
                                        {
                                            new SizedBox(height:10),
                                            new ClipOval(

                                                child:
                                                string.IsNullOrWhiteSpace(m_offcialAccount.open_id)?
                                                    Image.asset(
                                                    m_offcialAccount.headimage ?? "products/backpack",
                                                    fit: BoxFit.cover,
                                                    width: 120,
                                                    height: 120) 
                                                :
                                                
                                                Image.network(
                                                    m_offcialAccount.headimage??"",
                                                    fit: BoxFit.cover,
                                                    width: 120,
                                                    height: 120                                                )
                                            )
                                            ,new Row(
                                                mainAxisAlignment: MainAxisAlignment.center
                                                ,children: new List<Widget>()
                                                {
                                                    new Padding(
                                                        padding: EdgeInsets.all(16)
                                                        ,child:
                                                              new Text(data:"群发数：" + m_offcialAccount?.post_perm,style:Theme.of(context).textTheme.body1)


                                                    )
                                                    ,
                                                    new Padding(
                                                        padding: EdgeInsets.all(16)
                                                        ,child: new Text(data:"阅读量： 1000+",style:Theme.of(context).textTheme.body1)

                                                    )

                                                }

                                            )
                                            ,new Container(
                                                alignment:Alignment.center 
                                                ,child:
                                                        new Text(data:"简介",style:Theme.of(context).textTheme.body1) 
                                            )
                                            ,new Container(
                                                padding: EdgeInsets.only(28,16,28,8)
                                                ,child:
                                                    new Text(data:"\t" + m_offcialAccount.introduction??"这是一个帅气的简介这是一个帅气的简介这是一个帅气的简介这是一个帅气的简介这是一个帅气的简介这是一个帅气的简介"
                                                        ,style:Theme.of(context).textTheme.body2.copyWith(color:Colors.black54)
                                                        ,maxLines: 4)
                                            )

                                        }

                                    )
                                )
                        )
                    )
                )
                //,new Container(
                //    padding: EdgeInsets.all(16),
                //    child: new ArticleCard(new ArticleCover(){
                //        wechat_id = "test1"
                //        ,wechat_name = "暴走漫画"
                //        ,title = "\"网警\"人肉女孩求交往事件反转！"
                //        ,articleAbstract = "任谁都想不到，一场微博求助，居然会有如此反转"
                //        ,cover = "baozou-1"
                //    })
                //    )
 
            };

            //list.Add(
            //      new ArticleCard() 
            //    );


            return list;
        }


        public override Widget build(BuildContext context)
        {
            if (width == null)
            {
                width = MediaQuery.of(context).size.width;

            }
            return new Scaffold(

                appBar: new AppBar(
                      centerTitle: true
                    , elevation: 0
                    , backgroundColor: Colors.white
                    , iconTheme: Theme.of(context).iconTheme
                    , title:    new Text(m_offcialAccount.wechat_name??"这是名字",style:Theme.of(context).textTheme.headline)
                                
                    , leading: new IconButton(icon: new Icon(Icons.arrow_back)
                            , onPressed: () => {
                                Navigator.of(context).pop();
                            })
                    , actions: new List<Widget>()
                    {
                        new IconButton(icon:new Icon(icon:Icons.star)
                        ,onPressed:()=>{

                        }
                        )
                    }

                    )
                , body: new ListView(

                        children: OAList(context)
                    ) 
            );
        }
    }

}

