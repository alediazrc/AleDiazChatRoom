# AleDiazChatRoom

Tech Stack:
- AutoMapper.Extension.Microsoft.DependencyInjection: V12.0.0
    - Projects: 
      - AleDiazChatRoom
      - ChatBotMessages
- Microsoft.AspNetCore.Mvc.NewtownsoftJson: V3.1.1 
    - Projects:
      - AleBot
- Microsoft.AspNetCore.OpenAPi: V7.0.0
    - Projects:
      - ChatBotMessages  
- Microsoft.AspNetCore.SignalR.Client: V7.0.3
    - Projects:
      - AleDiazChatRoom
- Microsoft.AspNetCore.SignalR.Client.Core:V7.0.3
    - Projects:
      - AleDiazChatRoom
- Microsoft.Bot.Builder.Integration.AspNetCore: V4.18.1
    - Projects:
      - AleBot
- Microsoft.EntityFrameworkCore: V7.0.3
    - Projects:
      - AleDiazChatRoom
      - ChatBotMessages   
- Microsoft.EntityFrameworkCore.Design: V7.0.3
    - Projects:
      - AleDiazChatRoom
      - ChatBotMessages
- Microsoft.EntityFrameworkCore.SqlServer: V7.0.3
    - Projects:
      - AleDiazChatRoom
      - ChatBotMessages
- Microsoft.EntityFrameworkCore.Tools: V7.0.3
    - Projects:
      - AleDiazChatRoom
      - ChatBotMessages
- Microsoft.NETCore.Platforms: V7.0.0
    - Projects:
      - AleDiazChatRoom
      - ChatBotMessages
- Microsoft.VisualStudio.Web.CodeGeneration.Design: V7.0.4
    - Projects:
      -  ChatBotMessages
- Microsoft.VisualStudio.Web.CodeGeneration.Mvc: V7.0.4
    - Projects:
      -  ChatBotMessages
-  RabbitMQ.Client: V6.4.0
    - Projects:
      - AleBot
      - AleDiazChatRoom
- Swashbuckle.AspNetCore: V6.4.0
    - Projects:
      - ChatBotMessages
- System.ComponentModel.Annotations: V5.0.0
    - Projects:
      - AleDiazChatRoom
      - ChatBotMessages


1- Execute setup.exe file that was uploaded in SetUpProject
    - In case you have a problem, all packages you need are in TechStack section.
    
2- Open AlediazChatRoom as startup project

3- Run update-databse with AlediazChatRoom in order to create the DB

3- Run ChatRoomMessages (APi)

4- Run AleBot (.Net bot)

5- Run AlediazChatRoom (Blazor Chat app)
