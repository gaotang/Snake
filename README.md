### Abstract

  ��ô֪��web api�����õ�Ƶ���ˣ�  
  ��η�����ʱ��web api���ӿڷ����ĵ��ô�����  
  ��λ�ȡweb api�ӿڷ����ĵ���ʧ��Ƶ�Σ�  
  ��η���web api�ӿڷ�����ʱ�쳣��  

  Snake�ǻ���C#������ʵʱapi���ƽ̨������apiѹ����غ͵����쳣��ء�  
  �ǻ���RESTFul api��񿪷���.net web api΢����Ӧ�ü�Ⱥ��ʵʱ�Ľӿڵ��ü��Ϊϵͳ�������ṩ�������ķ������ݡ�  
  Snake��Ϊ�˶����İ�����ƽ˳���ϵͳ����ͨ��Filterʵ�ּ��Ƕ�룬�첽���ͼ����־��Ϣ��ͨ������RabbitMQ  
  ʵ�ֵ���ҵ��������ƽ˳������Ϣ�����ս������־��������洢��Mongodb�С�  

### Requirements

  * Windows 7 ��Windows Server 2008���ϲ���ϵͳ  
  * IIS 8.5 +  
  * .NET Framework 4.6  
  * [RabbitMQ 3.6.5](http://www.rabbitmq.com)  
  * [Mongodb 3.2.1](https://www.mongodb.com)  
  
### Quick Started

1. Snake.Api��Ŀ��webapi��Ŀ�����벢����Snake.Api��IISվ�㣬�޸������ļ�web.config�����£�
```
	<!--************************* RabbitMQ Connection Settings ****************** -->
	<RabbitMQ.Connection>
		<add key="RabbitMQ.HostName" value="localhost" />
		<add key="RabbitMQ.Port" value="5672" />
		<add key="RabbitMQ.UserName" value="snake" />
		<add key="RabbitMQ.Password" value="snake" />
		<add key="RabbitMQ.VirtualHost" value="snakeTest" />
		<add key="RabbitMQ.QueueName" value="q_snake_apitrack" />
		<!--���Դ���-->
		<add key="RabbitMQ.UseRetryNum" value="3" />
	</RabbitMQ.Connection>
```
2. Snake.ApiTrackService��Ŀ��windows���񣬱���Snake.ApiTrackService��Ŀ
  * �޸������ļ�App.config��������£�
```
	<appSettings>
		<add key="MongoConnectionString" value="mongodb://snake:snake@localhost:27017/SnakeDbTest/?MaximumPoolSize=500;socketTimeoutMS=2000;MinimumPoolSize=1;waitQueueTimeoutMS=300;waitQueueMultiple=10;ConnectionLifetime=30000;ConnectTimeout=30000;Pooled=true" />
	</appSettings>  
	<!--************************** snake.Service Settings ********************** -->
	<snake.service>
		<add key="snake.serviceName" value="SnakeConsumer" />
		<add key="snake.serviceDisplayName" value="Snake Consumer Server" />
		<add key="snake.serviceDescription" value="Snake Consumer Server" />
	</snake.service>
	<!--************************* RabbitMQ Connection Settings ****************** -->
	<RabbitMQ.Connection>
		<add key="RabbitMQ.HostName" value="localhost" />
		<add key="RabbitMQ.Port" value="5672" />
		<add key="RabbitMQ.UserName" value="snake" />
		<add key="RabbitMQ.Password" value="snake" />
		<add key="RabbitMQ.VirtualHost" value="snakeTest" />
		<add key="RabbitMQ.QueueName" value="q_snake_apitrack" />
		<!--`�����߸���-->
		<add key="RabbitMQ.ConsumerNum" value="4" />
		<!--���Դ���-->
		<add key="RabbitMQ.UseRetryNum" value="3" />
	</RabbitMQ.Connection>
```
  * ִ��start.bat������ű�����װ�����windows����  
3. ��װRabbitMQ����������1��2�����������û������VirtualHost  
4. ��װMongodb����������2�����������û���������ݿ⣬ִ��scriptĿ¼�µ�MongoScript.js�ű�  
5. ����Ҫ��ص�webapi��Ŀ������Snake.Client.dll��Snake.Core.dll��̬�⣬���������ã�  
  * ��App_Start��WebApiConfig.cs�ļ�������һ�д������£�  
  ```
	public static void Register(HttpConfiguration config)
	{
		// Web API ���úͷ���            
		config.Filters.Add(new TrackLogActionFilterAttribute());  //apiִ���¼�������־
  ```
  * ��web.config�����ļ��������������£�  
```
	<appSettings>
		<!--TrackLog����������-->
		<add key="TrackLogFilterEnabled" value="true" />
		<!--SnakeApi���� ��ǩ-->
		<add key="SnakeApi" value="SNAKE_API" />
		<add key="SnakeApiSecret" value="1!2@3#4$5" />
		<!--Snake.Api���� �ӿڵ�ַ-->
		<add key="SnakeServerApi" value="http://localhost:50424" />
	</appSettings>
```

### Copyright and license

[Apache ���֤2.0��](http://www.apache.org/licenses/LICENSE-2.0.html)

### AREAS FOR IMPROVEMENTS

QQ: 46313060  
Email: yepeng2002@icloud.com