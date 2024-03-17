# Advanced Web Technology Project <br> Metaverse: Developing Digital Twin experience

### 1. General Interface
![alt text](/images/overview1.png)

![alt text](/images/overview2.png)

![alt text](/images/ai.png)

![alt text](/images/ai-log.png)
AI backend server log (LM-Studio)


### 2. Running the geoTwin application
To run the geoTwin application, follow these steps:

1. Navigate to the ExecutableApp folder.
2. Run DigitalTwinCity.exe.


### 3. AI-Assistant settings

You can input any OpenAI API or **OpenAI compatible API** base path.

```
private const string BASE_PATH = "http://{url:port}/v1";
```

For example using LocalAI backend: 
 - `https://{LocalAI}:8080/v1  `      
 - `8080` is default port for LocalAI

For example using LM-Studio backend:
 - `https://{LM-Studio}:1234/v1   ` 
 - `1234` is default port for LM-Studio

![alt text](/images/api-path.png)