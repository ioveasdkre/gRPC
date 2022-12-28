Unary：一對一
  一個 request 對上一個 response

Server-side streaming：一對多
  Client 只上傳一個請求，但 Server 回一堆 response（Streaming）

Client-side streaming: 多對一
  Client 送很多個請求（Streaming），結束之後 server 只回一個 response

Bi directional streaming：多對多
  Client 和 Server 都以 Streaming 的形式交互
  
4TypesOf_gRPC_APIs
  四種 gRPC撰寫方式 stream表示多