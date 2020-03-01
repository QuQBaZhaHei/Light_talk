import wechatsogou
import socket
# 可配置参数

# 直连
ws_api = wechatsogou.WechatSogouAPI()

# 验证码输入错误的重试次数，默认为1
ws_api = wechatsogou.WechatSogouAPI(captcha_break_time=3)

# 所有requests库的参数都能在这用
# 如 配置代理，代理列表中至少需包含1个 HTTPS 协议的代理, 并确保代理可用
ws_api = wechatsogou.WechatSogouAPI(proxies={
    "http": "127.0.0.1:8888",
    "https": "127.0.0.1:8888",
})

# 如 设置超时
ws_api = wechatsogou.WechatSogouAPI(timeout=0.5)

def designated():
    #获取特定公众号信息
    '''
    {
        'profile_url': '',  # 最近10条群发页链接
        'headimage': '',  # 头像
        'wechat_name': '',  # 名称
        'wechat_id': '',  # 微信id
        'post_perm': int,  # 最近一月群发数
        'view_perm': int,  # 最近一月阅读量
        'qrcode': '',  # 二维码
        'introduction': '',  # 简介
        'authentication': ''  # 认证
    }
    '''
    designated_gzh=ws_api.get_gzh_info('南航青年志愿者')
    print(designated_gzh)


def search_gzh():
    #搜索公众号
    '''
    {
        'profile_url': '',  # 最近10条群发页链接
        'headimage': '',  # 头像
        'wechat_name': '',  # 名称
        'wechat_id': '',  # 微信id
        'post_perm': int,  # 最近一月群发数
        'view_perm': int,  # 最近一月阅读量
        'qrcode': '',  # 二维码
        'introduction': '',  # 介绍
        'authentication': ''  # 认证
    }'''
    for e in ws_api.search_gzh('南航青年志愿者'):
        print(e)


def search_article():
    #搜索微信文章
    '''
    {
        'article': {
            'title': '',  # 文章标题
            'url': '',  # 文章链接
            'imgs': '',  # 文章图片list
            'abstract': '',  # 文章摘要
            'time': int  # 文章推送时间 10位时间戳
        },
        'gzh': {
            'profile_url': '',  # 公众号最近10条群发页链接
            'headimage': '',  # 头像
            'wechat_name': '',  # 名称
            'isv': int,  # 是否加v 1 or 0
        }
    }
    '''
    info=ws_api.search_article('小酒桶')
    for e in info:
        print(e)
    b=input("请输入想阅读的文章号：")
    c=ws_api.get_article_content(info[int(b)]['article']['url'])
    print(c['content_html'])




if __name__ == '__main__':
    a=''
    while(a!='q'):
        a=input("请输入:")
        if(a=='1'):
            designated()
        if(a=='2'):
            search_gzh()
        if(a=='3'):
            search_article()




