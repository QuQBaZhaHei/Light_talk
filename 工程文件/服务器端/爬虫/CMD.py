
AppMsg={
    'cmd':0,
    'ReqHotList':{'wechat_id_list':[]},
    'RspHotList':{'article_cover_list':[]},
    'ReqSearchList':{'input_text':''},
    'RspSearchList':{
        'RspSearchList':[],
        'offcial_account_list':[]
    },
    'ReqArticleContent':{
        'title':'',
        'author':''
    },
    'RspArticleContent':{
        'Article':{
                    #文章题目
                    'article_id':'',
                    #文章地址
                    'article_url':'',
                    #文章图片
                    'article_imgs':'',
                    #文章摘要
                    'article_abstract':'',
                    #文章来源公众号头像
                    'gzh_headimage':'',
                    #文章来源公众号id
                    'gzh_id':'',
        }
    },
    'ReqOAInfo':{'wechat_id':''},
    'RspOAInfo':{
        'OffcialAccount':{
                'open_id': '', # 微信号唯一ID
                'headimage': '',  # 头像
                'wechat_name': '',  # 名称
                'wechat_id': '',  # 微信id
                'post_perm': '',  # 最近一月群发数
                'introduction': '',  # 介绍
        }
    },
    'RcvQRCode':{'qrcode':[]},
    'BackQRCode':{'qrcodestring':''},

}