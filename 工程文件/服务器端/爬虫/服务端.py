#!/usr/bin/python
import socket
import json
import struct
import threading                                               # 导入多线程模块
import time
import wechatsogou

##########################################
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

#################################################
dataBuffer = bytes()
headerSize = 4


AppMsg={
    'cmd':1,
    'reqHotList':{'wechat_id_list':['']},
    'rspHotList':{'article_cover_list':[]},
    'reqSearchList':{'input_text':''},
    'rspSearchList':{
        'article_cover_list':[],
        'offcial_account_list':[]
    },
    'reqArticleContent':{
        'title':'',
        'author':''
    },
    'rspArticleContent':{
        'article':{
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
    'reqOAInfo':{'wechat_id':''},
    'rspOAInfo':{
        'offcialAccount':{
                'open_id': '', # 微信号唯一ID
                'headimage': '',  # 头像
                'wechat_name': '',  # 名称
                'wechat_id': '',  # 微信id
                'post_perm': '',  # 最近一月群发数
                'introduction': '',  # 介绍
        }
    },
    'rcvQRCode':{'qrcode':''},
    'backQRCode':{'qrcodestring':''},

}


def Send(msg):
    body = json.dumps(msg)

    header = [body.__len__()]
    print(body.__len__())
    headPack = struct.pack("!1I",*header)

    conn.send(headPack+body.encode("utf-8"))

def dataHandle(body):
    
     print(body.decode())
     msg = json.loads(body.decode())
     
     print(msg['cmd'])
     if msg['cmd'] == 1:
         string=msg['reqSearchList']['input_text']
         print(string)
         designated_gzh=ws_api.get_gzh_info(string)
         offcialAccount={} 
         offcialAccount.update(open_id=designated_gzh['open_id'],headimage=designated_gzh['headimage'],wechat_name=designated_gzh['wechat_name'],wechat_id=designated_gzh['wechat_id'],post_perm=designated_gzh['post_perm'],introduction=designated_gzh['introduction'])
         a=[]
         a.append(offcialAccount)
         msg['rspSearchList']['offcial_account_list']=a
         print(msg)
         Send(msg)# msg获取搜索信息 msg['reqSearchList']['input_text']
  


def Recive():
    global dataBuffer
    global headerSize
    while True:
        data=conn.recv(1024)
        if len(data) == 0:
                print("网络连接断开") 
                break
        if data:
            dataBuffer += data
            
            
            while True:
                if len(dataBuffer) < headerSize:
                    print("数据包（%s Byte）小于消息头部长度，跳出小循环" % len(dataBuffer))
                    break

                # 读取包头
                # struct中:!代表Network order，3I代表3个unsigned int数据
                print( dataBuffer[:headerSize])
                headPack = struct.unpack('!1I', dataBuffer[:headerSize])
                bodySize = headPack[0]
                print(headPack)
                print(bodySize)

                # 分包情况处理，跳出函数继续接收数据
                if len(dataBuffer) < headerSize+bodySize :
                    print("数据包（%s Byte）不完整（总共%s Byte），跳出小循环" % (len(dataBuffer), headerSize+bodySize))
                    break
                # 读取消息正文的内容
                body = dataBuffer[headerSize:headerSize+bodySize]

                # 数据处理
                dataHandle(body)

                # 粘包情况的处理
                dataBuffer = dataBuffer[headerSize+bodySize:] # 获取下一个数据包，类似于把数据pop出
                     

 
    conn.close()
    print("结束")

print("Waitting to be connected......")
HostPort = ('172.19.73.67',6688)
s = socket.socket(socket.AF_INET,socket.SOCK_STREAM)            # 创建socket实例
s.bind(HostPort)
s.listen(100)
while True:
     conn,addr = s.accept()
     Recive()
 
 
