来自：http://www.DotNetOpenAuth.com

注意事项
1.Cryptography.cs文件封装了AES加解密过程，用户无须关心具体实现。WXBizMsgCrypt.cs文件提供了用户接入企业微信的三个接口，Sample.cs文件提供了如何使用这三个接口的示例。
2.WXBizMsgCrypt.cs封装了VerifyURL, DecryptMsg, EncryptMsg三个接口，分别用于开发者验证回调url，收到用户回复消息的解密以及开发者回复消息的加密过程。使用方法可以参考Sample.cs文件。
3.加解密协议请参考企业微信官方文档。